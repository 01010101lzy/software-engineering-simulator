﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Sesim.Models;
using System;

namespace Tests
{
    public class EmployeeTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void EmployeeEfficiencyTest()
        {
            Employee e = new Employee
            {
                id = new Ulid(),
                name = "Test Employee",
                baseEfficiency = 1.5f,
                health = 1.0f,
                pressure = 0f,
                abilities = new Dictionary<string, float>
                {
                    ["java"] = 3f,
                    ["csharp"] = 1.5f,
                    ["php"] = 0.1f,
                    ["lua"] = 0f
                }
            };

            // HealthCurve: [0, 0, 0, 0, 0.33, 0.33] => [1, 1, 0, 0, 0.33, 0.33]
            e.SetEfficiencyHealthCurve();
            // Makes pressureCurve constant in lower pressure
            e.SetEfficiencyPressureCurve(1f, 0.9f, 1f);
            e.SetEfficiencyTimeCurve(1f);

            // Test with basic multiplier
            Assert.AreEqual(3f, e.GetEfficiency("java", 0), .01f, "Known type");
            Assert.AreEqual(0f, e.GetEfficiency("lua", 0), .01f, "Known type, zero exp");
            Assert.AreEqual(0f, e.GetEfficiency("javascript", 0), .01f, "Unknown type");

            // Test through time
            e.SetEfficiencyTimeCurve();
            Assert.AreEqual(1.5f, e.GetEfficiency("java", 0), .01f, "T=0 (startEfficiency)");
            Assert.AreEqual(3f, e.GetEfficiency("java", 90), .01f, "T=startTime (max efficiency)");
            Assert.AreEqual(3f, e.GetEfficiency("java", 600), .01f, "T=maxTime (max efficiency)");
            Assert.AreEqual(1.5f, e.GetEfficiency("java", 1200), .01f, "T=(maxTime+declineTime)/2 (1/2 efficiency)");
            Assert.AreEqual(0f, e.GetEfficiency("java", 1800), .01f, "T=declineTime (0 efficiency)");

            // Test through health
            e.health = 0.5f;
            Assert.AreEqual(1.5f, e.GetEfficiency("java", 600), .01f, "health=0.5, half efficiency");
            e.health = 0f;
            Assert.AreEqual(0f, e.GetEfficiency("java", 600), .01f, "health=0 (0 efficiency)");
            // reset
            e.health = 1f;

            // Test through pressure
            e.SetEfficiencyPressureCurve();
            // no pressure
            e.pressure = 0f;
            Assert.AreEqual(2.25f, e.GetEfficiency("java", 600), .01f, "pressure=0 (startEfficiency)");
            // max efficiency
            e.pressure = 0.35f;
            Assert.AreEqual(4.8f, e.GetEfficiency("java", 600), .01f, "pressure=maxEfficiencyPressure (maxEfficiency)");
            // max pressure
            e.pressure = 1f;
            Assert.AreEqual(1.5f, e.GetEfficiency("java", 600), .01f, "pressure=1 (maxPressureEfficiency)");

        }
    }
}
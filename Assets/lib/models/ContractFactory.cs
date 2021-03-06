using System;
using System.Collections.Generic;
using Ceras;
using Hocon;
using Sesim.Helpers.Config;
using UnityEngine;

namespace Sesim.Models
{
    public class ContractFactory : IHoconDeserializable, IPickedGenerator<Contract, Company>
    {
        public string name;
        public string category;
        public string title;
        public string description;
        public AnimationCurve abundanceCurve;
        public AnimationCurve durationCurve;
        public AnimationCurve workloadCurve;

        public ContractReward baseDepositReward;
        public ContractReward baseAbortPunishment;
        public ContractReward baseFinishReward;

        System.Random random = new System.Random();

        // public 

        public ContractFactory()
        {

        }

        public float GetWeight(Company c)
        {
            return abundanceCurve.Evaluate(c.reputation);
        }

        public Contract Generate(Company c)
        {
            var contractor = RandomContractor();
            // var nameDescriptionPair = RandomNameDescription(contractor);
            var contract = new Contract
            {
                id = Ulid.NewUlid(),
                status = ContractStatus.Open,
                contractor = contractor,
                name = title.Replace("$contractor", contractor),
                description = description.Replace("$contractor", contractor),
                startTime = c.ut,
                LiveDuration = RandomLiveDuration(),
                LimitDuration = durationCurve.Evaluate(c.reputation),
                totalWorkload = workloadCurve.Evaluate(c.reputation),
                depositReward = baseDepositReward.Copy(),
                breakContractPunishment = baseAbortPunishment.Copy(),
                completeReward = baseFinishReward.Copy(),
                techStack = "java",
            };
            // MultiplyPow(ref contract.depositReward.reputation, );
            return contract;
        }

        IList<String> contractorNames { get => GlobalSettings.Instance.contractorNames; }

        public String RandomContractor()
        {
            return contractorNames[random.Next(contractorNames.Count)];
        }

        ContractReward parseReward(HoconValue val)
        {
            var result = new ContractReward();
            var valObject = val.GetObject();
            result.fund = valObject["fund"].Value.GetDecimal();
            result.reputation = valObject["reputation"].Value.GetFloat();
            return result;
        }

        static void MultiplyPow(ref decimal value, float x, float y)
        {
            value = value * (decimal)Math.Round(Math.Pow(x, y), -3);
        }
        static void MultiplyPow(ref float value, float x, float y)
        {
            value = value * (float)Math.Pow(x, y);
        }
        static void MultiplyPow(ref double value, float x, float y)
        {
            value = value * Math.Pow(x, y);
        }

        public double RandomLiveDuration()
        {
            return MathNet.Numerics.Distributions.LogNormal.Sample(random, 9.73, 0.5);
        }

        public void ReadFromHocon(HoconValue e)
        {
            if (!(e.Type == HoconType.Object)) throw new DeformedObjectException();
            var obj = e.GetObject();
            name = obj["name"].GetString();
            title = obj["title"].GetString();
            description = obj["description"].GetString();
            abundanceCurve = Helpers.Config.Deserializer.AnimationCurveParser.ParseHocon(obj["abundance"].Value);
            durationCurve = Helpers.Config.Deserializer.AnimationCurveParser.ParseHocon(obj["duration"].Value);
            workloadCurve = Helpers.Config.Deserializer.AnimationCurveParser.ParseHocon(obj["workload"].Value);
            baseDepositReward = parseReward(obj["reward"].GetObject()["deposit"].Value);
            baseFinishReward = parseReward(obj["reward"].GetObject()["finish"].Value);
            baseAbortPunishment = parseReward(obj["reward"].GetObject()["abort"].Value);
            // throw new NotImplementedException();
        }

        public ContractFactory SetDebugDefault()
        {
            name = "Test Factory";
            title = "Debug Test Contract";
            description = "This is a debug test contract";
            abundanceCurve = AnimationCurve.Constant(0, 100, 1);
            durationCurve = AnimationCurve.Constant(0, 100, 100000);
            workloadCurve = AnimationCurve.Constant(0, 100, 10);
            baseDepositReward = new ContractReward()
            {
                fund = 10000,
                reputation = 1
            };
            baseFinishReward = new ContractReward()
            {
                fund = 100000,
                reputation = 1
            };
            baseAbortPunishment = new ContractReward()
            {
                fund = -10000,
                reputation = -1
            };
            return this;
        }
    }
}

using System;
using ProtoBuf;

namespace Sesim.Library.Models
{
    [ProtoContract]
    public partial class Contract
    {
        [ProtoMember(16)]
        public long id;
    }
}
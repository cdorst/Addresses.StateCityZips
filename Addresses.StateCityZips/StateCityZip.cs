// Copyright © Christopher Dorst. All rights reserved.
// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.

using Addresses.States;
using Addresses.ZipCodes;
using DevOps.Code.Entities.Interfaces.StaticEntity;
using Position = ProtoBuf.ProtoMemberAttribute;
using ProtoBufSerializable = ProtoBuf.ProtoContractAttribute;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Addresses.StateCityZips
{
    /// <summary>Contains US State-City-ZIP group component of addresses</summary>
    [ProtoBufSerializable]
    [Table("StateCityZips", Schema = "Addresses")]
    public class StateCityZip : IStaticEntity<StateCityZip, int>
    {
        public StateCityZip()
        {
        }

        public StateCityZip(State stateCity, ZipCode zipPlusFour)
        {
            StateCity = stateCity;
            ZipPlusFour = zipPlusFour;
        }

        /// <summary>Contains StateCity reference</summary>
        [Position(3)]
        public State StateCity { get; set; }

        /// <summary>Contains StateCity foreign key</summary>
        [Position(2)]
        public int StateCityId { get; set; }

        /// <summary>StateCityZip unique identifier (primary key)</summary>
        [Key]
        [Position(1)]
        public int StateCityZipId { get; set; }

        /// <summary>Contains ZipPlusFour reference</summary>
        [Position(5)]
        public ZipCode ZipPlusFour { get; set; }

        /// <summary>Contains ZipPlusFour foreign key</summary>
        [Position(4)]
        public int ZipPlusFourId { get; set; }

        /// <summary>Returns a value that uniquely identifies this entity type. Each entity type in the model has a unique identifier</summary>
        public int GetEntityType() => 10;

        /// <summary>Returns the entity's unique identifier</summary>
        public int GetKey() => StateCityZipId;

        /// <summary>Returns an expression defining this entity's unique index (alternate key)</summary>
        public Expression<Func<StateCityZip, object>> GetUniqueIndex() => entity => new { entity.StateCityId, entity.ZipPlusFourId };
    }
}

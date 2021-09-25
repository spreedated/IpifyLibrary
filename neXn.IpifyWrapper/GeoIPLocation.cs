﻿using Newtonsoft.Json;
using neXn.IpifyWrapper.Models;
using System;
using System.Linq;
using neXn.IpifyWrapper.Attributes;

namespace neXn.IpifyWrapper
{
    /// <summary>
    /// Main Class of Geolocation Informmation <br/>
    /// Instance this with APIKey as String
    /// </summary>
    public class GeoIPLocation
    {
        /// <summary>
        /// Main Class of Geolocation Informmation <br/>
        /// Instance this with APIKey as String
        /// </summary>
        /// <returns></returns>
        public string APIKey { get; internal set; }
        public enum QueryType
        {
            [QueryName("ipAddress")]
            IP_Address,
            [QueryName("email")]
            E_Mail,
            [QueryName("domain")]
            Domain
        }

        private const string ipifyAddress = "https://geo.ipify.org/api/v1?apiKey={0}&{1}={2}";

        #region Constructor
        public GeoIPLocation(string apiKey)
        {
            this.APIKey = apiKey;
        }
        #endregion

        /// <summary>
        /// Retrieve Information
        /// </summary>
        /// <param name="queryValue">What you want to query, usually an IP address</param>
        /// <param name="queryType">Typically an ipaddress, but also able to query a domain or email</param>
        /// <returns></returns>
        public IpifyGeoInformation Get(string queryValue, QueryType queryType = QueryType.IP_Address)
        {
            string ipifyIdentifier = typeof(QueryType).GetField(Enum.GetName(typeof(QueryType), queryType)).GetCustomAttributes(false).OfType<QueryNameAttribute>().SingleOrDefault().name;
            return JsonConvert.DeserializeObject<IpifyGeoInformation>(Download.IpifiyString(string.Format(ipifyAddress, APIKey, ipifyIdentifier, queryValue)));
        }
    }
}
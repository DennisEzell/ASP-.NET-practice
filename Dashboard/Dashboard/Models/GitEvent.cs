using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Dashboard.Models
{
    public class GitEvent
    {
        /// <summary>
        /// Fields for the GitEvent class
        /// </summary>
        private string id;
        private string eventType;
        //public bool public;
        private string createdOn;

        /// <summary>
        /// Properties for the GitEvent class
        /// </summary>
        [JsonProperty("id")]
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty("type")]
        public string Type
        {
            get { return eventType; }
            set { eventType = value; }
        }

        //public bool IsPublic
        //{
        //    get { return isPublic; }
        //    set { isPublic = value; }
        //}

        [JsonProperty("created_at")]
        public string Created
        {
            get { return createdOn; }
            set { createdOn = value; }
        }
    }
}
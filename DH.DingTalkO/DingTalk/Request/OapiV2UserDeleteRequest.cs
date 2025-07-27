using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.v2.user.delete
    /// </summary>
    public class OapiV2UserDeleteRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiV2UserDeleteResponse>
    {
        /// <summary>
        /// 资源模型（共5种）
        /// </summary>
        public string HandoverResource { get; set; }

        public HandoverResourceModelDomain HandoverResource_ { set { this.HandoverResource = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 员工id，长度最大64个字符。员工在当前企业内的唯一标识。如果不传，服务器将自动生成一个userid。创建后不可修改，企业内必须唯一。
        /// </summary>
        public string Userid { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.v2.user.delete";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("handoverResource", this.HandoverResource);
            parameters.Add("userid", this.Userid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("userid", this.Userid);
            RequestValidator.ValidateMaxLength("userid", this.Userid, 64);
        }

	/// <summary>
/// HandoverModelDomain Data Structure.
/// </summary>
[Serializable]

public class HandoverModelDomain : TopObject
{
	        /// <summary>
	        /// 转交(handover)、删除(remove)或跳过(skip)。
	        /// </summary>
	        [XmlElement("action")]
	        public string Action { get; set; }
	
	        /// <summary>
	        /// 转交人userId
	        /// </summary>
	        [XmlElement("handoverUserId")]
	        public string HandoverUserId { get; set; }
}

	/// <summary>
/// HandoverResourceModelDomain Data Structure.
/// </summary>
[Serializable]

public class HandoverResourceModelDomain : TopObject
{
	        /// <summary>
	        /// 2.钉钉文档
	        /// </summary>
	        [XmlElement("dingDoc")]
	        public HandoverModelDomain DingDoc { get; set; }
	
	        /// <summary>
	        /// 1.钉盘
	        /// </summary>
	        [XmlElement("dingPan")]
	        public HandoverModelDomain DingPan { get; set; }
	
	        /// <summary>
	        /// 4.OA审批
	        /// </summary>
	        [XmlElement("oaApproval")]
	        public HandoverModelDomain OaApproval { get; set; }
	
	        /// <summary>
	        /// 3.子管理员
	        /// </summary>
	        [XmlElement("subAdmin")]
	        public HandoverModelDomain SubAdmin { get; set; }
	
	        /// <summary>
	        /// 5.直属下级
	        /// </summary>
	        [XmlElement("subordinate")]
	        public HandoverModelDomain Subordinate { get; set; }
}

        #endregion
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LRSystemClient.QAWebService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="QAWebService.QAWebServiceSoap")]
    public interface QAWebServiceSoap {
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 GetQAInfoListResult 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetQAInfoList", ReplyAction="*")]
        LRSystemClient.QAWebService.GetQAInfoListResponse GetQAInfoList(LRSystemClient.QAWebService.GetQAInfoListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetQAInfoList", ReplyAction="*")]
        System.Threading.Tasks.Task<LRSystemClient.QAWebService.GetQAInfoListResponse> GetQAInfoListAsync(LRSystemClient.QAWebService.GetQAInfoListRequest request);
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 str 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SaveQAInfoList", ReplyAction="*")]
        LRSystemClient.QAWebService.SaveQAInfoListResponse SaveQAInfoList(LRSystemClient.QAWebService.SaveQAInfoListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SaveQAInfoList", ReplyAction="*")]
        System.Threading.Tasks.Task<LRSystemClient.QAWebService.SaveQAInfoListResponse> SaveQAInfoListAsync(LRSystemClient.QAWebService.SaveQAInfoListRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetQAInfoListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetQAInfoList", Namespace="http://tempuri.org/", Order=0)]
        public LRSystemClient.QAWebService.GetQAInfoListRequestBody Body;
        
        public GetQAInfoListRequest() {
        }
        
        public GetQAInfoListRequest(LRSystemClient.QAWebService.GetQAInfoListRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetQAInfoListRequestBody {
        
        public GetQAInfoListRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetQAInfoListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetQAInfoListResponse", Namespace="http://tempuri.org/", Order=0)]
        public LRSystemClient.QAWebService.GetQAInfoListResponseBody Body;
        
        public GetQAInfoListResponse() {
        }
        
        public GetQAInfoListResponse(LRSystemClient.QAWebService.GetQAInfoListResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetQAInfoListResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetQAInfoListResult;
        
        public GetQAInfoListResponseBody() {
        }
        
        public GetQAInfoListResponseBody(string GetQAInfoListResult) {
            this.GetQAInfoListResult = GetQAInfoListResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SaveQAInfoListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SaveQAInfoList", Namespace="http://tempuri.org/", Order=0)]
        public LRSystemClient.QAWebService.SaveQAInfoListRequestBody Body;
        
        public SaveQAInfoListRequest() {
        }
        
        public SaveQAInfoListRequest(LRSystemClient.QAWebService.SaveQAInfoListRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SaveQAInfoListRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string str;
        
        public SaveQAInfoListRequestBody() {
        }
        
        public SaveQAInfoListRequestBody(string str) {
            this.str = str;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SaveQAInfoListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SaveQAInfoListResponse", Namespace="http://tempuri.org/", Order=0)]
        public LRSystemClient.QAWebService.SaveQAInfoListResponseBody Body;
        
        public SaveQAInfoListResponse() {
        }
        
        public SaveQAInfoListResponse(LRSystemClient.QAWebService.SaveQAInfoListResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SaveQAInfoListResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool SaveQAInfoListResult;
        
        public SaveQAInfoListResponseBody() {
        }
        
        public SaveQAInfoListResponseBody(bool SaveQAInfoListResult) {
            this.SaveQAInfoListResult = SaveQAInfoListResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface QAWebServiceSoapChannel : LRSystemClient.QAWebService.QAWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class QAWebServiceSoapClient : System.ServiceModel.ClientBase<LRSystemClient.QAWebService.QAWebServiceSoap>, LRSystemClient.QAWebService.QAWebServiceSoap {
        
        public QAWebServiceSoapClient() {
        }
        
        public QAWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public QAWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public QAWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public QAWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LRSystemClient.QAWebService.GetQAInfoListResponse LRSystemClient.QAWebService.QAWebServiceSoap.GetQAInfoList(LRSystemClient.QAWebService.GetQAInfoListRequest request) {
            return base.Channel.GetQAInfoList(request);
        }
        
        public string GetQAInfoList() {
            LRSystemClient.QAWebService.GetQAInfoListRequest inValue = new LRSystemClient.QAWebService.GetQAInfoListRequest();
            inValue.Body = new LRSystemClient.QAWebService.GetQAInfoListRequestBody();
            LRSystemClient.QAWebService.GetQAInfoListResponse retVal = ((LRSystemClient.QAWebService.QAWebServiceSoap)(this)).GetQAInfoList(inValue);
            return retVal.Body.GetQAInfoListResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<LRSystemClient.QAWebService.GetQAInfoListResponse> LRSystemClient.QAWebService.QAWebServiceSoap.GetQAInfoListAsync(LRSystemClient.QAWebService.GetQAInfoListRequest request) {
            return base.Channel.GetQAInfoListAsync(request);
        }
        
        public System.Threading.Tasks.Task<LRSystemClient.QAWebService.GetQAInfoListResponse> GetQAInfoListAsync() {
            LRSystemClient.QAWebService.GetQAInfoListRequest inValue = new LRSystemClient.QAWebService.GetQAInfoListRequest();
            inValue.Body = new LRSystemClient.QAWebService.GetQAInfoListRequestBody();
            return ((LRSystemClient.QAWebService.QAWebServiceSoap)(this)).GetQAInfoListAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LRSystemClient.QAWebService.SaveQAInfoListResponse LRSystemClient.QAWebService.QAWebServiceSoap.SaveQAInfoList(LRSystemClient.QAWebService.SaveQAInfoListRequest request) {
            return base.Channel.SaveQAInfoList(request);
        }
        
        public bool SaveQAInfoList(string str) {
            LRSystemClient.QAWebService.SaveQAInfoListRequest inValue = new LRSystemClient.QAWebService.SaveQAInfoListRequest();
            inValue.Body = new LRSystemClient.QAWebService.SaveQAInfoListRequestBody();
            inValue.Body.str = str;
            LRSystemClient.QAWebService.SaveQAInfoListResponse retVal = ((LRSystemClient.QAWebService.QAWebServiceSoap)(this)).SaveQAInfoList(inValue);
            return retVal.Body.SaveQAInfoListResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<LRSystemClient.QAWebService.SaveQAInfoListResponse> LRSystemClient.QAWebService.QAWebServiceSoap.SaveQAInfoListAsync(LRSystemClient.QAWebService.SaveQAInfoListRequest request) {
            return base.Channel.SaveQAInfoListAsync(request);
        }
        
        public System.Threading.Tasks.Task<LRSystemClient.QAWebService.SaveQAInfoListResponse> SaveQAInfoListAsync(string str) {
            LRSystemClient.QAWebService.SaveQAInfoListRequest inValue = new LRSystemClient.QAWebService.SaveQAInfoListRequest();
            inValue.Body = new LRSystemClient.QAWebService.SaveQAInfoListRequestBody();
            inValue.Body.str = str;
            return ((LRSystemClient.QAWebService.QAWebServiceSoap)(this)).SaveQAInfoListAsync(inValue);
        }
    }
}

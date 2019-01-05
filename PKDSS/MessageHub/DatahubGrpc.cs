// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: MessageHub/protos/datahub.proto
// </auto-generated>
// Original file comments:
// Copyright 2015 gRPC authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Datahub {
  /// <summary>
  /// The greeting service definition.
  /// </summary>
  public static partial class MessageHub
  {
    static readonly string __ServiceName = "datahub.MessageHub";

    static readonly grpc::Marshaller<global::Datahub.DataRequest> __Marshaller_datahub_DataRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Datahub.DataRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Datahub.DataReply> __Marshaller_datahub_DataReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Datahub.DataReply.Parser.ParseFrom);

    static readonly grpc::Method<global::Datahub.DataRequest, global::Datahub.DataReply> __Method_DoScan = new grpc::Method<global::Datahub.DataRequest, global::Datahub.DataReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DoScan",
        __Marshaller_datahub_DataRequest,
        __Marshaller_datahub_DataReply);

    static readonly grpc::Method<global::Datahub.DataRequest, global::Datahub.DataReply> __Method_IsDeviceReady = new grpc::Method<global::Datahub.DataRequest, global::Datahub.DataReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "IsDeviceReady",
        __Marshaller_datahub_DataRequest,
        __Marshaller_datahub_DataReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Datahub.DatahubReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of MessageHub</summary>
    public abstract partial class MessageHubBase
    {
      /// <summary>
      /// do scanning
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Datahub.DataReply> DoScan(global::Datahub.DataRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// check if device is ready
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Datahub.DataReply> IsDeviceReady(global::Datahub.DataRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for MessageHub</summary>
    public partial class MessageHubClient : grpc::ClientBase<MessageHubClient>
    {
      /// <summary>Creates a new client for MessageHub</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public MessageHubClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for MessageHub that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public MessageHubClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected MessageHubClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected MessageHubClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// do scanning
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Datahub.DataReply DoScan(global::Datahub.DataRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DoScan(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// do scanning
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Datahub.DataReply DoScan(global::Datahub.DataRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DoScan, null, options, request);
      }
      /// <summary>
      /// do scanning
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Datahub.DataReply> DoScanAsync(global::Datahub.DataRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DoScanAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// do scanning
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Datahub.DataReply> DoScanAsync(global::Datahub.DataRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DoScan, null, options, request);
      }
      /// <summary>
      /// check if device is ready
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Datahub.DataReply IsDeviceReady(global::Datahub.DataRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IsDeviceReady(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// check if device is ready
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Datahub.DataReply IsDeviceReady(global::Datahub.DataRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_IsDeviceReady, null, options, request);
      }
      /// <summary>
      /// check if device is ready
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Datahub.DataReply> IsDeviceReadyAsync(global::Datahub.DataRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IsDeviceReadyAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// check if device is ready
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Datahub.DataReply> IsDeviceReadyAsync(global::Datahub.DataRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_IsDeviceReady, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override MessageHubClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new MessageHubClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(MessageHubBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_DoScan, serviceImpl.DoScan)
          .AddMethod(__Method_IsDeviceReady, serviceImpl.IsDeviceReady).Build();
    }

    /// <summary>Register service method implementations with a service binder. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, MessageHubBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_DoScan, serviceImpl.DoScan);
      serviceBinder.AddMethod(__Method_IsDeviceReady, serviceImpl.IsDeviceReady);
    }

  }
}
#endregion
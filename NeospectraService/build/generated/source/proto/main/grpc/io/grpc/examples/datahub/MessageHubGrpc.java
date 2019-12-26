package io.grpc.examples.datahub;

import static io.grpc.MethodDescriptor.generateFullMethodName;
import static io.grpc.stub.ClientCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ClientCalls.asyncClientStreamingCall;
import static io.grpc.stub.ClientCalls.asyncServerStreamingCall;
import static io.grpc.stub.ClientCalls.asyncUnaryCall;
import static io.grpc.stub.ClientCalls.blockingServerStreamingCall;
import static io.grpc.stub.ClientCalls.blockingUnaryCall;
import static io.grpc.stub.ClientCalls.futureUnaryCall;
import static io.grpc.stub.ServerCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ServerCalls.asyncClientStreamingCall;
import static io.grpc.stub.ServerCalls.asyncServerStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnaryCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall;

/**
 * <pre>
 * The greeting service definition.
 * </pre>
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.17.0)",
    comments = "Source: datahub.proto")
public final class MessageHubGrpc {

  private MessageHubGrpc() {}

  public static final String SERVICE_NAME = "datahub.MessageHub";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<io.grpc.examples.datahub.DataRequest,
      io.grpc.examples.datahub.DataReply> getDoScanMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "DoScan",
      requestType = io.grpc.examples.datahub.DataRequest.class,
      responseType = io.grpc.examples.datahub.DataReply.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<io.grpc.examples.datahub.DataRequest,
      io.grpc.examples.datahub.DataReply> getDoScanMethod() {
    io.grpc.MethodDescriptor<io.grpc.examples.datahub.DataRequest, io.grpc.examples.datahub.DataReply> getDoScanMethod;
    if ((getDoScanMethod = MessageHubGrpc.getDoScanMethod) == null) {
      synchronized (MessageHubGrpc.class) {
        if ((getDoScanMethod = MessageHubGrpc.getDoScanMethod) == null) {
          MessageHubGrpc.getDoScanMethod = getDoScanMethod = 
              io.grpc.MethodDescriptor.<io.grpc.examples.datahub.DataRequest, io.grpc.examples.datahub.DataReply>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "datahub.MessageHub", "DoScan"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  io.grpc.examples.datahub.DataRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  io.grpc.examples.datahub.DataReply.getDefaultInstance()))
                  .setSchemaDescriptor(new MessageHubMethodDescriptorSupplier("DoScan"))
                  .build();
          }
        }
     }
     return getDoScanMethod;
  }

  private static volatile io.grpc.MethodDescriptor<io.grpc.examples.datahub.DataRequest,
      io.grpc.examples.datahub.DataReply> getIsDeviceReadyMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "IsDeviceReady",
      requestType = io.grpc.examples.datahub.DataRequest.class,
      responseType = io.grpc.examples.datahub.DataReply.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<io.grpc.examples.datahub.DataRequest,
      io.grpc.examples.datahub.DataReply> getIsDeviceReadyMethod() {
    io.grpc.MethodDescriptor<io.grpc.examples.datahub.DataRequest, io.grpc.examples.datahub.DataReply> getIsDeviceReadyMethod;
    if ((getIsDeviceReadyMethod = MessageHubGrpc.getIsDeviceReadyMethod) == null) {
      synchronized (MessageHubGrpc.class) {
        if ((getIsDeviceReadyMethod = MessageHubGrpc.getIsDeviceReadyMethod) == null) {
          MessageHubGrpc.getIsDeviceReadyMethod = getIsDeviceReadyMethod = 
              io.grpc.MethodDescriptor.<io.grpc.examples.datahub.DataRequest, io.grpc.examples.datahub.DataReply>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "datahub.MessageHub", "IsDeviceReady"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  io.grpc.examples.datahub.DataRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  io.grpc.examples.datahub.DataReply.getDefaultInstance()))
                  .setSchemaDescriptor(new MessageHubMethodDescriptorSupplier("IsDeviceReady"))
                  .build();
          }
        }
     }
     return getIsDeviceReadyMethod;
  }

  private static volatile io.grpc.MethodDescriptor<io.grpc.examples.datahub.DataRequest,
      io.grpc.examples.datahub.DataReply> getDoBackgroundMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "DoBackground",
      requestType = io.grpc.examples.datahub.DataRequest.class,
      responseType = io.grpc.examples.datahub.DataReply.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<io.grpc.examples.datahub.DataRequest,
      io.grpc.examples.datahub.DataReply> getDoBackgroundMethod() {
    io.grpc.MethodDescriptor<io.grpc.examples.datahub.DataRequest, io.grpc.examples.datahub.DataReply> getDoBackgroundMethod;
    if ((getDoBackgroundMethod = MessageHubGrpc.getDoBackgroundMethod) == null) {
      synchronized (MessageHubGrpc.class) {
        if ((getDoBackgroundMethod = MessageHubGrpc.getDoBackgroundMethod) == null) {
          MessageHubGrpc.getDoBackgroundMethod = getDoBackgroundMethod = 
              io.grpc.MethodDescriptor.<io.grpc.examples.datahub.DataRequest, io.grpc.examples.datahub.DataReply>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "datahub.MessageHub", "DoBackground"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  io.grpc.examples.datahub.DataRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  io.grpc.examples.datahub.DataReply.getDefaultInstance()))
                  .setSchemaDescriptor(new MessageHubMethodDescriptorSupplier("DoBackground"))
                  .build();
          }
        }
     }
     return getDoBackgroundMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static MessageHubStub newStub(io.grpc.Channel channel) {
    return new MessageHubStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static MessageHubBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    return new MessageHubBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static MessageHubFutureStub newFutureStub(
      io.grpc.Channel channel) {
    return new MessageHubFutureStub(channel);
  }

  /**
   * <pre>
   * The greeting service definition.
   * </pre>
   */
  public static abstract class MessageHubImplBase implements io.grpc.BindableService {

    /**
     * <pre>
     * do scanning
     * </pre>
     */
    public void doScan(io.grpc.examples.datahub.DataRequest request,
        io.grpc.stub.StreamObserver<io.grpc.examples.datahub.DataReply> responseObserver) {
      asyncUnimplementedUnaryCall(getDoScanMethod(), responseObserver);
    }

    /**
     * <pre>
     * check if device is ready
     * </pre>
     */
    public void isDeviceReady(io.grpc.examples.datahub.DataRequest request,
        io.grpc.stub.StreamObserver<io.grpc.examples.datahub.DataReply> responseObserver) {
      asyncUnimplementedUnaryCall(getIsDeviceReadyMethod(), responseObserver);
    }

    /**
     * <pre>
     * do background
     * </pre>
     */
    public void doBackground(io.grpc.examples.datahub.DataRequest request,
        io.grpc.stub.StreamObserver<io.grpc.examples.datahub.DataReply> responseObserver) {
      asyncUnimplementedUnaryCall(getDoBackgroundMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getDoScanMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                io.grpc.examples.datahub.DataRequest,
                io.grpc.examples.datahub.DataReply>(
                  this, METHODID_DO_SCAN)))
          .addMethod(
            getIsDeviceReadyMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                io.grpc.examples.datahub.DataRequest,
                io.grpc.examples.datahub.DataReply>(
                  this, METHODID_IS_DEVICE_READY)))
          .addMethod(
            getDoBackgroundMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                io.grpc.examples.datahub.DataRequest,
                io.grpc.examples.datahub.DataReply>(
                  this, METHODID_DO_BACKGROUND)))
          .build();
    }
  }

  /**
   * <pre>
   * The greeting service definition.
   * </pre>
   */
  public static final class MessageHubStub extends io.grpc.stub.AbstractStub<MessageHubStub> {
    private MessageHubStub(io.grpc.Channel channel) {
      super(channel);
    }

    private MessageHubStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected MessageHubStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new MessageHubStub(channel, callOptions);
    }

    /**
     * <pre>
     * do scanning
     * </pre>
     */
    public void doScan(io.grpc.examples.datahub.DataRequest request,
        io.grpc.stub.StreamObserver<io.grpc.examples.datahub.DataReply> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getDoScanMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     * <pre>
     * check if device is ready
     * </pre>
     */
    public void isDeviceReady(io.grpc.examples.datahub.DataRequest request,
        io.grpc.stub.StreamObserver<io.grpc.examples.datahub.DataReply> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getIsDeviceReadyMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     * <pre>
     * do background
     * </pre>
     */
    public void doBackground(io.grpc.examples.datahub.DataRequest request,
        io.grpc.stub.StreamObserver<io.grpc.examples.datahub.DataReply> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getDoBackgroundMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   * <pre>
   * The greeting service definition.
   * </pre>
   */
  public static final class MessageHubBlockingStub extends io.grpc.stub.AbstractStub<MessageHubBlockingStub> {
    private MessageHubBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private MessageHubBlockingStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected MessageHubBlockingStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new MessageHubBlockingStub(channel, callOptions);
    }

    /**
     * <pre>
     * do scanning
     * </pre>
     */
    public io.grpc.examples.datahub.DataReply doScan(io.grpc.examples.datahub.DataRequest request) {
      return blockingUnaryCall(
          getChannel(), getDoScanMethod(), getCallOptions(), request);
    }

    /**
     * <pre>
     * check if device is ready
     * </pre>
     */
    public io.grpc.examples.datahub.DataReply isDeviceReady(io.grpc.examples.datahub.DataRequest request) {
      return blockingUnaryCall(
          getChannel(), getIsDeviceReadyMethod(), getCallOptions(), request);
    }

    /**
     * <pre>
     * do background
     * </pre>
     */
    public io.grpc.examples.datahub.DataReply doBackground(io.grpc.examples.datahub.DataRequest request) {
      return blockingUnaryCall(
          getChannel(), getDoBackgroundMethod(), getCallOptions(), request);
    }
  }

  /**
   * <pre>
   * The greeting service definition.
   * </pre>
   */
  public static final class MessageHubFutureStub extends io.grpc.stub.AbstractStub<MessageHubFutureStub> {
    private MessageHubFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private MessageHubFutureStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected MessageHubFutureStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new MessageHubFutureStub(channel, callOptions);
    }

    /**
     * <pre>
     * do scanning
     * </pre>
     */
    public com.google.common.util.concurrent.ListenableFuture<io.grpc.examples.datahub.DataReply> doScan(
        io.grpc.examples.datahub.DataRequest request) {
      return futureUnaryCall(
          getChannel().newCall(getDoScanMethod(), getCallOptions()), request);
    }

    /**
     * <pre>
     * check if device is ready
     * </pre>
     */
    public com.google.common.util.concurrent.ListenableFuture<io.grpc.examples.datahub.DataReply> isDeviceReady(
        io.grpc.examples.datahub.DataRequest request) {
      return futureUnaryCall(
          getChannel().newCall(getIsDeviceReadyMethod(), getCallOptions()), request);
    }

    /**
     * <pre>
     * do background
     * </pre>
     */
    public com.google.common.util.concurrent.ListenableFuture<io.grpc.examples.datahub.DataReply> doBackground(
        io.grpc.examples.datahub.DataRequest request) {
      return futureUnaryCall(
          getChannel().newCall(getDoBackgroundMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_DO_SCAN = 0;
  private static final int METHODID_IS_DEVICE_READY = 1;
  private static final int METHODID_DO_BACKGROUND = 2;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final MessageHubImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(MessageHubImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_DO_SCAN:
          serviceImpl.doScan((io.grpc.examples.datahub.DataRequest) request,
              (io.grpc.stub.StreamObserver<io.grpc.examples.datahub.DataReply>) responseObserver);
          break;
        case METHODID_IS_DEVICE_READY:
          serviceImpl.isDeviceReady((io.grpc.examples.datahub.DataRequest) request,
              (io.grpc.stub.StreamObserver<io.grpc.examples.datahub.DataReply>) responseObserver);
          break;
        case METHODID_DO_BACKGROUND:
          serviceImpl.doBackground((io.grpc.examples.datahub.DataRequest) request,
              (io.grpc.stub.StreamObserver<io.grpc.examples.datahub.DataReply>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        default:
          throw new AssertionError();
      }
    }
  }

  private static abstract class MessageHubBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    MessageHubBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return io.grpc.examples.datahub.DataHubProto.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("MessageHub");
    }
  }

  private static final class MessageHubFileDescriptorSupplier
      extends MessageHubBaseDescriptorSupplier {
    MessageHubFileDescriptorSupplier() {}
  }

  private static final class MessageHubMethodDescriptorSupplier
      extends MessageHubBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    MessageHubMethodDescriptorSupplier(String methodName) {
      this.methodName = methodName;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (MessageHubGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new MessageHubFileDescriptorSupplier())
              .addMethod(getDoScanMethod())
              .addMethod(getIsDeviceReadyMethod())
              .addMethod(getDoBackgroundMethod())
              .build();
        }
      }
    }
    return result;
  }
}

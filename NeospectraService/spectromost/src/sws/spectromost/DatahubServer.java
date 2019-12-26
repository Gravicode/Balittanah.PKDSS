package sws.spectromost;

import io.grpc.Server;
import io.grpc.ServerBuilder;
import io.grpc.examples.datahub.DataReply;
import io.grpc.examples.datahub.DataRequest;
import io.grpc.examples.datahub.MessageHubGrpc;
import io.grpc.stub.StreamObserver;
import sws.p2AppManager.p2AppManager;
import sws.p2AppManager.utils.p2Enumerations.p2AppManagerStatus;
import sws.spectromost.*;

import java.awt.EventQueue;
import java.io.*;
import java.nio.file.Paths;
import java.util.logging.Logger;

import com.google.api.Distribution.BucketOptionsOrBuilder;

/**
 * Server that manages startup/shutdown of a {@code Greeter} server.
 */
public class DatahubServer {
  private static final Logger logger = Logger.getLogger(DatahubServer.class.getName());

  private Server server;
  static p2AppManager applicationManager;

  private void start() throws IOException {
    /* The port on which the server should run */
    int port = 50051;
    server = ServerBuilder.forPort(port).addService(new DatahubImpl()).build().start();
    logger.info("Server started, listening on " + port); 
    
    Runtime.getRuntime().addShutdownHook(new Thread() {
      @Override
      public void run() {
        // Use stderr here since the logger may have been reset by its JVM shutdown hook.
        System.err.println("*** shutting down gRPC server since JVM is shutting down");
        DatahubServer.this.stop();
        
        System.err.println("*** server shut down");
      }
    });
  }
  
  private void stop() {
    if (server != null) {
      server.shutdown();
    }
  }    

  /**
   * Await termination on the main thread since the grpc library uses daemon threads.
   */
  private void blockUntilShutdown() throws InterruptedException {
    if (server != null) {
      server.awaitTermination();
    }
  }

  /**
   * Main launches the server from the command line.
 * @throws Exception 
   */
  public static void main(String[] args) throws Exception {
    final DatahubServer server = new DatahubServer();    
    server.start();
    
    //run check device thread    
    UserInterface.runDeviceManager();
    SpectroscopyPanel.loadFileConfig();

    Thread PKDSS = new Thread() {
    	public void run() {
    		try {
    			Runtime.getRuntime().exec("cmd /c start " + SpectroscopyPanel.PKDSSPath);
    			
    	      } catch(Exception e) {
    	          System.out.println(e.toString());
    	          e.printStackTrace();
    	      } 
    		}
    };
    
    PKDSS.start();
    
//    DoRun();
    
    server.blockUntilShutdown();
  }
  
  public static void DoRun() throws Exception {
	  try {
	      ProcessBuilder builder = new ProcessBuilder(
	          "cmd.exe", "/c", SpectroscopyPanel.PKDSSPath);
	      builder.redirectErrorStream(true);
	      Process p = builder.start();
	      BufferedReader r = new BufferedReader(new InputStreamReader(p.getInputStream()));
	      String line;
	      while (true) {
	          line = r.readLine();
	          if (line == null) { break; }
	          System.out.println(line);
	      }
	  }
	  catch (Exception e) {
          System.out.println(e.toString());
          e.printStackTrace();
	}
  }
  
  static class DatahubImpl extends MessageHubGrpc.MessageHubImplBase {	  
	  
    @Override
    public void doScan(DataRequest req, StreamObserver<DataReply> responseObserver) {
    	try {    		
    		SpectroscopyPanel scp = new SpectroscopyPanel();
    		scp.doRunService();
    		
    		String Message = VariableHelper.getMessage();
    		boolean Status = VariableHelper.getStatus();
    		
        	DataReply reply = DataReply.newBuilder()
        			.setResult(Message + req.getParameter())
//        			.setStatus(Status)
        			.build();
        	responseObserver.onNext(reply);
        	responseObserver.onCompleted();
    	}
    	catch (Exception e) {
    		System.err.println(e.getMessage());
		}
    }
    
    @Override
    public void isDeviceReady(DataRequest req, StreamObserver<DataReply> responseObserver) {
    	try {    	
    		String Message = VariableHelper.getMessage();
    		boolean Status = VariableHelper.getStatus();
    		
    		if (Message != null)
    		{
        		DataReply reply = DataReply.newBuilder()
        				.setResult(Message + req.getParameter())
        				.setStatus(Status)
        				.build();
            	responseObserver.onNext(reply);
            	responseObserver.onCompleted();
    		}
    	}
    	catch (Exception e) {
			System.err.println(e.getMessage());
		}
    }
    
    @Override
    public void doBackground(DataRequest req, StreamObserver<DataReply> responseObserver) {
    	try {
    		SpectroscopyPanel scp = new SpectroscopyPanel();
    		scp.doBackgroundService();
    		
    		String Message = VariableHelper.getMessage();
    		boolean Status = VariableHelper.getStatus();
    		
    		DataReply reply = DataReply.newBuilder()
    				.setResult(Message + req.getParameter())
//    				.setStatus(Status)
    				.build();
        	responseObserver.onNext(reply);
        	responseObserver.onCompleted();
    	}
    	catch (Exception e) {
			System.err.println(e.getMessage());
		}
    }
  }
}

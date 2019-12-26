package sws.spectromost;

import java.awt.EventQueue;

import javax.imageio.ImageIO;
import javax.swing.JFrame;

import java.awt.Toolkit;

import javax.swing.JTabbedPane;

import java.awt.BorderLayout;
import java.awt.Checkbox;
import java.awt.Dimension;
import java.awt.Frame;
import java.awt.Image;

import javax.swing.Box;
import javax.swing.BoxLayout;
import javax.swing.JDialog;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JMenu;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JProgressBar;
import javax.swing.JScrollPane;
import javax.swing.SwingConstants;
import javax.swing.border.BevelBorder;

import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.event.ComponentEvent;
import java.awt.event.ComponentListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileFilter;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.Writer;
import java.util.ArrayList;
import java.util.Observable;
import java.util.Observer;

import org.apache.log4j.Logger;

import sws.p2AppManager.*;
import sws.p2AppManager.utils.p2AppManagerNotification;
import sws.p2AppManager.utils.p2AppManagerUtils;
import sws.p2AppManager.utils.p2Constants;
import sws.p2AppManager.utils.p2Enumerations;
import sws.p2AppManager.utils.p2Enumerations.p2AppManagerStatus;

import java.awt.Font;
import java.awt.Color;


public class UserInterface implements Observer{

	private static Logger logger = Logger.getLogger(UserInterface.class);

	/*
	 * ! boolean to indicate finishing switching device (upon notification)
	 */
	public static boolean switchingDeviceFinished = false;

	/*
	 * ! time to wait for switching device notification before time out
	 */
	public static final long switchingDeviceTimeOut = 2000;

	/*
	 * ! Path of the file you want to write values of ASIC registers to.
	 */
	public static String regFileToWrite = "";

	public static boolean stopEnablingButtons = false;

	/*
	 * ! state of actuation whether started or not
	 */
	public static boolean actState = false;

	/*
	 * ! boolean value to stop continuous sample when needed
	 */
	public static boolean isContinuousRun = false;
	public static boolean stopContinuousRun = false;

	/*
	 * ! gets the path of running application
	 */
	public static String APPLICATION_WORKING_DIRECTORY = p2Constants.Original_APPLICATION_WORKING_DIRECTORY;

	public static final String GRAPH_FILES_FOLDER_PATH = APPLICATION_WORKING_DIRECTORY + File.separatorChar + "Temp_Graphs";

	public static final String OPTIONS_PATH = APPLICATION_WORKING_DIRECTORY + File.separatorChar + "Conf_Files";

	public static String defaultDirectorySaveLoad;

	public static String fileNameToSave = "";
	/*
	 * ! Module ID to be written to the board EEPROM
	 */
	public static String moduleID = "";

	static p2AppManager applicationManager;
	static InterSpecPanel pnl_Inter_Spec;
	static SpectroscopyPanel pnl_Spectroscopy;

	/*
	 * ! boolean value to stop checkDeviceStatusThread when needed
	 */
	static boolean checkDeviceStatusThreadStop = false;

	//scan time of the current run to set the progress based on it.
	static double progressTime = -1;

	//time of sleep of check device status thread
	static final int THREAD_SLEEP_TIME = 1000;

	//boolean value to indicate whether the board was just restarted or not (used to force background reading after restarting board)
	static boolean boardRestarted = true;
	
	//progress parameter
	private static int progressPar;	
	public static void setprogressPar(int Progress) {progressPar = Progress;}
	public static int getprogressPar() {return progressPar;}

	Thread checkDeviceStatusThread = new Thread() {

		public void run() {
			try {

				while (true) {
					Thread.sleep(THREAD_SLEEP_TIME);
//					System.out.println("Run thread");
					if (checkDeviceStatusThreadStop == false) {

						p2AppManagerStatus status = applicationManager.checkDeviceStatus();

						if (p2AppManagerStatus.NO_ERROR == status) {

							if(!VariableHelper.getMessage().equals("Background Measurement completed successfully!"))
							{
								VariableHelper.setMessage("NeoSpectra module is Ready!");
								VariableHelper.setStatus(true);
							}
							VariableHelper.setStatus(true);

						} else {

							setprogressPar(0);
							boardRestarted = true;

							if (p2AppManagerStatus.INITIALIZATION_IN_PROGRESS == status) {
								VariableHelper.setMessage("Initializing NeoSpectra module. Please wait...");
								VariableHelper.setStatus(false);

							} else if (p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == status) {

								VariableHelper.setMessage("NeoSpectra module is connected");
								VariableHelper.setStatus(false);

							} else if (p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == status) {

								VariableHelper.setMessage("SpectroMOST does not detect any connected NeoSpectra module");
								VariableHelper.setStatus(false);
								
								SpectroscopyPanel.lbl_moduleID_Spec.setText("");
								InterSpecPanel.lbl_ModuleID_Inter_Spec.setText("");

								SpectroscopyPanel.cmb_Resolution_Spec.removeAllItems();
								InterSpecPanel.cmb_Resolution_Inter_Spec.removeAllItems();

								SpectroscopyPanel.cmb_Optical_Settings_Spec.removeAllItems();
								InterSpecPanel.cmb_Optical_Settings_Inter_Spec.removeAllItems();

								InterSpecPanel.lastResolutionSelected = "";
								SpectroscopyPanel.lastResolutionSelected = "";
								SpectroscopyPanel.lastZeroPaddingSelected = "";

								SpectroscopyPanel.lastOpticalSettingsSelected = "";
								InterSpecPanel.lastOpticalSettingsSelected = "";

							} else {

								VariableHelper.setMessage(convertErrorCodesToMessages(status) + ".");
								VariableHelper.setStatus(false);
							}

							boardReadyRoutine(false);

							SpectroscopyPanel.btn_Stop_Spec.setEnabled(false);
							InterSpecPanel.btn_Stop_Inter_Spec.setEnabled(false);

						}
					}
					else
					{
						if(progressTime != -1)
						{
							if((int)((THREAD_SLEEP_TIME/progressTime) * 100) != 0)
							{
								setprogressPar(getprogressPar() + (int)((THREAD_SLEEP_TIME/progressTime) * 100));
							}
							else
							{
								setprogressPar(getprogressPar() + (int)Math.ceil((THREAD_SLEEP_TIME/progressTime) * 100));	
							}
						}
					}
				}
			} catch (Exception ex) {
				logger.error(ex.getMessage());
			}
		}
	};
	
	/*
	 * ! Initialize the contents of the frame.
	 */
	private void initialize() {
		p2AppManagerUtils.removeDir(p2Constants.getPath(GRAPH_FILES_FOLDER_PATH));
		p2AppManagerUtils.createDir(p2Constants.getPath(GRAPH_FILES_FOLDER_PATH));
	}		
	
	/*
	 * ! Launch the application.
	 */
	public static void runDeviceManager() {

		EventQueue.invokeLater(new Runnable() {

			public void run() {
				try {
					logger.info("Starting Application.....");

					UserInterface window = new UserInterface();

					// Initialize the Application Manager
					p2AppManagerStatus status = applicationManager.initializeCore();

					if (p2AppManagerStatus.NO_ERROR != status) {

						logger.error("error happen while trying to run current initialize \n"
								+ convertErrorCodesToMessages(status));
					}

					window.checkDeviceStatusThread.start();

				} catch (Exception e) {
					logger.error(e.getMessage());
				}
			}
		});
	}

	/*
	 * ! Create the application.
	 */
	public UserInterface() {
		initialize();
		
		// Construct the Application Manager
		applicationManager = new p2AppManagerImpl();
		pnl_Inter_Spec = new InterSpecPanel();
		pnl_Spectroscopy = new SpectroscopyPanel();

		applicationManager.addObserver(this);
	}

	@Override
	public void update(Observable arg0, Object arg1) {
		if (arg1 instanceof p2AppManagerNotification) {
			p2AppManagerNotification resp = (p2AppManagerNotification) arg1;

			switch (resp.getAction()) {

			case 0: // Initialization
				if (resp.getStatus() == 0) {
					VariableHelper.setMessage("Initialization of NeoSpectra module completed successfully!");
					initializationPostAction();

				} else {

					VariableHelper.setMessage(convertErrorCodesToMessages(resp.getStatus()));
				}
				break;

			case 1: // Interferogram & Spectrum Run
				pnl_Inter_Spec.update(arg1);
				break;
			case 2: // Spectroscopy background run
				pnl_Spectroscopy.update(arg1);
				break;
			case 3: // Spectroscopy sample Run
				pnl_Spectroscopy.update(arg1);
				break;
			case 4: // actuation setting
				if (resp.getStatus() != 0) {

					JOptionPane.showMessageDialog(
							null,
							convertErrorCodesToMessages(resp.getStatus()), "switch device",
							JOptionPane.OK_OPTION);

				}
				else
				{
					switchingDeviceFinished = true;
				}
				checkDeviceStatusThreadStop = false;
				break;

			case 23: // Adaptive Gain
				try {
					SpecGainPanel.update(arg1);
				} catch (Exception e) {

					progressTime = -1;
					setprogressPar(100);

					JOptionPane.showMessageDialog(null,
							"Failed to save gain settings.",
							"Gain Adjustment", JOptionPane.OK_OPTION);

					logger.info("switching actuation off started");
					//switch off actuation
					switchOnOFF(false, true);
					logger.info("switching actuation off finished");

					logger.info("enabling GUI fields started");
					boardReadyRoutine(true);
					logger.info("enabling GUI fields finished");

					// resume checking the status of the device
					checkDeviceStatusThreadStop = false;	
				}

				break;
			case 25: //Interferogram gain and offset correction parameters calculation

				try {
					WL_WN_CalibrationPanel.update(arg1);
				} catch (Exception e) {

					progressTime = -1;
					setprogressPar(100);

					JOptionPane.showMessageDialog(
							null,
							convertErrorCodesToMessages(resp.getStatus()),
							"Self Calibration", JOptionPane.OK_OPTION);

					logger.info("switching actuation off started");
					//switch off actuation
					switchOnOFF(false, true);
					logger.info("switching actuation off finished");

					logger.info("enabling GUI fields started");
					boardReadyRoutine(true);
					logger.info("enabling GUI fields finished");

					// resume checking the status of the device
					checkDeviceStatusThreadStop = false;
				}
				break;
			case 26: //Wavelength calibration in spectrum tab

				try {
					WL_WN_CalibrationPanel.update(arg1);
				} catch (Exception e) {

					progressTime = -1;
					setprogressPar(100);

					JOptionPane.showMessageDialog(
							null,
							convertErrorCodesToMessages(resp.getStatus()),
							"Wavenumber Calibration", JOptionPane.OK_OPTION);

					logger.info("switching actuation off started");
					//switch off actuation
					switchOnOFF(false, true);
					logger.info("switching actuation off finished");

					logger.info("enabling GUI fields started");
					boardReadyRoutine(true);
					logger.info("enabling GUI fields finished");

					// resume checking the status of the device
					checkDeviceStatusThreadStop = false;
				}

				break;
			case 28: // Gain Adjustment Spec BG
				try {
					SpecGainPanel.update(arg1);
				} catch (Exception e) {

					progressTime = -1;
					setprogressPar(100);

					JOptionPane.showMessageDialog(null,
							"Failed to save gain settings.",
							"Gain Adjustment", JOptionPane.OK_OPTION);

					logger.info("switching actuation off started");
					//switch off actuation
					switchOnOFF(false, true);
					logger.info("switching actuation off finished");

					logger.info("enabling GUI fields started");
					boardReadyRoutine(true);
					logger.info("enabling GUI fields finished");

					// resume checking the status of the device
					checkDeviceStatusThreadStop = false;	
				}

				break;
			case 29: // Gain Adjustment Spec Sample
				try {
					SpecGainPanel.update(arg1);
				} catch (Exception e) {

					progressTime = -1;
					setprogressPar(100);

					JOptionPane.showMessageDialog(null,
							"Failed to save gain settings.",
							"Gain Adjustment", JOptionPane.OK_OPTION);

					logger.info("switching actuation off started");
					//switch off actuation
					switchOnOFF(false, true);
					logger.info("switching actuation off finished");

					logger.info("enabling GUI fields started");
					boardReadyRoutine(true);
					logger.info("enabling GUI fields finished");

					// resume checking the status of the device
					checkDeviceStatusThreadStop = false;	
				}

				break;
			case 30: //BG measurement for Wavelength calibration in spectrum tab

				try {
					WL_WN_CalibrationPanel.update(arg1);
				} catch (Exception e) {

					progressTime = -1;
					setprogressPar(100);

					JOptionPane.showMessageDialog(
							null,
							convertErrorCodesToMessages(resp.getStatus()),
							"Wavenumber Calibration", JOptionPane.OK_OPTION);

					logger.info("switching actuation off started");
					//switch off actuation
					switchOnOFF(false, true);
					logger.info("switching actuation off finished");

					logger.info("enabling GUI fields started");
					boardReadyRoutine(true);
					logger.info("enabling GUI fields finished");

					// resume checking the status of the device
					checkDeviceStatusThreadStop = false;
				}

				break;
			case 31: // Interferogram & Spectrum update fft settings
				pnl_Inter_Spec.update(arg1);
			case 32: // Spectroscopy update fft settings
				pnl_Spectroscopy.update(arg1);
			case 33:// Restore default settings
				if (resp.getStatus() == 0) {
					VariableHelper.setMessage("Restoring to default completed successfully!");

				} else {

					JOptionPane.showMessageDialog(
							null,
							"Restore default settings has error: "
									+ resp.getStatus(), "Restore Default Settings",
									JOptionPane.OK_OPTION);
				}
				UserInterface.boardReadyRoutine(true);


				UserInterface.displayInterSpecOpticalSettings();
				UserInterface.displaySpecOpticalSettings();

				// resume checking the status of the device
				UserInterface.checkDeviceStatusThreadStop = false;
				break;
			case 34:// burn settings
				if (resp.getStatus() == 0) {
					displayInterSpecOpticalSettings();
					displaySpecOpticalSettings();

					VariableHelper.setMessage("Burn Setting completed successfully!");

				} else {

					JOptionPane.showMessageDialog(
							null,
							"Burn settings has error: "
									+ resp.getStatus(), "Burn settings",
									JOptionPane.OK_OPTION);
				}
				UserInterface.boardReadyRoutine(true);
				// resume checking the status of the device
				UserInterface.checkDeviceStatusThreadStop = false;
				break;
			default:
				// not supported action
				;
			}
		}
	}

	public static void initializationPostAction() {
		try
		{
			moduleID = applicationManager.getDeviceId();
			SpectroscopyPanel.lbl_moduleID_Spec.setText(moduleID);
			InterSpecPanel.lbl_ModuleID_Inter_Spec.setText(moduleID);

			displayInterSpecOpticalSettings();
			displaySpecOpticalSettings();

			displayStandardCalibrators();

			if(SpectroscopyPanel.cmb_Optical_Settings_Spec.getItemCount() > 0)
				SpectroscopyPanel.cmb_Optical_Settings_Spec.setSelectedIndex(0);

			pnl_Spectroscopy.changeOptionRoutine();

			if(InterSpecPanel.cmb_Optical_Settings_Inter_Spec.getItemCount() > 0)
				InterSpecPanel.cmb_Optical_Settings_Inter_Spec.setSelectedIndex(0);

			displayResolutions();

			SpectroscopyPanel.cmb_Resolution_Spec.setSelectedIndex(0);
			InterSpecPanel.cmb_Resolution_Inter_Spec.setSelectedIndex(0);

			SpectroscopyPanel.cmb_Apodization_Spec.setSelectedIndex(p2Constants.apodizationDefaultIndex);
			InterSpecPanel.cmb_Apodization_Inter_Spec.setSelectedIndex(p2Constants.apodizationDefaultIndex);

			SpectroscopyPanel.cmb_ZeroPadding_Spec.setSelectedIndex(p2Constants.paddingDefaultIndex);
			InterSpecPanel.cmb_ZeroPadding_Inter_Spec.setSelectedIndex(p2Constants.paddingDefaultIndex);

			String[] resolutions = readResolutionsFromDisk();

		}
		catch(Exception c)
		{
			logger.error(c.getMessage());
		}
	}

	public static String[] readResolutionsFromDisk()
	{
		ArrayList<String> resolutionsList = new ArrayList<String>();

		if(moduleID.equals(""))
		{
			return new String[0];
		}

		// get all conf. profile folders name
		String[] tempFolders = p2AppManagerUtils.getFolderSubFoldersNames( p2AppManagerUtils.formatString( p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE),
				moduleID),
				new ArrayList<String>(),
				false);


		ArrayList<String> validTempFolders = new ArrayList<String>();

		// loop on the temp folders to get the valid ones
		for( String tempFolder : tempFolders)
		{
			if(!tempFolder.equals(".svn"))
			{
				validTempFolders.add(tempFolder);
			}
		}

		if (validTempFolders.size() == 0)
		{
			return new String[0];
		}


		for(int i = 0; i < validTempFolders.size(); i++)
		{
			// get all resolutions folders name
			String[] resolutionsFolders = p2AppManagerUtils.getFolderSubFoldersNames( p2AppManagerUtils.formatString( p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE),
					moduleID) + File.separatorChar + validTempFolders.get(i),
					new ArrayList<String>(),
					false);

			ArrayList<String> validResolutionsFolders = new ArrayList<String>();

			// loop on the resolutions folders to get the valid ones
			for( String resolutionFolder : resolutionsFolders)
			{
				if(!resolutionFolder.equals(".svn"))
				{
					validResolutionsFolders.add(resolutionFolder);
				}
			}

			if (validResolutionsFolders.size() == 0)
			{
				return new String[0];
			}

			//for the first temp load all resolution
			if(i == 0)
			{
				for(int index = 0; index < validResolutionsFolders.size(); index++)
				{
					resolutionsList.add(validResolutionsFolders.get(index));
				}
			}
			//Remove any resolution that could not be found in another temp
			else
			{
				for(int index = 0; index < resolutionsList.size(); index++)
				{
					if(!validResolutionsFolders.contains(resolutionsList.get(index)))
					{
						resolutionsList.remove(index);
					}
				}
			}
		}

		return (String[]) resolutionsList.toArray(new String[resolutionsList.size()]);
	}

//	public static boolean writeGraphFile(double[] x, double[] y, String path, String header) {
//
//		Writer writer = null;
//
//		try {
//
//			writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(path), "utf-8"));
//			writer.write(header);
//			writer.write("\n");
//			int length = x.length < y.length ? x.length : y.length;
//
//			for (int i = 0; i < length; i++) {
//				writer.write(Double.toString(x[i]) + "\t" + Double.toString(y[i]));
//				writer.write("\n");
//			}
//
//			return true;
//
//		} catch (IOException ex) {
//			logger.error(ex.getMessage());
//			return false;
//		} finally {
//			try {
//				writer.close();
//			} catch (Exception ex) {
//				logger.error(ex.getMessage());
//			}
//		}
//	}
	
	public static boolean writeGraphFile(double[] x, double[] y, String path, String header) {

		Writer writer = null;

		try {

			writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(path), "utf-8"));
			
			int length = x.length < y.length ? x.length : y.length;
			
			for (int i = 0; i < length; i++) {
				if (i < length -1)
				{
					writer.write(Double.toString(x[i]) + ",");
				}
				else
				{
					writer.write(Double.toString(x[i]));
				}
				
			}			

			writer.write("\n");
			
			for (int i = 0; i < length; i++) {
				if (i < length -1)
				{
					writer.write(Double.toString(y[i]) + ",");
				}
				else
				{
					writer.write(Double.toString(y[i]));
				}
				
			}	
			writer.write("\n");

			return true;

		} catch (IOException ex) {
			logger.error(ex.getMessage());
			return false;
		} finally {
			try {
				writer.close();
			} catch (Exception ex) {
				logger.error(ex.getMessage());
			}
		}
	}

	static double[] switch_NM_CM(double[] data) {
		double[] xAxis = new double[data.length];
		for (int i = 0; i < xAxis.length; i++) {
			xAxis[i] = 10000000 / data[i];
		}
		return xAxis;
	}

	static double[][] loadGraphDataFromFile(String strFilePath) {
		ArrayList<Double> xList = new ArrayList<Double>();
		ArrayList<Double> yList = new ArrayList<Double>();
		BufferedReader reader = null;
		try {
			reader = new BufferedReader(new FileReader(strFilePath));

			// Read units line (do nothing with it for now)
			String line = reader.readLine();
			if (line.contains("y_Axis:Absorbance")) {

				SpectroscopyPanel.rdbtn_Absorbance.setSelected(true);
				SpectroscopyPanel.rdbtn_Refl_Trans.setSelected(false);
			} else if (line.contains("y_Axis:%Transmittance") || line.contains("y_Axis:%Reflectance")) {
				SpectroscopyPanel.rdbtn_Refl_Trans.setSelected(true);
				SpectroscopyPanel.rdbtn_Absorbance.setSelected(false);
			}
			if (line.contains("x_Axis:Wavenumber (cm-1)")) {

				SpectroscopyPanel.rdbtn_cm_Spec.setSelected(true);
				SpectroscopyPanel.rdbtn_nm_Spec.setSelected(false);

				InterSpecPanel.rdbtn_cm_Inter_Spec.setSelected(true);
				InterSpecPanel.rdbtn_nm_Inter_Spec.setSelected(false);
			} else if (line.contains("x_Axis:Wavelength (nm)")) {

				SpectroscopyPanel.rdbtn_nm_Spec.setSelected(true);
				SpectroscopyPanel.rdbtn_nm_Spec.setSelected(false);

				InterSpecPanel.rdbtn_nm_Inter_Spec.setSelected(true);
				InterSpecPanel.rdbtn_cm_Inter_Spec.setSelected(false);
			}
			while ((line = reader.readLine()) != null) {
				String[] strLineTokens = line.split("\t");

				if (strLineTokens.length == 2) {
					xList.add(Double.parseDouble(strLineTokens[0]));
					yList.add(Double.parseDouble(strLineTokens[1]));
				}
			}

		} catch (Exception ex) {
			logger.error(ex.getMessage());
			JOptionPane.showMessageDialog(null, ex.getMessage(), "Load error", JOptionPane.ERROR_MESSAGE);
			return null;
		} finally {
			try {
				reader.close();
			} catch (Exception ex) {
				logger.error(ex.getMessage());
			}
		}

		double[][] arrayToReturn = new double[2][];
		arrayToReturn[0] = new double[xList.size()];
		arrayToReturn[1] = new double[yList.size()];

		for (int y = 0; y < arrayToReturn[0].length; y++) {
			arrayToReturn[0][y] = xList.get(y);
		}

		for (int y = 0; y < arrayToReturn[1].length; y++) {
			arrayToReturn[1][y] = yList.get(y);
		}

		xList = null;
		yList = null;

		return arrayToReturn;
	}

	public static boolean checkEmptyDirectory(String filePath) {

		File file = new File(filePath);

		if (file.isDirectory()) {
			if (file.list().length > 0) {
				return false;
			} else {
				return true;
			}
		}
		return false;
	}

	/*
	 * !converts transmission data to absorbance data
	 */
	public static double[] convertRefltoAbs(double[] data) {
		double[] xInverse = new double[data.length];
		for (int i = 0; i < xInverse.length; i++) {
			xInverse[i] = -(Math.log10(data[i] / 100.0));
		}
		return xInverse;
	}

	/*
	 * !converts absorbance data to transmission data
	 */
	public static double[] convertAbstoRefl(double[] data) {
		double[] xInverse = new double[data.length];
		for (int i = 0; i < xInverse.length; i++) {
			xInverse[i] = 100.0 * Math.pow(10.0, -data[i]);
		}
		return xInverse;
	}

	public static double[] convertDataToT(double[] data) {
		double[] TArray = new double[data.length];
		for (int i = 0; i < TArray.length; i++) {
			TArray[i] = Math.pow(10, data[i] / 10) * 100;
		}
		return TArray;
	}

	public static String[] readOptions() {
		String[] temps = null;
		String[] options = null;
		try {
			if(!moduleID.equals(""))
			{
				String directory = p2Constants.getPath(OPTIONS_PATH) + File.separatorChar + moduleID;
				File dir = new File(directory);

				// lists all folders in module ID (temperature folders).
				File[] subDirs = dir.listFiles(new FileFilter() {
					public boolean accept(File pathname) {
						return pathname.isDirectory() && (!pathname.getName().equals(".svn"));
					}
				});
				temps = new String[subDirs.length];
				for (int i = 0; i< subDirs.length; i++) {
					temps[i] = subDirs[i].getName();
				}
				directory += File.separatorChar + temps[0];
				dir = new File(directory);

				// lists all folders in temperature folder (Refl / Trans).
				subDirs = dir.listFiles(new FileFilter() {
					public boolean accept(File pathname) {
						return pathname.isDirectory() && (!pathname.getName().equals(".svn"));
					}
				});
				options = new String[subDirs.length];

				int j = 0;
				for (int i = subDirs.length - 1; i >= 0; i--) {
					options[j] = subDirs[i].getName();
					j++;
				}
			}
			else
			{
				return new String[] {""};
			}
		} catch (Exception e) {
			logger.error(e.getMessage());
		}

		return options;
	}


	public static String[] readOpticalSettings() {
		try {

			String path = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), UserInterface.moduleID);
			ArrayList<String> list = new ArrayList<String>();

			File filePath = new File(path);

			if(filePath.exists())
			{
				BufferedReader reader = null;
				try {
					reader = new BufferedReader(new FileReader(path));

					String line = null;
					while ((line = reader.readLine()) != null) {
						if(line.startsWith(".option"))
						{
							list.add(line.replace(".option ", ""));
						}
					}

				} catch (Exception ex) {
					return null;
				} finally {
					try {
						reader.close();
					} catch (Exception ex) {
						return null;
					}
				}
			}

			return (list.toArray(new String[list.size()]));


		} catch (Exception e) {
			logger.error(e.getMessage());
		}

		return null;
	}




	public static void deleteOpticalSetting(String setting)
	{

		try {

			String path = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), UserInterface.moduleID);
			ArrayList<String> list = new ArrayList<String>();

			File filePath = new File(path);
			boolean bypass = false;

			if(filePath.exists())
			{
				BufferedReader reader = null;
				try {
					reader = new BufferedReader(new FileReader(path));

					String line = null;
					while ((line = reader.readLine()) != null) {
						if(line.replace(".option ", "").trim().equals(setting))
						{
							bypass = true;
						}
						else if(line.contains(".end") && bypass)
						{
							bypass = false;
						}
						else{
							if(!bypass)
								list.add(line);
						}
					}

				} catch (Exception ex) {
					return;
				} finally {
					try {
						reader.close();
					} catch (Exception ex) {
						return;
					}
				}

				BufferedWriter writer= null;
				try {
					writer = new BufferedWriter(new FileWriter(path, false));
					for(String line : list)
					{
						writer.write(line + "\r\n");
					}
				} catch (Exception ex) {
					return;
				} finally {
					try {
						writer.close();
					} catch (Exception ex) {
						return;
					}
				}
			}



		} catch (Exception e) {
			logger.error(e.getMessage());
		}
	}

	public static String[] readResolutions() {
		String[] temps = null;
		String[] resolutions = null;
		try {
			if(!moduleID.equals(""))
			{
				String directory = p2Constants.getPath(OPTIONS_PATH) + File.separatorChar + moduleID;
				File dir = new File(directory);

				// lists all folders in module ID (temperature folders).
				File[] subDirs = dir.listFiles(new FileFilter() {
					public boolean accept(File pathname) {
						return pathname.isDirectory() && (!pathname.getName().equals(".svn"));
					}
				});
				temps = new String[subDirs.length];
				for (int i = 0; i< subDirs.length; i++) {
					temps[i] = subDirs[i].getName();
				}

				directory = p2Constants.getPath(OPTIONS_PATH) + File.separatorChar + moduleID + File.separatorChar + temps[0] + File.separatorChar;
				dir = new File(directory);

				// lists all folders in directory.
				subDirs = dir.listFiles(new FileFilter() {
					public boolean accept(File pathname) {
						return pathname.isDirectory() && (!pathname.getName().equals(".svn"));
					}
				});
				resolutions = new String[subDirs.length];

				for (int i = 0; i< subDirs.length; i++) {
					resolutions[i] = subDirs[i].getName();
				}
			}
			else
			{
				return new String[] {""};
			}
		} catch (Exception e) {
			logger.error(e.getMessage());
		}
		return resolutions;
	}

	public static String[] readStandardCalibrators() {
		String[] calibrators = null;
		String[] returnedCalibrators = null;
		try {
			String directory = p2Constants.getPath(p2Constants.STANDARD_CALIBRATORS_FOLDER_PATH);
			File dir = new File(directory);

			// lists all folders in directory.
			File[] subDirs = dir.listFiles();
			calibrators = new String[subDirs.length];
			int noCalibrators = 0;

			for (int i = 0; i< subDirs.length; i++) {
				if(subDirs[i].isFile() && subDirs[i].getName().contains(p2Constants.STANDARD_CALIBRATORS_FILE_EXT))
				{
					calibrators[noCalibrators] = subDirs[i].getName().replace(p2Constants.STANDARD_CALIBRATORS_FILE_EXT, "");
					noCalibrators++;
				}
			}

			returnedCalibrators = new String[noCalibrators];
			System.arraycopy(calibrators, 0, returnedCalibrators, 0, noCalibrators);

		} catch (Exception e) {
			logger.error(e.getMessage());
		}
		return returnedCalibrators;
	}

	public static void switchOnOFF(boolean On, boolean openLoop) {
		if (On) {
			try {
				if(openLoop)
				{
					applicationManager.switchDevice("true", "true");
				}
				else
				{
					applicationManager.switchDevice("true", "false");
				}
			} catch (Exception e) {

				JOptionPane.showMessageDialog(
						null,
						"Error occurred during calling switch device: "
								+ e.getMessage(), "switch device",
								JOptionPane.OK_OPTION);

			}

		} else {
			try {
				if(openLoop)
				{
					applicationManager.switchDevice("false", "true");
				}
				else
				{
					applicationManager.switchDevice("false", "false");
				}
			} catch (Exception e) {

				JOptionPane.showMessageDialog(
						null,
						"Error occurred during calling switch device: "
								+ e.getMessage(), "switch device",
								JOptionPane.OK_OPTION);

			}
		}

	}

	public static void boardReadyRoutine(boolean ready) {
		if (ready) {
			SpectroscopyPanel.cmb_Optical_Settings_Spec.setEnabled(true);
			SpectroscopyPanel.btn_Run_Background.setEnabled(true);
			SpectroscopyPanel.btn_Run_Spec.setEnabled(true);
			SpectroscopyPanel.btn_Stop_Spec.setEnabled(true);
			SpectroscopyPanel.rdbtn_SingleRun_Spec.setEnabled(true);
			SpectroscopyPanel.rdbtn_ContRun_Spec.setEnabled(true);
			SpectroscopyPanel.cmb_Resolution_Spec.setEnabled(true);
			SpectroscopyPanel.cmb_Apodization_Spec.setEnabled(true);
			SpectroscopyPanel.cmb_ZeroPadding_Spec.setEnabled(true);
			SpectroscopyPanel.btn_FFT_UpdateResults_Spec.setEnabled(true);
			SpectroscopyPanel.btn_GainAdjustmentPanel_Spec.setEnabled(true);
			SpectroscopyPanel.btn_WavelengthWavenumberCalibration_Spec.setEnabled(true);
			SpectroscopyPanel.btn_WriteSettings_Spec.setEnabled(true);
			SpectroscopyPanel.btn_RestoreDefault_spec.setEnabled(true);
			SpectroscopyPanel.btn_DeleteOpticalOption_Spec.setEnabled(true);

			InterSpecPanel.cmb_Optical_Settings_Inter_Spec.setEnabled(true);
			InterSpecPanel.btn_Run_Inter_Spec.setEnabled(true);
			InterSpecPanel.btn_Stop_Inter_Spec.setEnabled(true);
			InterSpecPanel.rdbtn_SingleRun_Inter_Spec.setEnabled(true);
			InterSpecPanel.rdbtn_ContRun_Inter_Spec.setEnabled(true);
			InterSpecPanel.cmb_Resolution_Inter_Spec.setEnabled(true);
			InterSpecPanel.cmb_Apodization_Inter_Spec.setEnabled(true);
			InterSpecPanel.cmb_ZeroPadding_Inter_Spec.setEnabled(true);
			InterSpecPanel.btn_FFT_UpdateResults_Inter_Spec.setEnabled(true);
			InterSpecPanel.btn_GainAdjustmentPanel_Inter_Spec.setEnabled(true);
			InterSpecPanel.btn_WavelengthWavenumberCalibration_Inter_Spec.setEnabled(true);
			InterSpecPanel.btn_WriteSettings_Inter_Spec.setEnabled(true);
			InterSpecPanel.btn_RestoreDefault_Inter_Spec.setEnabled(true);
			InterSpecPanel.btn_DeleteOpticalOption_Inter_Spec.setEnabled(true);

		} else {
			SpectroscopyPanel.cmb_Optical_Settings_Spec.setEnabled(false);
			SpectroscopyPanel.btn_Run_Background.setEnabled(false);
			SpectroscopyPanel.btn_Run_Spec.setEnabled(false);
			SpectroscopyPanel.rdbtn_SingleRun_Spec.setEnabled(false);
			SpectroscopyPanel.rdbtn_ContRun_Spec.setEnabled(false);
			SpectroscopyPanel.cmb_Resolution_Spec.setEnabled(false);
			SpectroscopyPanel.cmb_Apodization_Spec.setEnabled(false);
			SpectroscopyPanel.cmb_ZeroPadding_Spec.setEnabled(false);
			SpectroscopyPanel.btn_FFT_UpdateResults_Spec.setEnabled(false);
			SpectroscopyPanel.btn_GainAdjustmentPanel_Spec.setEnabled(false);
			SpectroscopyPanel.btn_WavelengthWavenumberCalibration_Spec.setEnabled(false);
			SpectroscopyPanel.btn_WriteSettings_Spec.setEnabled(false);
			SpectroscopyPanel.btn_RestoreDefault_spec.setEnabled(false);
			SpectroscopyPanel.btn_DeleteOpticalOption_Spec.setEnabled(false);

			InterSpecPanel.cmb_Optical_Settings_Inter_Spec.setEnabled(false);
			InterSpecPanel.btn_Run_Inter_Spec.setEnabled(false);
			InterSpecPanel.rdbtn_SingleRun_Inter_Spec.setEnabled(false);
			InterSpecPanel.rdbtn_ContRun_Inter_Spec.setEnabled(false);
			InterSpecPanel.cmb_Resolution_Inter_Spec.setEnabled(false);
			InterSpecPanel.cmb_Apodization_Inter_Spec.setEnabled(false);
			InterSpecPanel.cmb_ZeroPadding_Inter_Spec.setEnabled(false);
			InterSpecPanel.btn_FFT_UpdateResults_Inter_Spec.setEnabled(false);
			InterSpecPanel.btn_GainAdjustmentPanel_Inter_Spec.setEnabled(false);
			InterSpecPanel.btn_WavelengthWavenumberCalibration_Inter_Spec.setEnabled(false);
			InterSpecPanel.btn_WriteSettings_Inter_Spec.setEnabled(false);
			InterSpecPanel.btn_RestoreDefault_Inter_Spec.setEnabled(false);
			InterSpecPanel.btn_DeleteOpticalOption_Inter_Spec.setEnabled(false);

		}
	}

	/*
	 * !reads optical settings from folder and displays them in InterSpec
	 */
	public static void displayInterSpecOpticalSettings() {
		logger.info("Reading InterSpec optical settings");

		InterSpecPanel.cmb_Optical_Settings_Inter_Spec.removeAllItems();

		String[] opticalSettings = UserInterface.readOpticalSettings();
		if (opticalSettings != null) {
			for (String s : opticalSettings) {
				if(s.contains(p2Constants.InterSpecPrefix))
				{
					InterSpecPanel.cmb_Optical_Settings_Inter_Spec.addItem(s.replace(p2Constants.InterSpecPrefix, ""));
				}
			}
		}
	}

	/*
	 * !reads optical settings from folder and displays them in Spec
	 */
//	public static void displaySpecOpticalSettings() {
//		logger.info("Reading Spec optical settings");
//
//		SpectroscopyPanel.cmb_Optical_Settings_Spec.removeAllItems();
//
//		String[] opticalSettings = UserInterface.readOpticalSettings();
//		if (opticalSettings != null) {
//			for (String s : opticalSettings) {
//				if(s.contains(p2Constants.SpecPrefix))
//				{
//					SpectroscopyPanel.cmb_Optical_Settings_Spec.addItem(s.replace(p2Constants.SpecPrefix, ""));
//				}
//			}
//		}
//	}
	public static void displaySpecOpticalSettings() {
		logger.info("Reading Spec optical settings");

		SpectroscopyPanel.optical_Settings_Spec.clear();

		String[] opticalSettings = UserInterface.readOpticalSettings();
		if (opticalSettings != null) {
			for (String s : opticalSettings) {
				if(s.contains(p2Constants.SpecPrefix))
				{
					SpectroscopyPanel.optical_Settings_Spec.add(s.replace(p2Constants.SpecPrefix, ""));
				}
			}
		}
	}

	/*
	 * !reads resolution folders from option folder and displays them in the 3 tabs
	 */
//	public static void displayResolutions() {
//		String[] options = UserInterface.readResolutions();
//		if (options != null) {
//			SpectroscopyPanel.cmb_Resolution_Spec.removeAllItems();
//			InterSpecPanel.cmb_Resolution_Inter_Spec.removeAllItems();
//
//			for (String s : options) {
//				if(!s.equals(p2Constants.TWO_POINTS_CORR_CALIB_FOLDER_NAME))
//				{
//					SpectroscopyPanel.cmb_Resolution_Spec.addItem(s);
//					InterSpecPanel.cmb_Resolution_Inter_Spec.addItem(s);
//				}
//			}
//		}
//	}
	
	public static void displayResolutions() {
		String[] options = UserInterface.readResolutions();
		if (options != null) {
			SpectroscopyPanel.resolution_Spec.clear();

			for (String s : options) {
				if(!s.equals(p2Constants.TWO_POINTS_CORR_CALIB_FOLDER_NAME))
				{
					SpectroscopyPanel.resolution_Spec.add(s);
				}
			}
		}
	}

	/*
	 * !reads standard calibrators from standard_calibrator folder and display them in the calibration and spectroscopy tabs
	 */
	public static void displayStandardCalibrators() {
		String[] options = UserInterface.readStandardCalibrators();
		if (options != null) {
			try
			{
				WL_WN_CalibrationPanel.cmb_StandardCalibrator_WL_Calib.removeAllItems();
			}
			catch (Exception e) {

			}

			try
			{
				WL_WN_CalibrationPanel.cmb_StandardCalibrator_WL_Calib.addItem(p2Constants.STANDARD_CALIBRATOR_DEFAULT_CHOISE);
			}
			catch (Exception e) {

			}

			for (String s : options) {
				try
				{
					WL_WN_CalibrationPanel.cmb_StandardCalibrator_WL_Calib.addItem(s);
				}
				catch (Exception e) {

				}
			}
		}
	}

	/*
	 * !reads standard calibrators from standard_calibrator folder and display them in the calibration and spectroscopy tabs
	 */
	public static boolean addNewStandardCalibrator(String newStandardCalibrator) {		
		newStandardCalibrator = newStandardCalibrator.replace(" ", "");
		newStandardCalibrator = newStandardCalibrator.replace("\t", "");

		if ((!newStandardCalibrator.contains("{")) || (!newStandardCalibrator.contains("}"))) {
			return false;
		}
		int calibratorNameLength = newStandardCalibrator.indexOf("{");
		int endOfString = newStandardCalibrator.indexOf("}");

		String calibratorName = newStandardCalibrator.substring(0, calibratorNameLength);

		if(!p2AppManagerUtils.isFilenameValid(calibratorName))
			return false;

		String calibratorValues = newStandardCalibrator.substring(calibratorNameLength + 1, endOfString);

		String[] wavenumbers = calibratorValues.split(",");

		for(String wavenumber : wavenumbers)
		{
			try{
				Double.parseDouble(wavenumber);
			}
			catch(Exception c){
				return false;
			}
		}

		try {
			BufferedWriter writer1 = new BufferedWriter(new FileWriter((p2Constants.getPath(p2Constants.STANDARD_CALIBRATORS_FOLDER_PATH) + File.separatorChar + calibratorName + p2Constants.STANDARD_CALIBRATORS_FILE_EXT)));

			for(int j = 0; j < wavenumbers.length; j++)
			{
				writer1.write(wavenumbers[j] + "\n");
			}
			writer1.close();
		} catch (IOException e) {
			e.printStackTrace();
		}

		return true;
	}

	public static void restoreSequence() {
		Object[] options = {p2Enumerations.RestoreOptionsEnum.OPTICAL_GAIN_SETTINGS.getStringVal(),
				p2Enumerations.RestoreOptionsEnum.CORRECTION_SETTINGS.getStringVal(),
				p2Enumerations.RestoreOptionsEnum.ALL.getStringVal()};

		String choice = (String)JOptionPane.showInputDialog(null, "Choose which settings to restore to default", "Restore Settings", JOptionPane.QUESTION_MESSAGE, 
				null, options, options[2]);

		if(choice == null || !(choice.length() > 0))
		{
			return;
		}

		UserInterface.checkDeviceStatusThreadStop = true;
		// Start RUN
		p2AppManagerStatus status = UserInterface.applicationManager.restoreDefaultSettings(choice);
		if (p2AppManagerStatus.NO_ERROR != status) {
			JOptionPane.showMessageDialog(null,
					"Restore to default failed to start: : " + status,
					"Restore Default Settings", JOptionPane.OK_OPTION);

			if (p2AppManagerStatus.DEVICE_BUSY_ERROR != status) {
				// resume checking the status of the device
				UserInterface.checkDeviceStatusThreadStop = false;

			}
		} else {
			VariableHelper.setMessage("Restoring to default started. Please wait...");
			UserInterface.boardReadyRoutine(false);
		}

	}
	public static void burnSequence(String [] opticalSettings) {
		Checkbox correction= new Checkbox("Include Correction");
		JList list = new JList(opticalSettings);
		JPanel panel = new JPanel();
		panel.add(new JScrollPane(list));
		panel.add(correction);
		//Object [] params ={list,correction}; 
		int n = JOptionPane.showConfirmDialog(
				null, panel, "Burn Settings", JOptionPane.OK_CANCEL_OPTION);

		String [] SettingstoBurn;
		if (n == JOptionPane.OK_OPTION)
		{


			int []indices= list.getSelectedIndices();
			SettingstoBurn= new String[indices.length];
			for (int i = 0; i < indices.length; i++) {
				SettingstoBurn[i] = list.getModel().getElementAt(indices[i]).toString();
			}

			if(indices.length == 0 && correction.getState() == false)
				return;

			String[] params = new String[SettingstoBurn.length + 1];
			System.arraycopy(SettingstoBurn, 0, params, 0, SettingstoBurn.length);
			params[params.length - 1] = Boolean.toString(correction.getState());
			
			UserInterface.checkDeviceStatusThreadStop = true;
			// Start RUN
			p2AppManagerStatus status = UserInterface.applicationManager.burnSpecificSettings(params);
			if (p2AppManagerStatus.NO_ERROR != status) {
				JOptionPane.showMessageDialog(null,
						"Burn Settings failed to start: : " + status,
						"Burn Settings", JOptionPane.OK_OPTION);

				if (p2AppManagerStatus.DEVICE_BUSY_ERROR != status) {
					// resume checking the status of the device
					UserInterface.checkDeviceStatusThreadStop = false;

				}
			} else {
				VariableHelper.setMessage("Burn Settings started. Please wait...");
				
				UserInterface.boardReadyRoutine(false);
			}
		}
	}
	/*
	 * !convert error codes into messages
	 */
	public static String convertErrorCodesToMessages(int errorCode) {
		switch(errorCode)
		{
		case 1:
			return "Error Code : " + errorCode + "\n NeoSpectra module is busy. \n Please wait until the current operation is done.";

		case 2:
			return "Error Code : " + errorCode + "\n SpectroMOST does not detect any connected NeoSpectra module.";

		case 3:
			return "Error Code : " + errorCode + "\n NeoSpectra module is not initialized. \n Please disconnect and reconnect your module.";

		case 4:
			return "Error Code : " + errorCode + "\n Unknown error. \n Please contact Si-Ware Systems.";

		case 7:
			return "Error Code : " + errorCode + "\n Error in loading configuration files. \n Please contact Si-Ware Systems.";

		case 8:
			return "Error Code : " + errorCode + "\n Error in configuration files' format. \n Please contact Si-Ware Systems.";

		case 11:
			return "Error Code : " + errorCode + "\n Invalid scan time. \n Please type a valid entry.";

		case 23:
			return "Error Code : " + errorCode + "\n Error in configuration files' format. \n Please contact Si-Ware Systems.";

		case 24:
			return "Error Code : " + errorCode + "\n Internal error in DSP. \n Please contact Si-Ware Systems.";

		case 25:
			return "Error Code : " + errorCode + "\n Internal error in DSP. \n Please contact Si-Ware Systems.";

		case 26:
			return "Error Code : " + errorCode + "\n Internal error in DSP. \n Please contact Si-Ware Systems.";

		case 27:
			return "Error Code : " + errorCode + "\n Internal error in DSP. \n Please contact Si-Ware Systems.";

		case 28:
			return "Error Code : " + errorCode + "\n Error updating configuration files.\n Please contact Si-Ware Systems.";    

		case 29:
			return "Error Code : " + errorCode + "\n Error in saving data of background measurement. \n Please retry.";

		case 30:
			return "Error Code : " + errorCode + "\n Internal error in DSP. \n Please contact Si-Ware Systems.";

		case 31:
			return "Error Code : " + errorCode + "\n Invalid run parameters. \n Please use valid entries.";

		case 32:
			return "Error Code : " + errorCode + "\n The scan time of the background is different than the scan time of sample measurement. \n Please take a new background measurement.";

		case 33:
			return "Error Code : " + errorCode + "\n No valid background measurement found. \n Please take a new background measurement.";

		case 34:
			return "Error Code : " + errorCode + "\n Error occurred during saving interferogram data. \n Please try saving in a different directory.";

		case 35:
			return "Error Code : " + errorCode + "\n Error occurred during saving PSD data.\n Please try saving in a different directory.";

		case 36:
			return "Error Code : " + errorCode + "\n Error occurred during saving spectrum data.\n Please try saving in a different directory.";

		case 37:
			return "Error Code : " + errorCode + "\n Error occurred during creating folder to save measurement data. \n Please try creating the folder in a different directory.";

		case 42:
			return "Error Code : " + errorCode + "\n Error occurred during initialization of NeoSpectra module. \n Please disconnect and reconnect your module.";

		case 43:
			return "Error Code : " + errorCode + "\n Error occurred during initialization of NeoSpectra module. \n Please disconnect and reconnect your module.";

		case 50:
			return "Error Code : " + errorCode + "\n Error occurred during streaming from NeoSpectra module. \n Please disconnect and reconnect your module.";

		case 51:
			return "Error Code : " + errorCode + "\n Error occurred during streaming from NeoSpectra module. \n Please disconnect and reconnect your module.";

		case 52:
			return "Error Code : " + errorCode + "\n Error occurred during result return. \n Please make a new measurement.";

		case 53:
			return "Error Code : " + errorCode + "\n Invalid action !!";

		case 54:
			return "Error Code : " + errorCode + "\n Invalid device is connected.";

		case 55:
			return "Error Code : " + errorCode + "\n Internal threading error occurred. \n Please make a new measurement. \n If the error persists, please contact Si-Ware Systems.";

		case 60:
			return "Error Code : " + errorCode + "\n Error occurred during the setup of actuation settings. \n Please make a new measurement. \n If the error persists, please contact Si-Ware Systems.";

		case 61:
			return "Error Code : " + errorCode + "\n Actuation setting is turned off. \n Please make a new measurement. \n If the error persists, please contact Si-Ware Systems.";

		case 62:
			return "Error Code : " + errorCode + "\n Internal error occurred during writing to ASIC chip registers. \n Please contact Si-Ware Systems." ;

		case 110:
			return "Error Code : " + errorCode + "\n Internal error occurred while running adaptive gain. \n Please contact Si-Ware Systems." ;

		case 111:
			return "Error Code : " + errorCode + "\n Internal error occurred during reading registers from ASIC chip. \n Please contact Si-Ware Systems." ;

		case 112:
			return "Error Code : " + errorCode + " Failed to start. \nCorrection profile doesn't exist. \nPlease contact Si-Ware Systems.";

		case 113:
			return "Error Code : " + errorCode + "Failed to write optical gain settings. \n Please try again. \n If the error persists, please contact Si-Ware Systems.";

		case 114:
			return "Error Code : " + errorCode + "Failed to create optical gain settings file. \n Please try again. \n If the error persists, please contact Si-Ware Systems.";

		case 115:
			return "Error Code : " + errorCode + "Failed to load standard calibrator file. \n Please try again. \n If the error persists, please contact Si-Ware Systems.";

		case 116:
			return "Error Code : " + errorCode + "\n Internal error occurred while running wavelength calibration. \n Please contact Si-Ware Systems.";

		case 117:
			return "Error Code : " + errorCode + "SpectroMOST didn't find any data to update. \n Please take a measurement first."; 

		case 118:
			return "Error Code : " + errorCode + "Internal error while updating results after changing FFT settings. \n Please contact Si-Ware Systems.";

		case 119:
			return "Error Code : " + errorCode + "\nSpectroMOST didn't find the selected Optical gain option. \nPlease contact Si-Ware Systems.";

		default:
			return "";
		}
	}

	/*
	 * !convert error codes into messages
	 */
	public static String convertErrorCodesToMessages(p2AppManagerStatus errorStatus) {
		return convertErrorCodesToMessages(errorStatus.getNumVal());
	}

}

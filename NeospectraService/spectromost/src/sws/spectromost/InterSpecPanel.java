package sws.spectromost;

import java.awt.event.ActionEvent;

import javax.imageio.ImageIO;

import java.awt.Dimension;
import java.awt.Image;

import javax.swing.ButtonGroup;
import javax.swing.ImageIcon;
import javax.swing.JCheckBox;
import javax.swing.JComboBox;
import javax.swing.JFileChooser;
import javax.swing.JFormattedTextField;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.SwingConstants;

import java.awt.event.ActionListener;

import javax.swing.JButton;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
import org.jfree.chart.ChartPanel;

import net.miginfocom.swing.MigLayout;
import sws.spectromost.jfreechart.XYLineChart;
import sws.p2AppManager.utils.p2AppManagerException;
import sws.p2AppManager.utils.p2AppManagerNotification;
import sws.p2AppManager.utils.p2AppManagerUtils;
import sws.p2AppManager.utils.p2Constants;
import sws.p2AppManager.utils.p2Enumerations.p2AppManagerStatus;

import javax.swing.JPanel;
import javax.swing.event.PopupMenuEvent;
import javax.swing.event.PopupMenuListener;
import javax.swing.filechooser.FileNameExtensionFilter;
import javax.swing.JSeparator;

import java.awt.Font;
import java.awt.Color;

import javax.swing.DefaultComboBoxModel;
import javax.swing.border.LineBorder;

import java.awt.Label;

import javax.swing.JRadioButton;

import org.apache.log4j.Logger;

//@SuppressWarnings("serial")
public class InterSpecPanel extends JPanel {

	private static Logger logger = Logger.getLogger(InterSpecPanel.class);
	/*
	 * ! Interferogram & Spectrum tab
	 */
	public static final String INTERFERO_PATH_TEMPLATE = p2Constants.getPath(UserInterface.GRAPH_FILES_FOLDER_PATH) + File.separatorChar + "Measurement_{0}.Interferogram";
	public static final String INTERFERO_FILE_X_AXIS = "x_Axis:Optical Path Difference (\u00B5m)";
	public static final String INTERFERO_FILE_Y_AXIS = "y_Axis:Current (nA)";

	public static final String PSD_PATH_TEMPLATE = p2Constants.getPath(UserInterface.GRAPH_FILES_FOLDER_PATH) + File.separatorChar + "Measurement_{0}.InterPSD";

	public static final String PSD_FILE_X_AXIS_CM = "x_Axis:Wavenumber (cm-1)";
	public static final String PSD_FILE_X_AXIS_NM = "x_Axis:Wavelength (nm)";

	public static final String PSD_FILE_Y_AXIS_N = "y_Axis:Normalized PSD (a.u.)";
	public static final String PSD_FILE_Y_AXIS = "y_Axis:PSD (a.u.)";

	// boolean to check whether a capture button was pressed
	public static boolean capture_Displayed_InterSpec = false;

	// boolean to guard the clearing plots method
	private static boolean clearingGraphsInProgress = false;

	/*
	 * ! Auto Save Path for Interferogram & spectroscopy tab
	 */
	private String AutoSavePath_Inter_Spec = "";

	/*
	 * ! The last selected resolution
	 */
	public static String lastResolutionSelected = "";

	/*
	 * ! The last selected opticalGainSettings
	 */
	public static String lastOpticalSettingsSelected = "";

	/*
	 * !GUI fields
	 */

	public static JRadioButton rdbtn_nm_Inter_Spec = new JRadioButton("nm");
	public static JRadioButton rdbtn_cm_Inter_Spec = new JRadioButton("cm\u207B\u00B9");

	static Label lbl_ModuleID_Inter_Spec;

	static XYLineChart interferogramChart = null;
	static XYLineChart spectrumChart_NM = null;
	static XYLineChart spectrumChart_CM = null;

	static ChartPanel interferogramChartPanel = null;
	static ChartPanel spectrumChartPanel = null;

	public static final JCheckBox chb_AutoSave_Inter_Spec = new JCheckBox("Auto-save");
	static JButton btn_Run_Inter_Spec;
	static JButton btn_Capture_Interfero;
	static JButton btn_ClearGraphs_Inter_Spec;
	static JButton btn_LoadGraphs_Inter_Spec;
	static JButton btn_SaveGraphs_Inter_Spec;
	static JButton btn_Stop_Inter_Spec;
	static JButton btn_GainAdjustmentPanel_Inter_Spec;
	static JButton btn_WavelengthWavenumberCalibration_Inter_Spec;
	static JButton btn_WriteSettings_Inter_Spec;
	static JButton btn_FFT_UpdateResults_Inter_Spec;
	static JButton btn_RestoreDefault_Inter_Spec;
	static JButton btn_DeleteOpticalOption_Inter_Spec;
	static JComboBox<String> cmb_Optical_Settings_Inter_Spec;
	static JFormattedTextField txt_RunTime_Inter_Spec;
	static JComboBox<String> cmb_Resolution_Inter_Spec;
	static JComboBox<String> cmb_Apodization_Inter_Spec;
	static JComboBox<String> cmb_ZeroPadding_Inter_Spec;

	private int measurementCount_Interferogram = 0;
	private int measurementCount_Spectrum = 0;

	/*
	 * ! Interferogram's axis default values
	 */
	public static final double INTER_X_MIN = -254;
	public static final double INTER_X_MAX = 254;
	public static final double INTER_Y_MIN = 0;
	public static final double INTER_Y_MAX = 1.2;

	/*
	 * ! PSD's axis default values
	 */
	public static final double PSD_X_NM_MIN = 1100;
	public static final double PSD_X_NM_MAX = 1722;
	public static final double PSD_X_CM_MIN = 5882;
	public static final double PSD_X_CM_MAX = 9090;
	public static final double PSD_Y_MIN = 0;
	public static final double PSD_Y_MAX = 1.2;
	private Label lbl_SpectrometerInfo_Inter_Spec;

	public static JRadioButton rdbtn_SingleRun_Inter_Spec;
	public static JRadioButton rdbtn_ContRun_Inter_Spec;
	private Label lblDataDisplay_Inter_Spec;
	private Label lblXaxis_Inter_Spec;


	public InterSpecPanel() {
		super();
		this.initialize();
	}

	public void initialize() {

		this.setFont(new Font("Dialog", Font.PLAIN, 12));
		this.setBackground(new Color(176, 196, 222));
		this.setLayout(new MigLayout("", "[90.00:90.00:90.00][45.00:45.00:45.00][45.00:45.00:45.00][30.00:30.00:30.00][30.00:30.00:30.00][30.00:30.00:30.00][90.00:90.00:90.00][90.00:90.00:90.00][90.00:90.00:90.00][90.00:90.00:90.00][grow,fill][][][][][grow,fill]", "[][][][][][][][][][][][][][][][][][20:n][20:n][][][][][][][][][][][][grow,fill]"));

		lbl_SpectrometerInfo_Inter_Spec = new Label("NeoSpectra module Info");
		lbl_SpectrometerInfo_Inter_Spec.setFont(new Font("Dialog", Font.BOLD, 12));
		add(lbl_SpectrometerInfo_Inter_Spec, "cell 0 0 6 1");

		Label lbl_SpectrometerID_Inter_Spec = new Label("Module ID");
		lbl_SpectrometerID_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		this.add(lbl_SpectrometerID_Inter_Spec, "cell 0 1 2 1,growx");

		lbl_ModuleID_Inter_Spec = new Label(UserInterface.moduleID);
		lbl_ModuleID_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		this.add(lbl_ModuleID_Inter_Spec, "cell 2 1 2 1,alignx right");

		JSeparator separator1_Inter_Spec = new JSeparator();
		add(separator1_Inter_Spec, "cell 0 2 6 1,growx");

		Label lbl_MeasurementParams_Inter_Spec = new Label("Measurement Parameters");
		lbl_MeasurementParams_Inter_Spec.setFont(new Font("Dialog", Font.BOLD, 12));
		this.add(lbl_MeasurementParams_Inter_Spec, "cell 0 3 6 1,growx");

		Label lbl_RunTime_Inter_Spec = new Label("Scan Time");
		lbl_RunTime_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		this.add(lbl_RunTime_Inter_Spec, "cell 0 4,growx");

		txt_RunTime_Inter_Spec = new JFormattedTextField();
		txt_RunTime_Inter_Spec.setEditable(true);
		txt_RunTime_Inter_Spec.setFont(new Font("Dialog", Font.BOLD, 10));
		txt_RunTime_Inter_Spec.setText("2");
		txt_RunTime_Inter_Spec.setMinimumSize(new Dimension(p2Constants.MAX_WIDTH_OF_FIELD, txt_RunTime_Inter_Spec.getPreferredSize().height));
		txt_RunTime_Inter_Spec.setMaximumSize(new Dimension(p2Constants.MAX_WIDTH_OF_FIELD, txt_RunTime_Inter_Spec.getPreferredSize().height));
		txt_RunTime_Inter_Spec.setPreferredSize(new Dimension(p2Constants.MAX_WIDTH_OF_FIELD, txt_RunTime_Inter_Spec.getPreferredSize().height));
		this.add(txt_RunTime_Inter_Spec, "cell 2 4 3 1,alignx left");

		Label lbl_Sec_Inter_Spec = new Label("s");
		lbl_Sec_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		this.add(lbl_Sec_Inter_Spec, "cell 5 4,growx");

		Label lbl_Resolution_Inter_Spec = new Label("Resolution");
		lbl_Resolution_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		add(lbl_Resolution_Inter_Spec, "cell 0 5,growx");

		cmb_Resolution_Inter_Spec = new JComboBox<String>();
		cmb_Resolution_Inter_Spec.setEnabled(false);
		cmb_Resolution_Inter_Spec.setFont(new Font("Dialog", Font.BOLD, 10));
		cmb_Resolution_Inter_Spec.setMaximumSize(new Dimension(
				p2Constants.MAX_WIDTH_OF_FIELD, cmb_Resolution_Inter_Spec
				.getPreferredSize().height));

		cmb_Resolution_Inter_Spec.addPopupMenuListener(new PopupMenuListener() {
			public void popupMenuCanceled(PopupMenuEvent e) {
			}

			public void popupMenuWillBecomeInvisible(PopupMenuEvent e) {
				SpectroscopyPanel.cmb_Resolution_Spec.setSelectedIndex(cmb_Resolution_Inter_Spec.getSelectedIndex());
			}

			public void popupMenuWillBecomeVisible(PopupMenuEvent e) {
				UserInterface.displayResolutions();
			}
		});

		add(cmb_Resolution_Inter_Spec, "cell 2 5 4 1,growx");

		/* Adaptive gain edit*/

		Label lbl_Optical_Gain = new Label("Optical Gain Settings");
		lbl_Optical_Gain.setFont(new Font("Dialog", Font.PLAIN, 10));
		add(lbl_Optical_Gain, "cell 0 6,growx");

		cmb_Optical_Settings_Inter_Spec = new JComboBox<String>();
		cmb_Optical_Settings_Inter_Spec.setEditable(false);
		cmb_Optical_Settings_Inter_Spec.setFont(new Font("Dialog", Font.BOLD, 10));
		cmb_Optical_Settings_Inter_Spec.setMaximumSize(new Dimension(
				p2Constants.MAX_WIDTH_OF_FIELD, cmb_Optical_Settings_Inter_Spec.getPreferredSize().height));
		this.add(cmb_Optical_Settings_Inter_Spec, "cell 2 6 4 1,growx");

		cmb_Optical_Settings_Inter_Spec.addPopupMenuListener(new PopupMenuListener() {
			public void popupMenuCanceled(PopupMenuEvent e) {
			}

			public void popupMenuWillBecomeInvisible(PopupMenuEvent e) {
			}

			public void popupMenuWillBecomeVisible(PopupMenuEvent e) {
				UserInterface.displayInterSpecOpticalSettings();
			}
		});

		btn_DeleteOpticalOption_Inter_Spec = new JButton("");
		btn_DeleteOpticalOption_Inter_Spec.setEnabled(false);
		btn_DeleteOpticalOption_Inter_Spec.setToolTipText("Delete the selected optical gain setting");
		btn_DeleteOpticalOption_Inter_Spec.setMaximumSize(new Dimension(30, cmb_Optical_Settings_Inter_Spec.getPreferredSize().height));
		btn_DeleteOpticalOption_Inter_Spec.setMinimumSize(new Dimension(30, cmb_Optical_Settings_Inter_Spec.getPreferredSize().height));
		btn_DeleteOpticalOption_Inter_Spec.setPreferredSize(new Dimension(30, cmb_Optical_Settings_Inter_Spec.getPreferredSize().height));
		btn_DeleteOpticalOption_Inter_Spec.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {

				if(JOptionPane.showConfirmDialog(null, "Are you sure you want to delete " + cmb_Optical_Settings_Inter_Spec.getSelectedItem().toString() + " ?", 
						"Delete optical gain", JOptionPane.YES_NO_OPTION) == JOptionPane.NO_OPTION)
				{
					return;
				}

				UserInterface.deleteOpticalSetting(p2Constants.SpecPrefix + cmb_Optical_Settings_Inter_Spec.getSelectedItem().toString());
				UserInterface.deleteOpticalSetting(p2Constants.InterSpecPrefix + cmb_Optical_Settings_Inter_Spec.getSelectedItem().toString());
				UserInterface.displaySpecOpticalSettings();
				UserInterface.displayInterSpecOpticalSettings();
			}
		});
		add(btn_DeleteOpticalOption_Inter_Spec, "cell 5 6,grow");

		/* End of Adaptive gain edit*/

		Label lbl_RunMode_Inter_Spec = new Label("Run Mode");
		lbl_RunMode_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		add(lbl_RunMode_Inter_Spec, "cell 0 7,growx");

		ButtonGroup bgRunMode_Inter_Spec = new ButtonGroup();
		rdbtn_SingleRun_Inter_Spec = new JRadioButton("Single");
		rdbtn_SingleRun_Inter_Spec.setEnabled(false);
		rdbtn_SingleRun_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		rdbtn_SingleRun_Inter_Spec.setSelected(true);
		rdbtn_SingleRun_Inter_Spec.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent arg0) {
				btn_Capture_Interfero.setEnabled(false);
			}
		});
		add(rdbtn_SingleRun_Inter_Spec, "cell 1 7 2 1,growx");
		bgRunMode_Inter_Spec.add(rdbtn_SingleRun_Inter_Spec);


		btn_Run_Inter_Spec = new JButton("");
		btn_Run_Inter_Spec.setEnabled(false);
		btn_Run_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		btn_Run_Inter_Spec.setText("Run");
		btn_Run_Inter_Spec.setVerticalTextPosition(SwingConstants.BOTTOM);
		btn_Run_Inter_Spec.setHorizontalTextPosition(SwingConstants.CENTER);
		btn_Run_Inter_Spec.setToolTipText("Run");

		btn_Run_Inter_Spec.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				RunSequence();
				try{logger.info("Run_Inter_Spec Finished (With PowerUp) - Scan Time = " + String.valueOf(Double.parseDouble(txt_RunTime_Inter_Spec.getText()) * 1000));}catch(Exception d){}
			}
		});

		rdbtn_ContRun_Inter_Spec = new JRadioButton("Cont.");
		rdbtn_ContRun_Inter_Spec.setEnabled(false);
		rdbtn_ContRun_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		rdbtn_ContRun_Inter_Spec.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent arg0) {
				btn_Capture_Interfero.setEnabled(true);
			}
		});
		add(rdbtn_ContRun_Inter_Spec, "cell 3 7 3 1,growx");
		bgRunMode_Inter_Spec.add(rdbtn_ContRun_Inter_Spec);

		this.add(btn_Run_Inter_Spec, "cell 1 8 2 1,growx");

		btn_Stop_Inter_Spec = new JButton("Stop");
		btn_Stop_Inter_Spec.setEnabled(false);
		btn_Stop_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		btn_Stop_Inter_Spec.setText("Stop");
		btn_Stop_Inter_Spec.setVerticalTextPosition(SwingConstants.BOTTOM);
		btn_Stop_Inter_Spec.setHorizontalTextPosition(SwingConstants.CENTER);
		btn_Stop_Inter_Spec.setToolTipText("Stop");

		btn_Stop_Inter_Spec.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent arg0) {
				UserInterface.stopContinuousRun = true;
				UserInterface.isContinuousRun = false;

				VariableHelper.setMessage("Stopping NeoSpectra module. Please wait...");
			}
		});
		this.add(btn_Stop_Inter_Spec, "cell 3 8 3 1,growx");


		JSeparator separator2_Inter_Spec = new JSeparator();
		this.add(separator2_Inter_Spec, "cell 0 9 6 1,growx");

		btn_SaveGraphs_Inter_Spec = new JButton("");
		btn_SaveGraphs_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		btn_SaveGraphs_Inter_Spec.setText("Save");
		btn_SaveGraphs_Inter_Spec.setVerticalTextPosition(SwingConstants.BOTTOM);
		btn_SaveGraphs_Inter_Spec.setHorizontalTextPosition(SwingConstants.CENTER);
		btn_SaveGraphs_Inter_Spec.setToolTipText("Save Plots");
		btn_SaveGraphs_Inter_Spec.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {

				UserInterface.stopEnablingButtons = true;
				UserInterface.boardReadyRoutine(false);
				btn_SaveGraphs_Inter_Spec.setEnabled(false);
				btn_LoadGraphs_Inter_Spec.setEnabled(false);
				btn_ClearGraphs_Inter_Spec.setEnabled(false);

				String [] graphs = spectrumChart_NM.getSeriesKeys();
				int graph_count = graphs.length;
				for(String graph : graphs)
				{
					double[][] data_NM = spectrumChart_NM.getGraphData(graph);
					double[][] data_CM = spectrumChart_CM.getGraphData(graph);

					if(rdbtn_nm_Inter_Spec.isSelected())
					{
						UserInterface.writeGraphFile(data_NM[0], data_NM[1], 
								p2AppManagerUtils.formatString(p2Constants.getPath(PSD_PATH_TEMPLATE), graph_count), PSD_FILE_X_AXIS_NM + "\t" + PSD_FILE_Y_AXIS); 	
					}
					else
					{
						UserInterface.writeGraphFile(data_CM[0], data_CM[1], 
								p2AppManagerUtils.formatString(p2Constants.getPath(PSD_PATH_TEMPLATE), graph_count), PSD_FILE_X_AXIS_CM + "\t" + PSD_FILE_Y_AXIS); 
					}
					graph_count--;
				}

				graphs = interferogramChart.getSeriesKeys();
				graph_count = graphs.length;
				for(String graph : graphs)
				{
					double[][] data = interferogramChart.getGraphData(graph);


					UserInterface.writeGraphFile(data[0], data[1], 
							p2AppManagerUtils.formatString(p2Constants.getPath(INTERFERO_PATH_TEMPLATE), graph_count), INTERFERO_FILE_X_AXIS + "\t" + INTERFERO_FILE_Y_AXIS); 

					graph_count--;
				}

				new SaveGraphsPanel(p2Constants.InterSpecPrefix);
				SaveGraphsPanel.frmSaveGraphs.setVisible(true);
			}
		});

		this.add(btn_SaveGraphs_Inter_Spec, "cell 0 11,growx");

		btn_LoadGraphs_Inter_Spec = new JButton("");
		btn_LoadGraphs_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		btn_LoadGraphs_Inter_Spec.setText("Load");
		btn_LoadGraphs_Inter_Spec.setVerticalTextPosition(SwingConstants.BOTTOM);
		btn_LoadGraphs_Inter_Spec.setHorizontalTextPosition(SwingConstants.CENTER);
		btn_LoadGraphs_Inter_Spec.setToolTipText("Load Plot");

		btn_LoadGraphs_Inter_Spec.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {

				// remove any previous uncaptured plots
				if ((!capture_Displayed_InterSpec) && (measurementCount_Interferogram != 0)) {
					measurementCount_Interferogram--;
					measurementCount_Spectrum--;
				}
				capture_Displayed_InterSpec = false;

				JFileChooser openInterFile;
				if(UserInterface.defaultDirectorySaveLoad.equals("") || !new File(UserInterface.defaultDirectorySaveLoad).exists())
				{
					openInterFile = new JFileChooser();
				}
				else
				{
					openInterFile = new JFileChooser(UserInterface.defaultDirectorySaveLoad);
				}
				openInterFile.setMultiSelectionEnabled(true);
				openInterFile.setFileFilter(new FileNameExtensionFilter("Interferogram or PSD plots (*.Interferogram , *.InterPSD)", "Interferogram", "InterPSD"));
				if (openInterFile.showOpenDialog(null) == JFileChooser.APPROVE_OPTION) {
					for(File loadedFile: openInterFile.getSelectedFiles())
					{
						LoadCharts(loadedFile);
					}


					UserInterface.defaultDirectorySaveLoad = openInterFile.getSelectedFile().getParentFile().getAbsolutePath();
				}
			}
		});
		this.add(btn_LoadGraphs_Inter_Spec, "cell 1 11 2 1,growx");

		btn_Capture_Interfero = new JButton("Capture");
		btn_Capture_Interfero.setEnabled(false);
		btn_Capture_Interfero.setToolTipText("Capture Plot");
		btn_Capture_Interfero.setFont(new Font("Dialog", Font.PLAIN, 10));
		btn_Capture_Interfero.setVerticalTextPosition(SwingConstants.BOTTOM);
		btn_Capture_Interfero.setHorizontalTextPosition(SwingConstants.CENTER);
		btn_Capture_Interfero.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				if (!capture_Displayed_InterSpec) {
					capture_Displayed_InterSpec = true;
					if ((!AutoSavePath_Inter_Spec.equals("")) && (capture_Displayed_InterSpec)) {
						try {
							p2AppManagerUtils.createDir(p2Constants.getPath(UserInterface.GRAPH_FILES_FOLDER_PATH));
							File folder = new File(p2Constants.getPath(UserInterface.GRAPH_FILES_FOLDER_PATH));
							File[] listOfFiles = folder.listFiles();
							if (listOfFiles.length != 0) {

								for (int i = 0; i < listOfFiles.length; i++) {
									if (listOfFiles[i].isFile()) {
										if (listOfFiles[i].getAbsolutePath().endsWith(".Interferogram") || listOfFiles[i].getAbsolutePath().endsWith(".InterPSD")) {
											try {
												p2AppManagerUtils.createDir(AutoSavePath_Inter_Spec);
												Files.copy(listOfFiles[i].toPath(), (new File(AutoSavePath_Inter_Spec + File.separatorChar + listOfFiles[i].getName())).toPath(), StandardCopyOption.REPLACE_EXISTING);

											} catch (Exception ex) {
												JOptionPane.showMessageDialog(
														null,
														"Failed to save files to the selected destination: "
																+ ex.getMessage(),
																"Saving files",
																JOptionPane.OK_OPTION);
											}
										}
									}
								}
							}

						} catch (Exception ex) {
						}
					}
				}
			}
		});

		this.add(btn_Capture_Interfero, "cell 1 12 2 1,growx");

		JSeparator separator3_Inter_Spec = new JSeparator();
		this.add(separator3_Inter_Spec, "cell 0 13 6 1,growx");

		lblDataDisplay_Inter_Spec = new Label("Data Display");
		lblDataDisplay_Inter_Spec.setFont(new Font("Dialog", Font.BOLD, 12));
		add(lblDataDisplay_Inter_Spec, "cell 0 16,growx");
		rdbtn_nm_Inter_Spec.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {

				remove(spectrumChartPanel);
				spectrumChartPanel = null;

				spectrumChartPanel = spectrumChart_NM.getChartPanel();
				spectrumChartPanel.setBorder(new LineBorder(new Color(0, 0, 0), 1, true));

				//Remove legend of the fake data plotted to chart if no valid data was plotted
				if(measurementCount_Spectrum == 0)
				{
					spectrumChartPanel.getChart().removeLegend();
				}

				spectrumChartPanel.repaint();

//				spectrumChartPanel.setPreferredSize(new Dimension( (int) spectrumChartPanel.getPreferredSize().getWidth(), (int) UserInterface.screenSize.getHeight()));

				add(spectrumChartPanel, "cell 11 0 5 20, grow");

				revalidate();
				repaint();
			}
		});

		ButtonGroup bgDataDisplay_X_Axis = new ButtonGroup();

		rdbtn_nm_Inter_Spec.setSelected(true);
		rdbtn_nm_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		add(rdbtn_nm_Inter_Spec, "flowx,cell 1 17 2 1,aligny top");
		bgDataDisplay_X_Axis.add(rdbtn_nm_Inter_Spec);
		rdbtn_cm_Inter_Spec.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {

				remove(spectrumChartPanel);
				spectrumChartPanel = null;

				spectrumChartPanel = spectrumChart_CM.getChartPanel();
				spectrumChartPanel.setBorder(new LineBorder(new Color(0, 0, 0), 1, true));

				//Remove legend of the fake data plotted to chart if no valid data was plotted
				if(measurementCount_Spectrum == 0)
				{
					spectrumChartPanel.getChart().removeLegend();
				}

				spectrumChartPanel.repaint();

//				spectrumChartPanel.setPreferredSize(new Dimension( (int) spectrumChartPanel.getPreferredSize().getWidth(), (int) UserInterface.screenSize.getHeight()));

				add(spectrumChartPanel, "cell 11 0 5 20, grow");

				revalidate();
				repaint();
			}
		});

		rdbtn_cm_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		add(rdbtn_cm_Inter_Spec, "cell 3 17 3 1,aligny top");
		bgDataDisplay_X_Axis.add(rdbtn_cm_Inter_Spec);

		lblXaxis_Inter_Spec = new Label("X-Axis:");
		lblXaxis_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		add(lblXaxis_Inter_Spec, "cell 0 17,growx,aligny top");


		JSeparator separator4_Inter_Spec = new JSeparator();
		this.add(separator4_Inter_Spec, "cell 0 19 6 1,growx");

		Label lbl_advancedSettings_Inter_Spec = new Label("Advanced Settings");
		lbl_advancedSettings_Inter_Spec.setFont(new Font("Dialog", Font.BOLD, 12));
		this.add(lbl_advancedSettings_Inter_Spec, "cell 6 22 2 1,growx");

		Label lbl_FFT_Settings_Inter_Spec = new Label("FFT Settings");
		lbl_FFT_Settings_Inter_Spec.setFont(new Font("Dialog", Font.BOLD, 12));
		this.add(lbl_FFT_Settings_Inter_Spec, "cell 12 22,growx");

		btn_GainAdjustmentPanel_Inter_Spec = new JButton("");
		btn_GainAdjustmentPanel_Inter_Spec.setEnabled(false);
		btn_GainAdjustmentPanel_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		btn_GainAdjustmentPanel_Inter_Spec.setText("<html><center>Add <br />Optical Gain Settings</center></html>");
		btn_GainAdjustmentPanel_Inter_Spec.setVerticalTextPosition(SwingConstants.CENTER);
		btn_GainAdjustmentPanel_Inter_Spec.setHorizontalTextPosition(SwingConstants.CENTER);
		btn_GainAdjustmentPanel_Inter_Spec.setToolTipText("Add new optical gain settings");

		btn_GainAdjustmentPanel_Inter_Spec.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if(null != cmb_Resolution_Inter_Spec.getSelectedItem().toString() && "" != cmb_Resolution_Inter_Spec.getSelectedItem().toString())
				{
					UserInterface.stopEnablingButtons = true;
					UserInterface.boardReadyRoutine(false);
					new SpecGainPanel(cmb_Resolution_Inter_Spec.getSelectedItem().toString(),
							Integer.toString(cmb_Apodization_Inter_Spec.getSelectedIndex()),
							cmb_ZeroPadding_Inter_Spec.getSelectedItem().toString());
					SpecGainPanel.frmSpecGain.setVisible(true);

				}else {
					JOptionPane.showMessageDialog(null,
							"Failed to start. Please select a resolution!",
							"Gain Adjustment", JOptionPane.OK_OPTION);
				}

			}
		});
		this.add(btn_GainAdjustmentPanel_Inter_Spec, "cell 6 23 2 2,grow");

		btn_WavelengthWavenumberCalibration_Inter_Spec = new JButton("");
		btn_WavelengthWavenumberCalibration_Inter_Spec.setEnabled(false);
		btn_WavelengthWavenumberCalibration_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		btn_WavelengthWavenumberCalibration_Inter_Spec.setText("<html><center>Wavelength &<br />Wavenumber<br />Correction</center></html>");
		btn_WavelengthWavenumberCalibration_Inter_Spec.setVerticalTextPosition(SwingConstants.CENTER);
		btn_WavelengthWavenumberCalibration_Inter_Spec.setHorizontalTextPosition(SwingConstants.CENTER);
		btn_WavelengthWavenumberCalibration_Inter_Spec.setToolTipText("Wavelength & Wavenumber Correction");

		btn_WavelengthWavenumberCalibration_Inter_Spec.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				UserInterface.stopEnablingButtons = true;
				UserInterface.boardReadyRoutine(false);
				try{
					new WL_WN_CalibrationPanel(
							String.valueOf(Double.parseDouble(txt_RunTime_Inter_Spec.getText()) * 1000),
							cmb_Resolution_Inter_Spec.getSelectedItem().toString(),
							cmb_Optical_Settings_Inter_Spec.getSelectedItem().toString(),
							Integer.toString(cmb_Apodization_Inter_Spec.getSelectedIndex()),
							cmb_ZeroPadding_Inter_Spec.getSelectedItem().toString(),
							p2Constants.InterSpecPrefix);
					WL_WN_CalibrationPanel.frmWL_Calib.setVisible(true);
				}
				catch (Exception e)
				{
					UserInterface.stopEnablingButtons = false;
					UserInterface.boardReadyRoutine(true);
					JOptionPane.showMessageDialog(null,
							"Failed to start. \n Please make sure that entries in measurement parameters are valid.",
							"Wavelength & Wavenumber Correction", JOptionPane.OK_OPTION);
				}

			}
		});
		this.add(btn_WavelengthWavenumberCalibration_Inter_Spec, "cell 8 23 2 2,grow");

		Label lbl_Apodization_Inter_Spec = new Label("Apodization");
		lbl_Apodization_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		add(lbl_Apodization_Inter_Spec, "cell 12 23,growx");

		JLabel lbl_logo_Inter_Spec = new JLabel("");
		lbl_logo_Inter_Spec.setFont(new Font("Dialog", Font.BOLD, 10));
		lbl_logo_Inter_Spec.setForeground(Color.WHITE);
		lbl_logo_Inter_Spec.setBackground(Color.WHITE);
		this.add(lbl_logo_Inter_Spec, "cell 0 21 6 5,alignx left");

		interferogramChart = new XYLineChart("Interferogram", "", "Optical Path Difference (\u00B5m)", "Current (nA)", new double[][] { new double[] { 0 }, new double[] { 0 } }, INTER_X_MIN, INTER_X_MAX, INTER_Y_MIN, INTER_Y_MAX);

		// Plot fake data to let the panel appeared
		spectrumChart_NM = new XYLineChart("PSD", "", "Wavelength (nm)", "PSD (a.u.)", new double[][] { new double[] { 0 }, new double[] { 0 } }, PSD_X_NM_MIN, PSD_X_NM_MAX, PSD_Y_MIN, PSD_Y_MAX);
		spectrumChart_CM = new XYLineChart("PSD", "", "Wavenumber (cm -\u00B9)", "PSD (a.u.)", new double[][] { new double[] { 0 }, new double[] { 0 } }, PSD_X_CM_MIN, PSD_X_CM_MAX, PSD_Y_MIN, PSD_Y_MAX);

		interferogramChartPanel = interferogramChart.getChartPanel();
		spectrumChartPanel = spectrumChart_NM.getChartPanel();

		interferogramChartPanel.setBorder(new LineBorder(new Color(0, 0, 0), 1, true));
		spectrumChartPanel.setBorder(new LineBorder(new Color(0, 0, 0), 1, true));

		//Remove legend of the fake data plotted to chart
		interferogramChartPanel.getChart().removeLegend();
		spectrumChartPanel.getChart().removeLegend();

//		interferogramChartPanel.setPreferredSize(new Dimension( (int) interferogramChartPanel.getPreferredSize().getWidth(), (int) UserInterface.screenSize.getHeight()));
//		spectrumChartPanel.setPreferredSize(new Dimension( (int) spectrumChartPanel.getPreferredSize().getWidth(), (int) UserInterface.screenSize.getHeight()));

		this.add(interferogramChartPanel, "cell 6 0 5 20, grow");
		this.add(spectrumChartPanel, "cell 11 0 5 20, grow");

		Label lbl_Graphs_Inter_Spec = new Label("Plots");
		lbl_Graphs_Inter_Spec.setFont(new Font("Dialog", Font.BOLD, 12));
		this.add(lbl_Graphs_Inter_Spec, "cell 0 10,growx");

		btn_ClearGraphs_Inter_Spec = new JButton("");
		btn_ClearGraphs_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		btn_ClearGraphs_Inter_Spec.setText("Clear");
		btn_ClearGraphs_Inter_Spec.setVerticalTextPosition(SwingConstants.BOTTOM);
		btn_ClearGraphs_Inter_Spec.setHorizontalTextPosition(SwingConstants.CENTER);
		btn_ClearGraphs_Inter_Spec.setToolTipText("Clear Plots");

		btn_ClearGraphs_Inter_Spec.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {

				clearingGraphsInProgress = true;

				p2AppManagerUtils.createDir(p2Constants.getPath(UserInterface.GRAPH_FILES_FOLDER_PATH));
				File folder = new File(p2Constants.getPath(UserInterface.GRAPH_FILES_FOLDER_PATH));
				File[] listOfFiles = folder.listFiles();
				for (File file : listOfFiles) {
					if (file.getAbsolutePath().endsWith(".Interferogram") || file.getAbsolutePath().endsWith(".InterPSD")) {
						file.delete();
					}
				}

				// Plot fake data to let the panel appeared
				interferogramChart = new XYLineChart("Interferogram", "", "Optical Path Difference (\u00B5m)", "Current (nA)", new double[][] { new double[] { 0 }, new double[] { 0 } }, INTER_X_MIN, INTER_X_MAX, INTER_Y_MIN, INTER_Y_MAX);
				spectrumChart_NM = new XYLineChart("PSD", "", "Wavelength (nm)", "PSD (a.u.)", new double[][] { new double[] { 0 }, new double[] { 0 } }, PSD_X_NM_MIN, PSD_X_NM_MAX, PSD_Y_MIN, PSD_Y_MAX);
				spectrumChart_CM = new XYLineChart("PSD", "", "Wavenumber (cm -\u00B9)", "PSD (a.u.)", new double[][] { new double[] { 0 }, new double[] { 0 } }, PSD_X_CM_MIN, PSD_X_CM_MAX, PSD_Y_MIN, PSD_Y_MAX);

				remove(interferogramChartPanel);
				remove(spectrumChartPanel);

				interferogramChartPanel = null;
				spectrumChartPanel = null;

				interferogramChartPanel = interferogramChart.getChartPanel();
				spectrumChartPanel = spectrumChart_NM.getChartPanel();
				rdbtn_nm_Inter_Spec.setSelected(true);

				interferogramChartPanel.setBorder(new LineBorder(new Color(0, 0, 0), 1, true));
				spectrumChartPanel.setBorder(new LineBorder(new Color(0, 0, 0), 1, true));

				//Remove legend of the fake data plotted to chart
				interferogramChartPanel.getChart().removeLegend();
				spectrumChartPanel.getChart().removeLegend();

				interferogramChartPanel.repaint();
				spectrumChartPanel.repaint();

//				interferogramChartPanel.setPreferredSize(new Dimension( (int) interferogramChartPanel.getPreferredSize().getWidth(), (int) UserInterface.screenSize.getHeight()));
//				spectrumChartPanel.setPreferredSize(new Dimension( (int) spectrumChartPanel.getPreferredSize().getWidth(), (int) UserInterface.screenSize.getHeight()));

				add(interferogramChartPanel, "cell 6 0 5 20, grow");
				add(spectrumChartPanel, "cell 11 0 5 20, grow");

				measurementCount_Interferogram = 0;
				measurementCount_Spectrum = 0;

//				UserInterface.frmMain.revalidate();
//				UserInterface.frmMain.repaint();

				AutoSavePath_Inter_Spec = "";
				if (chb_AutoSave_Inter_Spec.isSelected()) {
					chb_AutoSave_Inter_Spec.setSelected(false);
					JOptionPane.showMessageDialog(
							null,
							"Auto-save is disabled, please rechoose saving directory",
							"Auto-save Disabled!",
							JOptionPane.OK_OPTION);
				}

				clearingGraphsInProgress = false;
			}
		});
		this.add(btn_ClearGraphs_Inter_Spec, "cell 3 11 3 1,growx");

		chb_AutoSave_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		chb_AutoSave_Inter_Spec.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				JFileChooser autoSaveSpec;

				if(UserInterface.defaultDirectorySaveLoad.equals("") || !new File(UserInterface.defaultDirectorySaveLoad).exists())
				{
					autoSaveSpec = new JFileChooser() {
						@Override
						public void approveSelection() {
							File f = getSelectedFile();
							if (!UserInterface.checkEmptyDirectory(f.getAbsolutePath())) {
								int result = JOptionPane.showConfirmDialog(
										this,
										"The chosen directory is not empty. Overwritting might occur, overwrite?",
										"Directory not empty",
										JOptionPane.YES_NO_OPTION);
								switch (result) {
								case JOptionPane.YES_OPTION:
									super.approveSelection();
									return;
								case JOptionPane.CLOSED_OPTION:
									return;
								case JOptionPane.NO_OPTION:
									return;
								}
							}
							super.approveSelection();
						}
					};
				}
				else
				{
					autoSaveSpec = new JFileChooser(UserInterface.defaultDirectorySaveLoad) {
						@Override
						public void approveSelection() {
							File f = getSelectedFile();
							if (!UserInterface.checkEmptyDirectory(f.getAbsolutePath())) {
								int result = JOptionPane.showConfirmDialog(
										this,
										"The chosen directory is not empty. Overwritting might occur, overwrite?",
										"Directory not empty",
										JOptionPane.YES_NO_OPTION);
								switch (result) {
								case JOptionPane.YES_OPTION:
									super.approveSelection();
									return;
								case JOptionPane.CLOSED_OPTION:
									return;
								case JOptionPane.NO_OPTION:
									return;
								}
							}
							super.approveSelection();
						}
					};
				}
				autoSaveSpec.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);

				autoSaveSpec.setApproveButtonText("Save");
				autoSaveSpec.setDialogTitle( "Save");

				if (chb_AutoSave_Inter_Spec.isSelected()) {
					if (autoSaveSpec.showOpenDialog(null) == JFileChooser.APPROVE_OPTION) {
						AutoSavePath_Inter_Spec = autoSaveSpec.getSelectedFile().getAbsolutePath();
						UserInterface.defaultDirectorySaveLoad = AutoSavePath_Inter_Spec;
					} else {
						chb_AutoSave_Inter_Spec.setSelected(false);
					}
				} else {
					AutoSavePath_Inter_Spec = "";
				}
			}
		});

		this.add(chb_AutoSave_Inter_Spec, "cell 1 10 2 1,growx");

		JSeparator separatorV1_Inter_Spec = new JSeparator();
		separatorV1_Inter_Spec.setOrientation(SwingConstants.VERTICAL);
		add(separatorV1_Inter_Spec, "cell 11 22 1 5,growy");

		btn_WriteSettings_Inter_Spec = new JButton("");
		btn_WriteSettings_Inter_Spec.setVisible(true);
		btn_WriteSettings_Inter_Spec.setEnabled(false);
		btn_WriteSettings_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		btn_WriteSettings_Inter_Spec.setText("Burn Settings");
		btn_WriteSettings_Inter_Spec.setVerticalTextPosition(SwingConstants.CENTER);
		btn_WriteSettings_Inter_Spec.setHorizontalTextPosition(SwingConstants.CENTER);
		btn_WriteSettings_Inter_Spec.setToolTipText("Burn current settings in module's ROM");

		btn_WriteSettings_Inter_Spec.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {

				UserInterface.displayInterSpecOpticalSettings();
				String [] OpticalSettings = new String[cmb_Optical_Settings_Inter_Spec.getItemCount()];
				for(int i=0 ; i <cmb_Optical_Settings_Inter_Spec.getItemCount();i++ )
				{
					OpticalSettings[i]= cmb_Optical_Settings_Inter_Spec.getItemAt(i).toString();
				}
				UserInterface.burnSequence(OpticalSettings);
			}
		});

		cmb_Apodization_Inter_Spec = new JComboBox<String>();
		cmb_Apodization_Inter_Spec.setEnabled(false);
		cmb_Apodization_Inter_Spec.setFont(new Font("Dialog", Font.BOLD, 10));
		cmb_Apodization_Inter_Spec.setModel(new DefaultComboBoxModel<String>(p2Constants.apodizationOptions));
		cmb_Apodization_Inter_Spec.setMaximumSize(new Dimension(
				p2Constants.MAX_WIDTH_OF_FIELD, cmb_Apodization_Inter_Spec.getPreferredSize().height));
		this.add(cmb_Apodization_Inter_Spec, "cell 13 23,growx");

		cmb_Apodization_Inter_Spec.addPopupMenuListener(new PopupMenuListener() {
			public void popupMenuCanceled(PopupMenuEvent e) {
			}

			public void popupMenuWillBecomeInvisible(PopupMenuEvent e) {
				SpectroscopyPanel.cmb_Apodization_Spec.setSelectedIndex(cmb_Apodization_Inter_Spec.getSelectedIndex());
			}

			public void popupMenuWillBecomeVisible(PopupMenuEvent e) {
			}
		});

		Label lbl_ZeroPadding_Inter_Spec = new Label("Zero Padding");
		lbl_ZeroPadding_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		add(lbl_ZeroPadding_Inter_Spec, "cell 12 24,growx");

		cmb_ZeroPadding_Inter_Spec = new JComboBox<String>();
		cmb_ZeroPadding_Inter_Spec.setEnabled(false);
		cmb_ZeroPadding_Inter_Spec.setFont(new Font("Dialog", Font.BOLD, 10));
		cmb_ZeroPadding_Inter_Spec.setModel(new DefaultComboBoxModel<String>( p2Constants.paddingOptions ));
		cmb_ZeroPadding_Inter_Spec.setMaximumSize(new Dimension(
				p2Constants.MAX_WIDTH_OF_FIELD, cmb_ZeroPadding_Inter_Spec.getPreferredSize().height));
		this.add(cmb_ZeroPadding_Inter_Spec, "cell 13 24,growx");

		cmb_ZeroPadding_Inter_Spec.addPopupMenuListener(new PopupMenuListener() {
			public void popupMenuCanceled(PopupMenuEvent e) {
			}

			public void popupMenuWillBecomeInvisible(PopupMenuEvent e) {
				SpectroscopyPanel.cmb_ZeroPadding_Spec.setSelectedIndex(cmb_ZeroPadding_Inter_Spec.getSelectedIndex());
			}

			public void popupMenuWillBecomeVisible(PopupMenuEvent e) {
			}
		});

		btn_FFT_UpdateResults_Inter_Spec = new JButton("");
		btn_FFT_UpdateResults_Inter_Spec.setEnabled(false);
		btn_FFT_UpdateResults_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		btn_FFT_UpdateResults_Inter_Spec.setText("Update Results");
		btn_FFT_UpdateResults_Inter_Spec.setVerticalTextPosition(SwingConstants.CENTER);
		btn_FFT_UpdateResults_Inter_Spec.setHorizontalTextPosition(SwingConstants.CENTER);
		btn_FFT_UpdateResults_Inter_Spec.setToolTipText("Apply FFT Settings and Update Results");
		btn_FFT_UpdateResults_Inter_Spec.setMaximumSize(new Dimension(p2Constants.MAX_WIDTH_OF_FIELD, btn_FFT_UpdateResults_Inter_Spec.getPreferredSize().height));

		btn_FFT_UpdateResults_Inter_Spec.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				logger.info("updateFFT_SettingsInterSpec Started");
				updateFFT_SettingsInterSpec();
			}
		});
		this.add(btn_FFT_UpdateResults_Inter_Spec, "cell 14 24,growx");
		this.add(btn_WriteSettings_Inter_Spec, "cell 6 25 2 1,growx");

		btn_RestoreDefault_Inter_Spec = new JButton("Restore Default Settings");
		btn_RestoreDefault_Inter_Spec.setToolTipText("Restore Default Settings");
		btn_RestoreDefault_Inter_Spec.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				UserInterface.restoreSequence();
			}
		});
		btn_RestoreDefault_Inter_Spec.setEnabled(false);
		btn_RestoreDefault_Inter_Spec.setFont(new Font("Dialog", Font.PLAIN, 10));
		add(btn_RestoreDefault_Inter_Spec, "cell 8 25 2 1,growx");

	}

	public void update(Object arg1) {
		if (arg1 instanceof p2AppManagerNotification) {
			logger.info("update method started");
			p2AppManagerNotification resp = (p2AppManagerNotification) arg1;

			switch (resp.getAction()) {
			case 1: // Interferogram & Spectrum Run
				logger.info("Run_Inter_Spec Finished");
				if (!UserInterface.stopContinuousRun) {
					if (resp.getStatus() == 0) {
						logger.info("Get Data of Run_Inter_Spec Started");
						double[][] data = UserInterface.applicationManager.getInterSpecData();
						logger.info("Get Data of Run_Inter_Spec Finished");
						double[] xInverse = UserInterface.switch_NM_CM(data[p2Constants.WAVENUMBER_INDEX]);
						boolean	clearedGraph_Interferogram = false; 
						boolean	clearedGraph_Spectrum = false; 

						if(clearingGraphsInProgress == false)
						{
							//Clear plots is not running now

							// Drawing Charts
							try {
								if(measurementCount_Interferogram == 0)
									clearedGraph_Interferogram = true;
								if(measurementCount_Spectrum == 0)
									clearedGraph_Spectrum = true;

								// removes last plot if user didn't capture it.
								if ((!capture_Displayed_InterSpec) && (measurementCount_Interferogram != 0)) {
									measurementCount_Interferogram--;
									measurementCount_Spectrum--;
								}
								measurementCount_Interferogram++;
								if (measurementCount_Interferogram == 1 && clearedGraph_Interferogram) {
									interferogramChart = new XYLineChart("Interferogram", "Measurement No. " + measurementCount_Interferogram, "Optical Path Difference (\u00B5m)", "Current (nA)", new double[][] { data[0], data[1] }, true);
									clearedGraph_Interferogram = false;
								} else {
									interferogramChart.addSeries("Measurement No. " + measurementCount_Interferogram, new double[][] { data[0], data[1] }, true);
								}
								measurementCount_Spectrum++;
								if (measurementCount_Spectrum == 1 && clearedGraph_Spectrum) {
									spectrumChart_NM = new XYLineChart("PSD", "Measurement No. " + measurementCount_Spectrum, "Wavelength (nm)", "PSD (a.u.)", new double[][] { xInverse, data[3] }, true);
									spectrumChart_CM = new XYLineChart("PSD", "Measurement No. " + measurementCount_Spectrum, "Wavenumber (cm -\u00B9)", "PSD (a.u.)", new double[][] { data[2], data[3] }, true);
									clearedGraph_Spectrum = false;
								} else {

									spectrumChart_NM.addSeries("Measurement No. " + measurementCount_Spectrum, new double[][] { xInverse, data[3] }, true);
									spectrumChart_CM.addSeries("Measurement No. " + measurementCount_Spectrum, new double[][] { data[2], data[3] }, true);
								}

								capture_Displayed_InterSpec = false;

								remove(interferogramChartPanel);
								remove(spectrumChartPanel);

								interferogramChartPanel = null;
								spectrumChartPanel = null;

								interferogramChartPanel = interferogramChart.getChartPanel();
								if(rdbtn_nm_Inter_Spec.isSelected())
								{
									spectrumChartPanel = spectrumChart_NM.getChartPanel();
								}
								else
								{
									spectrumChartPanel = spectrumChart_CM.getChartPanel();
								}

								interferogramChartPanel.setBorder(new LineBorder( new Color(0, 0, 0), 1, true));
								spectrumChartPanel.setBorder(new LineBorder( new Color(0, 0, 0), 1, true));

//								interferogramChartPanel.setPreferredSize(new Dimension( (int) interferogramChartPanel.getPreferredSize().getWidth(), (int) UserInterface.screenSize.getHeight()));
//								spectrumChartPanel.setPreferredSize(new Dimension( (int) spectrumChartPanel.getPreferredSize().getWidth(), (int) UserInterface.screenSize.getHeight()));

								add(interferogramChartPanel, "cell 6 0 5 20, grow");
								add(spectrumChartPanel, "cell 11 0 5 20, grow");

								interferogramChartPanel.repaint();
								spectrumChartPanel.repaint();
							} catch (Exception e) {
								logger.error(e.getMessage());
							}
							// //////////////////////////////////////////////////////////////////

							if (data != null) {
								logger.info("writing plot to file started");
								writeRunDataFile(data, resp.getDeviceId());
								logger.info("writing plot to file finished");
							}
						}
						else
						{
							//Ignore plotting
						}

						data = null;
						xInverse = null;
						if (UserInterface.stopContinuousRun || !UserInterface.isContinuousRun || !rdbtn_ContRun_Inter_Spec.isSelected()) {

							VariableHelper.setMessage("Measurement completed successfully.");
//							UserInterface.colorLabel.setForeground(Color.green.darker());
//							UserInterface.colorLabel.setBackground(Color.green.darker());

							UserInterface.progressTime = -1;
//							UserInterface.progressPar.setValue(100);
						}

					} else {
//						UserInterface.colorLabel.setForeground(Color.red);
//						UserInterface.colorLabel.setBackground(Color.red);

						UserInterface.progressTime = -1;
//						UserInterface.progressPar.setValue(100);

						JOptionPane.showMessageDialog(
								null,
								UserInterface.convertErrorCodesToMessages(resp.getStatus()),
								"Run Interferogram", JOptionPane.OK_OPTION);
						btn_Stop_Inter_Spec.doClick();
					}
				}

				//cont run
				if (!UserInterface.stopContinuousRun && UserInterface.isContinuousRun && rdbtn_ContRun_Inter_Spec.isSelected()) {
					RunSequence();
					try{logger.info("Run_Inter_Spec Finished (Without PowerUp) - Scan Time = " + String.valueOf(Double.parseDouble(txt_RunTime_Inter_Spec.getText()) * 1000));}catch(Exception d){}
				}
				else //single run
				{
					if(rdbtn_ContRun_Inter_Spec.isSelected())
					{
//						UserInterface.colorLabel.setForeground(Color.green.darker());
//						UserInterface.colorLabel.setBackground(Color.green.darker());
					}
					logger.info("switching actuation off started");
					//switch off actuation
					UserInterface.switchOnOFF(false, true);
					logger.info("switching actuation off finished");

					logger.info("enabling GUI fields started");
					UserInterface.boardReadyRoutine(true);
					logger.info("enabling GUI fields finished");

					boolean btn_capture_status = btn_Capture_Interfero.isEnabled();
					btn_Capture_Interfero.setEnabled(true);
					btn_Capture_Interfero.doClick();
					btn_Capture_Interfero.setEnabled(btn_capture_status);

					// resume checking the status of the device
					UserInterface.checkDeviceStatusThreadStop = false;

				}

				break;
			case 31: // Interferogram & Spectrum update fft settings
				logger.info("Update_Inter_Spec Finished");

				if (resp.getStatus() == 0) {
					logger.info("Get Data of Run_Inter_Spec Started");
					double[][] data = UserInterface.applicationManager.getInterSpecData();
					logger.info("Get Data of Run_Inter_Spec Finished");
					double[] xInverse = UserInterface.switch_NM_CM(data[p2Constants.WAVENUMBER_INDEX]);
					boolean	clearedGraph_Interferogram = false; 
					boolean	clearedGraph_Spectrum = false; 

					if(clearingGraphsInProgress == false)
					{
						//Clear plots is not running now

						// Drawing Charts
						try {
							if(measurementCount_Interferogram == 0)
								clearedGraph_Interferogram = true;
							if(measurementCount_Spectrum == 0)
								clearedGraph_Spectrum = true;

							// removes last plot if user didn't capture it.
							if ((!capture_Displayed_InterSpec) && (measurementCount_Interferogram != 0)) {
								measurementCount_Interferogram--;
								measurementCount_Spectrum--;
							}
							measurementCount_Interferogram++;
							if (measurementCount_Interferogram == 1 && clearedGraph_Interferogram) {
								interferogramChart = new XYLineChart("Interferogram", "Measurement No. " + measurementCount_Interferogram, "Optical Path Difference (\u00B5m)", "Current (nA)", new double[][] { data[0], data[1] }, true);
								clearedGraph_Interferogram = false;
							} else {
								interferogramChart.addSeries("Measurement No. " + measurementCount_Interferogram, new double[][] { data[0], data[1] }, true);
							}
							measurementCount_Spectrum++;
							if (measurementCount_Spectrum == 1 && clearedGraph_Spectrum) {
								spectrumChart_NM = new XYLineChart("PSD", "Measurement No. " + measurementCount_Spectrum, "Wavelength (nm)", "PSD (a.u.)", new double[][] { xInverse, data[3] }, true);
								spectrumChart_CM = new XYLineChart("PSD", "Measurement No. " + measurementCount_Spectrum, "Wavenumber (cm -\u00B9)", "PSD (a.u.)", new double[][] { data[2], data[3] }, true);
								clearedGraph_Spectrum = false;
							} else {

								spectrumChart_NM.addSeries("Measurement No. " + measurementCount_Spectrum, new double[][] { xInverse, data[3] }, true);
								spectrumChart_CM.addSeries("Measurement No. " + measurementCount_Spectrum, new double[][] { data[2], data[3] }, true);
							}

							capture_Displayed_InterSpec = false;

							remove(interferogramChartPanel);
							remove(spectrumChartPanel);

							interferogramChartPanel = null;
							spectrumChartPanel = null;

							interferogramChartPanel = interferogramChart.getChartPanel();
							if(rdbtn_nm_Inter_Spec.isSelected())
							{
								spectrumChartPanel = spectrumChart_NM.getChartPanel();
							}
							else
							{
								spectrumChartPanel = spectrumChart_CM.getChartPanel();
							}

							interferogramChartPanel.setBorder(new LineBorder( new Color(0, 0, 0), 1, true));
							spectrumChartPanel.setBorder(new LineBorder( new Color(0, 0, 0), 1, true));

//							interferogramChartPanel.setPreferredSize(new Dimension( (int) interferogramChartPanel.getPreferredSize().getWidth(), (int) UserInterface.screenSize.getHeight()));
//							spectrumChartPanel.setPreferredSize(new Dimension( (int) spectrumChartPanel.getPreferredSize().getWidth(), (int) UserInterface.screenSize.getHeight()));

							add(interferogramChartPanel, "cell 6 0 5 20, grow");
							add(spectrumChartPanel, "cell 11 0 5 20, grow");

							interferogramChartPanel.repaint();
							spectrumChartPanel.repaint();
						} catch (Exception e) {
							logger.error(e.getMessage());
						}
						// //////////////////////////////////////////////////////////////////

						if (data != null) {
							logger.info("writing plot to file started");
							writeRunDataFile(data, resp.getDeviceId());
							logger.info("writing plot to file finished");
						}
					}
					else
					{
						//Ignore plotting
					}

					data = null;
					xInverse = null;
					VariableHelper.setMessage("Measurement completed successfully.");
//					UserInterface.colorLabel.setForeground(Color.green.darker());
//					UserInterface.colorLabel.setBackground(Color.green.darker());

					UserInterface.progressTime = -1;
//					UserInterface.progressPar.setValue(100);

				} else {
//					UserInterface.colorLabel.setForeground(Color.red);
//					UserInterface.colorLabel.setBackground(Color.red);

					UserInterface.progressTime = -1;
//					UserInterface.progressPar.setValue(100);

					JOptionPane.showMessageDialog(
							null,
							UserInterface.convertErrorCodesToMessages(resp.getStatus()),
							"Run Interferogram", JOptionPane.OK_OPTION);
					btn_Stop_Inter_Spec.doClick();
				}


				if(rdbtn_ContRun_Inter_Spec.isSelected())
				{
//					UserInterface.colorLabel.setForeground(Color.green.darker());
//					UserInterface.colorLabel.setBackground(Color.green.darker());
				}
				logger.info("switching actuation off started");
				//switch off actuation
				UserInterface.switchOnOFF(false, true);
				logger.info("switching actuation off finished");

				logger.info("enabling GUI fields started");
				UserInterface.boardReadyRoutine(true);
				logger.info("enabling GUI fields finished");

				boolean btn_capture_status = btn_Capture_Interfero.isEnabled();
				btn_Capture_Interfero.setEnabled(true);
				btn_Capture_Interfero.doClick();
				btn_Capture_Interfero.setEnabled(btn_capture_status);

				// resume checking the status of the device
				UserInterface.checkDeviceStatusThreadStop = false;

				break;
			default:
				// not supported action
				;
			}
		}

	}

	boolean writeRunDataFile(double[][] data, String moduleId) {

		if (!UserInterface.writeGraphFile(data[0], data[1], p2AppManagerUtils.formatString(p2Constants.getPath(INTERFERO_PATH_TEMPLATE), measurementCount_Interferogram), INTERFERO_FILE_X_AXIS + "\t" + INTERFERO_FILE_Y_AXIS)) {

			throw new
			p2AppManagerException("Error while writing interferogram file    ",
					p2AppManagerStatus.INTERFERO_FILE_CREATION_ERROR.getNumVal()
					);

		}
		// interfero file
		double[] xInverse = UserInterface.switch_NM_CM(data[p2Constants.WAVENUMBER_INDEX]);

		if(rdbtn_nm_Inter_Spec.isSelected())
		{
			// PSD file
			if (!UserInterface.writeGraphFile(xInverse, data[p2Constants.POWER_SPECTRAL_DENSITY_INDEX], p2AppManagerUtils.formatString(p2Constants.getPath(PSD_PATH_TEMPLATE), measurementCount_Spectrum), PSD_FILE_X_AXIS_NM + "\t" + PSD_FILE_Y_AXIS)) {

				throw new
				p2AppManagerException("Error writing write PSD file    ",
						p2AppManagerStatus.PSD_FILE_CREATION_ERROR.getNumVal());

			}
		}
		else
		{
			// PSD file
			if (!UserInterface.writeGraphFile(data[p2Constants.WAVENUMBER_INDEX], data[p2Constants.POWER_SPECTRAL_DENSITY_INDEX], p2AppManagerUtils.formatString(p2Constants.getPath(PSD_PATH_TEMPLATE), measurementCount_Spectrum), PSD_FILE_X_AXIS_CM + "\t" + PSD_FILE_Y_AXIS)) {

				throw new
				p2AppManagerException("Error while writing PSD file    ",
						p2AppManagerStatus.PSD_FILE_CREATION_ERROR.getNumVal());

			}
		}

		xInverse = null;

		return true;

	}

	private void RunSequence()
	{

		UserInterface.isContinuousRun = true;
		UserInterface.stopContinuousRun = false;
		logger.info("RunSequence function started");
		// Start RUN
		if (!UserInterface.stopContinuousRun) {
			try{
				// stop checking the status of the device
				UserInterface.checkDeviceStatusThreadStop = true;

				try
				{
					if(!lastResolutionSelected.equals(cmb_Resolution_Inter_Spec.getSelectedItem().toString()))
					{
						logger.info("setSettings function (reg file rewrite) started");
						//true is for reloading t.reg
						UserInterface.applicationManager.setSettings(cmb_Resolution_Inter_Spec.getSelectedItem().toString(), "true");
						logger.info("setSettings function (reg file rewrite) finished");

						lastResolutionSelected = cmb_Resolution_Inter_Spec.getSelectedItem().toString();
					}
					else
					{
						logger.info("setSettings function (no reg file rewrite) started");
						//false --> don't reload t.reg
						UserInterface.applicationManager.setSettings(cmb_Resolution_Inter_Spec.getSelectedItem().toString(), "false");
						logger.info("setSettings function (no reg file rewrite) finished");
					}

					logger.info("Setting Optical Settings started");
					UserInterface.applicationManager.setOpticalSettings(cmb_Optical_Settings_Inter_Spec.getSelectedItem().toString(), p2Constants.InterSpecPrefix);
					logger.info("Setting Optical Settings finished");

				}
				catch(Exception ex)
				{
//					UserInterface.colorLabel.setForeground(Color.red);
//					UserInterface.colorLabel.setBackground(Color.red);

					JOptionPane.showMessageDialog(null,
							"Run failed to start. Module setup failed!",
							"Run Interferogram", JOptionPane.OK_OPTION);

					UserInterface.checkDeviceStatusThreadStop = false;
					UserInterface.stopContinuousRun = true;
					UserInterface.isContinuousRun = false;
					return;
				}

				UserInterface.progressTime = Double.parseDouble(txt_RunTime_Inter_Spec.getText().toString()) * 1000;
//				UserInterface.progressPar.setValue(0);
				logger.info("runInterSpec function started");
				p2AppManagerStatus status = UserInterface.applicationManager.runInterSpec(
						String.valueOf(Double.parseDouble(txt_RunTime_Inter_Spec.getText()) * 1000),
						Integer.toString(cmb_Apodization_Inter_Spec.getSelectedIndex()),
						cmb_ZeroPadding_Inter_Spec.getSelectedItem().toString());
				logger.info("runInterSpec function finished");
				if (p2AppManagerStatus.NO_ERROR != status) {

					if (p2AppManagerStatus.DEVICE_BUSY_ERROR != status) {
						// resume checking the status of the device
						UserInterface.checkDeviceStatusThreadStop = false;

//						UserInterface.colorLabel.setForeground(Color.red);
//						UserInterface.colorLabel.setBackground(Color.red);
					}

					JOptionPane.showMessageDialog(null,
							"Run failed to start: " + UserInterface.convertErrorCodesToMessages(status),
							"Run Interferogram", JOptionPane.OK_OPTION);

					UserInterface.stopContinuousRun = true;
					UserInterface.isContinuousRun = false;
				} else {
					logger.info("disabling GUI fields started");
					UserInterface.boardReadyRoutine(false);
					logger.info("disabling GUI fields finished");
					VariableHelper.setMessage("Run started. Please wait...");

//					UserInterface.colorLabel.setForeground(Color.yellow);
//					UserInterface.colorLabel.setBackground(Color.yellow);

				}
			}
			catch(Exception ex)
			{
//				UserInterface.colorLabel.setForeground(Color.red);
//				UserInterface.colorLabel.setBackground(Color.red);

				JOptionPane.showMessageDialog(null,
						"Run failed to start. \n Please make sure that the entries in measurement parameters are valid.",
						"Run Interferogram", JOptionPane.OK_OPTION);
			}
		}
//		UserInterface.frmMain.revalidate();
//		UserInterface.frmMain.repaint();
	}

	private void LoadCharts(File loadedFile)
	{

		double[][] arraysToPlot = UserInterface.loadGraphDataFromFile(loadedFile.getAbsolutePath());
		if(arraysToPlot == null)
			return;
		try {
			if (loadedFile.getAbsolutePath().endsWith(".InterPSD")) {
				remove(spectrumChartPanel);
				measurementCount_Spectrum++;

				double[] xInverse = UserInterface.switch_NM_CM(arraysToPlot[0]);

				if (measurementCount_Spectrum == 1) {
					if(rdbtn_nm_Inter_Spec.isSelected())
					{
						spectrumChart_NM = new XYLineChart("PSD", "Measurement No. " + measurementCount_Spectrum, "Wavelength (nm)", "PSD (a.u.)", arraysToPlot);
						spectrumChart_CM = new XYLineChart("PSD", "Measurement No. " + measurementCount_Spectrum, "Wavenumber (cm -\u00B9)", "PSD (a.u.)", new double[][] { xInverse, arraysToPlot[1] });
					}
					else
					{
						spectrumChart_CM = new XYLineChart("PSD", "Measurement No. " + measurementCount_Spectrum, "Wavenumber (cm -\u00B9)", "PSD (a.u.)", arraysToPlot);
						spectrumChart_NM = new XYLineChart("PSD", "Measurement No. " + measurementCount_Spectrum, "Wavelength (nm)", "PSD (a.u.)", new double[][] { xInverse, arraysToPlot[1] });
					}
				} else {
					if(rdbtn_nm_Inter_Spec.isSelected())
					{
						spectrumChart_NM.addSeries("Measurement No. " + measurementCount_Spectrum, arraysToPlot);
						spectrumChart_CM.addSeries("Measurement No. " + measurementCount_Spectrum, new double[][] { xInverse, arraysToPlot[1] });
					}
					else
					{
						spectrumChart_CM.addSeries("Measurement No. " + measurementCount_Spectrum, arraysToPlot);
						spectrumChart_NM.addSeries("Measurement No. " + measurementCount_Spectrum, new double[][] { xInverse, arraysToPlot[1] });
					}
				}

				if(rdbtn_nm_Inter_Spec.isSelected())
				{
					spectrumChartPanel = spectrumChart_NM.getChartPanel();
				}
				else
				{
					spectrumChartPanel = spectrumChart_CM.getChartPanel();
				}
				spectrumChartPanel.setBorder(new LineBorder(new Color(0, 0, 0), 1, true));
				spectrumChartPanel.repaint();

//				spectrumChartPanel.setPreferredSize(new Dimension( (int) spectrumChartPanel.getPreferredSize().getWidth(), (int) UserInterface.screenSize.getHeight()));

				add(spectrumChartPanel, "cell 11 0 5 20, grow");

				// copy the plot file to temp plots directory
				p2AppManagerUtils.createDir(p2Constants.getPath(UserInterface.GRAPH_FILES_FOLDER_PATH));
				File folder = new File(p2AppManagerUtils.formatString(p2Constants.getPath(PSD_PATH_TEMPLATE), measurementCount_Spectrum));

				Files.copy(loadedFile.toPath(), folder.toPath(), StandardCopyOption.REPLACE_EXISTING);
			} else {
				remove(interferogramChartPanel);
				measurementCount_Interferogram++;
				if (measurementCount_Interferogram == 1) {
					interferogramChart = new XYLineChart("Interferogram", "Measurement No. " + measurementCount_Interferogram, "Optical Path Difference (\u00B5m)", "Current (nA)", arraysToPlot, true);
				} else {
					interferogramChart.addSeries("Measurement No. " + measurementCount_Interferogram, arraysToPlot, true);
				}
				interferogramChartPanel = interferogramChart.getChartPanel();
				interferogramChartPanel.setBorder(new LineBorder(new Color(0, 0, 0), 1, true));
				interferogramChartPanel.repaint();

//				interferogramChartPanel.setPreferredSize(new Dimension( (int) interferogramChartPanel.getPreferredSize().getWidth(), (int) UserInterface.screenSize.getHeight()));

				add(interferogramChartPanel, "cell 6 0 5 20, grow");

				// copy the plot file to temp plots directory
				p2AppManagerUtils.createDir(p2Constants.getPath(UserInterface.GRAPH_FILES_FOLDER_PATH));
				File folder = new File(p2AppManagerUtils.formatString(p2Constants.getPath(INTERFERO_PATH_TEMPLATE), measurementCount_Interferogram));

				Files.copy(loadedFile.toPath(), folder.toPath(), StandardCopyOption.REPLACE_EXISTING);
			}
			
			boolean btn_capture_status = btn_Capture_Interfero.isEnabled();
			btn_Capture_Interfero.setEnabled(true);
			btn_Capture_Interfero.doClick();
			btn_Capture_Interfero.setEnabled(btn_capture_status);
			
			repaint();
//			UserInterface.frmMain.revalidate();
//			UserInterface.frmMain.repaint();
		} catch (Exception ex) {
			JOptionPane.showMessageDialog(null,
					"Failed to save measurement data files in the temporary directory: "
							+ ex.getMessage(), "Saving files",
							JOptionPane.OK_OPTION);
		}

	}
	private void updateFFT_SettingsInterSpec()
	{

		logger.info("updateFFT_SettingsInterSpec function started");
		// Start RUN
		try{
			// stop checking the status of the device
			UserInterface.checkDeviceStatusThreadStop = true;

			try
			{
				try
				{
					if(!lastResolutionSelected.equals(cmb_Resolution_Inter_Spec.getSelectedItem().toString()))
					{
						logger.info("setSettings function (reg file rewrite) started");
						//true is for reloading t.reg
						UserInterface.applicationManager.setSettings(cmb_Resolution_Inter_Spec.getSelectedItem().toString(), "true");
						logger.info("setSettings function (reg file rewrite) finished");

						lastResolutionSelected = cmb_Resolution_Inter_Spec.getSelectedItem().toString();
					}
					else
					{
						logger.info("setSettings function (no reg file rewrite) started");
						//false --> don't reload t.reg
						UserInterface.applicationManager.setSettings(cmb_Resolution_Inter_Spec.getSelectedItem().toString(), "false");
						logger.info("setSettings function (no reg file rewrite) finished");
					}

				}
				catch(Exception ex)
				{
//					UserInterface.colorLabel.setForeground(Color.red);
//					UserInterface.colorLabel.setBackground(Color.red);

					JOptionPane.showMessageDialog(null,
							"Module setup failed!. \n Please take another measurement. \n If the error persists, please contact Si-Ware Systems.",
							"Update Results", JOptionPane.OK_OPTION);

					UserInterface.checkDeviceStatusThreadStop = false;
					return;
				}


				//Check if old interSpec result is found
				double[][] data = UserInterface.applicationManager.getInterSpecData();
				if(null == data || p2Constants.DSP_DATA_LENGTH != data.length)
				{
//					UserInterface.colorLabel.setForeground(Color.red);
//					UserInterface.colorLabel.setBackground(Color.red);

					JOptionPane.showMessageDialog(null,
							"No data to update. \n Please take a measurement first.",
							"Update Results", JOptionPane.OK_OPTION);

					UserInterface.checkDeviceStatusThreadStop = false;
					return;
				}

				data = null;

			}
			catch(Exception ex)
			{
//				UserInterface.colorLabel.setForeground(Color.red);
//				UserInterface.colorLabel.setBackground(Color.red);

				JOptionPane.showMessageDialog(null,
						"No data to update. \n Please take a measurement first.",
						"Update Results", JOptionPane.OK_OPTION);

				UserInterface.checkDeviceStatusThreadStop = false;
				return;
			}

			logger.info("updateFFT_SettingsInterSpec function started");
			p2AppManagerStatus status = UserInterface.applicationManager.updateFFT_SettingsInterSpec(
					Integer.toString(cmb_Apodization_Inter_Spec.getSelectedIndex()),
					cmb_ZeroPadding_Inter_Spec.getSelectedItem().toString());
			logger.info("updateFFT_SettingsInterSpec function finished");

			if (p2AppManagerStatus.NO_ERROR != status) {

				if (p2AppManagerStatus.DEVICE_BUSY_ERROR != status) {
					// resume checking the status of the device
					UserInterface.checkDeviceStatusThreadStop = false;

//					UserInterface.colorLabel.setForeground(Color.red);
//					UserInterface.colorLabel.setBackground(Color.red);
				}

				JOptionPane.showMessageDialog(null,
						"Update failed: " + UserInterface.convertErrorCodesToMessages(status),
						"Update FFT Settings", JOptionPane.OK_OPTION);

			} else {
				logger.info("disabling GUI fields started");
				UserInterface.boardReadyRoutine(false);
				logger.info("disabling GUI fields finished");
				VariableHelper.setMessage("FFT settings calculations started. Please wait...");

//				UserInterface.colorLabel.setForeground(Color.yellow);
//				UserInterface.colorLabel.setBackground(Color.yellow);

			}
		}
		catch(Exception ex)
		{
//			UserInterface.colorLabel.setForeground(Color.red);
//			UserInterface.colorLabel.setBackground(Color.red);

			JOptionPane.showMessageDialog(null,
					"Update failed. Please make sure that entries in FFT settings are valid.",
					"Update FFT Settings", JOptionPane.OK_OPTION);
		}
//		UserInterface.frmMain.revalidate();
//		UserInterface.frmMain.repaint();
	}

	public static void saveGraphsRoutine()
	{
		p2AppManagerUtils.createDir(p2Constants.getPath(UserInterface.GRAPH_FILES_FOLDER_PATH));
		File folder = new File(p2Constants.getPath(UserInterface.GRAPH_FILES_FOLDER_PATH));
		File[] listOfFiles = folder.listFiles();

		String[] finalFileNames = new String[listOfFiles.length];
		for(int i = 0; i < finalFileNames.length; i++)
		{
			finalFileNames[i] = UserInterface.fileNameToSave.equals("!Default!") ? listOfFiles[i].getName() : UserInterface.fileNameToSave + listOfFiles[i].getName().substring(listOfFiles[i].getName().indexOf("_"));
		}

		JFileChooser saveSpecFile;
		if(UserInterface.defaultDirectorySaveLoad.equals("") || !new File(UserInterface.defaultDirectorySaveLoad).exists())
		{
			saveSpecFile = new JFileChooser();
		}
		else
		{
			saveSpecFile = new JFileChooser(UserInterface.defaultDirectorySaveLoad);
		}
		saveSpecFile.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);

		saveSpecFile.setApproveButtonText("Save");
		saveSpecFile.setDialogTitle("Save");

		if (finalFileNames.length != 0) {
			if (saveSpecFile.showOpenDialog(null) == JFileChooser.APPROVE_OPTION) {

				p2AppManagerUtils.createDir(saveSpecFile.getSelectedFile().getAbsolutePath());
				int overwriteRemember = -1;

				for (int i = 0; i < finalFileNames.length; i++) {
					if (listOfFiles[i].isFile()) {
						if (listOfFiles[i].getAbsolutePath().endsWith(".Interferogram") || listOfFiles[i].getAbsolutePath().endsWith(".InterPSD")) {
							try {
								//overwriting will happen
								if(new File(saveSpecFile.getSelectedFile().getAbsolutePath() + File.separatorChar + finalFileNames[i]).exists())
								{
									if(overwriteRemember == -1)
									{
										int result = JOptionPane.showConfirmDialog(
												null,
												"The chosen directory has plot(s) with the same name, overwrite all?",
												"Overwrite",
												JOptionPane.YES_NO_OPTION);
										switch (result) {
										case JOptionPane.YES_OPTION:
										{
											overwriteRemember = 1;
											Files.copy(listOfFiles[i].toPath(), (new File(saveSpecFile.getSelectedFile().getAbsolutePath() + File.separatorChar + finalFileNames[i])).toPath(), StandardCopyOption.REPLACE_EXISTING);
											break;
										}
										case JOptionPane.CLOSED_OPTION:
										{
											overwriteRemember = 0;
											break;
										}
										case JOptionPane.NO_OPTION:
										{
											overwriteRemember = 0;
											break;
										}
										}
									}
									else if (overwriteRemember == 1)
									{
										Files.copy(listOfFiles[i].toPath(), (new File(saveSpecFile.getSelectedFile().getAbsolutePath() + File.separatorChar + finalFileNames[i])).toPath(), StandardCopyOption.REPLACE_EXISTING);
									}
								}
								//no overwriting will happen
								else
								{
									Files.copy(listOfFiles[i].toPath(), (new File(saveSpecFile.getSelectedFile().getAbsolutePath() + File.separatorChar + finalFileNames[i])).toPath(), StandardCopyOption.REPLACE_EXISTING);
								}

							} catch (Exception ex) {
								JOptionPane.showMessageDialog(null,
										"Failed to save files to the selected destination: "
												+ ex.getMessage(),
												"Saving files",
												JOptionPane.OK_OPTION);
								return;
							}
						}
					}
				}
				UserInterface.defaultDirectorySaveLoad = saveSpecFile.getSelectedFile().getAbsolutePath();
			}
		}
	}
}

package sws.spectromost;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.Image;
import java.awt.Label;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;
import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JFormattedTextField;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.SwingConstants;
import javax.swing.border.Border;
import javax.swing.border.EtchedBorder;
import javax.swing.JLabel;

import net.miginfocom.swing.MigLayout;

import org.apache.log4j.Logger;

import sws.p2AppManager.utils.p2AppManagerNotification;
import sws.p2AppManager.utils.p2Constants;
import sws.p2AppManager.utils.p2Enumerations.p2AppManagerStatus;

@SuppressWarnings("serial")
public class SpecGainPanel extends JPanel {
	private static Logger logger = Logger.getLogger(SpecGainPanel.class);
	
	private static String resolution = null;
	private static String apodizationIndex = null;
	private static String zeroPaddingMultiplier = null;
	
	static JFrame frmSpecGain;

	static JFormattedTextField txt_SetupName_Spec_Gain;
	static JButton btn_Proceed_Spec_Gain;
	static JButton btn_Close_Spec_Gain;
	static JLabel lbl_Progress_Details_Spec_Gain;
	
	/*
	 * ! This class is used for actions needed in this panel
	 */
	private class SpecGainActions{
		private final String actionName;
		private boolean succeeded;

		SpecGainActions(String actionName) {
			this.actionName = actionName;
			this.succeeded = false;
		}

		public String getActionName() {
			return this.actionName;
		}
		
		public Boolean getSucceeded(){
			return this.succeeded;
		}
		
		public void setSucceeded(boolean succeeded){
			this.succeeded = succeeded;
		}
	}
	
	//private static String[] panelActionNames = new String[]{"Background Measurement", "Sample Measurement", "Save Settings"};
	//change to make only bg gain adj 
	private static String[] panelActionNames = new String[]{"Step 1: Optical power measurement ", "Step 2: Save settings"};

	private static SpecGainActions[] panelActions = new SpecGainActions[panelActionNames.length];
	
	public SpecGainPanel(String resolution, String apodizationIndex, String zeroPaddingMultiplier) {
		super();
		SpecGainPanel.resolution = resolution;
		SpecGainPanel.apodizationIndex = apodizationIndex;
		SpecGainPanel.zeroPaddingMultiplier = zeroPaddingMultiplier;
		this.initialize();
	}
	
	public void initialize() {
		
		frmSpecGain = new JFrame();
		frmSpecGain.setAlwaysOnTop (true);
		
		//Initialize actions array
		for(int i = 0; i < panelActions.length; i ++){
			panelActions[i] = new SpecGainActions(panelActionNames[i]);
		}

		frmSpecGain.setBackground(new Color(176, 196, 222));
		frmSpecGain.getContentPane().setBackground(new Color(176, 196, 222));
		frmSpecGain.setVisible(true);
		frmSpecGain.setName("SpecFrame");

		frmSpecGain.setMinimumSize(new Dimension((int)(p2Constants.SUB_PANELS_DIMENTION * 1.2), (int)(p2Constants.SUB_PANELS_DIMENTION)));
		frmSpecGain.setMaximumSize(new Dimension((int)(p2Constants.SUB_PANELS_DIMENTION * 1.2), (int)(p2Constants.SUB_PANELS_DIMENTION)));
		frmSpecGain.setPreferredSize(new Dimension((int)(p2Constants.SUB_PANELS_DIMENTION * 1.2), (int)(p2Constants.SUB_PANELS_DIMENTION)));
//		frmSpecGain.setLocation((int)(UserInterface.screenSize.getWidth()/2 - p2Constants.SUB_PANELS_DIMENTION / 2), (int)(UserInterface.screenSize.getHeight()/2 - p2Constants.SUB_PANELS_DIMENTION / 2));
		
		frmSpecGain.addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent arg0) {
				// Exit
				onCloseOperation();
			}
		});
		frmSpecGain.setTitle("Gain Adjustment");
		frmSpecGain.setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
		frmSpecGain.setResizable(false);

		frmSpecGain.setFont(new Font("Dialog", Font.PLAIN, 12));
		frmSpecGain.setBackground(new Color(176, 196, 222));
		frmSpecGain.setLayout(new MigLayout("", "[90.00:90.00][45.00:45.00][grow,fill]", "[][][grow][]"));
		
		Label lbl_Setup_Name = new Label("Setup Name");
		lbl_Setup_Name.setFont(new Font("Dialog", Font.PLAIN, 12));
		frmSpecGain.getContentPane().add(lbl_Setup_Name, "cell 0 0,growx");
		
		txt_SetupName_Spec_Gain = new JFormattedTextField();
		txt_SetupName_Spec_Gain.setFont(new Font("Dialog", Font.PLAIN, 12));
		txt_SetupName_Spec_Gain.setText("Setup_Name");
		txt_SetupName_Spec_Gain.setMinimumSize(new Dimension(p2Constants.MAX_WIDTH_OF_FIELD, txt_SetupName_Spec_Gain.getPreferredSize().height));
		frmSpecGain.getContentPane().add(txt_SetupName_Spec_Gain, "flowx,cell 1 0 2 1,growx");
		
		Label lbl_Progress_Spec_Gain = new Label("Progress");
		lbl_Progress_Spec_Gain.setFont(new Font("Dialog", Font.BOLD, 12));
		frmSpecGain.getContentPane().add(lbl_Progress_Spec_Gain, "cell 0 1 3 1,growx");

		
		lbl_Progress_Details_Spec_Gain = new JLabel();
		lbl_Progress_Details_Spec_Gain.setFont(new Font("Dialog", Font.PLAIN, 12));
		Border border = (Border) BorderFactory.createEtchedBorder(EtchedBorder.LOWERED);
		lbl_Progress_Details_Spec_Gain.setBorder(border);
		lbl_Progress_Details_Spec_Gain.setText(getActionsString());
		lbl_Progress_Details_Spec_Gain.setVerticalAlignment(JLabel.TOP);
		lbl_Progress_Details_Spec_Gain.setVerticalTextPosition(JLabel.TOP);
		lbl_Progress_Details_Spec_Gain.setAlignmentY(TOP_ALIGNMENT);
		frmSpecGain.getContentPane().add(lbl_Progress_Details_Spec_Gain, "cell 0 2 3 1,grow");
		
		btn_Proceed_Spec_Gain = new JButton("");
		btn_Proceed_Spec_Gain.setFont(new Font("Dialog", Font.PLAIN, 12));
		btn_Proceed_Spec_Gain.setText("Proceed >>");
		btn_Proceed_Spec_Gain.setVerticalTextPosition(SwingConstants.CENTER);
		btn_Proceed_Spec_Gain.setHorizontalTextPosition(SwingConstants.CENTER);
		btn_Proceed_Spec_Gain.setToolTipText("Proceed");
		btn_Proceed_Spec_Gain.setMaximumSize(new Dimension((int)(p2Constants.MAX_WIDTH_OF_FIELD), btn_Proceed_Spec_Gain.getPreferredSize().height));

		btn_Proceed_Spec_Gain.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if(txt_SetupName_Spec_Gain.getText().equals(""))
				{
					JOptionPane.showMessageDialog(frmSpecGain,
							"Please enter a setup name.",
							"Gain Adjustment", JOptionPane.ERROR_MESSAGE);
					return;
				}
				
				int currentActionIndex = 0;
				for (currentActionIndex = 0; currentActionIndex < panelActions.length; currentActionIndex++) {
					if(!panelActions[currentActionIndex].getSucceeded())
						break;
				}
				
				switch (currentActionIndex) {
				case 0:
					//Background measurement
					
					if(checkOverWriting())
					{
						JOptionPane.showMessageDialog(frmSpecGain,
							"Please inject reference light from the setup "+ txt_SetupName_Spec_Gain.getText() +" in the NeoSpectra module.",
							"Gain Adjustment", JOptionPane.INFORMATION_MESSAGE);
						SpecGainAdjustmentBG();
					}
					break;
					
				/*case 1:
					//Sample measurement
					JOptionPane.showMessageDialog(frmSpecGain,
							"Please insert your sample.",
							"Gain Adjustment", JOptionPane.INFORMATION_MESSAGE);
					SpecGainAdjustmentSample();
					break;
					*/
				case 1:
					//Save settings
					
					logger.info("Get Data of SpecGainAdjustment Started");
					double[][] data = UserInterface.applicationManager.getGainAdjustSpecData();
					logger.info("Get Data of SpecGainAdjustment Finished");
					
					String opticalOptionName = txt_SetupName_Spec_Gain.getText();
					
					logger.info("saveSpecGainSettings function started");
					p2AppManagerStatus status = UserInterface.applicationManager.saveSpecGainSettings(opticalOptionName, data);
					logger.info("saveSpecGainSettings function finished");
					
					if (p2AppManagerStatus.NO_ERROR != status) {

						if (p2AppManagerStatus.DEVICE_BUSY_ERROR != status) {
							// resume checking the status of the device
							UserInterface.checkDeviceStatusThreadStop = false;

//							UserInterface.colorLabel.setForeground(Color.red);
//							UserInterface.colorLabel.setBackground(Color.red);
						}

						JOptionPane.showMessageDialog(frmSpecGain,
								"Failed to save optical setting.",
								"Gain Adjustment", JOptionPane.OK_OPTION);

					}
					
					logger.info("saveInterSpecGainSettings function started");
					status = UserInterface.applicationManager.saveInterSpecGainSettings(opticalOptionName, data);
					logger.info("saveInterSpecGainSettings function finished");
					
					if (p2AppManagerStatus.NO_ERROR != status) {

						if (p2AppManagerStatus.DEVICE_BUSY_ERROR != status) {
							// resume checking the status of the device
							UserInterface.checkDeviceStatusThreadStop = false;

//							UserInterface.colorLabel.setForeground(Color.red);
//							UserInterface.colorLabel.setBackground(Color.red);
						}

						JOptionPane.showMessageDialog(frmSpecGain,
								"Failed to save optical setting.",
								"Gain Adjustment", JOptionPane.OK_OPTION);

					} else {
						logger.info("disabling panel GUI fields started");
						panelReadyRoutine(false);
						logger.info("disabling panel GUI fields finished");
						VariableHelper.setMessage("Saving gain settings started. Please wait...");

//						UserInterface.colorLabel.setForeground(Color.yellow);
//						UserInterface.colorLabel.setBackground(Color.yellow);

						UserInterface.displaySpecOpticalSettings();
						UserInterface.displayInterSpecOpticalSettings();
						
						panelActions[1].setSucceeded(true);

						lbl_Progress_Details_Spec_Gain.setText(getActionsString());
						
						VariableHelper.setMessage("Gain settings saved successfully!");
//						UserInterface.colorLabel.setForeground(Color.green.darker());
//						UserInterface.colorLabel.setBackground(Color.green.darker());

						UserInterface.progressTime = -1;
//						UserInterface.progressPar.setValue(100);
						
						JOptionPane.showMessageDialog(frmSpecGain,
								"Gain settings saved successfully!",
								"Gain Adjustment", JOptionPane.PLAIN_MESSAGE);
						
						onCloseOperation();

					}
					
					break;
				default:
					JOptionPane.showMessageDialog(frmSpecGain,"Unsupported Action!",
							"Gain Adjustment", JOptionPane.OK_OPTION);
					break;
				}
			}

		});
		frmSpecGain.getContentPane().add(btn_Proceed_Spec_Gain, "cell 0 3 3 1,growx, alignx right");
		
		btn_Close_Spec_Gain = new JButton("");
		btn_Close_Spec_Gain.setFont(new Font("Dialog", Font.PLAIN, 12));
		btn_Close_Spec_Gain.setText("Close");
		btn_Close_Spec_Gain.setToolTipText("Close");
		btn_Close_Spec_Gain.setMaximumSize(new Dimension((int)(p2Constants.MAX_WIDTH_OF_FIELD), btn_Close_Spec_Gain.getPreferredSize().height));

		btn_Close_Spec_Gain.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				onCloseOperation();
			}
		});
		frmSpecGain.getContentPane().add(btn_Close_Spec_Gain, "cell 0 3 3 1,growx, alignx right");
	}
	
	private boolean checkOverWriting() {

		String opticalSettings[] = UserInterface.readOpticalSettings();
		
		if (opticalSettings != null) {
			for (String s : opticalSettings) {
				if(s.contains(p2Constants.SpecPrefix))
				{
					if(s.replace(p2Constants.SpecPrefix, "").equals(txt_SetupName_Spec_Gain.getText()))
					{
						int choice = JOptionPane.showConfirmDialog(frmSpecGain
								, "The Setup name " + txt_SetupName_Spec_Gain.getText()
								+ " already exists. Would you like to overwrite the existing settings?"
								, "Gain Adjustment", JOptionPane.YES_NO_OPTION);
						if(choice == JOptionPane.YES_OPTION)
							return true;
						else
							return false;
					}
				}
			}
		}
		return true;
	}
	
	private void onCloseOperation()
	{
		UserInterface.stopEnablingButtons = false;
		// resume checking the status of the device
		UserInterface.checkDeviceStatusThreadStop = false;
		UserInterface.boardReadyRoutine(true);
		frmSpecGain.dispose();
	}
	
	private static String getActionsString()
	{
		String result = "<html>";
		int checkCurrent = 0;
		for(int i = 0; i < panelActions.length; i++)
		{
			if(0 == checkCurrent)
			{
				if(panelActions[i].getSucceeded())
				{
					result += "<font color='green'>" + panelActions[i].getActionName() + " &#10004; </font><br />";
				}
				else
				{
					checkCurrent ++;
					result += "<font color='black'>" + panelActions[i].getActionName() + "</font><br />";
				}
			}
			else
			{
				result += "<font color='gray'>" + panelActions[i].getActionName() + "</font><br />";
			}
		}
		
		result += "</html>";
		return result;
	}
	
	public void SpecGainAdjustmentBG()
	{

		logger.info("SpecGainAdjustmentBG function started");
		// Start RUN
		try{
			// stop checking the status of the device
			UserInterface.checkDeviceStatusThreadStop = true;

			try
			{
				logger.info("setSettings function (reg file rewrite) started");
				//true is for reloading t.reg
				UserInterface.applicationManager.setSettings(resolution, "true");
				logger.info("setSettings function (reg file rewrite) finished");

				SpectroscopyPanel.lastResolutionSelected = resolution;
				SpectroscopyPanel.lastZeroPaddingSelected = zeroPaddingMultiplier;
			}
			catch(Exception ex)
			{
//				UserInterface.colorLabel.setForeground(Color.red);
//				UserInterface.colorLabel.setBackground(Color.red);

				JOptionPane.showMessageDialog(frmSpecGain,
						"Run failed to start. Module setup failed!",
						"Gain Adjustment", JOptionPane.OK_OPTION);

				UserInterface.checkDeviceStatusThreadStop = false;
				return;
			}

			UserInterface.progressTime = p2Constants.adaptiveGainRunTime;
//			UserInterface.progressPar.setValue(0);
			logger.info("runSpecGainAdjBG function started");
			p2AppManagerStatus status = UserInterface.applicationManager.runSpecGainAdjBG(Double.toString(p2Constants.adaptiveGainRunTime));
			logger.info("runSpecGainAdjBG function finished");
			if (p2AppManagerStatus.NO_ERROR != status) {

				if (p2AppManagerStatus.DEVICE_BUSY_ERROR != status) {
					// resume checking the status of the device
					UserInterface.checkDeviceStatusThreadStop = false;

//					UserInterface.colorLabel.setForeground(Color.red);
//					UserInterface.colorLabel.setBackground(Color.red);
				}

				JOptionPane.showMessageDialog(frmSpecGain,
						"Run failed to start: " + UserInterface.convertErrorCodesToMessages(status),
						"Gain Adjustment", JOptionPane.OK_OPTION);

			} else {
				logger.info("disabling panel GUI fields started");
				panelReadyRoutine(false);
				logger.info("disabling panel GUI fields finished");
				VariableHelper.setMessage("BG Measurement started. Please wait...");

//				UserInterface.colorLabel.setForeground(Color.yellow);
//				UserInterface.colorLabel.setBackground(Color.yellow);

			}
		}
		catch(Exception ex)
		{
//			UserInterface.colorLabel.setForeground(Color.red);
//			UserInterface.colorLabel.setBackground(Color.red);

			JOptionPane.showMessageDialog(frmSpecGain,
					"Run failed to start. Please check inputs.",
					"Gain Adjustment", JOptionPane.OK_OPTION);
		}
	}
	
	public void SpecGainAdjustmentSample()
	{
		
		logger.info("SpecGainAdjustmentSample function started");
		// Start RUN
		try{
			// stop checking the status of the device
			UserInterface.checkDeviceStatusThreadStop = true;
			
			UserInterface.progressTime = p2Constants.adaptiveGainRunTime;
//			UserInterface.progressPar.setValue(0);
			logger.info("runSpecGainAdjSample function started");
			p2AppManagerStatus status = UserInterface.applicationManager.runSpecGainAdjSample(Double.toString(p2Constants.adaptiveGainRunTime), apodizationIndex, zeroPaddingMultiplier);
			logger.info("runSpecGainAdjSample function finished");
			if (p2AppManagerStatus.NO_ERROR != status) {
				
				if (p2AppManagerStatus.DEVICE_BUSY_ERROR != status) {
					// resume checking the status of the device
					UserInterface.checkDeviceStatusThreadStop = false;
					
//					UserInterface.colorLabel.setForeground(Color.red);
//					UserInterface.colorLabel.setBackground(Color.red);
				}
				
				JOptionPane.showMessageDialog(frmSpecGain,
						"Run failed to start: " + UserInterface.convertErrorCodesToMessages(status),
						"Gain Adjustment", JOptionPane.OK_OPTION);
				
			} else {
				logger.info("disabling panel GUI fields started");
				panelReadyRoutine(false);
				logger.info("disabling panel GUI fields finished");
				VariableHelper.setMessage("Sample Measurement started. Please wait...");
				
//				UserInterface.colorLabel.setForeground(Color.yellow);
//				UserInterface.colorLabel.setBackground(Color.yellow);
				
			}
		}
		catch(Exception ex)
		{
//			UserInterface.colorLabel.setForeground(Color.red);
//			UserInterface.colorLabel.setBackground(Color.red);
			
			JOptionPane.showMessageDialog(frmSpecGain,
					"Run failed to start. Please check inputs.",
					"Gain Adjustment", JOptionPane.OK_OPTION);
		}
	}
	
	public static void update(Object arg1) {
		if (arg1 instanceof p2AppManagerNotification) {
			logger.info("update method started");
			p2AppManagerNotification resp = (p2AppManagerNotification) arg1;

			switch (resp.getAction()) {
			case 28: // BG Measurement
				InterSpecGainAdjusment();
				break;
			case 23: // Gain adjustment for InterSpec Panel
				if (resp.getStatus() == 0) {

					panelActions[0].setSucceeded(true);

					lbl_Progress_Details_Spec_Gain.setText(getActionsString());

					VariableHelper.setMessage("Background measurement completed successfully!");
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
							frmSpecGain,
							UserInterface.convertErrorCodesToMessages(resp.getStatus()),
							"Gain Adjustment", JOptionPane.OK_OPTION);
				}

				logger.info("switching actuation off started");
				//switch off actuation
				UserInterface.switchOnOFF(false, true);
				logger.info("switching actuation off finished");

				logger.info("enabling panel GUI fields started");
				panelReadyRoutine(true);
				logger.info("enabling panel GUI fields finished");

				// resume checking the status of the device
				UserInterface.checkDeviceStatusThreadStop = false;

				break;
			case 29: // Sample Measurement
				
				// deleted this to make bg adjust do it once
			/*	if (resp.getStatus() == 0) {
					
					panelActions[1].setSucceeded(true);
					
					lbl_Progress_Details_Spec_Gain.setText(getActionsString());
					
					UserInterface.statusLabel.setText("Sample measurement completed successfully!");
					UserInterface.colorLabel.setForeground(Color.green.darker());
					UserInterface.colorLabel.setBackground(Color.green.darker());
					
					UserInterface.progressTime = -1;
					UserInterface.progressPar.setValue(100);
					
				} else {
					UserInterface.colorLabel.setForeground(Color.red);
					UserInterface.colorLabel.setBackground(Color.red);
					
					UserInterface.progressTime = -1;
					UserInterface.progressPar.setValue(100);
					
					JOptionPane.showMessageDialog(
							frmSpecGain,
							UserInterface.convertErrorCodesToMessages(resp.getStatus()),
							"Gain Adjustment", JOptionPane.OK_OPTION);
				}
				
				logger.info("switching actuation off started");
				//switch off actuation
				UserInterface.switchOnOFF(false, true);
				logger.info("switching actuation off finished");
				
				logger.info("enabling panel GUI fields started");
				panelReadyRoutine(true);
				logger.info("enabling panel GUI fields finished");
				
				// resume checking the status of the device
				UserInterface.checkDeviceStatusThreadStop = false;
				*/
				break;
			default:
				// not supported action
				;
			}
		}

	}
	

	private static void InterSpecGainAdjusment() 
	{

		logger.info("InterSpecGainAdjustment function started");
		// Start RUN
		try{
			// stop checking the status of the device
			UserInterface.checkDeviceStatusThreadStop = true;

			try
			{
				//Enforce reloading conf. files
				logger.info("setSettings function (reg file rewrite) started");
				//true is for reloading t.reg
				UserInterface.applicationManager.setSettings(resolution, "true");
				logger.info("setSettings function (reg file rewrite) finished");

				InterSpecPanel.lastResolutionSelected = resolution;
			}
			catch(Exception ex)
			{
//				UserInterface.colorLabel.setForeground(Color.red);
//				UserInterface.colorLabel.setBackground(Color.red);

				JOptionPane.showMessageDialog(frmSpecGain,
						"Run failed to start. Gain adjustment failed!",
						"Gain Adjustment", JOptionPane.OK_OPTION);

				UserInterface.checkDeviceStatusThreadStop = false;
				return;
			}

			UserInterface.progressTime = p2Constants.adaptiveGainRunTime;
//			UserInterface.progressPar.setValue(0);
			logger.info("runInterSpecGainAdj function started");
			p2AppManagerStatus status = UserInterface.applicationManager.runInterSpecGainAdj(Double.toString(p2Constants.adaptiveGainRunTime));
			logger.info("runInterSpecGainAdj function finished");
			if (p2AppManagerStatus.NO_ERROR != status) {

				if (p2AppManagerStatus.DEVICE_BUSY_ERROR != status) {
					// resume checking the status of the device
					UserInterface.checkDeviceStatusThreadStop = false;

//					UserInterface.colorLabel.setForeground(Color.red);
//					UserInterface.colorLabel.setBackground(Color.red);
				}

				JOptionPane.showMessageDialog(frmSpecGain,
						"Run failed to start: " + UserInterface.convertErrorCodesToMessages(status),
						"Gain Adjustment", JOptionPane.OK_OPTION);

			} else {
				logger.info("disabling panel GUI fields started");
				panelReadyRoutine(false);
				logger.info("disabling panel GUI fields finished");
				VariableHelper.setMessage("Gain Adjustment started. Please wait...");

//				UserInterface.colorLabel.setForeground(Color.yellow);
//				UserInterface.colorLabel.setBackground(Color.yellow);

			}
		}
		catch(Exception ex)
		{
//			UserInterface.colorLabel.setForeground(Color.red);
//			UserInterface.colorLabel.setBackground(Color.red);

			JOptionPane.showMessageDialog(frmSpecGain,
					"Run failed to start. Please check inputs.",
					"Gain Adjustment", JOptionPane.OK_OPTION);
		}
	}

	public static void panelReadyRoutine(boolean ready) {
		if (ready) {
			btn_Proceed_Spec_Gain.setEnabled(true);
			btn_Close_Spec_Gain.setEnabled(true);
			
		} else {
			btn_Proceed_Spec_Gain.setEnabled(false);
			btn_Close_Spec_Gain.setEnabled(false);

		}
	}
	
}
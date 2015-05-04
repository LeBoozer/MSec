/*******************************************************************************************************************************************************************
	File	:	ViewWithTechniqueSelection.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*******************************************************************************************************************************************************************
	Class: ViewWithTechniqueSelection
*******************************************************************************************************************************************************************/
namespace MSec
{
    public abstract class ViewWithTechniqueSelection : View
    {
        // The control for the technique selection
        private TechniqueSelection m_controlTechniqueSelection = null;
        protected TechniqueSelection ControlTechniqueSel
        {
            get { return m_controlTechniqueSelection; }
            private set { }
        }

        // Techniques
        protected Technique m_currentTechnique = null;
        public Technique CurrentTechnique
        {
            get { return m_currentTechnique; }
            private set { }
        }
        protected Technique m_techniqueRadish = null;
        protected Technique m_techniqueDCT = null;
        protected Technique m_techniqueWavelet = null;
        protected Technique m_techniqueBMB = null;

        // Constructor
        protected ViewWithTechniqueSelection(TabPage _tabPage, string _nameControlTechniqueSelection) :
            base(_tabPage)
        {
            // Extract technique selection
            m_controlTechniqueSelection = _tabPage.Controls.Find(_nameControlTechniqueSelection, true)[0] as TechniqueSelection;

            // Create techniques
            m_techniqueRadish = Technique.createTechniqueRadish();
            m_techniqueDCT = Technique.createTechniqueDCT();
            m_techniqueWavelet = Technique.createTechniqueWavelet();
            m_techniqueBMB = Technique.createTechniqueBMB();

            // Set default values for: general
            m_techniqueDCT.addAttribute(Technique.ATT_GENERAL_THRESHOLD, m_controlTechniqueSelection.Threshold);
            m_techniqueRadish.addAttribute(Technique.ATT_GENERAL_THRESHOLD, m_controlTechniqueSelection.Threshold);
            m_techniqueWavelet.addAttribute(Technique.ATT_GENERAL_THRESHOLD, m_controlTechniqueSelection.Threshold);
            m_techniqueBMB.addAttribute(Technique.ATT_GENERAL_THRESHOLD, m_controlTechniqueSelection.Threshold);

            // Set default values for: RADISH
            m_techniqueRadish.addAttribute(Technique.ATT_RADISH_GAMMA, m_controlTechniqueSelection.RadishGamma);
            m_techniqueRadish.addAttribute(Technique.ATT_RADISH_SIGMA, m_controlTechniqueSelection.RadishSigma);
            m_techniqueRadish.addAttribute(Technique.ATT_RADISH_NUM_ANGLES, m_controlTechniqueSelection.RadishNumberOfAngles);

            // Set default values for: wavelet
            m_techniqueWavelet.addAttribute(Technique.ATT_WAVELET_ALPHA, m_controlTechniqueSelection.WaveletAlpha);
            m_techniqueWavelet.addAttribute(Technique.ATT_WAVELET_LEVEL, m_controlTechniqueSelection.WaveletLevel);

            // Set default values for: BMB
            m_techniqueBMB.addAttribute(Technique.ATT_BMB_METHOD, m_controlTechniqueSelection.BMBMethod);

            // Set current technique
            if (m_controlTechniqueSelection.CurrentTechniqueID == TechniqueID.RADISH)
                m_currentTechnique = m_techniqueRadish;
            else if (m_controlTechniqueSelection.CurrentTechniqueID == TechniqueID.WAVELET)
                m_currentTechnique = m_techniqueWavelet;
            else if (m_controlTechniqueSelection.CurrentTechniqueID == TechniqueID.DCT)
                m_currentTechnique = m_techniqueDCT;
            else
                m_currentTechnique = m_techniqueBMB;

            // Set attribute events
            m_controlTechniqueSelection.OnTechniqueChanged += (TechniqueID _id) =>
                {
                    if (_id == TechniqueID.RADISH)
                        m_currentTechnique = m_techniqueRadish;
                    else if (_id == TechniqueID.WAVELET)
                        m_currentTechnique = m_techniqueWavelet;
                    else if (_id == TechniqueID.DCT)
                        m_currentTechnique = m_techniqueDCT;
                    else
                        m_currentTechnique = m_techniqueBMB;
                };

            m_controlTechniqueSelection.OnGeneralThresholdChanged += (decimal _v) =>
                {
                    m_techniqueDCT.addAttribute(Technique.ATT_GENERAL_THRESHOLD, m_controlTechniqueSelection.Threshold);
                    m_techniqueRadish.addAttribute(Technique.ATT_GENERAL_THRESHOLD, m_controlTechniqueSelection.Threshold);
                    m_techniqueWavelet.addAttribute(Technique.ATT_GENERAL_THRESHOLD, m_controlTechniqueSelection.Threshold);
                    m_techniqueBMB.addAttribute(Technique.ATT_GENERAL_THRESHOLD, m_controlTechniqueSelection.Threshold);
                };

            m_controlTechniqueSelection.OnRadishGammaChanged += (decimal _v) =>
                { m_techniqueRadish.addAttribute(Technique.ATT_RADISH_GAMMA, m_controlTechniqueSelection.RadishGamma); };
            m_controlTechniqueSelection.OnRadishSigmaChanged += (decimal _v) =>
                { m_techniqueRadish.addAttribute(Technique.ATT_RADISH_SIGMA, m_controlTechniqueSelection.RadishSigma); };
            m_controlTechniqueSelection.OnRadishNumberOfAnglesChanged += (decimal _v) =>
                { m_techniqueRadish.addAttribute(Technique.ATT_RADISH_NUM_ANGLES, m_controlTechniqueSelection.RadishNumberOfAngles); };

            m_controlTechniqueSelection.OnWaveletAlphaChanged += (decimal _v) =>
                { m_techniqueWavelet.addAttribute(Technique.ATT_WAVELET_ALPHA, m_controlTechniqueSelection.WaveletAlpha); };
            m_controlTechniqueSelection.OnWaveletLevelChanged += (decimal _v) =>
                { m_techniqueWavelet.addAttribute(Technique.ATT_WAVELET_LEVEL, m_controlTechniqueSelection.WaveletLevel); };

            m_controlTechniqueSelection.OnBMBMethodChanged += (int _v) =>
                { m_techniqueBMB.addAttribute(Technique.ATT_BMB_METHOD, m_controlTechniqueSelection.BMBMethod); };
        }

        // Locks the technique selection control
        protected void lockTechniqueSelection()
        {
            // Disable control
            m_controlTechniqueSelection.Enabled = false;
        }

        // Unlocks the technique selection control
        protected void unlockTechniqueSelection()
        {
            // Enable control
            m_controlTechniqueSelection.Enabled = true;
        }
    }
}

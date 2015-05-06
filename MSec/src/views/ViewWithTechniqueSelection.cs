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
        protected Technique         m_singleTechnique = null;
        protected List<Technique>   m_multipleTechniques = new List<Technique>();
        public TechniqueSelection.eMode OperatorMode
        {
            get { return m_controlTechniqueSelection.OperationMode; }
            private set { }
        }
        public Technique SingleModeTechnique
        {
            get { return m_singleTechnique; }
            private set { }
        }
        public List<Technique> MultipleModeTechniques
        {
            get { return m_multipleTechniques; }
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
            if (m_controlTechniqueSelection.OperationMode == TechniqueSelection.eMode.SINGLE)
            {
                if (m_controlTechniqueSelection.CurrentTechniqueIDs == TechniqueID.RADISH)
                    m_singleTechnique = m_techniqueRadish;
                else if (m_controlTechniqueSelection.CurrentTechniqueIDs == TechniqueID.WAVELET)
                    m_singleTechnique = m_techniqueWavelet;
                else if (m_controlTechniqueSelection.CurrentTechniqueIDs == TechniqueID.DCT)
                    m_singleTechnique = m_techniqueDCT;
                else
                    m_singleTechnique = m_techniqueBMB;
            }
            else
            {
                m_multipleTechniques.Clear();
                if ((m_controlTechniqueSelection.CurrentTechniqueIDs & TechniqueID.DCT) == TechniqueID.DCT)
                    m_multipleTechniques.Add(m_techniqueDCT);
                if ((m_controlTechniqueSelection.CurrentTechniqueIDs & TechniqueID.RADISH) == TechniqueID.RADISH)
                    m_multipleTechniques.Add(m_techniqueRadish);
                if ((m_controlTechniqueSelection.CurrentTechniqueIDs & TechniqueID.WAVELET) == TechniqueID.WAVELET)
                    m_multipleTechniques.Add(m_techniqueWavelet);
                if ((m_controlTechniqueSelection.CurrentTechniqueIDs & TechniqueID.BMB) == TechniqueID.BMB)
                    m_multipleTechniques.Add(m_techniqueBMB);
            }

            // Set attribute events
            m_controlTechniqueSelection.OnTechniqueIDsChanged += (TechniqueID _id) =>
                {
                    if (m_controlTechniqueSelection.OperationMode == TechniqueSelection.eMode.SINGLE)
                    {
                        if (_id == TechniqueID.RADISH)
                            m_singleTechnique = m_techniqueRadish;
                        else if (_id == TechniqueID.WAVELET)
                            m_singleTechnique = m_techniqueWavelet;
                        else if (_id == TechniqueID.DCT)
                            m_singleTechnique = m_techniqueDCT;
                        else
                            m_singleTechnique = m_techniqueBMB;
                    }
                    else
                    {
                        m_multipleTechniques.Clear();
                        if ((_id & TechniqueID.DCT) == TechniqueID.DCT)
                            m_multipleTechniques.Add(m_techniqueDCT);
                        if ((_id & TechniqueID.RADISH) == TechniqueID.RADISH)
                            m_multipleTechniques.Add(m_techniqueRadish);
                        if ((_id & TechniqueID.WAVELET) == TechniqueID.WAVELET)
                            m_multipleTechniques.Add(m_techniqueWavelet);
                        if ((_id & TechniqueID.BMB) == TechniqueID.BMB)
                            m_multipleTechniques.Add(m_techniqueBMB);
                    }
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

/*******************************************************************************************************************************************************************
	File	:	JobParameter.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/*******************************************************************************************************************************************************************
	Class: JobParameter
*******************************************************************************************************************************************************************/
namespace MSec
{
    public sealed class JobParameter<_R>
    {
        // The cancellation token
        private CancellationToken m_cancellationToken;
        public bool IsCancellationRequested
        {
            get { return m_cancellationToken.IsCancellationRequested; }
            private set { }
        }

        // The original data
        private object[] m_data = null;
        public object[] Data
        {
            get { return m_data; }
            private set { }
        }

        // Exception error
        private Exception m_error = null;
        public Exception Error
        {
            get { return m_error; }
            set { m_error = value; }
        }

        // The job's result
        private _R m_jobResult = default(_R);
        public _R Result
        {
            get { return m_jobResult; }
            set { m_jobResult = value; }
        }

        // Constructor
        public JobParameter(object[] _data, CancellationToken _token)
        {
            m_data = _data;
            m_cancellationToken = _token;
        }

        // Cancels the associated job
        public void dropJob()
        {
            m_cancellationToken.ThrowIfCancellationRequested();
        }
    }
}

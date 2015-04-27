/*******************************************************************************************************************************************************************
	File	:	Job.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************************************************************************************************************************
	Class: Job
*******************************************************************************************************************************************************************/
namespace MSec
{
    public sealed class Job<_R>
    {
        // Delegate for the job function function
        public delegate _R delegate_job(params object[] _args);

        // Delegate for the job finish function function
        public delegate void delegate_job_done(_R _result, Exception _error);

        // The lock object
        private object              m_jobLock = new object();

        // True if the job is enqueued
        private bool                m_isEnqueued = false;
        public bool isEnqueued
        {
            get
            {
                bool r = false;
                lock (m_jobLock)
                {
                    r = m_isEnqueued;
                }
                return r;
            }
            private set { }
        }

        // True if the job is done
        private bool                m_jobDone = false;
        public bool isDone
        {
            get 
            {
                bool r = false;
                lock (m_jobLock)
                {
                    r = m_jobDone;
                }
                return r;
            }
            private set { }
        }

        // The internal task
        private Task<_R>            m_taskObject = null;

        // The result value
        private _R                  m_result = default(_R);
        public _R Result
        {
            get
            {
                _R r = default(_R);
                lock (m_jobLock)
                {
                    r = m_result;
                }
                return r;
            }
            private set { }
        }

        // The error value
        private Exception           m_error = null;
        public Exception Error
        {
            get
            {
                Exception r = null;
                lock (m_jobLock)
                {
                    r = m_error;
                }
                return r;
            }
            private set { }
        }
    
        // The job function
        private delegate_job        m_jobFunc = null;
        public delegate_job JobFunc
        {
            get { return m_jobFunc; }
            private set { }
        }

        // The job-done function
        private delegate_job_done   m_jobDoneFunc = null;
        public delegate_job_done JobDoneFunc
        {
            get { return m_jobDoneFunc; }
            private set { }
        }

        // Static constructor -> only allow nullable types for _R
        static Job()
        {
            // Check
            if (default(_R) is ValueType && Nullable.GetUnderlyingType(typeof(_R)) == null)
            {
                throw new InvalidOperationException(string.Format("Cannot instantiate with non-nullable type: {0}", typeof(_R)));
            }
        }

        // Normal constructor
        public Job(delegate_job _jobFunc, delegate_job_done _jobDoneFunc, bool _start = true, params object[] _params)
        {
            // Copy
            m_jobFunc = _jobFunc;
            m_jobDoneFunc = _jobDoneFunc;

            // Auto start?
            if(_start == true)
                enqueue(this, _params);
        }

        // Waits for a certain amount of milliseconds until the job is either finished or the time-out event occurs
        // Returns true, if the job is done!
        public bool waitForDone(int _milliseconds = -1)
        {
            // Local variables
            Task t = null;

            // Lock
            lock (m_jobLock)
            {
                // Already done?
                if (m_jobDone == true)
                    return true;
                t = m_taskObject;
            }

            // Wait
            return t.Wait(_milliseconds);
        }

        // Will be called as soon as the job has been enqueued for execution
        private void _enqueued(Task<_R> _task)
        {
            // Lock
            lock (m_jobLock)
            {
                // Copy task
                m_taskObject = _task;

                // Set flag
                m_isEnqueued = true;
            }
        }

        // Will be called as soon as the job has been executed
        private void _done(_R _result, Exception _error)
        {
            // Lock
            lock (m_jobLock)
            {
                // Copy values
                m_result = _result;
                m_error = _error;

                // Set flag
                m_jobDone = true;
            }
        }

        // Enqueues the defined job
        public static Job<_R> enqueue(Job<_R> _job, params object[] _jobParams)
        {
            // Local parameters
            Task<_R> task = null;
            _JobParameter p = new _JobParameter(_jobParams);

            // Create wrapper function
            Func<object, _R> f = new Func<object, _R>((object _data) =>
            {
                // Local parameters
                _R result = default(_R);
                Exception error = null;

                // Execute job
                try
                {
                    if (_job.JobFunc != null)
                        result = _job.JobFunc((_data as _JobParameter).m_data);
                }
                catch(Exception _e)
                {
                    // Copy error
                    error = _e;
                }

                // Set result
                _job.Result = result;

                // Excute finish function
                try
                {
                    if (_job.JobDoneFunc != null)
                        _job.JobDoneFunc(result, error);
                }
                catch(Exception _e)
                {
                    // Copy error
                    error = _e;
                }

                // Job is done
                _job._done(result, error);

                return result;
            });

            // Start task
            if (_job.isEnqueued == true)
                return _job;
            task = new Task<_R>(f, p);
            _job._enqueued(task);
            task.Start();

            return _job;
        }

        // Creates a job for computing the percuptual hash for a certain image source by means of a defined technique
        public static Job<HashData> createJobComputeHash(ImageSource _src, Technique _technique,
            bool _recompute = false, bool _autoStart = true)
        {
            return createJobComputeHash(_src, _technique, null, _recompute, _autoStart);
        }

        // Creates a job for computing the percuptual hash for a certain image source by means of a defined technique
        public static Job<HashData> createJobComputeHash(ImageSource _src, Technique _technique, delegate_job_done _jobDoneFunc,
            bool _recompute = false, bool _autoStart = true)
        {
            // Local variables
            Job<HashData> job = null;

            // Check parameter
            if (_src == null || _technique == null)
                return null;

            // Create job
            job = new Job<HashData>((object[] _params) =>
            {
                // Calculate hash
                return _technique.computeHash(_src, _recompute);
            },
            (HashData _result, Exception _error) =>
            {
                // Call user function
                if (_jobDoneFunc != null)
                    _jobDoneFunc((_R)_result, _error);
            });

            // Auto start job?
            if(_autoStart == true)
            {
                // Enqueue job
                Job<HashData>.enqueue(job, null);
            }

            return job;
        }

        // Creates a job for comparing two computed perceptual hashes by means of a defined technique
        public static Job<ComparativeData> createJobCompareHashData(ImageSource _src0, ImageSource _src1, Technique _technique,
            bool _autoStart = true)
        {
            return createJobCompareHashData(_src0, _src1, _technique, _autoStart);
        }

        // Creates a job for comparing two computed perceptual hashes by means of a defined technique
        public static Job<ComparativeData> createJobCompareHashData(ImageSource _src0, ImageSource _src1, Technique _technique, delegate_job_done _jobDoneFunc,
            bool _autoStart = true)
        {
            // Local variables
            Job<ComparativeData> job = null;

            // Check parameter
            if (_src0 == null || _src1 == null || _technique == null)
                return null;

            // Create job
            job = new Job<ComparativeData>((object[] _params) =>
            {
                // Compare hashes
                return _technique.compareHashData(_src0, _src1);
            },
            (ComparativeData _result, Exception _error) =>
            {
                // Call user function
                if (_jobDoneFunc != null)
                    _jobDoneFunc((_R)_result, _error);
            });

            // Auto start job?
            if (_autoStart == true)
            {
                // Enqueue job
                Job<ComparativeData>.enqueue(job, null);
            }

            return job;
        }

        // Internal wrapper for the job parameter
        private sealed class _JobParameter
        {
            public object[] m_data;
            public _JobParameter(object[] _data)
            {
                m_data = _data;
            }
        }
    }
}

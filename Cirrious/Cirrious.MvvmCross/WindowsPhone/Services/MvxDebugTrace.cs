#region Copyright
// <copyright file="MvxDebugTrace.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion

using System.Diagnostics;
using Cirrious.MvvmCross.Interfaces.Services;

namespace Cirrious.MvvmCross.WindowsPhone.Services
{
    public class MvxDebugTrace : IMvxTrace
    {
        #region IMvxTrace Members

        public void Trace(string tag, string message)
        {
            Debug.WriteLine(tag + ":" + message);
        }

        public void Trace(string tag, string message, params object[] args)
        {
            Debug.WriteLine(tag + ":" + message, args);
        }

        #endregion
    }
}
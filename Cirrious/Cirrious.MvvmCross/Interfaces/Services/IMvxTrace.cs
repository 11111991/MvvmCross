#region Copyright
// <copyright file="IMvxTrace.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion
namespace Cirrious.MvvmCross.Interfaces.Services
{
    public interface IMvxTrace
    {
        void Trace(string message);
        void Trace(string message, params object[] args);
    }
}
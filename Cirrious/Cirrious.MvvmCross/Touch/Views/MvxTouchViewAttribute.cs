#region Copyright

// <copyright file="MvxTouchViewAttribute.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

using System;

namespace Cirrious.MvvmCross.Touch.Views
{
	public class MvxTouchViewAttribute : Attribute
	{
		public MvxTouchViewDisplayType DisplayType {get;set;}
		
		public MvxTouchViewAttribute (MvxTouchViewDisplayType displayType)
		{
			DisplayType = displayType;	
		}
	}
}


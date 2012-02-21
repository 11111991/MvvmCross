# MvvmCross

This project provides a cross-platform mvvm mobile development framework built on top of Silverlight for WP7, Mono for Android and MonoTouch for iOS.

# Getting started

To learn about what MVVM is... please go look on Bing, Google, StackOverflow or somewhere!

To see how MvvmCross provides ViewModels, Views and bindings, see the tutorial - https://github.com/slodge/MvvmCross/wiki/Tutorial

# The story...

This project was born from:

- a branch of the MonoCross project, moving away from MVC and towards MVVM
- an extension project from www.Cirrious.com
- some ideas from MvvmLight
- some ideas from Phone7.Fx (OpenNetCF?)

# Current state

Currently working:

- Android 
- Console
- WindowsPhone 
- Touch - mostly working but iPhone only - iPad master/detail/popup/etc all to follow
- CustomerManagement sample
- A Tutorial sample

Currently not progressed:

- Book sample

Will not be progressed:

- WebKit - simply don't believe it belongs here...

# Future direction

Under consideration

- Blendability
- Test integration
- Better Samples
- More cross platfrom services (accelerometer, contacts, sql, etc)

# Licensing

This project is developed and distributed under Ms-Pl - see http://opensource.org/licenses/ms-pl.html

- MonoCross was the original starting point for this project, and was used as a reference under MIT - please see http://code.google.com/p/monocross/ for original details.
- Phone7.Fx is redistributed and modified here under Ms-PL - please see http://phone7.codeplex.com for original details.
- Tiny bits of MvvmLight are redistributed and modified here under MIT - please see http://mvvmlight.codeplex.com/ for original details.
- NewtonSoft.Json is redistributed and modified here under MIT - please see http://json.codeplex.com for original details. 
- The original work on the JSON.Net port to MonoTouch and MonoDroid was done by @ChrisNTR - https://github.com/chrisntr/Newtonsoft.Json

- To be documented: MonoTouch.Dialog, MonoDroid.Dialog (not currently used), MonoTouch.NinePatch (not currently used), OPenNetCF IoC (used from wtihin Phone7.Fx?)

# Thanks

Thanks to McCannLondon for sponsoring part of this work - http://blogs.mccannlondon.co.uk/
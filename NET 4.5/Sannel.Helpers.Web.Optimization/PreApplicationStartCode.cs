/*
Copyright 2013 Sannel Software, L.L.C.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.Web.Optimization
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class PreApplicationStartCode
	{
		private static bool startWasCalled = false;
		public static void Start()
		{
			if (!PreApplicationStartCode.startWasCalled)
			{
				PreApplicationStartCode.startWasCalled = true;
				DynamicModuleUtility.RegisterModule(typeof(MediaQueryEnablerModule));
			}
		}
	}
}

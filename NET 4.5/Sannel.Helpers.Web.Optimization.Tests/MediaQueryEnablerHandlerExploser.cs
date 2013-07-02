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
using Sannel.Web.Optimization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sannel.Helpers.Web.Optimization.Tests
{
	public class MediaQueryEnablerHandlerExploser : MediaQueryEnablerHandler
	{
		public void FixFileExposed(String filepath, TextWriter writer)
		{
			base.FixFile(filepath, writer);
		}

		public void ProcessRequestExposed(HttpRequestBase request, HttpResponseBase response, HttpServerUtilityBase server)
		{
			base.ProcessRequest(request, response, server);
		}
	}
}

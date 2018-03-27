﻿// Papercut
//
// Copyright © 2008 - 2012 Ken Robertson
// Copyright © 2013 - 2017 Jaben Cargman
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


namespace Papercut.WebUI.Test.Base
{
    using System.Collections.ObjectModel;
    using System.IO;

    using Common.Helper;

    using Core.Domain.Paths;
    using System.Reflection;

    public class ServerPathTemplateProviderService : IPathTemplatesProvider
    {
        public ServerPathTemplateProviderService()
        {
            var basePath = Path.GetDirectoryName(typeof(ServerPathTemplateProviderService).GetTypeInfo().Assembly.Location);
            var messageStoragePath = Path.Combine(basePath, $"Incoming-{StringHelpers.SmallRandomString()}");

            if (!Directory.Exists(messageStoragePath))
            {
                Directory.CreateDirectory(messageStoragePath);
            }

            PathTemplates = new ObservableCollection<string>(new[] {messageStoragePath});
        }

        public ObservableCollection<string> PathTemplates { get; }
    }
}
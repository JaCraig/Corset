﻿/*
Copyright 2016 James Craig

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

using Canister.Interfaces;

namespace Corset.Registration
{
    /// <summary>
    /// Registration extension methods
    /// </summary>
    public static class CorsetRegistration
    {
        /// <summary>
        /// Registers the aspectus library with the bootstrapper.
        /// </summary>
        /// <param name="bootstrapper">The bootstrapper.</param>
        /// <returns>The bootstrapper</returns>
        public static ICanisterConfiguration? RegisterCorset(this ICanisterConfiguration? bootstrapper) => bootstrapper?.AddAssembly(typeof(CorsetRegistration).Assembly);
    }
}
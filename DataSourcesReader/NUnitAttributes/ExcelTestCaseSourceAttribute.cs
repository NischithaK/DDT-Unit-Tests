﻿using System;
using System.Collections.Generic;
using DataSourcesReaders.NUnitAttributes;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace DataSourcesReaders
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ExcelTestCaseSourceAttribute : BaseDataSourceAttribute
    {
        public ExcelTestCaseSourceAttribute(string filePath, string sheetName)
            : this(filePath, sheetName, null)
        {
        }

        public ExcelTestCaseSourceAttribute(string filePath, string sheetName, Type dataType)
            : base(new ExcelTestCaseReader(filePath, sheetName), dataType)
        {
        }

        public override IEnumerable<TestMethod> BuildFrom(IMethodInfo method, Test suite)
        {
            foreach (var testCases in GetTestCases())
            {
                yield return Builder.BuildTestMethod(method, suite, testCases);
            }
        }
    }
}
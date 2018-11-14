﻿using System;
using System.Reflection;
using System.Linq;
using System.IO;
using Xunit;
using Standard.Data.JsonPlus;

namespace Standard.Data.JsonPlus.Tests
{
    public class ExampleTest
    {
        private JPlusContext GetEmbedFileContent(string fileName)
        {
#if NETSTANDARD
            Assembly assembly = typeof(ExampleTest).GetTypeInfo().Assembly;
#else
            Assembly assembly = Assembly.GetExecutingAssembly();
#endif

            string resourceName = string.Format("Standard.Data.JsonPlus.Tests.Resource.{0}", fileName);

            return JPlusFactory.FromResource(resourceName, assembly);
        }

        [Fact]
        public void CanParseHelloFile()
        {
            JPlusContext ctx = GetEmbedFileContent("Hello.bsd");
            var val = ctx.GetString("root.simple-string");
            Assert.Equal("Hello world", val);
        }

        [Fact]
        public void CanParseSimpleSubstitutionFile()
        {
            JPlusContext ctx = GetEmbedFileContent("SimpleSub.bsd");
            var val = ctx.GetString("root.simple-string");
            Assert.Equal("Hello world", val);
        }

        [Fact]
        public void CanParseObjectMergeFile()
        {
            JPlusContext ctx = GetEmbedFileContent("ObjectMerge.bsd");

            var val1 = ctx.GetString("root.some-object.property1");
            var val2 = ctx.GetString("root.some-object.property2");
            var val3 = ctx.GetString("root.some-object.property3");

            Assert.Equal("123", val1);
            Assert.Equal("456", val2);
            Assert.Equal("789", val3);
        }

        [Fact]
        public void CanParseFallbackFile()
        {
            JPlusContext baseContext = GetEmbedFileContent("FallbackBase.bsd");
            JPlusContext userContext = GetEmbedFileContent("FallbackUser.bsd");
            JPlusContext merged = userContext.WithFallback(baseContext);

            var val1 = merged.GetString("root.some-property1");
            var val2 = merged.GetString("root.some-property2");
            var val3 = merged.GetString("root.some-property3");

            Assert.Equal("123", val1);
            Assert.Equal("456", val2);
            Assert.Equal("789", val3);
        }

        /*
        #todo
        [Fact]
        public void CanParseExternalRefFile()
        {
            string text = GetEmbedFileContent("ExternalRef.bsd").ToString();

            // in this example we use a file resolver as the include mechanism
            // but could be replaced with e.g. a resolver for assembly resources
            Func<string, ConfonRoot> fileResolver = null;

            fileResolver = fileName =>
                {
                    var content = GetEmbedFileContent(fileName).ToString();

                    //var content = File.ReadAllText(fileName);
                    var parsed = ConfonParser.Parse(content, fileResolver);
                    return parsed;
                };

            var config = ConfonFactory.ParseString(text, fileResolver);

            var val1 = config.GetInt32("root.some-property.foo");
            var val2 = config.GetInt32("root.some-property.bar");
            var val3 = config.GetInt32("root.some-property.baz");

            Assert.Equal(123, val1);
            Assert.Equal(234, val2);
            Assert.Equal(789, val3);
        }
        */
    }
}
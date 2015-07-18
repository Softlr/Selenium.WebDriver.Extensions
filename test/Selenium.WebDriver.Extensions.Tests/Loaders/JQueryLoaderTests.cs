﻿namespace OpenQA.Selenium.Tests.Loaders
 {
     using System;
     using System.Diagnostics.CodeAnalysis;
     using System.Linq;
     using OpenQA.Selenium.Loaders;
     using Xunit;

     [Trait("Category", "Unit")]
     [ExcludeFromCodeCoverage]
     [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
     [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
     public class JQueryLoaderTests
     {
         [Fact]
         public void ShouldThrowExceptionWhenLoadingScriptWithNullArguments()
         {
             // Given
             var loader = new JQueryLoader();

             // When
             Action action = () => loader.LoadScript(null);

             // Then
             var ex = Assert.Throws<ArgumentNullException>(action);
             Assert.Equal("args", ex.ParamName);
         }

         [Fact]
         public void ShouldThrowExceptionWhenLoadingLoadScriptWithEmptyArguments()
         {
             // Given
             var loader = new JQueryLoader();

             // When
             Action action = () => loader.LoadScript(Enumerable.Empty<string>().ToArray());

             // Then
             Assert.Throws<LoaderException>(action);
         }

         [Fact]
         public void ShouldGetLibraryUri()
         {
             // Given
             var loader = new JQueryLoader();

             // When
             var uri = loader.LibraryUri;

             // Then
             Assert.NotNull(uri);
         }

         [Fact]
         public void ShouldLoadScript()
         {
             // Given
             var loader = new JQueryLoader();

             // When
             var uri = loader.LoadScript("http://example.com");

             // Then
             Assert.NotNull(uri);
         }
     }
 }

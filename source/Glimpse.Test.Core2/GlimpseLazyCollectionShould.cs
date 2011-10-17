﻿using System;
using System.Linq;
using Glimpse.Core2;
using Glimpse.Core2.Extensibility;
using Xunit;

namespace Glimpse.Test.Core2
{
    public class GlimpseLazyCollectionShould
    {
        [Fact]
        public void Construct()
        {
            var collection = new GlimpseLazyCollection<IGlimpsePlugin,IGlimpsePluginMetadata>();

            Assert.NotNull(collection);
        }

        [Fact]
        public void AddPlugin()
        {
            var collection = new GlimpseLazyCollection<IGlimpsePlugin, IGlimpsePluginMetadata>();

            collection.Add(new Lazy<IGlimpsePlugin, IGlimpsePluginMetadata>(()=> new TestPlugin(), new GlimpsePluginAttribute()));

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        public void RemovePlugin()
        {
            var collection = new GlimpseLazyCollection<IGlimpsePlugin, IGlimpsePluginMetadata>();

            collection.Discoverability.Discover();

            Assert.Equal(1, collection.Count);
            
            collection.Remove(collection.First());

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        public void ReadPartMetadata()
        {
            var collection = new GlimpseLazyCollection<IGlimpsePlugin, IGlimpsePluginMetadata>();

            collection.Discoverability.Discover();

            Assert.Equal(1, collection.Count);

            Assert.Equal(typeof(string), collection.First().Metadata.RequestContextType);
        }
    }
}
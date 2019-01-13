﻿using NUnit.Framework;
using System;
using System.Text;
using rclcs;

namespace rclcs.TestNativeMethods
{
    [TestFixture]
    public class RCL
    {
        [Test]
        public void GetZeroInitializedContext()
        {
            rcl_context_t context = NativeMethods.rcl_get_zero_initialized_context();
        }

        [Test]
        public void GetDefaultAllocator()
        {
            rcl_allocator_t allocator = NativeMethods.rcl_get_default_allocator();
        }

        [Test]
        public void GetZeroInitializedInitOptions()
        {
            rcl_init_options_t init_options = NativeMethods.rcl_get_zero_initialized_init_options();
        }

        [Test]
        public void InitOptionsInit()
        {
            rcl_init_options_t init_options = NativeMethods.rcl_get_zero_initialized_init_options();
            rcl_allocator_t allocator = NativeMethods.rcl_get_default_allocator();
            int ret = NativeMethods.rcl_init_options_init(ref init_options, allocator);
            Assert.That((RCLReturnEnum)ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));
        }

        [Test]
        public void GetErrorString()
        {
            NativeMethods.rcl_reset_error();
            string messageString = Utils.GetRclErrorString();
            Assert.That(messageString, Is.EqualTo("error not set"));
        }


        [Test]
        public void ResetError()
        {
            NativeMethods.rcl_reset_error();
        }


        [Test]
        public void InitShutdownFinalize()
        {
            RCLReturnEnum ret;
            NativeMethods.rcl_reset_error();
            rcl_init_options_t init_options = NativeMethods.rcl_get_zero_initialized_init_options();
            rcl_allocator_t allocator = NativeMethods.rcl_get_default_allocator();
            ret = (RCLReturnEnum)NativeMethods.rcl_init_options_init(ref init_options, allocator);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));

            rcl_context_t context = NativeMethods.rcl_get_zero_initialized_context();
            
            ret = (RCLReturnEnum)NativeMethods.rcl_init(0, null, ref init_options, ref context);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK), Utils.PopRclErrorString());

            Assert.That(NativeMethods.rcl_context_is_valid(ref context), Is.True);
            ret = (RCLReturnEnum)NativeMethods.rcl_shutdown(ref context);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));

            ret = (RCLReturnEnum)NativeMethods.rcl_context_fini(ref context);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));
        }

        [Test]
        public void InitValidArgs()
        {
            rcl_init_options_t init_options = NativeMethods.rcl_get_zero_initialized_init_options();
            rcl_allocator_t allocator = NativeMethods.rcl_get_default_allocator();
            NativeMethods.rcl_init_options_init(ref init_options, allocator);
            rcl_context_t context = NativeMethods.rcl_get_zero_initialized_context();

            RCLReturnEnum ret = (RCLReturnEnum)NativeMethods.rcl_init(2, new string[] { "foo", "bar" }, ref init_options, ref context);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));

            Assert.That(NativeMethods.rcl_context_is_valid(ref context), Is.True);
            ret = (RCLReturnEnum)NativeMethods.rcl_shutdown(ref context);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));

            ret = (RCLReturnEnum)NativeMethods.rcl_context_fini(ref context);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));
        }
    }

    [TestFixture]
    public class Node
    {
        rcl_context_t context;

        [SetUp]
        public void SetUp()
        {
            rcl_init_options_t init_options = NativeMethods.rcl_get_zero_initialized_init_options();
            rcl_allocator_t allocator = NativeMethods.rcl_get_default_allocator();
            NativeMethods.rcl_init_options_init(ref init_options, allocator);
            context = NativeMethods.rcl_get_zero_initialized_context();

            NativeMethods.rcl_init(0, null, ref init_options, ref context);
        }

        [TearDown]
        public void TearDown()
        {
            NativeMethods.rcl_shutdown(ref context);
            NativeMethods.rcl_context_fini(ref context);
        }

        [Test]
        public void GetZeroInitializedNode()
        {
            rcl_node_t node = NativeMethods.rcl_get_zero_initialized_node();
        }

        [Test]
        public void NodeGetDefaultOptions()
        {
            rcl_node_options_t defaultNodeOptions = NativeMethods.rcl_node_get_default_options();
        }

        [Test]
        public void NodeInit()
        {
            rcl_node_t node = NativeMethods.rcl_get_zero_initialized_node();
            rcl_node_options_t defaultNodeOptions = NativeMethods.rcl_node_get_default_options();

            string name = "node_test";
            string nodeNamespace = "/ns";

            RCLReturnEnum ret = (RCLReturnEnum)NativeMethods.rcl_node_init(ref node, name, nodeNamespace, ref context, ref defaultNodeOptions);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));

            NativeMethods.rcl_node_fini(ref node);
        }


        [Test]
        public void NodeGetNamespace()
        {
            rcl_node_t node = NativeMethods.rcl_get_zero_initialized_node();
            rcl_node_options_t defaultNodeOptions = NativeMethods.rcl_node_get_default_options();

            string nodeName = "node_test";
            string nodeNamespace = "/ns";
            RCLReturnEnum ret = (RCLReturnEnum)NativeMethods.rcl_node_init(ref node, nodeName, nodeNamespace, ref context, ref defaultNodeOptions);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));

            string nodeNameFromRcl = MarshallingHelpers.PtrToString(NativeMethods.rcl_node_get_name(ref node));
            Assert.That("node_test", Is.EqualTo(nodeNameFromRcl));

            NativeMethods.rcl_node_fini(ref node);
        }

        [Test]
        public void NodeGetName()
        {
            rcl_node_t node = NativeMethods.rcl_get_zero_initialized_node();
            rcl_node_options_t defaultNodeOptions = NativeMethods.rcl_node_get_default_options();

            string name = "node_test";
            string nodeNamespace = "/ns";
            NativeMethods.rcl_node_init(ref node, name, nodeNamespace, ref context, ref defaultNodeOptions);

            string nodeNamespaceFromRcl = MarshallingHelpers.PtrToString(NativeMethods.rcl_node_get_namespace(ref node));
            Assert.That("/ns", Is.EqualTo(nodeNamespaceFromRcl));

            NativeMethods.rcl_node_fini(ref node);
        }

        [Test]
        public void NodeIsValid()
        {
            rcl_node_t node = NativeMethods.rcl_get_zero_initialized_node();
            rcl_node_options_t defaultNodeOptions = NativeMethods.rcl_node_get_default_options();

            string name = "node_test";
            string nodeNamespace = "/ns";
            NativeMethods.rcl_node_init(ref node, name, nodeNamespace, ref context, ref defaultNodeOptions);

            NativeMethods.rcl_node_fini(ref node);
        }

    }

    [TestFixture]
    public class Publisher
    {
        rcl_context_t context;
        rcl_node_t node;

        [SetUp]
        public void SetUp()
        {
            rcl_init_options_t init_options = NativeMethods.rcl_get_zero_initialized_init_options();
            rcl_allocator_t allocator = NativeMethods.rcl_get_default_allocator();
            NativeMethods.rcl_init_options_init(ref init_options, allocator);
            context = NativeMethods.rcl_get_zero_initialized_context();

            NativeMethods.rcl_init(0, null, ref init_options, ref context);

            node = NativeMethods.rcl_get_zero_initialized_node();
            rcl_node_options_t defaultNodeOptions = NativeMethods.rcl_node_get_default_options();

            string name = "publisher_test";
            string nodeNamespace = "/ns";
            NativeMethods.rcl_node_init(ref node, name, nodeNamespace, ref context, ref defaultNodeOptions);
        }

        [TearDown]
        public void TearDown()
        {
            NativeMethods.rcl_node_fini(ref node);
            NativeMethods.rcl_shutdown(ref context);
            NativeMethods.rcl_context_fini(ref context);
        }

        [Test]
        public void PublisherGetDefaultOptions()
        {
            rcl_publisher_options_t publisherOptions = NativeMethods.rcl_publisher_get_default_options();
        }

        [Test]
        public void GetZeroInitializedPublisher()
        {
            rcl_publisher_t publisher = NativeMethods.rcl_get_zero_initialized_publisher();
        }

        //[Test]
        //public void PublisherInit()
        //{
        //    RCLReturnEnum ret;
        //    //rcl_publisher_t publisher = NativeMethods.rcl_get_zero_initialized_publisher();

        //}
    }
}
#if defined(_MSC_VER)
    #define RCLDOTNET_EXPORT __declspec(dllexport)
    #define RCLDOTNET_IMPORT __declspec(dllimport)
    #define RCLDOTNET_CDECL __cdecl
#elif defined(__GNUC__)
    #define RCLDOTNET_EXPORT __attribute__((visibility("default")))
    #define RCLDOTNET_IMPORT
    #define RCLDOTNET_CDECL __attribute__((__cdecl__))
#else
    #define RCLDOTNET_EXPORT
    #define RCLDOTNET_IMPORT
    #define RCLDOTNET_CDECL
    #pragma warning Unknown dynamic link import/export semantics.
#endif

#define nullptr ((void*)0)

#include <rcl/error_handling.h>
#include <rcl/expand_topic_name.h>
#include <rcl/graph.h>
#include <rcl/node.h>
#include <rcl/rcl.h>
#include <rcl/time.h>
#include <rcl/validate_topic_name.h>
#include <rcl_interfaces/msg/parameter_type__struct.h>
#include <rcutils/allocator.h>
#include <rcutils/format_string.h>
#include <rcutils/strdup.h>
#include <rcutils/types.h>
#include <rmw/error_handling.h>
#include <rmw/rmw.h>
#include <rmw/serialized_message.h>
#include <rmw/types.h>
#include <rmw/validate_full_topic_name.h>
#include <rmw/validate_namespace.h>
#include <rmw/validate_node_name.h>
#include <rosidl_generator_c/message_type_support_struct.h>

#include <signal.h>

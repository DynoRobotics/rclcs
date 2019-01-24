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

ROSIDL_GENERATOR_C_EXPORT
rcl_node_options_t * rclcs_node_create_default_options()
{
  rcl_node_options_t  * default_node_options_handle = (rcl_node_options_t *)malloc(sizeof(rcl_node_options_t));
  *default_node_options_handle = rcl_node_get_default_options();
  return default_node_options_handle;
}

ROSIDL_GENERATOR_C_EXPORT
void rclcs_node_dispose_options(rcl_node_options_t * node_options_handle)
{
  free(node_options_handle);
}

ROSIDL_GENERATOR_C_EXPORT
rcl_subscription_options_t * rclcs_subscription_create_default_options()
{
  rcl_subscription_options_t  * default_subscription_options_handle = (rcl_subscription_options_t *)malloc(sizeof(rcl_subscription_options_t));
  *default_subscription_options_handle = rcl_subscription_get_default_options();
  return default_subscription_options_handle;
}

ROSIDL_GENERATOR_C_EXPORT
void rclcs_subscription_dispose_options(rcl_subscription_options_t * subscription_options_handle)
{
  free(subscription_options_handle);
}

ROSIDL_GENERATOR_C_EXPORT
char * rclcs_get_error_string()
{
  rcl_error_string_t error_string = rcl_get_error_string();
  return error_string.str;
}

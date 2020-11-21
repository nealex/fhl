﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace fhl.core.dictionaries
{
    // Спецификация веб сервера NGINX
    struct fhl_dic_nginx
    {
        public static string default_format_string = "$remote_addr - $remote_user [$time_local] \"$request\" $status $bytes_sent \"$http_referer\" \"$http_user_agent\"";
        public static fhl_websrv_var[] default_format_log_vars = {
            new fhl_websrv_var("$ancient_browser","(.*)"),
            new fhl_websrv_var("$arg_","(.*)"),
            new fhl_websrv_var("$args","(.*)"),
            new fhl_websrv_var("$binary_remote_addr","(.*)"),
            new fhl_websrv_var("$body_bytes_sent","(.*)"),
            new fhl_websrv_var("$bytes_received","(.*)"),
            new fhl_websrv_var("$bytes_sent","(.*)"),
            new fhl_websrv_var("$connection","(.*)"),
            new fhl_websrv_var("$connection_requests","(.*)"),
            new fhl_websrv_var("$connections_active","(.*)"),
            new fhl_websrv_var("$connections_reading","(.*)"),
            new fhl_websrv_var("$connections_waiting","(.*)"),
            new fhl_websrv_var("$connections_writing","(.*)"),
            new fhl_websrv_var("$content_length","(.*)"),
            new fhl_websrv_var("$content_type","(.*)"),
            new fhl_websrv_var("$cookie_","(.*)"),
            new fhl_websrv_var("$date_gmt","(.*)"),
            new fhl_websrv_var("$date_local","(.*)"),
            new fhl_websrv_var("$document_root","(.*)"),
            new fhl_websrv_var("$document_uri","(.*)"),
            new fhl_websrv_var("$fastcgi_path_info","(.*)"),
            new fhl_websrv_var("$fastcgi_script_name","(.*)"),
            new fhl_websrv_var("$geoip_area_code","(.*)"),
            new fhl_websrv_var("$geoip_city","(.*)"),
            new fhl_websrv_var("$geoip_city_continent_code","(.*)"),
            new fhl_websrv_var("$geoip_city_country_code","(.*)"),
            new fhl_websrv_var("$geoip_city_country_code3","(.*)"),
            new fhl_websrv_var("$geoip_city_country_name","(.*)"),
            new fhl_websrv_var("$geoip_country_code","(.*)"),
            new fhl_websrv_var("$geoip_country_code3","(.*)"),
            new fhl_websrv_var("$geoip_country_name","(.*)"),
            new fhl_websrv_var("$geoip_dma_code","(.*)"),
            new fhl_websrv_var("$geoip_latitude","(.*)"),
            new fhl_websrv_var("$geoip_longitude","(.*)"),
            new fhl_websrv_var("$geoip_org","(.*)"),
            new fhl_websrv_var("$geoip_postal_code","(.*)"),
            new fhl_websrv_var("$geoip_region","(.*)"),
            new fhl_websrv_var("$geoip_region_name","(.*)"),
            new fhl_websrv_var("$gzip_ratio","(.*)"),
            new fhl_websrv_var("$host","(.*)"),
            new fhl_websrv_var("$hostname","(.*)"),
            //new fhl_websrv_var("$http2","(.*)"),
            //new fhl_websrv_var("$http_","(.*)"),
            new fhl_websrv_var("$http_user_agent","(.*)"), // custom
            new fhl_websrv_var("$http_referer","(.*)"), // custom
            new fhl_websrv_var("$http_x_forwarded_for","(.*)"), // custom
            //new fhl_websrv_var("$https","(.*)"),
            new fhl_websrv_var("$invalid_referer","(.*)"),
            new fhl_websrv_var("$is_args","(.*)"),
            new fhl_websrv_var("$jwt_claim_","(.*)"),
            new fhl_websrv_var("$jwt_header_","(.*)"),
            new fhl_websrv_var("$limit_conn_status","(.*)"),
            new fhl_websrv_var("$limit_rate","(.*)"),
            new fhl_websrv_var("$limit_req_status","(.*)"),
            new fhl_websrv_var("$memcached_key","(.*)"),
            new fhl_websrv_var("$modern_browser","(.*)"),
            new fhl_websrv_var("$msec","(.*)"),
            new fhl_websrv_var("$msie","(.*)"),
            new fhl_websrv_var("$nginx_version","(.*)"),
            new fhl_websrv_var("$pid","(.*)"),
            new fhl_websrv_var("$pipe","(.*)"),
            new fhl_websrv_var("$protocol","(.*)"),
            new fhl_websrv_var("$proxy_add_x_forwarded_for","(.*)"),
            new fhl_websrv_var("$proxy_host","(.*)"),
            new fhl_websrv_var("$proxy_port","(.*)"),
            new fhl_websrv_var("$proxy_protocol_addr","(.*)"),
            new fhl_websrv_var("$proxy_protocol_port","(.*)"),
            new fhl_websrv_var("$proxy_protocol_server_addr","(.*)"),
            new fhl_websrv_var("$proxy_protocol_server_port","(.*)"),
            new fhl_websrv_var("$query_string","(.*)"),
            new fhl_websrv_var("$realip_remote_addr","(.*)"),
            new fhl_websrv_var("$realip_remote_port","(.*)"),
            new fhl_websrv_var("$realpath_root","(.*)"),
            new fhl_websrv_var("$remote_addr","(.*)"),
            new fhl_websrv_var("$remote_port","(.*)"),
            new fhl_websrv_var("$remote_user","(.*)"),
           // 
            new fhl_websrv_var("$request_body","(.*)"),
            new fhl_websrv_var("$request_body_file","(.*)"),
            new fhl_websrv_var("$request_completion","(.*)"),
            new fhl_websrv_var("$request_filename","(.*)"),
            new fhl_websrv_var("$request_id","(.*)"),
            new fhl_websrv_var("$request_length","(.*)"),
            new fhl_websrv_var("$request_method","(.*)"),
            new fhl_websrv_var("$request_time","(.*)"),
            new fhl_websrv_var("$request_uri","(.*)"),
            new fhl_websrv_var("$request","(.*)"),
            new fhl_websrv_var("$scheme","(.*)"),
            new fhl_websrv_var("$secure_link","(.*)"),
            new fhl_websrv_var("$secure_link_expires","(.*)"),
            new fhl_websrv_var("$sent_http_","(.*)"),
            new fhl_websrv_var("$sent_trailer_","(.*)"),
            new fhl_websrv_var("$server_addr","(.*)"),
            new fhl_websrv_var("$server_name","(.*)"),
            new fhl_websrv_var("$server_port","(.*)"),
            new fhl_websrv_var("$server_protocol","(.*)"),
            new fhl_websrv_var("$session_time","(.*)"),
            new fhl_websrv_var("$slice_range","(.*)"),
            new fhl_websrv_var("$spdy","(.*)"),
            new fhl_websrv_var("$spdy_request_priority","(.*)"),
            new fhl_websrv_var("$ssl_cipher","(.*)"),
            new fhl_websrv_var("$ssl_ciphers","(.*)"),
            new fhl_websrv_var("$ssl_client_cert","(.*)"),
            new fhl_websrv_var("$ssl_client_escaped_cert","(.*)"),
            new fhl_websrv_var("$ssl_client_fingerprint","(.*)"),
            new fhl_websrv_var("$ssl_client_i_dn","(.*)"),
            new fhl_websrv_var("$ssl_client_i_dn_legacy","(.*)"),
            new fhl_websrv_var("$ssl_client_raw_cert","(.*)"),
            new fhl_websrv_var("$ssl_client_s_dn","(.*)"),
            new fhl_websrv_var("$ssl_client_s_dn_legacy","(.*)"),
            new fhl_websrv_var("$ssl_client_serial","(.*)"),
            new fhl_websrv_var("$ssl_client_v_end","(.*)"),
            new fhl_websrv_var("$ssl_client_v_remain","(.*)"),
            new fhl_websrv_var("$ssl_client_v_start","(.*)"),
            new fhl_websrv_var("$ssl_client_verify","(.*)"),
            new fhl_websrv_var("$ssl_curves","(.*)"),
            new fhl_websrv_var("$ssl_early_data","(.*)"),
            new fhl_websrv_var("$ssl_preread_alpn_protocols","(.*)"),
            new fhl_websrv_var("$ssl_preread_protocol","(.*)"),
            new fhl_websrv_var("$ssl_preread_server_name","(.*)"),
            new fhl_websrv_var("$ssl_protocol","(.*)"),
            new fhl_websrv_var("$ssl_server_name","(.*)"),
            new fhl_websrv_var("$ssl_session_id","(.*)"),
            new fhl_websrv_var("$ssl_session_reused","(.*)"),
            new fhl_websrv_var("$status","(.*)"),
            new fhl_websrv_var("$tcpinfo_rtt","(.*)"),
            new fhl_websrv_var("$tcpinfo_rttvar","(.*)"),
            new fhl_websrv_var("$tcpinfo_snd_cwnd","(.*)"),
            new fhl_websrv_var("$tcpinfo_rcv_space","(.*)"),
            new fhl_websrv_var("$time_iso8601","(.*)"),
            new fhl_websrv_var("$time_local","(.*)"),
            new fhl_websrv_var("$uid_got","(.*)"),
            new fhl_websrv_var("$uid_reset","(.*)"),
            new fhl_websrv_var("$uid_set","(.*)"),
            new fhl_websrv_var("$upstream_addr","(.*)"),
            new fhl_websrv_var("$upstream_bytes_received","(.*)"),
            new fhl_websrv_var("$upstream_bytes_sent","(.*)"),
            new fhl_websrv_var("$upstream_cache_status","(.*)"),
            new fhl_websrv_var("$upstream_connect_time","(.*)"),
            new fhl_websrv_var("$upstream_cookie_","(.*)"),
            new fhl_websrv_var("$upstream_first_byte_time","(.*)"),
            new fhl_websrv_var("$upstream_header_time","(.*)"),
            new fhl_websrv_var("$upstream_http_","(.*)"),
            new fhl_websrv_var("$upstream_queue_time","(.*)"),
            new fhl_websrv_var("$upstream_response_length","(.*)"),
            new fhl_websrv_var("$upstream_response_time","(.*)"),
            new fhl_websrv_var("$upstream_session_time","(.*)"),
            new fhl_websrv_var("$upstream_status","(.*)"),
            new fhl_websrv_var("$upstream_trailer_","(.*)"),
            new fhl_websrv_var("$uri","(.*)"),
        };
    }
}

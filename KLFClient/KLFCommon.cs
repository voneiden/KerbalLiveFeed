﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class KLFCommon
{

	public const String PROGRAM_VERSION = "0.0.5";
	public const Int32 FILE_FORMAT_VERSION = 2;
	public const Int32 NET_PROTOCOL_VERSION = 2;
	public const int MSG_HEADER_LENGTH = 8;

	public static byte[] intToBytes(Int32 val)
	{
		byte[] bytes = new byte[4];
		bytes[0] = (byte)(val & byte.MaxValue);
		bytes[1] = (byte)((val >> 8) & byte.MaxValue);
		bytes[2] = (byte)((val >> 16) & byte.MaxValue);
		bytes[3] = (byte)((val >> 24) & byte.MaxValue);

		return bytes;
	}

	public static Int32 intFromBytes(byte[] bytes, int offset = 0)
	{
		Int32 val = 0;
		val |= bytes[offset];
		val |= ((Int32)bytes[offset + 1]) << 8;
		val |= ((Int32)bytes[offset + 2]) << 16;
		val |= ((Int32)bytes[offset + 3]) << 24;

		return val;
	}

	public enum ClientMessageID
	{
		HANDSHAKE /*Username Length : Username : Version*/,
		PLUGIN_UPDATE /*data*/,
		TEXT_MESSAGE /*Message text*/
	}

	public enum ServerMessageID
	{
		HANDSHAKE /*Protocol Version : Protocol String*/,
		HANDSHAKE_REFUSAL /*Refusal message*/,
		SERVER_MESSAGE /*Message text*/,
		TEXT_MESSAGE /*Message text*/,
		PLUGIN_UPDATE /*data*/,
		SERVER_SETTINGS /*UpdateInterval : MaxQueueSize*/
	}
}


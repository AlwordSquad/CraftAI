// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

#pragma warning disable SA1200 // Using directives should be placed correctly
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Resolvers
{
    using System;

    public class GeneratedResolver : global::MessagePack.IFormatterResolver
    {
        public static readonly global::MessagePack.IFormatterResolver Instance = new GeneratedResolver();

        private GeneratedResolver()
        {
        }

        public global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.Formatter;
        }

        private static class FormatterCache<T>
        {
            internal static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> Formatter;

            static FormatterCache()
            {
                var f = GeneratedResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (f != null)
                {
                    Formatter = (global::MessagePack.Formatters.IMessagePackFormatter<T>)f;
                }
            }
        }
    }

    internal static class GeneratedResolverGetFormatterHelper
    {
        private static readonly global::System.Collections.Generic.Dictionary<Type, int> lookup;

        static GeneratedResolverGetFormatterHelper()
        {
            lookup = new global::System.Collections.Generic.Dictionary<Type, int>(12)
            {
                { typeof(global::Craft.AI.Worker.Interface.Network.Shared.ChunkPosition[]), 0 },
                { typeof(global::Craft.AI.Worker.Interface.Network.Shared.Float2[]), 1 },
                { typeof(global::Craft.AI.Worker.Interface.Network.Shared.Int3[]), 2 },
                { typeof(global::Craft.AI.Worker.Interface.Network.Clientbound.SetChunkRenderCommand), 3 },
                { typeof(global::Craft.AI.Worker.Interface.Network.Clientbound.SetPlayerSpawnDataCommand), 4 },
                { typeof(global::Craft.AI.Worker.Interface.Network.Serverbound.CreateAgentRequest), 5 },
                { typeof(global::Craft.AI.Worker.Interface.Network.Serverbound.TerrainRequest), 6 },
                { typeof(global::Craft.AI.Worker.Interface.Network.Shared.ChunkPosition), 7 },
                { typeof(global::Craft.AI.Worker.Interface.Network.Shared.Float2), 8 },
                { typeof(global::Craft.AI.Worker.Interface.Network.Shared.Int2), 9 },
                { typeof(global::Craft.AI.Worker.Interface.Network.Shared.Int3), 10 },
                { typeof(global::Craft.AI.Worker.Interface.Network.Shared.PingPacket), 11 },
            };
        }

        internal static object GetFormatter(Type t)
        {
            int key;
            if (!lookup.TryGetValue(t, out key))
            {
                return null;
            }

            switch (key)
            {
                case 0: return new global::MessagePack.Formatters.ArrayFormatter<global::Craft.AI.Worker.Interface.Network.Shared.ChunkPosition>();
                case 1: return new global::MessagePack.Formatters.ArrayFormatter<global::Craft.AI.Worker.Interface.Network.Shared.Float2>();
                case 2: return new global::MessagePack.Formatters.ArrayFormatter<global::Craft.AI.Worker.Interface.Network.Shared.Int3>();
                case 3: return new MessagePack.Formatters.Craft.AI.Worker.Interface.Network.Clientbound.SetChunkRenderCommandFormatter();
                case 4: return new MessagePack.Formatters.Craft.AI.Worker.Interface.Network.Clientbound.SetPlayerSpawnDataCommandFormatter();
                case 5: return new MessagePack.Formatters.Craft.AI.Worker.Interface.Network.Serverbound.CreateAgentRequestFormatter();
                case 6: return new MessagePack.Formatters.Craft.AI.Worker.Interface.Network.Serverbound.TerrainRequestFormatter();
                case 7: return new MessagePack.Formatters.Craft.AI.Worker.Interface.Network.Shared.ChunkPositionFormatter();
                case 8: return new MessagePack.Formatters.Craft.AI.Worker.Interface.Network.Shared.Float2Formatter();
                case 9: return new MessagePack.Formatters.Craft.AI.Worker.Interface.Network.Shared.Int2Formatter();
                case 10: return new MessagePack.Formatters.Craft.AI.Worker.Interface.Network.Shared.Int3Formatter();
                case 11: return new MessagePack.Formatters.Craft.AI.Worker.Interface.Network.Shared.PingPacketFormatter();
                default: return null;
            }
        }
    }
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning restore SA1649 // File name should match first type name




// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

#pragma warning disable SA1129 // Do not use default value type constructor
#pragma warning disable SA1200 // Using directives should be placed correctly
#pragma warning disable SA1309 // Field names should not begin with underscore
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1403 // File may only contain a single namespace
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters.Craft.AI.Worker.Interface.Network.Clientbound
{
    using global::System.Buffers;
    using global::MessagePack;

    public sealed class SetChunkRenderCommandFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Craft.AI.Worker.Interface.Network.Clientbound.SetChunkRenderCommand>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Craft.AI.Worker.Interface.Network.Clientbound.SetChunkRenderCommand value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            writer.WriteArrayHeader(5);
            writer.WriteNil();
            formatterResolver.GetFormatterWithVerify<global::Craft.AI.Worker.Interface.Network.Shared.ChunkPosition>().Serialize(ref writer, value.ChunkPosition, options);
            formatterResolver.GetFormatterWithVerify<global::Craft.AI.Worker.Interface.Network.Shared.Int3[]>().Serialize(ref writer, value.Vertices, options);
            formatterResolver.GetFormatterWithVerify<int[]>().Serialize(ref writer, value.Triangles, options);
            formatterResolver.GetFormatterWithVerify<global::Craft.AI.Worker.Interface.Network.Shared.Float2[]>().Serialize(ref writer, value.Uvs, options);
        }

        public global::Craft.AI.Worker.Interface.Network.Clientbound.SetChunkRenderCommand Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            var length = reader.ReadArrayHeader();
            var ____result = new global::Craft.AI.Worker.Interface.Network.Clientbound.SetChunkRenderCommand();

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 1:
                        ____result.ChunkPosition = formatterResolver.GetFormatterWithVerify<global::Craft.AI.Worker.Interface.Network.Shared.ChunkPosition>().Deserialize(ref reader, options);
                        break;
                    case 2:
                        ____result.Vertices = formatterResolver.GetFormatterWithVerify<global::Craft.AI.Worker.Interface.Network.Shared.Int3[]>().Deserialize(ref reader, options);
                        break;
                    case 3:
                        ____result.Triangles = formatterResolver.GetFormatterWithVerify<int[]>().Deserialize(ref reader, options);
                        break;
                    case 4:
                        ____result.Uvs = formatterResolver.GetFormatterWithVerify<global::Craft.AI.Worker.Interface.Network.Shared.Float2[]>().Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;
            return ____result;
        }
    }

    public sealed class SetPlayerSpawnDataCommandFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Craft.AI.Worker.Interface.Network.Clientbound.SetPlayerSpawnDataCommand>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Craft.AI.Worker.Interface.Network.Clientbound.SetPlayerSpawnDataCommand value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            writer.WriteArrayHeader(8);
            writer.WriteNil();
            writer.Write(value.EntityId);
            formatterResolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.PlayerUUUI, options);
            writer.Write(value.X);
            writer.Write(value.Y);
            writer.Write(value.Z);
            writer.Write(value.Yaw);
            writer.Write(value.Pitch);
        }

        public global::Craft.AI.Worker.Interface.Network.Clientbound.SetPlayerSpawnDataCommand Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            var length = reader.ReadArrayHeader();
            var ____result = new global::Craft.AI.Worker.Interface.Network.Clientbound.SetPlayerSpawnDataCommand();

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 1:
                        ____result.EntityId = reader.ReadInt32();
                        break;
                    case 2:
                        ____result.PlayerUUUI = formatterResolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        break;
                    case 3:
                        ____result.X = reader.ReadDouble();
                        break;
                    case 4:
                        ____result.Y = reader.ReadDouble();
                        break;
                    case 5:
                        ____result.Z = reader.ReadDouble();
                        break;
                    case 6:
                        ____result.Yaw = reader.ReadByte();
                        break;
                    case 7:
                        ____result.Pitch = reader.ReadByte();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;
            return ____result;
        }
    }
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1129 // Do not use default value type constructor
#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning restore SA1309 // Field names should not begin with underscore
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning restore SA1403 // File may only contain a single namespace
#pragma warning restore SA1649 // File name should match first type name

// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

#pragma warning disable SA1129 // Do not use default value type constructor
#pragma warning disable SA1200 // Using directives should be placed correctly
#pragma warning disable SA1309 // Field names should not begin with underscore
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1403 // File may only contain a single namespace
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters.Craft.AI.Worker.Interface.Network.Serverbound
{
    using global::System.Buffers;
    using global::MessagePack;

    public sealed class CreateAgentRequestFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Craft.AI.Worker.Interface.Network.Serverbound.CreateAgentRequest>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Craft.AI.Worker.Interface.Network.Serverbound.CreateAgentRequest value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            writer.WriteArrayHeader(3);
            writer.WriteNil();
            formatterResolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Nickname, options);
            formatterResolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Host, options);
        }

        public global::Craft.AI.Worker.Interface.Network.Serverbound.CreateAgentRequest Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            var length = reader.ReadArrayHeader();
            var ____result = new global::Craft.AI.Worker.Interface.Network.Serverbound.CreateAgentRequest();

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 1:
                        ____result.Nickname = formatterResolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        break;
                    case 2:
                        ____result.Host = formatterResolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;
            return ____result;
        }
    }

    public sealed class TerrainRequestFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Craft.AI.Worker.Interface.Network.Serverbound.TerrainRequest>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Craft.AI.Worker.Interface.Network.Serverbound.TerrainRequest value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            writer.WriteArrayHeader(2);
            writer.WriteNil();
            formatterResolver.GetFormatterWithVerify<global::Craft.AI.Worker.Interface.Network.Shared.ChunkPosition[]>().Serialize(ref writer, value.Positions, options);
        }

        public global::Craft.AI.Worker.Interface.Network.Serverbound.TerrainRequest Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            var length = reader.ReadArrayHeader();
            var ____result = new global::Craft.AI.Worker.Interface.Network.Serverbound.TerrainRequest();

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 1:
                        ____result.Positions = formatterResolver.GetFormatterWithVerify<global::Craft.AI.Worker.Interface.Network.Shared.ChunkPosition[]>().Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;
            return ____result;
        }
    }
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1129 // Do not use default value type constructor
#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning restore SA1309 // Field names should not begin with underscore
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning restore SA1403 // File may only contain a single namespace
#pragma warning restore SA1649 // File name should match first type name

// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

#pragma warning disable SA1129 // Do not use default value type constructor
#pragma warning disable SA1200 // Using directives should be placed correctly
#pragma warning disable SA1309 // Field names should not begin with underscore
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1403 // File may only contain a single namespace
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters.Craft.AI.Worker.Interface.Network.Shared
{
    using global::System.Buffers;
    using global::MessagePack;

    public sealed class ChunkPositionFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Craft.AI.Worker.Interface.Network.Shared.ChunkPosition>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Craft.AI.Worker.Interface.Network.Shared.ChunkPosition value, global::MessagePack.MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(3);
            writer.WriteNil();
            writer.Write(value.X);
            writer.Write(value.Z);
        }

        public global::Craft.AI.Worker.Interface.Network.Shared.ChunkPosition Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                throw new global::System.InvalidOperationException("typecode is null, struct not supported");
            }

            options.Security.DepthStep(ref reader);
            var length = reader.ReadArrayHeader();
            var ____result = new global::Craft.AI.Worker.Interface.Network.Shared.ChunkPosition();

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 1:
                        ____result.X = reader.ReadInt16();
                        break;
                    case 2:
                        ____result.Z = reader.ReadInt16();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;
            return ____result;
        }
    }

    public sealed class Float2Formatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Craft.AI.Worker.Interface.Network.Shared.Float2>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Craft.AI.Worker.Interface.Network.Shared.Float2 value, global::MessagePack.MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(3);
            writer.WriteNil();
            writer.Write(value.X);
            writer.Write(value.Z);
        }

        public global::Craft.AI.Worker.Interface.Network.Shared.Float2 Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                throw new global::System.InvalidOperationException("typecode is null, struct not supported");
            }

            options.Security.DepthStep(ref reader);
            var length = reader.ReadArrayHeader();
            var ____result = new global::Craft.AI.Worker.Interface.Network.Shared.Float2();

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 1:
                        ____result.X = reader.ReadSingle();
                        break;
                    case 2:
                        ____result.Z = reader.ReadSingle();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;
            return ____result;
        }
    }

    public sealed class Int2Formatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Craft.AI.Worker.Interface.Network.Shared.Int2>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Craft.AI.Worker.Interface.Network.Shared.Int2 value, global::MessagePack.MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(3);
            writer.WriteNil();
            writer.Write(value.X);
            writer.Write(value.Z);
        }

        public global::Craft.AI.Worker.Interface.Network.Shared.Int2 Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                throw new global::System.InvalidOperationException("typecode is null, struct not supported");
            }

            options.Security.DepthStep(ref reader);
            var length = reader.ReadArrayHeader();
            var ____result = new global::Craft.AI.Worker.Interface.Network.Shared.Int2();

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 1:
                        ____result.X = reader.ReadInt32();
                        break;
                    case 2:
                        ____result.Z = reader.ReadInt32();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;
            return ____result;
        }
    }

    public sealed class Int3Formatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Craft.AI.Worker.Interface.Network.Shared.Int3>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Craft.AI.Worker.Interface.Network.Shared.Int3 value, global::MessagePack.MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(4);
            writer.WriteNil();
            writer.Write(value.X);
            writer.Write(value.Y);
            writer.Write(value.Z);
        }

        public global::Craft.AI.Worker.Interface.Network.Shared.Int3 Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                throw new global::System.InvalidOperationException("typecode is null, struct not supported");
            }

            options.Security.DepthStep(ref reader);
            var length = reader.ReadArrayHeader();
            var ____result = new global::Craft.AI.Worker.Interface.Network.Shared.Int3();

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 1:
                        ____result.X = reader.ReadInt32();
                        break;
                    case 2:
                        ____result.Y = reader.ReadInt32();
                        break;
                    case 3:
                        ____result.Z = reader.ReadInt32();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;
            return ____result;
        }
    }

    public sealed class PingPacketFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Craft.AI.Worker.Interface.Network.Shared.PingPacket>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Craft.AI.Worker.Interface.Network.Shared.PingPacket value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            writer.WriteArrayHeader(2);
            writer.WriteNil();
            writer.Write(value.Timestamp);
        }

        public global::Craft.AI.Worker.Interface.Network.Shared.PingPacket Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            var length = reader.ReadArrayHeader();
            var ____result = new global::Craft.AI.Worker.Interface.Network.Shared.PingPacket();

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 1:
                        ____result.Timestamp = reader.ReadInt64();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;
            return ____result;
        }
    }
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1129 // Do not use default value type constructor
#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning restore SA1309 // Field names should not begin with underscore
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning restore SA1403 // File may only contain a single namespace
#pragma warning restore SA1649 // File name should match first type name


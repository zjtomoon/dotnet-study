/**
 * <auto-generated>
 * Autogenerated by Thrift Compiler (0.18.1)
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 * </auto-generated>
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;


#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE0017  // object init can be simplified
#pragma warning disable IDE0028  // collection init can be simplified
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable CA1822   // empty DeepCopy() methods still non-static
#pragma warning disable IDE0083  // pattern matching "that is not SomeType" requires net5.0 but we still support earlier versions

public partial class UserService
{
  public interface IAsync
  {
    global::System.Threading.Tasks.Task<User> GetUserByID(int userID, CancellationToken cancellationToken = default);

    global::System.Threading.Tasks.Task<List<User>> GetAllUser(CancellationToken cancellationToken = default);

  }


  public class Client : TBaseClient, IDisposable, IAsync
  {
    public Client(TProtocol protocol) : this(protocol, protocol)
    {
    }

    public Client(TProtocol inputProtocol, TProtocol outputProtocol) : base(inputProtocol, outputProtocol)
    {
    }

    public async global::System.Threading.Tasks.Task<User> GetUserByID(int userID, CancellationToken cancellationToken = default)
    {
      await send_GetUserByID(userID, cancellationToken);
      return await recv_GetUserByID(cancellationToken);
    }

    public async global::System.Threading.Tasks.Task send_GetUserByID(int userID, CancellationToken cancellationToken = default)
    {
      await OutputProtocol.WriteMessageBeginAsync(new TMessage("GetUserByID", TMessageType.Call, SeqId), cancellationToken);
      
      var tmp5 = new InternalStructs.GetUserByID_args() {
        UserID = userID,
      };
      
      await tmp5.WriteAsync(OutputProtocol, cancellationToken);
      await OutputProtocol.WriteMessageEndAsync(cancellationToken);
      await OutputProtocol.Transport.FlushAsync(cancellationToken);
    }

    public async global::System.Threading.Tasks.Task<User> recv_GetUserByID(CancellationToken cancellationToken = default)
    {
      
      var tmp6 = await InputProtocol.ReadMessageBeginAsync(cancellationToken);
      if (tmp6.Type == TMessageType.Exception)
      {
        var tmp7 = await TApplicationException.ReadAsync(InputProtocol, cancellationToken);
        await InputProtocol.ReadMessageEndAsync(cancellationToken);
        throw tmp7;
      }

      var tmp8 = new InternalStructs.GetUserByID_result();
      await tmp8.ReadAsync(InputProtocol, cancellationToken);
      await InputProtocol.ReadMessageEndAsync(cancellationToken);
      if (tmp8.__isset.success)
      {
        return tmp8.Success;
      }
      throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetUserByID failed: unknown result");
    }

    public async global::System.Threading.Tasks.Task<List<User>> GetAllUser(CancellationToken cancellationToken = default)
    {
      await send_GetAllUser(cancellationToken);
      return await recv_GetAllUser(cancellationToken);
    }

    public async global::System.Threading.Tasks.Task send_GetAllUser(CancellationToken cancellationToken = default)
    {
      await OutputProtocol.WriteMessageBeginAsync(new TMessage("GetAllUser", TMessageType.Call, SeqId), cancellationToken);
      
      var tmp9 = new InternalStructs.GetAllUser_args() {
      };
      
      await tmp9.WriteAsync(OutputProtocol, cancellationToken);
      await OutputProtocol.WriteMessageEndAsync(cancellationToken);
      await OutputProtocol.Transport.FlushAsync(cancellationToken);
    }

    public async global::System.Threading.Tasks.Task<List<User>> recv_GetAllUser(CancellationToken cancellationToken = default)
    {
      
      var tmp10 = await InputProtocol.ReadMessageBeginAsync(cancellationToken);
      if (tmp10.Type == TMessageType.Exception)
      {
        var tmp11 = await TApplicationException.ReadAsync(InputProtocol, cancellationToken);
        await InputProtocol.ReadMessageEndAsync(cancellationToken);
        throw tmp11;
      }

      var tmp12 = new InternalStructs.GetAllUser_result();
      await tmp12.ReadAsync(InputProtocol, cancellationToken);
      await InputProtocol.ReadMessageEndAsync(cancellationToken);
      if (tmp12.__isset.success)
      {
        return tmp12.Success;
      }
      throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetAllUser failed: unknown result");
    }

  }

  public class AsyncProcessor : ITAsyncProcessor
  {
    private readonly IAsync _iAsync;
    private readonly ILogger<AsyncProcessor> _logger;

    public AsyncProcessor(IAsync iAsync, ILogger<AsyncProcessor> logger = default)
    {
      _iAsync = iAsync ?? throw new ArgumentNullException(nameof(iAsync));
      _logger = logger;
      processMap_["GetUserByID"] = GetUserByID_ProcessAsync;
      processMap_["GetAllUser"] = GetAllUser_ProcessAsync;
    }

    protected delegate global::System.Threading.Tasks.Task ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken);
    protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

    public async Task<bool> ProcessAsync(TProtocol iprot, TProtocol oprot)
    {
      return await ProcessAsync(iprot, oprot, CancellationToken.None);
    }

    public async Task<bool> ProcessAsync(TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken)
    {
      try
      {
        var msg = await iprot.ReadMessageBeginAsync(cancellationToken);

        processMap_.TryGetValue(msg.Name, out var fn);

        if (fn == null)
        {
          await TProtocolUtil.SkipAsync(iprot, TType.Struct, cancellationToken);
          await iprot.ReadMessageEndAsync(cancellationToken);
          var x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
          await oprot.WriteMessageBeginAsync(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID), cancellationToken);
          await x.WriteAsync(oprot, cancellationToken);
          await oprot.WriteMessageEndAsync(cancellationToken);
          await oprot.Transport.FlushAsync(cancellationToken);
          return true;
        }

        await fn(msg.SeqID, iprot, oprot, cancellationToken);

      }
      catch (IOException)
      {
        return false;
      }

      return true;
    }

    public async global::System.Threading.Tasks.Task GetUserByID_ProcessAsync(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken)
    {
      var tmp13 = new InternalStructs.GetUserByID_args();
      await tmp13.ReadAsync(iprot, cancellationToken);
      await iprot.ReadMessageEndAsync(cancellationToken);
      var tmp14 = new InternalStructs.GetUserByID_result();
      try
      {
        tmp14.Success = await _iAsync.GetUserByID(tmp13.UserID, cancellationToken);
        await oprot.WriteMessageBeginAsync(new TMessage("GetUserByID", TMessageType.Reply, seqid), cancellationToken); 
        await tmp14.WriteAsync(oprot, cancellationToken);
      }
      catch (TTransportException)
      {
        throw;
      }
      catch (Exception tmp15)
      {
        var tmp16 = $"Error occurred in {GetType().FullName}: {tmp15.Message}";
        if(_logger != null)
          _logger.LogError("{Exception}, {Message}", tmp15, tmp16);
        else
          Console.Error.WriteLine(tmp16);
        var tmp17 = new TApplicationException(TApplicationException.ExceptionType.InternalError," Internal error.");
        await oprot.WriteMessageBeginAsync(new TMessage("GetUserByID", TMessageType.Exception, seqid), cancellationToken);
        await tmp17.WriteAsync(oprot, cancellationToken);
      }
      await oprot.WriteMessageEndAsync(cancellationToken);
      await oprot.Transport.FlushAsync(cancellationToken);
    }

    public async global::System.Threading.Tasks.Task GetAllUser_ProcessAsync(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken)
    {
      var tmp18 = new InternalStructs.GetAllUser_args();
      await tmp18.ReadAsync(iprot, cancellationToken);
      await iprot.ReadMessageEndAsync(cancellationToken);
      var tmp19 = new InternalStructs.GetAllUser_result();
      try
      {
        tmp19.Success = await _iAsync.GetAllUser(cancellationToken);
        await oprot.WriteMessageBeginAsync(new TMessage("GetAllUser", TMessageType.Reply, seqid), cancellationToken); 
        await tmp19.WriteAsync(oprot, cancellationToken);
      }
      catch (TTransportException)
      {
        throw;
      }
      catch (Exception tmp20)
      {
        var tmp21 = $"Error occurred in {GetType().FullName}: {tmp20.Message}";
        if(_logger != null)
          _logger.LogError("{Exception}, {Message}", tmp20, tmp21);
        else
          Console.Error.WriteLine(tmp21);
        var tmp22 = new TApplicationException(TApplicationException.ExceptionType.InternalError," Internal error.");
        await oprot.WriteMessageBeginAsync(new TMessage("GetAllUser", TMessageType.Exception, seqid), cancellationToken);
        await tmp22.WriteAsync(oprot, cancellationToken);
      }
      await oprot.WriteMessageEndAsync(cancellationToken);
      await oprot.Transport.FlushAsync(cancellationToken);
    }

  }

  public class InternalStructs
  {

    public partial class GetUserByID_args : TBase
    {
      private int _userID;

      public int UserID
      {
        get
        {
          return _userID;
        }
        set
        {
          __isset.userID = true;
          this._userID = value;
        }
      }


      public Isset __isset;
      public struct Isset
      {
        public bool userID;
      }

      public GetUserByID_args()
      {
      }

      public GetUserByID_args DeepCopy()
      {
        var tmp23 = new GetUserByID_args();
        if(__isset.userID)
        {
          tmp23.UserID = this.UserID;
        }
        tmp23.__isset.userID = this.__isset.userID;
        return tmp23;
      }

      public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          await iprot.ReadStructBeginAsync(cancellationToken);
          while (true)
          {
            field = await iprot.ReadFieldBeginAsync(cancellationToken);
            if (field.Type == TType.Stop)
            {
              break;
            }

            switch (field.ID)
            {
              case 1:
                if (field.Type == TType.I32)
                {
                  UserID = await iprot.ReadI32Async(cancellationToken);
                }
                else
                {
                  await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                }
                break;
              default: 
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                break;
            }

            await iprot.ReadFieldEndAsync(cancellationToken);
          }

          await iprot.ReadStructEndAsync(cancellationToken);
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
      {
        oprot.IncrementRecursionDepth();
        try
        {
          var tmp24 = new TStruct("GetUserByID_args");
          await oprot.WriteStructBeginAsync(tmp24, cancellationToken);
          var tmp25 = new TField();
          if(__isset.userID)
          {
            tmp25.Name = "userID";
            tmp25.Type = TType.I32;
            tmp25.ID = 1;
            await oprot.WriteFieldBeginAsync(tmp25, cancellationToken);
            await oprot.WriteI32Async(UserID, cancellationToken);
            await oprot.WriteFieldEndAsync(cancellationToken);
          }
          await oprot.WriteFieldStopAsync(cancellationToken);
          await oprot.WriteStructEndAsync(cancellationToken);
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override bool Equals(object that)
      {
        if (!(that is GetUserByID_args other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return ((__isset.userID == other.__isset.userID) && ((!__isset.userID) || (global::System.Object.Equals(UserID, other.UserID))));
      }

      public override int GetHashCode() {
        int hashcode = 157;
        unchecked {
          if(__isset.userID)
          {
            hashcode = (hashcode * 397) + UserID.GetHashCode();
          }
        }
        return hashcode;
      }

      public override string ToString()
      {
        var tmp26 = new StringBuilder("GetUserByID_args(");
        int tmp27 = 0;
        if(__isset.userID)
        {
          if(0 < tmp27++) { tmp26.Append(", "); }
          tmp26.Append("UserID: ");
          UserID.ToString(tmp26);
        }
        tmp26.Append(')');
        return tmp26.ToString();
      }
    }


    public partial class GetUserByID_result : TBase
    {
      private User _success;

      public User Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      public struct Isset
      {
        public bool success;
      }

      public GetUserByID_result()
      {
      }

      public GetUserByID_result DeepCopy()
      {
        var tmp28 = new GetUserByID_result();
        if((Success != null) && __isset.success)
        {
          tmp28.Success = (User)this.Success.DeepCopy();
        }
        tmp28.__isset.success = this.__isset.success;
        return tmp28;
      }

      public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          await iprot.ReadStructBeginAsync(cancellationToken);
          while (true)
          {
            field = await iprot.ReadFieldBeginAsync(cancellationToken);
            if (field.Type == TType.Stop)
            {
              break;
            }

            switch (field.ID)
            {
              case 0:
                if (field.Type == TType.Struct)
                {
                  Success = new User();
                  await Success.ReadAsync(iprot, cancellationToken);
                }
                else
                {
                  await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                }
                break;
              default: 
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                break;
            }

            await iprot.ReadFieldEndAsync(cancellationToken);
          }

          await iprot.ReadStructEndAsync(cancellationToken);
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
      {
        oprot.IncrementRecursionDepth();
        try
        {
          var tmp29 = new TStruct("GetUserByID_result");
          await oprot.WriteStructBeginAsync(tmp29, cancellationToken);
          var tmp30 = new TField();

          if(this.__isset.success)
          {
            if (Success != null)
            {
              tmp30.Name = "Success";
              tmp30.Type = TType.Struct;
              tmp30.ID = 0;
              await oprot.WriteFieldBeginAsync(tmp30, cancellationToken);
              await Success.WriteAsync(oprot, cancellationToken);
              await oprot.WriteFieldEndAsync(cancellationToken);
            }
          }
          await oprot.WriteFieldStopAsync(cancellationToken);
          await oprot.WriteStructEndAsync(cancellationToken);
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override bool Equals(object that)
      {
        if (!(that is GetUserByID_result other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return ((__isset.success == other.__isset.success) && ((!__isset.success) || (global::System.Object.Equals(Success, other.Success))));
      }

      public override int GetHashCode() {
        int hashcode = 157;
        unchecked {
          if((Success != null) && __isset.success)
          {
            hashcode = (hashcode * 397) + Success.GetHashCode();
          }
        }
        return hashcode;
      }

      public override string ToString()
      {
        var tmp31 = new StringBuilder("GetUserByID_result(");
        int tmp32 = 0;
        if((Success != null) && __isset.success)
        {
          if(0 < tmp32++) { tmp31.Append(", "); }
          tmp31.Append("Success: ");
          Success.ToString(tmp31);
        }
        tmp31.Append(')');
        return tmp31.ToString();
      }
    }


    public partial class GetAllUser_args : TBase
    {

      public GetAllUser_args()
      {
      }

      public GetAllUser_args DeepCopy()
      {
        var tmp33 = new GetAllUser_args();
        return tmp33;
      }

      public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          await iprot.ReadStructBeginAsync(cancellationToken);
          while (true)
          {
            field = await iprot.ReadFieldBeginAsync(cancellationToken);
            if (field.Type == TType.Stop)
            {
              break;
            }

            switch (field.ID)
            {
              default: 
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                break;
            }

            await iprot.ReadFieldEndAsync(cancellationToken);
          }

          await iprot.ReadStructEndAsync(cancellationToken);
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
      {
        oprot.IncrementRecursionDepth();
        try
        {
          var tmp34 = new TStruct("GetAllUser_args");
          await oprot.WriteStructBeginAsync(tmp34, cancellationToken);
          await oprot.WriteFieldStopAsync(cancellationToken);
          await oprot.WriteStructEndAsync(cancellationToken);
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override bool Equals(object that)
      {
        if (!(that is GetAllUser_args other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return true;
      }

      public override int GetHashCode() {
        int hashcode = 157;
        unchecked {
        }
        return hashcode;
      }

      public override string ToString()
      {
        var tmp35 = new StringBuilder("GetAllUser_args(");
        tmp35.Append(')');
        return tmp35.ToString();
      }
    }


    public partial class GetAllUser_result : TBase
    {
      private List<User> _success;

      public List<User> Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      public struct Isset
      {
        public bool success;
      }

      public GetAllUser_result()
      {
      }

      public GetAllUser_result DeepCopy()
      {
        var tmp37 = new GetAllUser_result();
        if((Success != null) && __isset.success)
        {
          tmp37.Success = this.Success.DeepCopy();
        }
        tmp37.__isset.success = this.__isset.success;
        return tmp37;
      }

      public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          await iprot.ReadStructBeginAsync(cancellationToken);
          while (true)
          {
            field = await iprot.ReadFieldBeginAsync(cancellationToken);
            if (field.Type == TType.Stop)
            {
              break;
            }

            switch (field.ID)
            {
              case 0:
                if (field.Type == TType.List)
                {
                  {
                    var _list38 = await iprot.ReadListBeginAsync(cancellationToken);
                    Success = new List<User>(_list38.Count);
                    for(int _i39 = 0; _i39 < _list38.Count; ++_i39)
                    {
                      User _elem40;
                      _elem40 = new User();
                      await _elem40.ReadAsync(iprot, cancellationToken);
                      Success.Add(_elem40);
                    }
                    await iprot.ReadListEndAsync(cancellationToken);
                  }
                }
                else
                {
                  await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                }
                break;
              default: 
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                break;
            }

            await iprot.ReadFieldEndAsync(cancellationToken);
          }

          await iprot.ReadStructEndAsync(cancellationToken);
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
      {
        oprot.IncrementRecursionDepth();
        try
        {
          var tmp41 = new TStruct("GetAllUser_result");
          await oprot.WriteStructBeginAsync(tmp41, cancellationToken);
          var tmp42 = new TField();

          if(this.__isset.success)
          {
            if (Success != null)
            {
              tmp42.Name = "Success";
              tmp42.Type = TType.List;
              tmp42.ID = 0;
              await oprot.WriteFieldBeginAsync(tmp42, cancellationToken);
              await oprot.WriteListBeginAsync(new TList(TType.Struct, Success.Count), cancellationToken);
              foreach (User _iter43 in Success)
              {
                await _iter43.WriteAsync(oprot, cancellationToken);
              }
              await oprot.WriteListEndAsync(cancellationToken);
              await oprot.WriteFieldEndAsync(cancellationToken);
            }
          }
          await oprot.WriteFieldStopAsync(cancellationToken);
          await oprot.WriteStructEndAsync(cancellationToken);
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override bool Equals(object that)
      {
        if (!(that is GetAllUser_result other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return ((__isset.success == other.__isset.success) && ((!__isset.success) || (TCollections.Equals(Success, other.Success))));
      }

      public override int GetHashCode() {
        int hashcode = 157;
        unchecked {
          if((Success != null) && __isset.success)
          {
            hashcode = (hashcode * 397) + TCollections.GetHashCode(Success);
          }
        }
        return hashcode;
      }

      public override string ToString()
      {
        var tmp44 = new StringBuilder("GetAllUser_result(");
        int tmp45 = 0;
        if((Success != null) && __isset.success)
        {
          if(0 < tmp45++) { tmp44.Append(", "); }
          tmp44.Append("Success: ");
          Success.ToString(tmp44);
        }
        tmp44.Append(')');
        return tmp44.ToString();
      }
    }

  }

}

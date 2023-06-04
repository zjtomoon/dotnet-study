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


public partial class User : TBase
{
  private int _ID;
  private string _Name;

  public int ID
  {
    get
    {
      return _ID;
    }
    set
    {
      __isset.ID = true;
      this._ID = value;
    }
  }

  public string Name
  {
    get
    {
      return _Name;
    }
    set
    {
      __isset.Name = true;
      this._Name = value;
    }
  }


  public Isset __isset;
  public struct Isset
  {
    public bool ID;
    public bool Name;
  }

  public User()
  {
  }

  public User DeepCopy()
  {
    var tmp0 = new User();
    if(__isset.ID)
    {
      tmp0.ID = this.ID;
    }
    tmp0.__isset.ID = this.__isset.ID;
    if((Name != null) && __isset.Name)
    {
      tmp0.Name = this.Name;
    }
    tmp0.__isset.Name = this.__isset.Name;
    return tmp0;
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
              ID = await iprot.ReadI32Async(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 2:
            if (field.Type == TType.String)
            {
              Name = await iprot.ReadStringAsync(cancellationToken);
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
      var tmp1 = new TStruct("User");
      await oprot.WriteStructBeginAsync(tmp1, cancellationToken);
      var tmp2 = new TField();
      if(__isset.ID)
      {
        tmp2.Name = "ID";
        tmp2.Type = TType.I32;
        tmp2.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp2, cancellationToken);
        await oprot.WriteI32Async(ID, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((Name != null) && __isset.Name)
      {
        tmp2.Name = "Name";
        tmp2.Type = TType.String;
        tmp2.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp2, cancellationToken);
        await oprot.WriteStringAsync(Name, cancellationToken);
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
    if (!(that is User other)) return false;
    if (ReferenceEquals(this, other)) return true;
    return ((__isset.ID == other.__isset.ID) && ((!__isset.ID) || (global::System.Object.Equals(ID, other.ID))))
      && ((__isset.Name == other.__isset.Name) && ((!__isset.Name) || (global::System.Object.Equals(Name, other.Name))));
  }

  public override int GetHashCode() {
    int hashcode = 157;
    unchecked {
      if(__isset.ID)
      {
        hashcode = (hashcode * 397) + ID.GetHashCode();
      }
      if((Name != null) && __isset.Name)
      {
        hashcode = (hashcode * 397) + Name.GetHashCode();
      }
    }
    return hashcode;
  }

  public override string ToString()
  {
    var tmp3 = new StringBuilder("User(");
    int tmp4 = 0;
    if(__isset.ID)
    {
      if(0 < tmp4++) { tmp3.Append(", "); }
      tmp3.Append("ID: ");
      ID.ToString(tmp3);
    }
    if((Name != null) && __isset.Name)
    {
      if(0 < tmp4++) { tmp3.Append(", "); }
      tmp3.Append("Name: ");
      Name.ToString(tmp3);
    }
    tmp3.Append(')');
    return tmp3.ToString();
  }
}

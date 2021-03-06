﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Intepreter;

namespace ILRuntime.Runtime.Enviorment
{
    public interface CrossBindingAdaptorType
    {
        ILTypeInstance ILInstance { get; }
    }
    /// <summary>
    /// This interface is used for inheritance and implementation of CLR Types or interfaces
    /// </summary>
    public abstract class CrossBindingAdaptor : IType
    {
        IType type;
        /// <summary>
        /// This returns the CLR type to be inherited or CLR interface to be implemented
        /// </summary>
        public abstract Type BaseCLRType { get; }

        public abstract Type AdaptorType { get; }

        public abstract object CreateCLRInstance(Enviorment.AppDomain appdomain, ILTypeInstance instance);

        internal IType RuntimeType { get { return type; } set { type = value; } }

        #region IType Members

        public IMethod GetMethod(string name, int paramCount)
        {
            return type.GetMethod(name, paramCount);
        }

        public IMethod GetMethod(string name, List<IType> param, IType[] genericArguments)
        {
            return type.GetMethod(name, param, genericArguments);
        }

        public List<IMethod> GetMethods()
        {
            return type.GetMethods();
        }

        public int GetFieldIndex(object token)
        {
            return type.GetFieldIndex(token);
        }

        public IMethod GetConstructor(List<IType> param)
        {
            return type.GetConstructor(param);
        }

        public bool CanAssignTo(IType type)
        {
            return type.CanAssignTo(type);
        }

        public IType MakeGenericInstance(KeyValuePair<string, IType>[] genericArguments)
        {
            return type.MakeGenericInstance(genericArguments);
        }

        public IType MakeByRefType()
        {
            return type.MakeByRefType();
        }

        public IType MakeArrayType()
        {
            return type.MakeArrayType();
        }

        public IType FindGenericArgument(string key)
        {
            return type.FindGenericArgument(key);
        }

        public IType ResolveGenericType(IType contextType)
        {
            return type.ResolveGenericType(contextType);
        }

        public bool IsGenericInstance
        {
            get
            {
                return type.IsGenericInstance;
            }
        }

        public KeyValuePair<string, IType>[] GenericArguments
        {
            get
            {
                return type.GenericArguments;
            }
        }

        public Type TypeForCLR
        {
            get
            {
                return type.TypeForCLR;
            }
        }

        public IType ByRefType
        {
            get
            {
                return type.ByRefType;
            }
        }

        public IType ArrayType
        {
            get
            {
                return type.ArrayType;
            }
        }

        public string FullName
        {
            get
            {
                return type.FullName;
            }
        }

        public string Name
        {
            get
            {
                return type.Name;
            }
        }

        public bool IsValueType
        {
            get
            {
                return type.IsValueType;
            }
        }

        public bool IsDelegate
        {
            get
            {
                return type.IsDelegate;
            }
        }

        public AppDomain AppDomain
        {
            get
            {
                return type.AppDomain;
            }
        }

        public Type ReflectionType
        {
            get
            {
                return type.ReflectionType;
            }
        }
        #endregion
    }
}

/* Header file automatically generated from ActivationRegistration.idl */
/*
 * File built with Microsoft(R) MIDLRT Compiler Engine Version 10.00.0231 
 */

#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 500
#endif

/* verify that the <rpcsal.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCSAL_H_VERSION__
#define __REQUIRED_RPCSAL_H_VERSION__ 100
#endif

#include <rpc.h>
#include <rpcndr.h>

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif /* __RPCNDR_H_VERSION__ */

#ifndef COM_NO_WINDOWS_H
#include <windows.h>
#include <ole2.h>
#endif /*COM_NO_WINDOWS_H*/
#ifndef __ActivationRegistration_h__
#define __ActivationRegistration_h__
#ifndef __ActivationRegistration_p_h__
#define __ActivationRegistration_p_h__


#pragma once

// Ensure that the setting of the /ns_prefix command line switch is consistent for all headers.
// If you get an error from the compiler indicating "warning C4005: 'CHECK_NS_PREFIX_STATE': macro redefinition", this
// indicates that you have included two different headers with different settings for the /ns_prefix MIDL command line switch
#if !defined(DISABLE_NS_PREFIX_CHECKS)
#define CHECK_NS_PREFIX_STATE "never"
#endif // !defined(DISABLE_NS_PREFIX_CHECKS)


#pragma push_macro("MIDL_CONST_ID")
#undef MIDL_CONST_ID
#define MIDL_CONST_ID const __declspec(selectany)


// Header files for imported files
#include "inspectable.h"
#include "hstring.h"

#if defined(__cplusplus) && !defined(CINTERFACE)
/* Forward Declarations */
#ifndef ____x_ActivationRegistration_CIDllServerActivatableClassRegistration_FWD_DEFINED__
#define ____x_ActivationRegistration_CIDllServerActivatableClassRegistration_FWD_DEFINED__

namespace ActivationRegistration {
    interface IDllServerActivatableClassRegistration;
} /* ActivationRegistration */
#define __x_ActivationRegistration_CIDllServerActivatableClassRegistration ActivationRegistration::IDllServerActivatableClassRegistration

#endif // ____x_ActivationRegistration_CIDllServerActivatableClassRegistration_FWD_DEFINED__

#ifndef ____x_ActivationRegistration_CIActivatableClassRegistration_FWD_DEFINED__
#define ____x_ActivationRegistration_CIActivatableClassRegistration_FWD_DEFINED__

namespace ActivationRegistration {
    interface IActivatableClassRegistration;
} /* ActivationRegistration */
#define __x_ActivationRegistration_CIActivatableClassRegistration ActivationRegistration::IActivatableClassRegistration

#endif // ____x_ActivationRegistration_CIActivatableClassRegistration_FWD_DEFINED__



/*
 *
 * Struct ActivationRegistration.RegistrationScope
 *
 */


namespace ActivationRegistration {
    /* [v1_enum, version] */
    enum RegistrationScope : int
    {
        RegistrationScope_PerMachine,
        RegistrationScope_PerUser,
        RegistrationScope_InboxApp,
    };
    
} /* ActivationRegistration */


/*
 *
 * Struct ActivationRegistration.ActivationType
 *
 */


namespace ActivationRegistration {
    /* [v1_enum, version] */
    enum ActivationType : int
    {
        ActivationType_InProcess,
        ActivationType_OutOfProcess,
        ActivationType_RemoteProcess,
    };
    
} /* ActivationRegistration */


/*
 *
 * Struct ActivationRegistration.ThreadingType
 *
 */


namespace ActivationRegistration {
    /* [v1_enum, version] */
    enum ThreadingType : int
    {
        ThreadingType_BOTH,
        ThreadingType_STA,
        ThreadingType_MTA,
    };
    
} /* ActivationRegistration */


/*
 *
 * Interface ActivationRegistration.IDllServerActivatableClassRegistration
 *
 */
#if !defined(____x_ActivationRegistration_CIDllServerActivatableClassRegistration_INTERFACE_DEFINED__)
#define ____x_ActivationRegistration_CIDllServerActivatableClassRegistration_INTERFACE_DEFINED__
extern const __declspec(selectany) _Null_terminated_ WCHAR InterfaceName_ActivationRegistration_IDllServerActivatableClassRegistration[] = L"ActivationRegistration.IDllServerActivatableClassRegistration";

namespace ActivationRegistration {
    /* [object, uuid("C8AA04F6-66C6-46A3-8FE6-F56BE7DDC091"), version] */
    MIDL_INTERFACE("C8AA04F6-66C6-46A3-8FE6-F56BE7DDC091")
    IDllServerActivatableClassRegistration : public IInspectable
    {
    public:
        /* [propget] */virtual HRESULT STDMETHODCALLTYPE get_DllPath(
            /* [out, retval] */HSTRING * dllPath
            ) = 0;
        /* [propget] */virtual HRESULT STDMETHODCALLTYPE get_ThreadingType(
            /* [out, retval] */ActivationRegistration::ThreadingType * threadingType
            ) = 0;
        
    };

    MIDL_CONST_ID IID & IID_IDllServerActivatableClassRegistration=_uuidof(IDllServerActivatableClassRegistration);
    
} /* ActivationRegistration */

EXTERN_C const IID IID___x_ActivationRegistration_CIDllServerActivatableClassRegistration;
#endif /* !defined(____x_ActivationRegistration_CIDllServerActivatableClassRegistration_INTERFACE_DEFINED__) */


/*
 *
 * Interface ActivationRegistration.IActivatableClassRegistration
 *
 */
#if !defined(____x_ActivationRegistration_CIActivatableClassRegistration_INTERFACE_DEFINED__)
#define ____x_ActivationRegistration_CIActivatableClassRegistration_INTERFACE_DEFINED__
extern const __declspec(selectany) _Null_terminated_ WCHAR InterfaceName_ActivationRegistration_IActivatableClassRegistration[] = L"ActivationRegistration.IActivatableClassRegistration";

namespace ActivationRegistration {
    /* [object, uuid("9BBCAE23-3DD6-49C3-B63C-1C587E7A6A67"), version] */
    MIDL_INTERFACE("9BBCAE23-3DD6-49C3-B63C-1C587E7A6A67")
    IActivatableClassRegistration : public IInspectable
    {
    public:
        /* [propget] */virtual HRESULT STDMETHODCALLTYPE get_ActivatableClassId(
            /* [out, retval] */HSTRING * activatableClassID
            ) = 0;
        /* [propget] */virtual HRESULT STDMETHODCALLTYPE get_ActivationType(
            /* [out, retval] */ActivationRegistration::ActivationType * activationType
            ) = 0;
        /* [propget] */virtual HRESULT STDMETHODCALLTYPE get_RegistrationScope(
            /* [out, retval] */ActivationRegistration::RegistrationScope * registrationScope
            ) = 0;
        
    };

    MIDL_CONST_ID IID & IID_IActivatableClassRegistration=_uuidof(IActivatableClassRegistration);
    
} /* ActivationRegistration */

EXTERN_C const IID IID___x_ActivationRegistration_CIActivatableClassRegistration;
#endif /* !defined(____x_ActivationRegistration_CIActivatableClassRegistration_INTERFACE_DEFINED__) */


#else // !defined(__cplusplus)
/* Forward Declarations */
#ifndef ____x_ActivationRegistration_CIDllServerActivatableClassRegistration_FWD_DEFINED__
#define ____x_ActivationRegistration_CIDllServerActivatableClassRegistration_FWD_DEFINED__
typedef interface __x_ActivationRegistration_CIDllServerActivatableClassRegistration __x_ActivationRegistration_CIDllServerActivatableClassRegistration;

#endif // ____x_ActivationRegistration_CIDllServerActivatableClassRegistration_FWD_DEFINED__

#ifndef ____x_ActivationRegistration_CIActivatableClassRegistration_FWD_DEFINED__
#define ____x_ActivationRegistration_CIActivatableClassRegistration_FWD_DEFINED__
typedef interface __x_ActivationRegistration_CIActivatableClassRegistration __x_ActivationRegistration_CIActivatableClassRegistration;

#endif // ____x_ActivationRegistration_CIActivatableClassRegistration_FWD_DEFINED__


/*
 *
 * Struct ActivationRegistration.RegistrationScope
 *
 */

/* [v1_enum, version] */
enum __x_ActivationRegistration_CRegistrationScope
{
    RegistrationScope_PerMachine,
    RegistrationScope_PerUser,
    RegistrationScope_InboxApp,
};


/*
 *
 * Struct ActivationRegistration.ActivationType
 *
 */

/* [v1_enum, version] */
enum __x_ActivationRegistration_CActivationType
{
    ActivationType_InProcess,
    ActivationType_OutOfProcess,
    ActivationType_RemoteProcess,
};


/*
 *
 * Struct ActivationRegistration.ThreadingType
 *
 */

/* [v1_enum, version] */
enum __x_ActivationRegistration_CThreadingType
{
    ThreadingType_BOTH,
    ThreadingType_STA,
    ThreadingType_MTA,
};


/*
 *
 * Interface ActivationRegistration.IDllServerActivatableClassRegistration
 *
 */
#if !defined(____x_ActivationRegistration_CIDllServerActivatableClassRegistration_INTERFACE_DEFINED__)
#define ____x_ActivationRegistration_CIDllServerActivatableClassRegistration_INTERFACE_DEFINED__
extern const __declspec(selectany) _Null_terminated_ WCHAR InterfaceName_ActivationRegistration_IDllServerActivatableClassRegistration[] = L"ActivationRegistration.IDllServerActivatableClassRegistration";
/* [object, uuid("C8AA04F6-66C6-46A3-8FE6-F56BE7DDC091"), version] */
typedef struct __x_ActivationRegistration_CIDllServerActivatableClassRegistrationVtbl
{
    BEGIN_INTERFACE
    HRESULT ( STDMETHODCALLTYPE *QueryInterface)(
    __RPC__in __x_ActivationRegistration_CIDllServerActivatableClassRegistration * This,
    /* [in] */ __RPC__in REFIID riid,
    /* [annotation][iid_is][out] */
    _COM_Outptr_  void **ppvObject
    );

ULONG ( STDMETHODCALLTYPE *AddRef )(
    __RPC__in __x_ActivationRegistration_CIDllServerActivatableClassRegistration * This
    );

ULONG ( STDMETHODCALLTYPE *Release )(
    __RPC__in __x_ActivationRegistration_CIDllServerActivatableClassRegistration * This
    );

HRESULT ( STDMETHODCALLTYPE *GetIids )(
    __RPC__in __x_ActivationRegistration_CIDllServerActivatableClassRegistration * This,
    /* [out] */ __RPC__out ULONG *iidCount,
    /* [size_is][size_is][out] */ __RPC__deref_out_ecount_full_opt(*iidCount) IID **iids
    );

HRESULT ( STDMETHODCALLTYPE *GetRuntimeClassName )(
    __RPC__in __x_ActivationRegistration_CIDllServerActivatableClassRegistration * This,
    /* [out] */ __RPC__deref_out_opt HSTRING *className
    );

HRESULT ( STDMETHODCALLTYPE *GetTrustLevel )(
    __RPC__in __x_ActivationRegistration_CIDllServerActivatableClassRegistration * This,
    /* [OUT ] */ __RPC__out TrustLevel *trustLevel
    );
/* [propget] */HRESULT ( STDMETHODCALLTYPE *get_DllPath )(
        __x_ActivationRegistration_CIDllServerActivatableClassRegistration * This,
        /* [out, retval] */HSTRING * dllPath
        );
    /* [propget] */HRESULT ( STDMETHODCALLTYPE *get_ThreadingType )(
        __x_ActivationRegistration_CIDllServerActivatableClassRegistration * This,
        /* [out, retval] */enum __x_ActivationRegistration_CThreadingType * threadingType
        );
    END_INTERFACE
    
} __x_ActivationRegistration_CIDllServerActivatableClassRegistrationVtbl;

interface __x_ActivationRegistration_CIDllServerActivatableClassRegistration
{
    CONST_VTBL struct __x_ActivationRegistration_CIDllServerActivatableClassRegistrationVtbl *lpVtbl;
};

#ifdef COBJMACROS
#define __x_ActivationRegistration_CIDllServerActivatableClassRegistration_QueryInterface(This,riid,ppvObject) \
( (This)->lpVtbl->QueryInterface(This,riid,ppvObject) )

#define __x_ActivationRegistration_CIDllServerActivatableClassRegistration_AddRef(This) \
        ( (This)->lpVtbl->AddRef(This) )

#define __x_ActivationRegistration_CIDllServerActivatableClassRegistration_Release(This) \
        ( (This)->lpVtbl->Release(This) )

#define __x_ActivationRegistration_CIDllServerActivatableClassRegistration_GetIids(This,iidCount,iids) \
        ( (This)->lpVtbl->GetIids(This,iidCount,iids) )

#define __x_ActivationRegistration_CIDllServerActivatableClassRegistration_GetRuntimeClassName(This,className) \
        ( (This)->lpVtbl->GetRuntimeClassName(This,className) )

#define __x_ActivationRegistration_CIDllServerActivatableClassRegistration_GetTrustLevel(This,trustLevel) \
        ( (This)->lpVtbl->GetTrustLevel(This,trustLevel) )

#define __x_ActivationRegistration_CIDllServerActivatableClassRegistration_get_DllPath(This,dllPath) \
    ( (This)->lpVtbl->get_DllPath(This,dllPath) )

#define __x_ActivationRegistration_CIDllServerActivatableClassRegistration_get_ThreadingType(This,threadingType) \
    ( (This)->lpVtbl->get_ThreadingType(This,threadingType) )


#endif /* COBJMACROS */


EXTERN_C const IID IID___x_ActivationRegistration_CIDllServerActivatableClassRegistration;
#endif /* !defined(____x_ActivationRegistration_CIDllServerActivatableClassRegistration_INTERFACE_DEFINED__) */


/*
 *
 * Interface ActivationRegistration.IActivatableClassRegistration
 *
 */
#if !defined(____x_ActivationRegistration_CIActivatableClassRegistration_INTERFACE_DEFINED__)
#define ____x_ActivationRegistration_CIActivatableClassRegistration_INTERFACE_DEFINED__
extern const __declspec(selectany) _Null_terminated_ WCHAR InterfaceName_ActivationRegistration_IActivatableClassRegistration[] = L"ActivationRegistration.IActivatableClassRegistration";
/* [object, uuid("9BBCAE23-3DD6-49C3-B63C-1C587E7A6A67"), version] */
typedef struct __x_ActivationRegistration_CIActivatableClassRegistrationVtbl
{
    BEGIN_INTERFACE
    HRESULT ( STDMETHODCALLTYPE *QueryInterface)(
    __RPC__in __x_ActivationRegistration_CIActivatableClassRegistration * This,
    /* [in] */ __RPC__in REFIID riid,
    /* [annotation][iid_is][out] */
    _COM_Outptr_  void **ppvObject
    );

ULONG ( STDMETHODCALLTYPE *AddRef )(
    __RPC__in __x_ActivationRegistration_CIActivatableClassRegistration * This
    );

ULONG ( STDMETHODCALLTYPE *Release )(
    __RPC__in __x_ActivationRegistration_CIActivatableClassRegistration * This
    );

HRESULT ( STDMETHODCALLTYPE *GetIids )(
    __RPC__in __x_ActivationRegistration_CIActivatableClassRegistration * This,
    /* [out] */ __RPC__out ULONG *iidCount,
    /* [size_is][size_is][out] */ __RPC__deref_out_ecount_full_opt(*iidCount) IID **iids
    );

HRESULT ( STDMETHODCALLTYPE *GetRuntimeClassName )(
    __RPC__in __x_ActivationRegistration_CIActivatableClassRegistration * This,
    /* [out] */ __RPC__deref_out_opt HSTRING *className
    );

HRESULT ( STDMETHODCALLTYPE *GetTrustLevel )(
    __RPC__in __x_ActivationRegistration_CIActivatableClassRegistration * This,
    /* [OUT ] */ __RPC__out TrustLevel *trustLevel
    );
/* [propget] */HRESULT ( STDMETHODCALLTYPE *get_ActivatableClassId )(
        __x_ActivationRegistration_CIActivatableClassRegistration * This,
        /* [out, retval] */HSTRING * activatableClassID
        );
    /* [propget] */HRESULT ( STDMETHODCALLTYPE *get_ActivationType )(
        __x_ActivationRegistration_CIActivatableClassRegistration * This,
        /* [out, retval] */enum __x_ActivationRegistration_CActivationType * activationType
        );
    /* [propget] */HRESULT ( STDMETHODCALLTYPE *get_RegistrationScope )(
        __x_ActivationRegistration_CIActivatableClassRegistration * This,
        /* [out, retval] */enum __x_ActivationRegistration_CRegistrationScope * registrationScope
        );
    END_INTERFACE
    
} __x_ActivationRegistration_CIActivatableClassRegistrationVtbl;

interface __x_ActivationRegistration_CIActivatableClassRegistration
{
    CONST_VTBL struct __x_ActivationRegistration_CIActivatableClassRegistrationVtbl *lpVtbl;
};

#ifdef COBJMACROS
#define __x_ActivationRegistration_CIActivatableClassRegistration_QueryInterface(This,riid,ppvObject) \
( (This)->lpVtbl->QueryInterface(This,riid,ppvObject) )

#define __x_ActivationRegistration_CIActivatableClassRegistration_AddRef(This) \
        ( (This)->lpVtbl->AddRef(This) )

#define __x_ActivationRegistration_CIActivatableClassRegistration_Release(This) \
        ( (This)->lpVtbl->Release(This) )

#define __x_ActivationRegistration_CIActivatableClassRegistration_GetIids(This,iidCount,iids) \
        ( (This)->lpVtbl->GetIids(This,iidCount,iids) )

#define __x_ActivationRegistration_CIActivatableClassRegistration_GetRuntimeClassName(This,className) \
        ( (This)->lpVtbl->GetRuntimeClassName(This,className) )

#define __x_ActivationRegistration_CIActivatableClassRegistration_GetTrustLevel(This,trustLevel) \
        ( (This)->lpVtbl->GetTrustLevel(This,trustLevel) )

#define __x_ActivationRegistration_CIActivatableClassRegistration_get_ActivatableClassId(This,activatableClassID) \
    ( (This)->lpVtbl->get_ActivatableClassId(This,activatableClassID) )

#define __x_ActivationRegistration_CIActivatableClassRegistration_get_ActivationType(This,activationType) \
    ( (This)->lpVtbl->get_ActivationType(This,activationType) )

#define __x_ActivationRegistration_CIActivatableClassRegistration_get_RegistrationScope(This,registrationScope) \
    ( (This)->lpVtbl->get_RegistrationScope(This,registrationScope) )


#endif /* COBJMACROS */


EXTERN_C const IID IID___x_ActivationRegistration_CIActivatableClassRegistration;
#endif /* !defined(____x_ActivationRegistration_CIActivatableClassRegistration_INTERFACE_DEFINED__) */


#endif // defined(__cplusplus)
#pragma pop_macro("MIDL_CONST_ID")
#endif // __ActivationRegistration_p_h__

#endif // __ActivationRegistration_h__

#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>


struct VirtualActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1>
struct VirtualActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2>
struct VirtualActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename R, typename T1>
struct VirtualFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1>
struct GenericVirtualActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1>
struct InterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2>
struct InterfaceActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename R>
struct InterfaceFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename R, typename T1>
struct InterfaceFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R, typename T1, typename T2, typename T3>
struct InterfaceFuncInvoker3
{
	typedef R (*Func)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
template <typename T1>
struct GenericInterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};

struct Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C;
struct Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87;
struct Action_1_t5EE2731CD3844B09BE19CB0B65A5DC8D80883480;
struct Action_2_t3EDD987DFCD31953576008A0D7D4F44D8C984B1D;
struct AsyncLocal_1_t1D3339EA4C8650D2DEDDF9553E5C932B3DC2CCFD;
struct AsyncOperationBase_1_t264CB4D817C2464BBB4459949707E3EE57EA0E59;
struct AsyncOperationBase_1_t777EC3ACED7579A0B8EFE3EEE605D824516B3C13;
struct Dictionary_2_t5C8F46F5D57502270DD9E1DA8303B23C7FE85588;
struct IEnumerable_1_tEA17B83295B756EFB23F3357537A3AAC9B4D9732;
struct IEnumerable_1_tF95C9E01A913DD50575531C8305932628663D9E9;
struct IList_1_tFEC432B87E444FFF0D7B8EFD6CBB918523AD6827;
struct IReadOnlyList_1_t7BB300FE9C8B0D3BCB34B752D2516BD12EB5E8CF;
struct IntHashtable_1_tDC7FED120C3F2BFFE052D1A2C011112467A0E2BC;
struct IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7;
struct List_1_tDB72209F35D56F62A287633F9450978E90B90987;
struct List_1_tBB2A683F0E0235131456ACFC1A1E2D0A2F6EC311;
struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D;
struct List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD;
struct Stack_1_tAD790A47551563636908E21E4F08C54C0C323EB5;
struct Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82;
struct Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81;
struct IntHashtableEntryU5BU5D_tCB257C41AA560EE20707A710641F2C7D63B423BE;
struct ActionU5BU5D_tF6161335A0A12A221AB081D78725C8AB6FE506D2;
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918;
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;
struct TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB;
struct FrameLimitUpdatorU5BU5D_t1B2A2CD744BCD317F13C0C187F57CD34876325CF;
struct TimeLimitUpdatorU5BU5D_t2C7C40955099B3F6EC405EAD8470629D3C246632;
struct AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1;
struct Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07;
struct ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6;
struct AssetReference_t6AF4EE7422535138F655BFF2636B23D0BE26C740;
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C;
struct Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235;
struct CancellationTokenSource_tAAE1E0033BCFC233801F8CB4CED5C852B350CB7B;
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3;
struct Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B;
struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0;
struct Delegate_t;
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
struct DisplayNameAttribute_tECBA9AC4CCBE61186E2B3C397C93AAFA5A2631E8;
struct EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF;
struct Exception_t;
struct ExecutionContext_t9D6EDFD92F0B2D391751963E2D77A8B03CB81710;
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F;
struct IAsyncOperation_tAA751C850291C1C50151BE8313DE52B2A894023C;
struct IAsyncResult_t7B9B5A0ECB35DCEC31B8A8122C37D687369253B5;
struct IController_t686B9685C82E6F34DA81497046667C7816DD8465;
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
struct IEnumerator_t7B609C2FFA6EB5167D9C62A0C32A21DE2F666DAA;
struct IModel_tF975C316F2169AE65113A7F4EF96EDC900083832;
struct IPrincipal_tE7AF5096287F6C3472585E124CB38FF2A51EAB5F;
struct IView_t01699911F63B14053AD21C2EB3A1580BBAE46E1D;
struct IncrementAttribute_t4EEF3E3CB6B83DC54346F0AB93DEA5102A661150;
struct InternalOptionsRegistry_t37F5D710767EF2F74CF225D94C602B84151A8F96;
struct InternalThread_tF40B7BFCBD60C82BD8475A22FF5186CA10293687;
struct LocalDataStoreHolder_t789DD474AE5141213C2105CE57830ECFC2D3C03F;
struct LocalDataStoreMgr_t205F1783D5CC2B148E829B5882E5406FF9A3AC1E;
struct MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553;
struct MethodInfo_t;
struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71;
struct MulticastDelegate_t;
struct NumberRangeAttribute_t36C0A939C7C6DC0971357D6A5BC6B4D8FD570585;
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C;
struct PropertyChangedEventArgs_tFA01343D8F2BD799951B40A3EBF4A6B38EE63321;
struct PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA;
struct SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F;
struct SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7;
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
struct SortAttribute_t745731D856AA0915EBA410630E554D11F6CCADBA;
struct Stopwatch_tA188A210449E22C07053A7D3014DD182C7369043;
struct String_t;
struct Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F;
struct Type_t;
struct UniqueMonoEventListener_t608C75BB5859C7C58DBD298123D78BAF8D15FD22;
struct UnitySourceGeneratedAssemblyMonoScriptTypes_v1_tC95F24D0C6E6B77389433852BB389F39C692926E;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
struct BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA;
struct FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6;
struct TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286;
struct DisplayNameAttribute_t36237DD738F919AF725D1A3160E859B8DB716264;
struct IncrementAttribute_tA4CDFC00F53F82FE8F31085E97F79F4BA1B76DD1;
struct NumberRangeAttribute_tF57CDD96B27582AF4FA0311F052A33A62467ABAD;
struct SortAttribute_t3BCAFC7857086FCCD52C024CFC9F51F00155E6FB;

IL2CPP_EXTERN_C RuntimeClass* AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Addressables_tB93529ED0B034BF1A8C7830710BAA45C20A0F7D6_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* DisplayNameAttribute_tECBA9AC4CCBE61186E2B3C397C93AAFA5A2631E8_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Exception_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ICollection_1_t5C589FDB16AA590F74FBE8A07066DD3139D14C1B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IList_1_tFEC432B87E444FFF0D7B8EFD6CBB918523AD6827_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IResourceLocation_tB0706DA8EB5339ECB4B64C7D2DAFC1EB35D2915C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_tDB72209F35D56F62A287633F9450978E90B90987_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* PropertyChangedEventArgs_tFA01343D8F2BD799951B40A3EBF4A6B38EE63321_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SRServiceManager_t65EAD8CD1C096A4BCD42B5D36406A7954972394F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* String_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeField* U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____80F16B889816C9E07DCA7BF19ACC6E3E5264FF44E2F83EECB1D18D13B29CAEF2_FieldInfo_var;
IL2CPP_EXTERN_C RuntimeField* U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____D88667469C6FCCC9E6D32B2D72E98848BA7A655342BB59B26CAAA782B608D078_FieldInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral0B34DFC38793BF0AF6DEA9A94F7CCB4150E999A6;
IL2CPP_EXTERN_C String_t* _stringLiteral0DDCAE3541991F7A132995973182C81F165202EA;
IL2CPP_EXTERN_C String_t* _stringLiteral22580C0B7AD84C4AECA419E0D9AFE6D911D665EB;
IL2CPP_EXTERN_C String_t* _stringLiteral2D44E239F7F7113B03C634F55CA3154323BD17FD;
IL2CPP_EXTERN_C String_t* _stringLiteral43C0D8B652A7EC1ED24DAB96DCAF8B8E0951199B;
IL2CPP_EXTERN_C String_t* _stringLiteral4C43361A0A500CC6B80443746394A4C1D19915BD;
IL2CPP_EXTERN_C String_t* _stringLiteral4CFB1E3E372A1023D954142752C1559837789E9A;
IL2CPP_EXTERN_C String_t* _stringLiteral55E382D2A87639E92586500E9D82F62C78BE7A5E;
IL2CPP_EXTERN_C String_t* _stringLiteral5836653E8843C7C00D22A75244ACDE7BADBC7E44;
IL2CPP_EXTERN_C String_t* _stringLiteral676847AA880D8C9BE69BAEB24A1780F4F5961D3A;
IL2CPP_EXTERN_C String_t* _stringLiteral888EBEBE9186AFB4A7D01CBC71C6B2371279F34C;
IL2CPP_EXTERN_C String_t* _stringLiteral9017E0B86CEA2958388B230907BD06616C5825A2;
IL2CPP_EXTERN_C String_t* _stringLiteral946BD80B231F5776B5307B385889C9ABB57D3D53;
IL2CPP_EXTERN_C String_t* _stringLiteral9F8B6416025F8E80F10F7DE5DE3B9F6E66DE44BF;
IL2CPP_EXTERN_C String_t* _stringLiteralA3F029047BA90CC134023587DF7DCF444B38D009;
IL2CPP_EXTERN_C String_t* _stringLiteralB5708797E9BA28F569AF0865FDDCC9EEAE306229;
IL2CPP_EXTERN_C String_t* _stringLiteralBCE5DFBBF7E64AB83566D2430482BC76DDB9B666;
IL2CPP_EXTERN_C String_t* _stringLiteralBF14C2BD89884057518C99D97A2C754419B37C13;
IL2CPP_EXTERN_C String_t* _stringLiteralC766BA5E1A2B4818EDC97B520C896F5B474C96BA;
IL2CPP_EXTERN_C String_t* _stringLiteralC797AA5566D618284C16BDB5B6BD0C58006C5CA5;
IL2CPP_EXTERN_C String_t* _stringLiteralC7E9DAF844B25471D821CB8F094AE5423C2EECC4;
IL2CPP_EXTERN_C String_t* _stringLiteralC8B1BFECA177AC9C06E600CD04A0B2690ADFD46B;
IL2CPP_EXTERN_C String_t* _stringLiteralC94C277BA0A3F63AE2448B986F92E23DD20CAEED;
IL2CPP_EXTERN_C String_t* _stringLiteralCAF9697CE37A5F300BFCA9F8EEBEB31D3261B016;
IL2CPP_EXTERN_C String_t* _stringLiteralCB3483C2BBD50C51695B5E82E68C99844AFBD5B2;
IL2CPP_EXTERN_C String_t* _stringLiteralCBE546B03B98A03E01E5D08EDAE4F54E2FC423BB;
IL2CPP_EXTERN_C String_t* _stringLiteralD67E94B0E217A14362DBB9C21C62D58060C381B6;
IL2CPP_EXTERN_C String_t* _stringLiteralD78C3C96EA9229AC2F206D616055366865E0FFA6;
IL2CPP_EXTERN_C String_t* _stringLiteralD94EE64A40FB09C92A977390D5E856181E063C88;
IL2CPP_EXTERN_C String_t* _stringLiteralE75D2BEC76121F70F5B673587DE49DE9EAD114BA;
IL2CPP_EXTERN_C const RuntimeMethod* Addressables_Release_TisIList_1_tFEC432B87E444FFF0D7B8EFD6CBB918523AD6827_m05E0F779E22A2AEB81C2DC54F3578A128A11920C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AsyncOperationHandle_1_WaitForCompletion_mB4F188A55BCF8E8117460DE5BF131EBE981F2F02_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* IntHashtable_1__ctor_m18015E230A511EE02627075413DCD4DB2AC32520_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* IntHashtable_1_get_Item_m35BE2466A07F288C6AC3196E60FBA36EE3539A70_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* IntHashtable_1_set_Item_mE8F2A507CD5AA919580B1B5ED50E6FB95125765C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_AddRange_m475DC02C782750D4036B11E287BC01ECB8313D1D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_m5B99D67CB378BFA8A1142343F9DB44D94322EAD3_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Clear_m344AD90676A608EA37B9DF93050BA9F80C23D17E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_mBFD6DF02E045EDF3C322E2112C922457016C8212_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Count_m5E7FCE3DF7B23B6D88C14A04177C1DCD15063858_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Item_m8A119323481338039197B73D82916BB46DEE3C2D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* SRServiceManager_GetService_TisInternalOptionsRegistry_t37F5D710767EF2F74CF225D94C602B84151A8F96_m9C1B26F6376FD4144BC139300A02AC30A89EF6DC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Stack_1_Pop_m4211BBED271E0EF23575C2E725EC27B70EC67FF4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Stack_1_Pop_m4FAF28A63461E2F308410C48D9F849FF58C620CB_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Stack_1_Push_m74B0B4001B47D54122FAD47F9A15CAE6999BE999_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Stack_1_Push_m9AC476B9994A6B99BDFEEA6D9083964E6E675247_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Stack_1__ctor_m1CD70C0A52FF57609719F8D154189A2D46D761E9_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Stack_1__ctor_mF4E396597BA5F70792292CD405F863A411F5EC0E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Stack_1_get_Count_m4873716797859474506B12AC03816C475F318082_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Stack_1_get_Count_m5EA24311FD8233421583A3D592432402CC0752DA_RuntimeMethod_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct U3CModuleU3E_tBB65183F1134474D09FF49B95625D25472B9BA8B 
{
};
struct IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7  : public RuntimeObject
{
	IntHashtableEntryU5BU5D_tCB257C41AA560EE20707A710641F2C7D63B423BE* ____table;
	int32_t ____count;
	int32_t ____threshold;
	float ____loadFactor;
};
struct List_1_tDB72209F35D56F62A287633F9450978E90B90987  : public RuntimeObject
{
	ActionU5BU5D_tF6161335A0A12A221AB081D78725C8AB6FE506D2* ____items;
	int32_t ____size;
	int32_t ____version;
	RuntimeObject* ____syncRoot;
};
struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D  : public RuntimeObject
{
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ____items;
	int32_t ____size;
	int32_t ____version;
	RuntimeObject* ____syncRoot;
};
struct List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD  : public RuntimeObject
{
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ____items;
	int32_t ____size;
	int32_t ____version;
	RuntimeObject* ____syncRoot;
};
struct Stack_1_tAD790A47551563636908E21E4F08C54C0C323EB5  : public RuntimeObject
{
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ____array;
	int32_t ____size;
	int32_t ____version;
	RuntimeObject* ____syncRoot;
};
struct Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82  : public RuntimeObject
{
	FrameLimitUpdatorU5BU5D_t1B2A2CD744BCD317F13C0C187F57CD34876325CF* ____array;
	int32_t ____size;
	int32_t ____version;
	RuntimeObject* ____syncRoot;
};
struct Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81  : public RuntimeObject
{
	TimeLimitUpdatorU5BU5D_t2C7C40955099B3F6EC405EAD8470629D3C246632* ____array;
	int32_t ____size;
	int32_t ____version;
	RuntimeObject* ____syncRoot;
};
struct U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA  : public RuntimeObject
{
};
struct AddressablesUtility_t4CCE6EE705EA0C281354F46964F27F480CE60695  : public RuntimeObject
{
};
struct Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA  : public RuntimeObject
{
};
struct CriticalFinalizerObject_t1DCAB623CAEA6529A96F5F3EDE3C7048A6E313C9  : public RuntimeObject
{
};
struct DefaultFacadeImpl_t2711022C8A1B4CD579F715ADD80DB423D3BAF12C  : public RuntimeObject
{
	RuntimeObject* ___m_controller;
	RuntimeObject* ___m_model;
	RuntimeObject* ___m_view;
};
struct EventArgs_t37273F03EAC87217701DD431B190FBD84AD7C377  : public RuntimeObject
{
};
struct InternalOptionsRegistry_t37F5D710767EF2F74CF225D94C602B84151A8F96  : public RuntimeObject
{
	List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* ____registeredContainers;
	Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ____handler;
};
struct MemberInfo_t  : public RuntimeObject
{
};
struct SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F  : public RuntimeObject
{
	int32_t ___U3CLevelIdU3Ek__BackingField;
	int32_t ___U3CGoldNumberU3Ek__BackingField;
	int32_t ___U3CRemainTimeU3Ek__BackingField;
	SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* ___PropertyChanged;
	PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* ___InterfacePropertyChangedEventHandler;
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
};
struct UnitySourceGeneratedAssemblyMonoScriptTypes_v1_tC95F24D0C6E6B77389433852BB389F39C692926E  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D  : public RuntimeObject
{
};
struct YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D_marshaled_pinvoke
{
};
struct YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D_marshaled_com
{
};
struct BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA  : public RuntimeObject
{
	int32_t ___U3CidU3Ek__BackingField;
	bool ___U3CactiveU3Ek__BackingField;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ____updateProxyHandler;
	Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ____updateHandler;
	RuntimeObject* ____param;
	bool ____once;
	int32_t ____disposeTimes;
};
struct AsyncOperationHandle_1_tDA2BA7FC48753E9F44D6A9B3873AAB9F2BE05DA4 
{
	AsyncOperationBase_1_t264CB4D817C2464BBB4459949707E3EE57EA0E59* ___m_InternalOp;
	int32_t ___m_Version;
	String_t* ___m_LocationName;
	bool ___m_UnloadSceneOpExcludeReleaseCallback;
};
struct AsyncOperationHandle_1_tDD1D892D87C7A0C3189DD56DDB997AB1A2089A74 
{
	AsyncOperationBase_1_t777EC3ACED7579A0B8EFE3EEE605D824516B3C13* ___m_InternalOp;
	int32_t ___m_Version;
	String_t* ___m_LocationName;
	bool ___m_UnloadSceneOpExcludeReleaseCallback;
};
struct ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6  : public DefaultFacadeImpl_t2711022C8A1B4CD579F715ADD80DB423D3BAF12C
{
	Dictionary_2_t5C8F46F5D57502270DD9E1DA8303B23C7FE85588* ____cachedNotiMap;
	List_1_tBB2A683F0E0235131456ACFC1A1E2D0A2F6EC311* ____cachedNotiList;
	bool ____cachedNoti;
	Stopwatch_tA188A210449E22C07053A7D3014DD182C7369043* ___stopwatch;
	double ___current;
	int32_t ____stackNum;
};
struct AsyncOperationHandle_t58B507DCAA6531B85FDBA6188D8E1F7DF89D3F5D 
{
	RuntimeObject* ___m_InternalOp;
	int32_t ___m_Version;
	String_t* ___m_LocationName;
};
struct AsyncOperationHandle_t58B507DCAA6531B85FDBA6188D8E1F7DF89D3F5D_marshaled_pinvoke
{
	RuntimeObject* ___m_InternalOp;
	int32_t ___m_Version;
	char* ___m_LocationName;
};
struct AsyncOperationHandle_t58B507DCAA6531B85FDBA6188D8E1F7DF89D3F5D_marshaled_com
{
	RuntimeObject* ___m_InternalOp;
	int32_t ___m_Version;
	Il2CppChar* ___m_LocationName;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value;
};
struct Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3 
{
	uint8_t ___m_value;
};
struct DisplayNameAttribute_tECBA9AC4CCBE61186E2B3C397C93AAFA5A2631E8  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	String_t* ___U3CDisplayNameValueU3Ek__BackingField;
};
struct Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F 
{
	double ___m_value;
};
struct IncrementAttribute_t4EEF3E3CB6B83DC54346F0AB93DEA5102A661150  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	double ___Increment;
};
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	int32_t ___m_value;
};
struct IntPtr_t 
{
	void* ___m_value;
};
struct NumberRangeAttribute_t36C0A939C7C6DC0971357D6A5BC6B4D8FD570585  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	double ___Max;
	double ___Min;
};
struct PropertyChangedEventArgs_tFA01343D8F2BD799951B40A3EBF4A6B38EE63321  : public EventArgs_t37273F03EAC87217701DD431B190FBD84AD7C377
{
	String_t* ____propertyName;
};
struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	float ___m_value;
};
struct SortAttribute_t745731D856AA0915EBA410630E554D11F6CCADBA  : public Attribute_tFDA8EFEFB0711976D22474794576DAF28F7440AA
{
	int32_t ___SortPriority;
};
struct Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F  : public CriticalFinalizerObject_t1DCAB623CAEA6529A96F5F3EDE3C7048A6E313C9
{
	InternalThread_tF40B7BFCBD60C82BD8475A22FF5186CA10293687* ___internal_thread;
	RuntimeObject* ___m_ThreadStartArg;
	RuntimeObject* ___pending_exception;
	MulticastDelegate_t* ___m_Delegate;
	ExecutionContext_t9D6EDFD92F0B2D391751963E2D77A8B03CB81710* ___m_ExecutionContext;
	bool ___m_ExecutionContextBelongsToOuterScope;
	RuntimeObject* ___principal;
	int32_t ___principal_version;
};
struct UpdateTimeInfo_tCC8E1C8131E776D226406C9D1F4FFE8E99577B22 
{
	int32_t ___frameCount;
	float ___timeScale;
	float ___smoothDeltaTime;
	float ___fixedDeltaTime;
	float ___fixedUnscaledDeltaTime;
	float ___unscaledDeltaTime;
	float ___fixedUnscaledTime;
	float ___unscaledTime;
	float ___fixedTime;
	float ___deltaTime;
	float ___timeSinceLevelLoad;
	float ___time;
	float ___realtimeSinceStartup;
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
#pragma pack(push, tp, 1)
struct __StaticArrayInitTypeSizeU3D421_tF006DBB4093BBE9FF75AE175713A212BD6240CB1 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D421_tF006DBB4093BBE9FF75AE175713A212BD6240CB1__padding[421];
	};
};
#pragma pack(pop, tp)
#pragma pack(push, tp, 1)
struct __StaticArrayInitTypeSizeU3D493_t2AE3B8A966BEE381AA636030EC391717DB1B0AC2 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D493_t2AE3B8A966BEE381AA636030EC391717DB1B0AC2__padding[493];
	};
};
#pragma pack(pop, tp)
struct FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6  : public BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA
{
	int32_t ____lastFrame;
	int32_t ____interval;
	bool ____inPool;
};
struct TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286  : public BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA
{
	double ____lastTime;
	float ____interval;
	bool ____inPool;
};
struct MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E 
{
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___FilePathsData;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___TypesData;
	int32_t ___TotalTypes;
	int32_t ___TotalFiles;
	bool ___IsEditorOnly;
};
struct MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E_marshaled_pinvoke
{
	Il2CppSafeArray* ___FilePathsData;
	Il2CppSafeArray* ___TypesData;
	int32_t ___TotalTypes;
	int32_t ___TotalFiles;
	int32_t ___IsEditorOnly;
};
struct MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E_marshaled_com
{
	Il2CppSafeArray* ___FilePathsData;
	Il2CppSafeArray* ___TypesData;
	int32_t ___TotalTypes;
	int32_t ___TotalFiles;
	int32_t ___IsEditorOnly;
};
struct AssetReference_t6AF4EE7422535138F655BFF2636B23D0BE26C740  : public RuntimeObject
{
	String_t* ___m_AssetGUID;
	String_t* ___m_SubObjectName;
	String_t* ___m_SubObjectType;
	AsyncOperationHandle_t58B507DCAA6531B85FDBA6188D8E1F7DF89D3F5D ___m_Operation;
};
struct Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B  : public YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D
{
	intptr_t ___m_Ptr;
};
struct Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B_marshaled_pinvoke : public YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D_marshaled_pinvoke
{
	intptr_t ___m_Ptr;
};
struct Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B_marshaled_com : public YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D_marshaled_com
{
	intptr_t ___m_Ptr;
};
struct Delegate_t  : public RuntimeObject
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	RuntimeObject* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	bool ___method_is_virtual;
};
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	Il2CppIUnknown* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	int32_t ___method_is_virtual;
};
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	Il2CppIUnknown* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	int32_t ___method_is_virtual;
};
struct Exception_t  : public RuntimeObject
{
	String_t* ____className;
	String_t* ____message;
	RuntimeObject* ____data;
	Exception_t* ____innerException;
	String_t* ____helpURL;
	RuntimeObject* ____stackTrace;
	String_t* ____stackTraceString;
	String_t* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	RuntimeObject* ____dynamicMethods;
	int32_t ____HResult;
	String_t* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Exception_t_marshaled_pinvoke
{
	char* ____className;
	char* ____message;
	RuntimeObject* ____data;
	Exception_t_marshaled_pinvoke* ____innerException;
	char* ____helpURL;
	Il2CppIUnknown* ____stackTrace;
	char* ____stackTraceString;
	char* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	Il2CppIUnknown* ____dynamicMethods;
	int32_t ____HResult;
	char* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	Il2CppSafeArray* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className;
	Il2CppChar* ____message;
	RuntimeObject* ____data;
	Exception_t_marshaled_com* ____innerException;
	Il2CppChar* ____helpURL;
	Il2CppIUnknown* ____stackTrace;
	Il2CppChar* ____stackTraceString;
	Il2CppChar* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	Il2CppIUnknown* ____dynamicMethods;
	int32_t ____HResult;
	Il2CppChar* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	Il2CppSafeArray* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C  : public RuntimeObject
{
	intptr_t ___m_CachedPtr;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
	intptr_t ___m_CachedPtr;
};
struct RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 
{
	intptr_t ___value;
};
struct RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B 
{
	intptr_t ___value;
};
struct DisplayNameAttribute_t36237DD738F919AF725D1A3160E859B8DB716264  : public DisplayNameAttribute_tECBA9AC4CCBE61186E2B3C397C93AAFA5A2631E8
{
};
struct IncrementAttribute_tA4CDFC00F53F82FE8F31085E97F79F4BA1B76DD1  : public IncrementAttribute_t4EEF3E3CB6B83DC54346F0AB93DEA5102A661150
{
};
struct NumberRangeAttribute_tF57CDD96B27582AF4FA0311F052A33A62467ABAD  : public NumberRangeAttribute_t36C0A939C7C6DC0971357D6A5BC6B4D8FD570585
{
};
struct SortAttribute_t3BCAFC7857086FCCD52C024CFC9F51F00155E6FB  : public SortAttribute_t745731D856AA0915EBA410630E554D11F6CCADBA
{
};
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};
struct MulticastDelegate_t  : public Delegate_t
{
	DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771* ___delegates;
};
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates;
};
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates;
};
struct Type_t  : public MemberInfo_t
{
	RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ____impl;
};
struct Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87  : public MulticastDelegate_t
{
};
struct Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07  : public MulticastDelegate_t
{
};
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C  : public MulticastDelegate_t
{
};
struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};
struct PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA  : public MulticastDelegate_t
{
};
struct SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7  : public MulticastDelegate_t
{
};
struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
	CancellationTokenSource_tAAE1E0033BCFC233801F8CB4CED5C852B350CB7B* ___m_CancellationTokenSource;
};
struct AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
};
struct EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7* ____updatorMap;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ____updateDelegate;
	List_1_tDB72209F35D56F62A287633F9450978E90B90987* ____pendingRunnableQueue;
	List_1_tDB72209F35D56F62A287633F9450978E90B90987* ____cachedRunnableQueue;
};
struct UniqueMonoEventListener_t608C75BB5859C7C58DBD298123D78BAF8D15FD22  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	Action_1_t5EE2731CD3844B09BE19CB0B65A5DC8D80883480* ___scriptOnStart;
	Action_1_t5EE2731CD3844B09BE19CB0B65A5DC8D80883480* ___scriptOnFixedUpdate;
	Action_1_t5EE2731CD3844B09BE19CB0B65A5DC8D80883480* ___scriptOnUpdate;
	Action_1_t5EE2731CD3844B09BE19CB0B65A5DC8D80883480* ___scriptOnLateUpdate;
	Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* ___scriptOnApplicationFocus;
	Action_1_t10DCB0C07D0D3C565CEACADC80D1152B35A45F6C* ___scriptOnApplicationPause;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___scriptOnApplicationQuit;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___scriptOnEndOfFrame;
	Action_2_t3EDD987DFCD31953576008A0D7D4F44D8C984B1D* ___scriptOnNativePluginMessage;
	UpdateTimeInfo_tCC8E1C8131E776D226406C9D1F4FFE8E99577B22 ___U3CcurrentUpdateTimeInfoU3Ek__BackingField;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___onApplicationQuit;
};
struct List_1_tDB72209F35D56F62A287633F9450978E90B90987_StaticFields
{
	ActionU5BU5D_tF6161335A0A12A221AB081D78725C8AB6FE506D2* ___s_emptyArray;
};
struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D_StaticFields
{
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___s_emptyArray;
};
struct List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_StaticFields
{
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___s_emptyArray;
};
struct U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA_StaticFields
{
	__StaticArrayInitTypeSizeU3D421_tF006DBB4093BBE9FF75AE175713A212BD6240CB1 ___80F16B889816C9E07DCA7BF19ACC6E3E5264FF44E2F83EECB1D18D13B29CAEF2;
	__StaticArrayInitTypeSizeU3D493_t2AE3B8A966BEE381AA636030EC391717DB1B0AC2 ___D88667469C6FCCC9E6D32B2D72E98848BA7A655342BB59B26CAAA782B608D078;
};
struct SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F_StaticFields
{
	SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* ____current;
};
struct String_t_StaticFields
{
	String_t* ___Empty;
};
struct ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_StaticFields
{
	RuntimeObject* ____staticSyncRoot;
	ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* ____instance;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString;
	String_t* ___FalseString;
};
struct DisplayNameAttribute_tECBA9AC4CCBE61186E2B3C397C93AAFA5A2631E8_StaticFields
{
	DisplayNameAttribute_tECBA9AC4CCBE61186E2B3C397C93AAFA5A2631E8* ___Default;
};
struct IntPtr_t_StaticFields
{
	intptr_t ___Zero;
};
struct Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F_StaticFields
{
	LocalDataStoreMgr_t205F1783D5CC2B148E829B5882E5406FF9A3AC1E* ___s_LocalDataStoreMgr;
	AsyncLocal_1_t1D3339EA4C8650D2DEDDF9553E5C932B3DC2CCFD* ___s_asyncLocalCurrentCulture;
	AsyncLocal_1_t1D3339EA4C8650D2DEDDF9553E5C932B3DC2CCFD* ___s_asyncLocalCurrentUICulture;
};
struct Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F_ThreadStaticFields
{
	LocalDataStoreHolder_t789DD474AE5141213C2105CE57830ECFC2D3C03F* ___s_LocalDataStore;
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___m_CurrentCulture;
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___m_CurrentUICulture;
	Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* ___current_thread;
};
struct FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_StaticFields
{
	Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82* ____frameLimitUpdatorStack;
};
struct TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_StaticFields
{
	Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81* ____timeLimitUpdatorStack;
};
struct Exception_t_StaticFields
{
	RuntimeObject* ___s_EDILock;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_StaticFields
{
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject;
};
struct Type_t_StaticFields
{
	Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235* ___s_defaultBinder;
	Il2CppChar ___Delimiter;
	TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB* ___EmptyTypes;
	RuntimeObject* ___Missing;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterAttribute;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterName;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterNameIgnoreCase;
};
struct AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1_StaticFields
{
	RuntimeObject* ___PatchedAOTAssemblyList;
};
struct EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields
{
	int32_t ____globalId;
	EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* ____instance;
	UpdateTimeInfo_tCC8E1C8131E776D226406C9D1F4FFE8E99577B22 ____currentFrameUpdateTimeInfo;
	int32_t ____mainThreadId;
};
struct UniqueMonoEventListener_t608C75BB5859C7C58DBD298123D78BAF8D15FD22_StaticFields
{
	UniqueMonoEventListener_t608C75BB5859C7C58DBD298123D78BAF8D15FD22* ____instance;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771  : public RuntimeArray
{
	ALIGN_FIELD (8) Delegate_t* m_Items[1];

	inline Delegate_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Delegate_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Delegate_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Delegate_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031  : public RuntimeArray
{
	ALIGN_FIELD (8) uint8_t m_Items[1];

	inline uint8_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint8_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint8_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint8_t value)
	{
		m_Items[index] = value;
	}
};
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918  : public RuntimeArray
{
	ALIGN_FIELD (8) RuntimeObject* m_Items[1];

	inline RuntimeObject* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RuntimeObject* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline RuntimeObject* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RuntimeObject* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};


IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* SRServiceManager_GetService_TisRuntimeObject_mCECA3E42BBB83185086FEC067BAE634309D9A6FD_gshared (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_m7F078BB342729BDF11327FD89D7872265328F690_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void List_1_Add_mEBCF994CC3814631017F46A387B1A192ED6C85C7_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, RuntimeObject* ___0_item, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* AsyncOperationHandle_1_WaitForCompletion_m4E4B5C196ABB1FB73BC34C54E9E6E4955B6255F6_gshared (AsyncOperationHandle_1_tDD1D892D87C7A0C3189DD56DDB997AB1A2089A74* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Addressables_Release_TisRuntimeObject_m532EA1203DD205F51CF634FD0E63965162B1AFB7_gshared (AsyncOperationHandle_1_tDD1D892D87C7A0C3189DD56DDB997AB1A2089A74 ___0_handle, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IntHashtable_1_set_Item_m634B5533B6C2C2E0B2557CA620A50ACDFC4CE74F_gshared (IntHashtable_1_tDC7FED120C3F2BFFE052D1A2C011112467A0E2BC* __this, int32_t ___0_key, RuntimeObject* ___1_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* IntHashtable_1_get_Item_m8B96FE67A64E6F32B04167D7ED0CC4C815D65A04_gshared (IntHashtable_1_tDC7FED120C3F2BFFE052D1A2C011112467A0E2BC* __this, int32_t ___0_key, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void List_1_Clear_m16C1F2C61FED5955F10EB36BC1CB2DF34B128994_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_m4407E4C389F22B8CEC282C15D56516658746C383_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_AddRange_m1F76B300133150E6046C5FED00E88B5DE0A02E17_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, RuntimeObject* ___0_collection, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* List_1_get_Item_m33561245D64798C2AB07584C0EC4F240E4839A38_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IntHashtable_1__ctor_mBE8B99A9FA3EA4BDCBFCBCCFBA21DEE35DC50319_gshared (IntHashtable_1_tDC7FED120C3F2BFFE052D1A2C011112467A0E2BC* __this, int32_t ___0_initialCapacity, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Stack_1_get_Count_mD08AE71D49787D30DDD9D484BCD323D646744D2E_gshared_inline (Stack_1_tAD790A47551563636908E21E4F08C54C0C323EB5* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Stack_1_Pop_m2AFF69249659372F07EE25817DBCAFE74E1CF778_gshared (Stack_1_tAD790A47551563636908E21E4F08C54C0C323EB5* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_1_Invoke_mF2422B2DD29F74CE66F791C3F68E288EC7C3DB9E_gshared_inline (Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Stack_1_Push_m709DD11BC1291A905814182CF9A367DE7399A778_gshared (Stack_1_tAD790A47551563636908E21E4F08C54C0C323EB5* __this, RuntimeObject* ___0_item, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Stack_1__ctor_m70E8EDA96A608CE9BAB7FC8313B233AADA573BD4_gshared (Stack_1_tAD790A47551563636908E21E4F08C54C0C323EB5* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_NO_INLINE IL2CPP_METHOD_ATTR void List_1_AddWithResize_m79A9BF770BEF9C06BE40D5401E55E375F2726CC4_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, RuntimeObject* ___0_item, const RuntimeMethod* method) ;

IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840 (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t SROptions_get_LevelId_mABDC5D192F16C09282ADF4A06036DD1CDBFDF076_inline (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t SROptions_get_GoldNumber_m2F2D8C12482B6A284F19F1D8D49A16962F413EE0_inline (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t SROptions_get_RemainTime_mF071B277830D566567DA56B760460E7B2583C5D8_inline (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions__ctor_m2658C7CC2E53229F15959A748C31F5B638661753 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) ;
inline InternalOptionsRegistry_t37F5D710767EF2F74CF225D94C602B84151A8F96* SRServiceManager_GetService_TisInternalOptionsRegistry_t37F5D710767EF2F74CF225D94C602B84151A8F96_m9C1B26F6376FD4144BC139300A02AC30A89EF6DC (const RuntimeMethod* method)
{
	return ((  InternalOptionsRegistry_t37F5D710767EF2F74CF225D94C602B84151A8F96* (*) (const RuntimeMethod*))SRServiceManager_GetService_TisRuntimeObject_mCECA3E42BBB83185086FEC067BAE634309D9A6FD_gshared)(method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* SROptions_get_Current_m297117B6D80C587A2A12BC79EFD5ADE46D591C4B_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InternalOptionsRegistry_AddOptionContainer_mF55C2902BBBFE5D741EBB38A3074BF47175FAC2D (InternalOptionsRegistry_t37F5D710767EF2F74CF225D94C602B84151A8F96* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t* Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00 (Delegate_t* ___0_a, Delegate_t* ___1_b, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t* Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3 (Delegate_t* ___0_source, Delegate_t* ___1_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_inline (SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* __this, RuntimeObject* ___0_sender, String_t* ___1_propertyName, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PropertyChangedEventArgs__ctor_mE3C901440BE057E5F17062BA316019C0B53A39B5 (PropertyChangedEventArgs_tFA01343D8F2BD799951B40A3EBF4A6B38EE63321* __this, String_t* ___0_propertyName, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PropertyChangedEventHandler_Invoke_m040B3056C279FDDC4EC678519D5D415771905298_inline (PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* __this, RuntimeObject* ___0_sender, PropertyChangedEventArgs_tFA01343D8F2BD799951B40A3EBF4A6B38EE63321* ___1_e, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_add_InterfacePropertyChangedEventHandler_m21A6CBB25DFAD5BE13C1FBD23CDCEBC42AED9486 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_remove_InterfacePropertyChangedEventHandler_m57D2972F000CDECCB3EAC82AD237736BD311D7A6 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DisplayNameAttribute__ctor_m396F07353E80428B4AEB85DC66F5B9380A077AE3 (DisplayNameAttribute_tECBA9AC4CCBE61186E2B3C397C93AAFA5A2631E8* __this, String_t* ___0_displayName, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IncrementAttribute__ctor_m086EE0EF33A7B9EBFD4C2157747DCC418CF62020 (IncrementAttribute_t4EEF3E3CB6B83DC54346F0AB93DEA5102A661150* __this, double ___0_increment, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NumberRangeAttribute__ctor_m573A8F52873A30F329617752AE167CC4775E267F (NumberRangeAttribute_t36C0A939C7C6DC0971357D6A5BC6B4D8FD570585* __this, double ___0_min, double ___1_max, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SortAttribute__ctor_m8C2E87A699EBF6FFE066341167159DF0F614AD0F (SortAttribute_t745731D856AA0915EBA410630E554D11F6CCADBA* __this, int32_t ___0_priority, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E (MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71* __this, const RuntimeMethod* method) ;
inline void List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD*, const RuntimeMethod*))List_1__ctor_m7F078BB342729BDF11327FD89D7872265328F690_gshared)(__this, method);
}
inline void List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* __this, String_t* ___0_item, const RuntimeMethod* method)
{
	((  void (*) (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD*, String_t*, const RuntimeMethod*))List_1_Add_mEBCF994CC3814631017F46A387B1A192ED6C85C7_gshared_inline)(__this, ___0_item, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AsyncOperationHandle_1_tDA2BA7FC48753E9F44D6A9B3873AAB9F2BE05DA4 Addressables_LoadResourceLocationsAsync_m96BF35184F12370BCD9A304065F42D080D7EE18B (RuntimeObject* ___0_key, Type_t* ___1_type, const RuntimeMethod* method) ;
inline RuntimeObject* AsyncOperationHandle_1_WaitForCompletion_mB4F188A55BCF8E8117460DE5BF131EBE981F2F02 (AsyncOperationHandle_1_tDA2BA7FC48753E9F44D6A9B3873AAB9F2BE05DA4* __this, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (AsyncOperationHandle_1_tDA2BA7FC48753E9F44D6A9B3873AAB9F2BE05DA4*, const RuntimeMethod*))AsyncOperationHandle_1_WaitForCompletion_m4E4B5C196ABB1FB73BC34C54E9E6E4955B6255F6_gshared)(__this, method);
}
inline void Addressables_Release_TisIList_1_tFEC432B87E444FFF0D7B8EFD6CBB918523AD6827_m05E0F779E22A2AEB81C2DC54F3578A128A11920C (AsyncOperationHandle_1_tDA2BA7FC48753E9F44D6A9B3873AAB9F2BE05DA4 ___0_handle, const RuntimeMethod* method)
{
	((  void (*) (AsyncOperationHandle_1_tDA2BA7FC48753E9F44D6A9B3873AAB9F2BE05DA4, const RuntimeMethod*))Addressables_Release_TisRuntimeObject_m532EA1203DD205F51CF634FD0E63965162B1AFB7_gshared)(___0_handle, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B (RuntimeArray* ___0_array, RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 ___1_fldHandle, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debug_LogError_mB00B2B4468EF3CAF041B038D840820FB84C924B2 (RuntimeObject* ___0_message, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* TimeLimitUpdator_Allocate_m3B2CF35DEA77C1FCC1ACA7BA8E43FD87E0EF6AC6 (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void BaseLimitUpdator_set_id_mB1C069E5930897FC57398002DB6DD1051D7AF8C5_inline (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, int32_t ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TimeLimitUpdator_Start_m5F76BAD87DD040FC820F1945F0843C363BA58AEB (TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* __this, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ___0_updateHandler, float ___1_interval, RuntimeObject* ___2_param, bool ___3_once, const RuntimeMethod* method) ;
inline void IntHashtable_1_set_Item_mE8F2A507CD5AA919580B1B5ED50E6FB95125765C (IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7* __this, int32_t ___0_key, BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* ___1_value, const RuntimeMethod* method)
{
	((  void (*) (IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7*, int32_t, BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*, const RuntimeMethod*))IntHashtable_1_set_Item_m634B5533B6C2C2E0B2557CA620A50ACDFC4CE74F_gshared)(__this, ___0_key, ___1_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* FrameLimitUpdator_Allocate_m7783EDB49B3EA53A56F09A218B0D31AE7F15DAAA (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FrameLimitUpdator_Start_m4E7618B39D780976865282B501647494837CA9B3 (FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* __this, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ___0_updateHandler, int32_t ___1_interval, RuntimeObject* ___2_param, bool ___3_once, const RuntimeMethod* method) ;
inline BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* IntHashtable_1_get_Item_m35BE2466A07F288C6AC3196E60FBA36EE3539A70 (IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7* __this, int32_t ___0_key, const RuntimeMethod* method)
{
	return ((  BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* (*) (IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7*, int32_t, const RuntimeMethod*))IntHashtable_1_get_Item_m8B96FE67A64E6F32B04167D7ED0CC4C815D65A04_gshared)(__this, ___0_key, method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void BaseLimitUpdator_set_active_m7879D0C8CB8E0C90D01F8DD7CFCDD49B4AD2544D_inline (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, bool ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___0_x, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___1_y, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B (Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object_DontDestroyOnLoad_m4B70C3AEF886C176543D1295507B6455C9DCAEA7 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___0_target, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* Thread_get_CurrentThread_m6D4719F4993DB9200490531FF02D4076FF9CA9BD (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Thread_get_ManagedThreadId_m74ACB74A574EE535C2B00B7D64F203A62E796B05 (Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR UniqueMonoEventListener_t608C75BB5859C7C58DBD298123D78BAF8D15FD22* UniqueMonoEventListener_get_instance_m4F0312B5F10159646AE36AC94C37FE9B65068146 (const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR UpdateTimeInfo_tCC8E1C8131E776D226406C9D1F4FFE8E99577B22 UniqueMonoEventListener_get_currentUpdateTimeInfo_m76901A493509552678DD377961BA7AEAE38DAFCB_inline (UniqueMonoEventListener_t608C75BB5859C7C58DBD298123D78BAF8D15FD22* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object_Destroy_mE97D0A766419A81296E8D4E5C23D01D3FE91ACBB (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___0_obj, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___0_x, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___1_y, const RuntimeMethod* method) ;
inline void List_1_Clear_m344AD90676A608EA37B9DF93050BA9F80C23D17E_inline (List_1_tDB72209F35D56F62A287633F9450978E90B90987* __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tDB72209F35D56F62A287633F9450978E90B90987*, const RuntimeMethod*))List_1_Clear_m16C1F2C61FED5955F10EB36BC1CB2DF34B128994_gshared_inline)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* MonoBehaviour_StartCoroutine_m4CAFF732AA28CD3BDC5363B44A863575530EC812 (MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71* __this, RuntimeObject* ___0_routine, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MonoBehaviour_StopCoroutine_mB0FC91BE84203BD8E360B3FBAE5B958B4C5ED22A (MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71* __this, Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* ___0_routine, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MonoBehaviour_StopAllCoroutines_m872033451D42013A99867D09337490017E9ED318 (MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_DoRunToMainThread_m02504EF3C5F142D5ABE95B85C46EB5CC5BF3F81C (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___0_action, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Monitor_Exit_m05B2CF037E2214B3208198C282490A2A475653FA (RuntimeObject* ___0_obj, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Monitor_Enter_m3CDB589DA1300B513D55FDCFB52B63E879794149 (RuntimeObject* ___0_obj, bool* ___1_lockTaken, const RuntimeMethod* method) ;
inline void List_1_Add_m5B99D67CB378BFA8A1142343F9DB44D94322EAD3_inline (List_1_tDB72209F35D56F62A287633F9450978E90B90987* __this, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___0_item, const RuntimeMethod* method)
{
	((  void (*) (List_1_tDB72209F35D56F62A287633F9450978E90B90987*, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*, const RuntimeMethod*))List_1_Add_mEBCF994CC3814631017F46A387B1A192ED6C85C7_gshared_inline)(__this, ___0_item, method);
}
inline int32_t List_1_get_Count_m5E7FCE3DF7B23B6D88C14A04177C1DCD15063858_inline (List_1_tDB72209F35D56F62A287633F9450978E90B90987* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_tDB72209F35D56F62A287633F9450978E90B90987*, const RuntimeMethod*))List_1_get_Count_m4407E4C389F22B8CEC282C15D56516658746C383_gshared_inline)(__this, method);
}
inline void List_1_AddRange_m475DC02C782750D4036B11E287BC01ECB8313D1D (List_1_tDB72209F35D56F62A287633F9450978E90B90987* __this, RuntimeObject* ___0_collection, const RuntimeMethod* method)
{
	((  void (*) (List_1_tDB72209F35D56F62A287633F9450978E90B90987*, RuntimeObject*, const RuntimeMethod*))List_1_AddRange_m1F76B300133150E6046C5FED00E88B5DE0A02E17_gshared)(__this, ___0_collection, method);
}
inline Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* List_1_get_Item_m8A119323481338039197B73D82916BB46DEE3C2D (List_1_tDB72209F35D56F62A287633F9450978E90B90987* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	return ((  Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* (*) (List_1_tDB72209F35D56F62A287633F9450978E90B90987*, int32_t, const RuntimeMethod*))List_1_get_Item_m33561245D64798C2AB07584C0EC4F240E4839A38_gshared)(__this, ___0_index, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debug_LogException_mAB3F4DC7297ED8FBB49DAA718B70E59A6B0171B0 (Exception_t* ___0_exception, const RuntimeMethod* method) ;
inline void IntHashtable_1__ctor_m18015E230A511EE02627075413DCD4DB2AC32520 (IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7* __this, int32_t ___0_initialCapacity, const RuntimeMethod* method)
{
	((  void (*) (IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7*, int32_t, const RuntimeMethod*))IntHashtable_1__ctor_mBE8B99A9FA3EA4BDCBFCBCCFBA21DEE35DC50319_gshared)(__this, ___0_initialCapacity, method);
}
inline void List_1__ctor_mBFD6DF02E045EDF3C322E2112C922457016C8212 (List_1_tDB72209F35D56F62A287633F9450978E90B90987* __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tDB72209F35D56F62A287633F9450978E90B90987*, const RuntimeMethod*))List_1__ctor_m7F078BB342729BDF11327FD89D7872265328F690_gshared)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action__ctor_mBDC7B0B4A3F583B64C2896F01BDED360772F67DC (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BaseLimitUpdator__ctor_m80CDE6F678884981954749212D5A82DB3105D852 (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, const RuntimeMethod* method) ;
inline int32_t Stack_1_get_Count_m4873716797859474506B12AC03816C475F318082_inline (Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81*, const RuntimeMethod*))Stack_1_get_Count_mD08AE71D49787D30DDD9D484BCD323D646744D2E_gshared_inline)(__this, method);
}
inline TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* Stack_1_Pop_m4FAF28A63461E2F308410C48D9F849FF58C620CB (Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81* __this, const RuntimeMethod* method)
{
	return ((  TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* (*) (Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81*, const RuntimeMethod*))Stack_1_Pop_m2AFF69249659372F07EE25817DBCAFE74E1CF778_gshared)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TimeLimitUpdator__ctor_mFD10EC99ACA0AF4BBBF49AE3368B2916F9250700 (TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BaseLimitUpdator_ResetVal_m3379690CAAF1297AE3A6290D522C2E6F8DDA90AC (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ___0_target, RuntimeObject* ___1_targetParam, bool ___2_once, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_add_updateEvent_mBBB672CA722F0AF108B571206656EE3E85B80ED0 (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___0_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool BaseLimitUpdator_get_active_mF70E508BDFE68081D15C2BB15351A207FA2D5AE1_inline (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, const RuntimeMethod* method) ;
inline void Action_1_Invoke_mF2422B2DD29F74CE66F791C3F68E288EC7C3DB9E_inline (Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method)
{
	((  void (*) (Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87*, RuntimeObject*, const RuntimeMethod*))Action_1_Invoke_mF2422B2DD29F74CE66F791C3F68E288EC7C3DB9E_gshared_inline)(__this, ___0_obj, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Delegate_op_Equality_m8B96593B665536587FFD27DE233442C075971C32 (Delegate_t* ___0_d1, Delegate_t* ___1_d2, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t BaseLimitUpdator_get_id_m3D5E38624A00972BFA083F2375D493AE0A3CE26E_inline (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_remove_updateEvent_m11222883F7F5BD1EC683A0CF759A86604AABAB95 (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BaseLimitUpdator_Dispose_mCB697B37892E33B5721E0CD13520FF81547CB972 (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, const RuntimeMethod* method) ;
inline void Stack_1_Push_m9AC476B9994A6B99BDFEEA6D9083964E6E675247 (Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81* __this, TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* ___0_item, const RuntimeMethod* method)
{
	((  void (*) (Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81*, TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286*, const RuntimeMethod*))Stack_1_Push_m709DD11BC1291A905814182CF9A367DE7399A778_gshared)(__this, ___0_item, method);
}
inline void Stack_1__ctor_mF4E396597BA5F70792292CD405F863A411F5EC0E (Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81* __this, const RuntimeMethod* method)
{
	((  void (*) (Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81*, const RuntimeMethod*))Stack_1__ctor_m70E8EDA96A608CE9BAB7FC8313B233AADA573BD4_gshared)(__this, method);
}
inline int32_t Stack_1_get_Count_m5EA24311FD8233421583A3D592432402CC0752DA_inline (Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82*, const RuntimeMethod*))Stack_1_get_Count_mD08AE71D49787D30DDD9D484BCD323D646744D2E_gshared_inline)(__this, method);
}
inline FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* Stack_1_Pop_m4211BBED271E0EF23575C2E725EC27B70EC67FF4 (Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82* __this, const RuntimeMethod* method)
{
	return ((  FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* (*) (Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82*, const RuntimeMethod*))Stack_1_Pop_m2AFF69249659372F07EE25817DBCAFE74E1CF778_gshared)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FrameLimitUpdator__ctor_mEEC55CAD1CB3D01834DB863BCE8CDE2F665B6D36 (FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Time_get_frameCount_m4A42E558A71301A216BDC49EC402D62F19C79667 (const RuntimeMethod* method) ;
inline void Stack_1_Push_m74B0B4001B47D54122FAD47F9A15CAE6999BE999 (Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82* __this, FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* ___0_item, const RuntimeMethod* method)
{
	((  void (*) (Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82*, FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6*, const RuntimeMethod*))Stack_1_Push_m709DD11BC1291A905814182CF9A367DE7399A778_gshared)(__this, ___0_item, method);
}
inline void Stack_1__ctor_m1CD70C0A52FF57609719F8D154189A2D46D761E9 (Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82* __this, const RuntimeMethod* method)
{
	((  void (*) (Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82*, const RuntimeMethod*))Stack_1__ctor_m70E8EDA96A608CE9BAB7FC8313B233AADA573BD4_gshared)(__this, method);
}
inline void List_1_AddWithResize_m79A9BF770BEF9C06BE40D5401E55E375F2726CC4 (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, RuntimeObject* ___0_item, const RuntimeMethod* method)
{
	((  void (*) (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D*, RuntimeObject*, const RuntimeMethod*))List_1_AddWithResize_m79A9BF770BEF9C06BE40D5401E55E375F2726CC4_gshared)(__this, ___0_item, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Array_Clear_m50BAA3751899858B097D3FF2ED31F284703FE5CB (RuntimeArray* ___0_array, int32_t ___1_index, int32_t ___2_length, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t SROptions_get_LevelId_mABDC5D192F16C09282ADF4A06036DD1CDBFDF076 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CLevelIdU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_set_LevelId_m491A826C74A4ED95FB14BBC462628921EF745944 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_value;
		__this->___U3CLevelIdU3Ek__BackingField = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_EnterLevel_mC3F523F472188E5DBA39194A905B1203E1CB8E80 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralCBE546B03B98A03E01E5D08EDAE4F54E2FC423BB);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		int32_t L_1;
		L_1 = SROptions_get_LevelId_mABDC5D192F16C09282ADF4A06036DD1CDBFDF076_inline(__this, NULL);
		int32_t L_2 = L_1;
		RuntimeObject* L_3 = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &L_2);
		NullCheck(L_0);
		VirtualActionInvoker2< String_t*, RuntimeObject* >::Invoke(32, L_0, _stringLiteralCBE546B03B98A03E01E5D08EDAE4F54E2FC423BB, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_GameWin_m31B1F8F05D14498C884E447D7B011416D8748EE7 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralBCE5DFBBF7E64AB83566D2430482BC76DDB9B666);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		NullCheck(L_0);
		VirtualActionInvoker1< String_t* >::Invoke(31, L_0, _stringLiteralBCE5DFBBF7E64AB83566D2430482BC76DDB9B666);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_FillFeverEnergy_m7EEC56F57353FB2DEE14625D70820532146BAA7C (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralD78C3C96EA9229AC2F206D616055366865E0FFA6);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		NullCheck(L_0);
		VirtualActionInvoker1< String_t* >::Invoke(31, L_0, _stringLiteralD78C3C96EA9229AC2F206D616055366865E0FFA6);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_ClearSave_m18C064363910ED418BE09DCEC78F14350DFAEF4C (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral888EBEBE9186AFB4A7D01CBC71C6B2371279F34C);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		NullCheck(L_0);
		VirtualActionInvoker1< String_t* >::Invoke(31, L_0, _stringLiteral888EBEBE9186AFB4A7D01CBC71C6B2371279F34C);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_AddStamina_m199D64768DEDCEE3625D238E5114F000C0AE95FC (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralBF14C2BD89884057518C99D97A2C754419B37C13);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		NullCheck(L_0);
		VirtualActionInvoker1< String_t* >::Invoke(31, L_0, _stringLiteralBF14C2BD89884057518C99D97A2C754419B37C13);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_RemoveStamina_mF7C04B4390BBD20CDB161857536D542C80A5D6C7 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralCB3483C2BBD50C51695B5E82E68C99844AFBD5B2);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		NullCheck(L_0);
		VirtualActionInvoker1< String_t* >::Invoke(31, L_0, _stringLiteralCB3483C2BBD50C51695B5E82E68C99844AFBD5B2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t SROptions_get_GoldNumber_m2F2D8C12482B6A284F19F1D8D49A16962F413EE0 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CGoldNumberU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_set_GoldNumber_m95354C20FFF84714A48C87507F82C904995896F3 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_value;
		__this->___U3CGoldNumberU3Ek__BackingField = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_AddGold_m505F4B65C83A86A56BB4BB848C11D90909973B62 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral43C0D8B652A7EC1ED24DAB96DCAF8B8E0951199B);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		int32_t L_1;
		L_1 = SROptions_get_GoldNumber_m2F2D8C12482B6A284F19F1D8D49A16962F413EE0_inline(__this, NULL);
		int32_t L_2 = L_1;
		RuntimeObject* L_3 = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &L_2);
		NullCheck(L_0);
		VirtualActionInvoker2< String_t*, RuntimeObject* >::Invoke(32, L_0, _stringLiteral43C0D8B652A7EC1ED24DAB96DCAF8B8E0951199B, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_RemoveGold_m1D65ED243C772888FAD65099C15CD1D57CC75F8C (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralB5708797E9BA28F569AF0865FDDCC9EEAE306229);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		int32_t L_1;
		L_1 = SROptions_get_GoldNumber_m2F2D8C12482B6A284F19F1D8D49A16962F413EE0_inline(__this, NULL);
		int32_t L_2 = L_1;
		RuntimeObject* L_3 = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &L_2);
		NullCheck(L_0);
		VirtualActionInvoker2< String_t*, RuntimeObject* >::Invoke(32, L_0, _stringLiteralB5708797E9BA28F569AF0865FDDCC9EEAE306229, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_AddAdTicket_mC3B465A9CA0EF5D1B84210E1135F1DF8E4FEF7EE (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral2D44E239F7F7113B03C634F55CA3154323BD17FD);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		NullCheck(L_0);
		VirtualActionInvoker1< String_t* >::Invoke(31, L_0, _stringLiteral2D44E239F7F7113B03C634F55CA3154323BD17FD);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_RemoveAdTicket_m6B542F5BFC7C2FFCD94EA9BDB94A2A7FFE1B97CB (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral22580C0B7AD84C4AECA419E0D9AFE6D911D665EB);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		NullCheck(L_0);
		VirtualActionInvoker1< String_t* >::Invoke(31, L_0, _stringLiteral22580C0B7AD84C4AECA419E0D9AFE6D911D665EB);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_AddMagnet_m10E85280D6A432B4BE7DE0CBE0DD86C156D796B1 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC797AA5566D618284C16BDB5B6BD0C58006C5CA5);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		NullCheck(L_0);
		VirtualActionInvoker1< String_t* >::Invoke(31, L_0, _stringLiteralC797AA5566D618284C16BDB5B6BD0C58006C5CA5);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_AddForceChoose_m335D310C61368FF0C45BB89C53CAF6C1FFED3EE2 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral9F8B6416025F8E80F10F7DE5DE3B9F6E66DE44BF);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		NullCheck(L_0);
		VirtualActionInvoker1< String_t* >::Invoke(31, L_0, _stringLiteral9F8B6416025F8E80F10F7DE5DE3B9F6E66DE44BF);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_AddHammer_m1626099FB71426076487E0621EFAE601DB788F95 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralCAF9697CE37A5F300BFCA9F8EEBEB31D3261B016);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		NullCheck(L_0);
		VirtualActionInvoker1< String_t* >::Invoke(31, L_0, _stringLiteralCAF9697CE37A5F300BFCA9F8EEBEB31D3261B016);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_AddRefresh_m403780DA1F808070EB79B1865169A08AA9C5E0B6 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralD67E94B0E217A14362DBB9C21C62D58060C381B6);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		NullCheck(L_0);
		VirtualActionInvoker1< String_t* >::Invoke(31, L_0, _stringLiteralD67E94B0E217A14362DBB9C21C62D58060C381B6);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t SROptions_get_RemainTime_mF071B277830D566567DA56B760460E7B2583C5D8 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CRemainTimeU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_set_RemainTime_m76765DA175CED1F5B7416C6DB1A1D110E1875F6B (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_value;
		__this->___U3CRemainTimeU3Ek__BackingField = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_SetRemainTime_m204E6069553D3873018CB937F9A1C45BE4E91F06 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral55E382D2A87639E92586500E9D82F62C78BE7A5E);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6_il2cpp_TypeInfo_var);
		ApplicationFacade_t1C4BAFCDC8CEF74B30494DD4C00D5B8088F391C6* L_0;
		L_0 = ApplicationFacade_get_instance_m5BBE73C3385168DB4A1289F093AE775F9F586840(NULL);
		int32_t L_1;
		L_1 = SROptions_get_RemainTime_mF071B277830D566567DA56B760460E7B2583C5D8_inline(__this, NULL);
		int32_t L_2 = L_1;
		RuntimeObject* L_3 = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &L_2);
		NullCheck(L_0);
		VirtualActionInvoker2< String_t*, RuntimeObject* >::Invoke(32, L_0, _stringLiteral55E382D2A87639E92586500E9D82F62C78BE7A5E, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* SROptions_get_Current_m297117B6D80C587A2A12BC79EFD5ADE46D591C4B (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* L_0 = ((SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F_StaticFields*)il2cpp_codegen_static_fields_for(SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F_il2cpp_TypeInfo_var))->____current;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_OnStartup_mED657444AD235B7BEB1764E5D0EB4C1794ED2281 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SRServiceManager_GetService_TisInternalOptionsRegistry_t37F5D710767EF2F74CF225D94C602B84151A8F96_m9C1B26F6376FD4144BC139300A02AC30A89EF6DC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SRServiceManager_t65EAD8CD1C096A4BCD42B5D36406A7954972394F_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* L_0 = (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F*)il2cpp_codegen_object_new(SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F_il2cpp_TypeInfo_var);
		SROptions__ctor_m2658C7CC2E53229F15959A748C31F5B638661753(L_0, NULL);
		((SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F_StaticFields*)il2cpp_codegen_static_fields_for(SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F_il2cpp_TypeInfo_var))->____current = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F_StaticFields*)il2cpp_codegen_static_fields_for(SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F_il2cpp_TypeInfo_var))->____current), (void*)L_0);
		il2cpp_codegen_runtime_class_init_inline(SRServiceManager_t65EAD8CD1C096A4BCD42B5D36406A7954972394F_il2cpp_TypeInfo_var);
		InternalOptionsRegistry_t37F5D710767EF2F74CF225D94C602B84151A8F96* L_1;
		L_1 = SRServiceManager_GetService_TisInternalOptionsRegistry_t37F5D710767EF2F74CF225D94C602B84151A8F96_m9C1B26F6376FD4144BC139300A02AC30A89EF6DC(SRServiceManager_GetService_TisInternalOptionsRegistry_t37F5D710767EF2F74CF225D94C602B84151A8F96_m9C1B26F6376FD4144BC139300A02AC30A89EF6DC_RuntimeMethod_var);
		SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* L_2;
		L_2 = SROptions_get_Current_m297117B6D80C587A2A12BC79EFD5ADE46D591C4B_inline(NULL);
		NullCheck(L_1);
		InternalOptionsRegistry_AddOptionContainer_mF55C2902BBBFE5D741EBB38A3074BF47175FAC2D(L_1, L_2, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_add_PropertyChanged_mD313CF8175CDEE6C8F50DE5E3DA93CAF1739BBE6 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* ___0_value, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* V_0 = NULL;
	SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* V_1 = NULL;
	SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* V_2 = NULL;
	{
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_0 = __this->___PropertyChanged;
		V_0 = L_0;
	}

IL_0007:
	{
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_1 = V_0;
		V_1 = L_1;
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_2 = V_1;
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_3 = ___0_value;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7*)CastclassSealed((RuntimeObject*)L_4, SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7_il2cpp_TypeInfo_var));
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7** L_5 = (SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7**)(&__this->___PropertyChanged);
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_6 = V_2;
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_7 = V_1;
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_8;
		L_8 = InterlockedCompareExchangeImpl<SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7*>(L_5, L_6, L_7);
		V_0 = L_8;
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_9 = V_0;
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_10 = V_1;
		if ((!(((RuntimeObject*)(SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7*)L_9) == ((RuntimeObject*)(SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7*)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_remove_PropertyChanged_m4C5C660100CDDEE462A1AEC5666351735CD0110D (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* ___0_value, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* V_0 = NULL;
	SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* V_1 = NULL;
	SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* V_2 = NULL;
	{
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_0 = __this->___PropertyChanged;
		V_0 = L_0;
	}

IL_0007:
	{
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_1 = V_0;
		V_1 = L_1;
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_2 = V_1;
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_3 = ___0_value;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7*)CastclassSealed((RuntimeObject*)L_4, SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7_il2cpp_TypeInfo_var));
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7** L_5 = (SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7**)(&__this->___PropertyChanged);
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_6 = V_2;
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_7 = V_1;
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_8;
		L_8 = InterlockedCompareExchangeImpl<SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7*>(L_5, L_6, L_7);
		V_0 = L_8;
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_9 = V_0;
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_10 = V_1;
		if ((!(((RuntimeObject*)(SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7*)L_9) == ((RuntimeObject*)(SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7*)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_OnPropertyChanged_m06D97D7FDCBA5FA530183C0286626FC0AF5DC154 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, String_t* ___0_propertyName, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PropertyChangedEventArgs_tFA01343D8F2BD799951B40A3EBF4A6B38EE63321_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_0 = __this->___PropertyChanged;
		if (!L_0)
		{
			goto IL_0015;
		}
	}
	{
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* L_1 = __this->___PropertyChanged;
		String_t* L_2 = ___0_propertyName;
		NullCheck(L_1);
		SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_inline(L_1, __this, L_2, NULL);
	}

IL_0015:
	{
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_3 = __this->___InterfacePropertyChangedEventHandler;
		if (!L_3)
		{
			goto IL_002f;
		}
	}
	{
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_4 = __this->___InterfacePropertyChangedEventHandler;
		String_t* L_5 = ___0_propertyName;
		PropertyChangedEventArgs_tFA01343D8F2BD799951B40A3EBF4A6B38EE63321* L_6 = (PropertyChangedEventArgs_tFA01343D8F2BD799951B40A3EBF4A6B38EE63321*)il2cpp_codegen_object_new(PropertyChangedEventArgs_tFA01343D8F2BD799951B40A3EBF4A6B38EE63321_il2cpp_TypeInfo_var);
		PropertyChangedEventArgs__ctor_mE3C901440BE057E5F17062BA316019C0B53A39B5(L_6, L_5, NULL);
		NullCheck(L_4);
		PropertyChangedEventHandler_Invoke_m040B3056C279FDDC4EC678519D5D415771905298_inline(L_4, __this, L_6, NULL);
	}

IL_002f:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_add_InterfacePropertyChangedEventHandler_m21A6CBB25DFAD5BE13C1FBD23CDCEBC42AED9486 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* ___0_value, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* V_0 = NULL;
	PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* V_1 = NULL;
	PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* V_2 = NULL;
	{
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_0 = __this->___InterfacePropertyChangedEventHandler;
		V_0 = L_0;
	}

IL_0007:
	{
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_1 = V_0;
		V_1 = L_1;
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_2 = V_1;
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_3 = ___0_value;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA*)CastclassSealed((RuntimeObject*)L_4, PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA_il2cpp_TypeInfo_var));
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA** L_5 = (PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA**)(&__this->___InterfacePropertyChangedEventHandler);
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_6 = V_2;
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_7 = V_1;
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_8;
		L_8 = InterlockedCompareExchangeImpl<PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA*>(L_5, L_6, L_7);
		V_0 = L_8;
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_9 = V_0;
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_10 = V_1;
		if ((!(((RuntimeObject*)(PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA*)L_9) == ((RuntimeObject*)(PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA*)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_remove_InterfacePropertyChangedEventHandler_m57D2972F000CDECCB3EAC82AD237736BD311D7A6 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* ___0_value, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* V_0 = NULL;
	PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* V_1 = NULL;
	PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* V_2 = NULL;
	{
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_0 = __this->___InterfacePropertyChangedEventHandler;
		V_0 = L_0;
	}

IL_0007:
	{
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_1 = V_0;
		V_1 = L_1;
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_2 = V_1;
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_3 = ___0_value;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA*)CastclassSealed((RuntimeObject*)L_4, PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA_il2cpp_TypeInfo_var));
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA** L_5 = (PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA**)(&__this->___InterfacePropertyChangedEventHandler);
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_6 = V_2;
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_7 = V_1;
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_8;
		L_8 = InterlockedCompareExchangeImpl<PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA*>(L_5, L_6, L_7);
		V_0 = L_8;
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_9 = V_0;
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_10 = V_1;
		if ((!(((RuntimeObject*)(PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA*)L_9) == ((RuntimeObject*)(PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA*)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_System_ComponentModel_INotifyPropertyChanged_add_PropertyChanged_m5B81598734579EEEF9AEDE807E67E5C9F424192E (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* ___0_value, const RuntimeMethod* method) 
{
	{
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_0 = ___0_value;
		SROptions_add_InterfacePropertyChangedEventHandler_m21A6CBB25DFAD5BE13C1FBD23CDCEBC42AED9486(__this, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions_System_ComponentModel_INotifyPropertyChanged_remove_PropertyChanged_m67FA67A06599300AD83B0F88A7023233482772A9 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* ___0_value, const RuntimeMethod* method) 
{
	{
		PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* L_0 = ___0_value;
		SROptions_remove_InterfacePropertyChangedEventHandler_m57D2972F000CDECCB3EAC82AD237736BD311D7A6(__this, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptions__ctor_m2658C7CC2E53229F15959A748C31F5B638661753 (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DisplayNameAttribute__ctor_m3AABB3EF231DE5C4596FBAC13A84359188956678 (DisplayNameAttribute_t36237DD738F919AF725D1A3160E859B8DB716264* __this, String_t* ___0_displayName, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DisplayNameAttribute_tECBA9AC4CCBE61186E2B3C397C93AAFA5A2631E8_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = ___0_displayName;
		il2cpp_codegen_runtime_class_init_inline(DisplayNameAttribute_tECBA9AC4CCBE61186E2B3C397C93AAFA5A2631E8_il2cpp_TypeInfo_var);
		DisplayNameAttribute__ctor_m396F07353E80428B4AEB85DC66F5B9380A077AE3(__this, L_0, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IncrementAttribute__ctor_m148ECDE23494DD90AAD74FC1517886B9EFBB0E33 (IncrementAttribute_tA4CDFC00F53F82FE8F31085E97F79F4BA1B76DD1* __this, double ___0_increment, const RuntimeMethod* method) 
{
	{
		double L_0 = ___0_increment;
		IncrementAttribute__ctor_m086EE0EF33A7B9EBFD4C2157747DCC418CF62020(__this, L_0, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NumberRangeAttribute__ctor_mBC5F2BAC3D7020AF5E604C896FF65C2CC68E8969 (NumberRangeAttribute_tF57CDD96B27582AF4FA0311F052A33A62467ABAD* __this, double ___0_min, double ___1_max, const RuntimeMethod* method) 
{
	{
		double L_0 = ___0_min;
		double L_1 = ___1_max;
		NumberRangeAttribute__ctor_m573A8F52873A30F329617752AE167CC4775E267F(__this, L_0, L_1, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SortAttribute__ctor_m485398CBC990FD50C8BFE28A3794048630C0A49A (SortAttribute_t3BCAFC7857086FCCD52C024CFC9F51F00155E6FB* __this, int32_t ___0_priority, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_priority;
		SortAttribute__ctor_m8C2E87A699EBF6FFE066341167159DF0F614AD0F(__this, L_0, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AOTGenericReferences_RefMethods_m17CF257D96D8BC2F232C4C1502905B792D17170C (AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1* __this, const RuntimeMethod* method) 
{
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AOTGenericReferences__ctor_m41CBD692FC9B521512E552575AFE7A385DEC71A6 (AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1* __this, const RuntimeMethod* method) 
{
	{
		MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AOTGenericReferences__cctor_mA46BDC06A6577D725A2E5284A2A34C974CE65F68 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral0B34DFC38793BF0AF6DEA9A94F7CCB4150E999A6);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral0DDCAE3541991F7A132995973182C81F165202EA);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral4C43361A0A500CC6B80443746394A4C1D19915BD);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral4CFB1E3E372A1023D954142752C1559837789E9A);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral5836653E8843C7C00D22A75244ACDE7BADBC7E44);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral676847AA880D8C9BE69BAEB24A1780F4F5961D3A);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral9017E0B86CEA2958388B230907BD06616C5825A2);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral946BD80B231F5776B5307B385889C9ABB57D3D53);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralA3F029047BA90CC134023587DF7DCF444B38D009);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC766BA5E1A2B4818EDC97B520C896F5B474C96BA);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC7E9DAF844B25471D821CB8F094AE5423C2EECC4);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC8B1BFECA177AC9C06E600CD04A0B2690ADFD46B);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralD94EE64A40FB09C92A977390D5E856181E063C88);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralE75D2BEC76121F70F5B673587DE49DE9EAD114BA);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_0 = (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD*)il2cpp_codegen_object_new(List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_il2cpp_TypeInfo_var);
		List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E(L_0, List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_1 = L_0;
		NullCheck(L_1);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_1, _stringLiteral5836653E8843C7C00D22A75244ACDE7BADBC7E44, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_2 = L_1;
		NullCheck(L_2);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_2, _stringLiteral9017E0B86CEA2958388B230907BD06616C5825A2, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_3 = L_2;
		NullCheck(L_3);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_3, _stringLiteralC766BA5E1A2B4818EDC97B520C896F5B474C96BA, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_4 = L_3;
		NullCheck(L_4);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_4, _stringLiteral0DDCAE3541991F7A132995973182C81F165202EA, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_5 = L_4;
		NullCheck(L_5);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_5, _stringLiteral4C43361A0A500CC6B80443746394A4C1D19915BD, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_6 = L_5;
		NullCheck(L_6);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_6, _stringLiteral946BD80B231F5776B5307B385889C9ABB57D3D53, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_7 = L_6;
		NullCheck(L_7);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_7, _stringLiteralA3F029047BA90CC134023587DF7DCF444B38D009, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_8 = L_7;
		NullCheck(L_8);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_8, _stringLiteralD94EE64A40FB09C92A977390D5E856181E063C88, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_9 = L_8;
		NullCheck(L_9);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_9, _stringLiteral676847AA880D8C9BE69BAEB24A1780F4F5961D3A, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_10 = L_9;
		NullCheck(L_10);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_10, _stringLiteralE75D2BEC76121F70F5B673587DE49DE9EAD114BA, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_11 = L_10;
		NullCheck(L_11);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_11, _stringLiteralC7E9DAF844B25471D821CB8F094AE5423C2EECC4, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_12 = L_11;
		NullCheck(L_12);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_12, _stringLiteral4CFB1E3E372A1023D954142752C1559837789E9A, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_13 = L_12;
		NullCheck(L_13);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_13, _stringLiteral0B34DFC38793BF0AF6DEA9A94F7CCB4150E999A6, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_14 = L_13;
		NullCheck(L_14);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_14, _stringLiteralC8B1BFECA177AC9C06E600CD04A0B2690ADFD46B, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		((AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1_StaticFields*)il2cpp_codegen_static_fields_for(AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1_il2cpp_TypeInfo_var))->___PatchedAOTAssemblyList = L_14;
		Il2CppCodeGenWriteBarrier((void**)(&((AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1_StaticFields*)il2cpp_codegen_static_fields_for(AOTGenericReferences_t7B8F9CD83F1EE53810C6F841826105D9416EA7C1_il2cpp_TypeInfo_var))->___PatchedAOTAssemblyList), (void*)L_14);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* AddressablesUtility_GetAddressFromAssetReference_m02AF0B6CD523EC9BFAFB68C4489824FCB4A9D377 (AssetReference_t6AF4EE7422535138F655BFF2636B23D0BE26C740* ___0_reference, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Addressables_Release_TisIList_1_tFEC432B87E444FFF0D7B8EFD6CBB918523AD6827_m05E0F779E22A2AEB81C2DC54F3578A128A11920C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Addressables_tB93529ED0B034BF1A8C7830710BAA45C20A0F7D6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AsyncOperationHandle_1_WaitForCompletion_mB4F188A55BCF8E8117460DE5BF131EBE981F2F02_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICollection_1_t5C589FDB16AA590F74FBE8A07066DD3139D14C1B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IList_1_tFEC432B87E444FFF0D7B8EFD6CBB918523AD6827_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IResourceLocation_tB0706DA8EB5339ECB4B64C7D2DAFC1EB35D2915C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&String_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	AsyncOperationHandle_1_tDA2BA7FC48753E9F44D6A9B3873AAB9F2BE05DA4 V_0;
	memset((&V_0), 0, sizeof(V_0));
	RuntimeObject* V_1 = NULL;
	{
		AssetReference_t6AF4EE7422535138F655BFF2636B23D0BE26C740* L_0 = ___0_reference;
		il2cpp_codegen_runtime_class_init_inline(Addressables_tB93529ED0B034BF1A8C7830710BAA45C20A0F7D6_il2cpp_TypeInfo_var);
		AsyncOperationHandle_1_tDA2BA7FC48753E9F44D6A9B3873AAB9F2BE05DA4 L_1;
		L_1 = Addressables_LoadResourceLocationsAsync_m96BF35184F12370BCD9A304065F42D080D7EE18B(L_0, (Type_t*)NULL, NULL);
		V_0 = L_1;
		RuntimeObject* L_2;
		L_2 = AsyncOperationHandle_1_WaitForCompletion_mB4F188A55BCF8E8117460DE5BF131EBE981F2F02((&V_0), AsyncOperationHandle_1_WaitForCompletion_mB4F188A55BCF8E8117460DE5BF131EBE981F2F02_RuntimeMethod_var);
		V_1 = L_2;
		RuntimeObject* L_3 = V_1;
		NullCheck(L_3);
		int32_t L_4;
		L_4 = InterfaceFuncInvoker0< int32_t >::Invoke(0, ICollection_1_t5C589FDB16AA590F74FBE8A07066DD3139D14C1B_il2cpp_TypeInfo_var, L_3);
		if ((((int32_t)L_4) <= ((int32_t)0)))
		{
			goto IL_002c;
		}
	}
	{
		RuntimeObject* L_5 = V_1;
		NullCheck(L_5);
		RuntimeObject* L_6;
		L_6 = InterfaceFuncInvoker1< RuntimeObject*, int32_t >::Invoke(0, IList_1_tFEC432B87E444FFF0D7B8EFD6CBB918523AD6827_il2cpp_TypeInfo_var, L_5, 0);
		NullCheck(L_6);
		String_t* L_7;
		L_7 = InterfaceFuncInvoker0< String_t* >::Invoke(7, IResourceLocation_tB0706DA8EB5339ECB4B64C7D2DAFC1EB35D2915C_il2cpp_TypeInfo_var, L_6);
		AsyncOperationHandle_1_tDA2BA7FC48753E9F44D6A9B3873AAB9F2BE05DA4 L_8 = V_0;
		il2cpp_codegen_runtime_class_init_inline(Addressables_tB93529ED0B034BF1A8C7830710BAA45C20A0F7D6_il2cpp_TypeInfo_var);
		Addressables_Release_TisIList_1_tFEC432B87E444FFF0D7B8EFD6CBB918523AD6827_m05E0F779E22A2AEB81C2DC54F3578A128A11920C(L_8, Addressables_Release_TisIList_1_tFEC432B87E444FFF0D7B8EFD6CBB918523AD6827_m05E0F779E22A2AEB81C2DC54F3578A128A11920C_RuntimeMethod_var);
		return L_7;
	}

IL_002c:
	{
		AsyncOperationHandle_1_tDA2BA7FC48753E9F44D6A9B3873AAB9F2BE05DA4 L_9 = V_0;
		il2cpp_codegen_runtime_class_init_inline(Addressables_tB93529ED0B034BF1A8C7830710BAA45C20A0F7D6_il2cpp_TypeInfo_var);
		Addressables_Release_TisIList_1_tFEC432B87E444FFF0D7B8EFD6CBB918523AD6827_m05E0F779E22A2AEB81C2DC54F3578A128A11920C(L_9, Addressables_Release_TisIList_1_tFEC432B87E444FFF0D7B8EFD6CBB918523AD6827_m05E0F779E22A2AEB81C2DC54F3578A128A11920C_RuntimeMethod_var);
		String_t* L_10 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->___Empty;
		return L_10;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
void SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_Multicast(SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* __this, RuntimeObject* ___0_sender, String_t* ___1_propertyName, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* currentDelegate = reinterpret_cast<SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, String_t*, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl)((Il2CppObject*)currentDelegate->___method_code, ___0_sender, ___1_propertyName, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method));
	}
}
void SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_OpenInst(SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* __this, RuntimeObject* ___0_sender, String_t* ___1_propertyName, const RuntimeMethod* method)
{
	NullCheck(___0_sender);
	typedef void (*FunctionPointerType) (RuntimeObject*, String_t*, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr)(___0_sender, ___1_propertyName, method);
}
void SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_OpenStatic(SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* __this, RuntimeObject* ___0_sender, String_t* ___1_propertyName, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (RuntimeObject*, String_t*, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr)(___0_sender, ___1_propertyName, method);
}
void SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_OpenVirtual(SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* __this, RuntimeObject* ___0_sender, String_t* ___1_propertyName, const RuntimeMethod* method)
{
	NullCheck(___0_sender);
	VirtualActionInvoker1< String_t* >::Invoke(il2cpp_codegen_method_get_slot(method), ___0_sender, ___1_propertyName);
}
void SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_OpenInterface(SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* __this, RuntimeObject* ___0_sender, String_t* ___1_propertyName, const RuntimeMethod* method)
{
	NullCheck(___0_sender);
	InterfaceActionInvoker1< String_t* >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___0_sender, ___1_propertyName);
}
void SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_OpenGenericVirtual(SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* __this, RuntimeObject* ___0_sender, String_t* ___1_propertyName, const RuntimeMethod* method)
{
	NullCheck(___0_sender);
	GenericVirtualActionInvoker1< String_t* >::Invoke(method, ___0_sender, ___1_propertyName);
}
void SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_OpenGenericInterface(SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* __this, RuntimeObject* ___0_sender, String_t* ___1_propertyName, const RuntimeMethod* method)
{
	NullCheck(___0_sender);
	GenericInterfaceActionInvoker1< String_t* >::Invoke(method, ___0_sender, ___1_propertyName);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptionsPropertyChanged__ctor_m01880AAF1B112E453572A03A7781D1C7DFCB49EF (SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method) 
{
	__this->___method_ptr = (intptr_t)il2cpp_codegen_get_method_pointer((RuntimeMethod*)___1_method);
	__this->___method = ___1_method;
	__this->___m_target = ___0_object;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target), (void*)___0_object);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___1_method);
	__this->___method_code = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___1_method))
	{
		bool isOpen = parameterCount == 2;
		if (isOpen)
			__this->___invoke_impl = (intptr_t)&SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_OpenStatic;
		else
			{
				__this->___invoke_impl = __this->___method_ptr;
				__this->___method_code = (intptr_t)__this->___m_target;
			}
	}
	else
	{
		bool isOpen = parameterCount == 1;
		if (isOpen)
		{
			if (__this->___method_is_virtual)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___1_method))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___1_method))
						__this->___invoke_impl = (intptr_t)&SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_OpenGenericInterface;
					else
						__this->___invoke_impl = (intptr_t)&SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___1_method))
						__this->___invoke_impl = (intptr_t)&SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_OpenInterface;
					else
						__this->___invoke_impl = (intptr_t)&SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl = (intptr_t)&SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_OpenInst;
			}
		}
		else
		{
			if (___0_object == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl = __this->___method_ptr;
			__this->___method_code = (intptr_t)__this->___m_target;
		}
	}
	__this->___extra_arg = (intptr_t)&SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_Multicast;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF (SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* __this, RuntimeObject* ___0_sender, String_t* ___1_propertyName, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, String_t*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_sender, ___1_propertyName, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* SROptionsPropertyChanged_BeginInvoke_m8A103EB4F6093C48C1B1529A2248B630A22FC93D (SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* __this, RuntimeObject* ___0_sender, String_t* ___1_propertyName, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___2_callback, RuntimeObject* ___3_object, const RuntimeMethod* method) 
{
	void *__d_args[3] = {0};
	__d_args[0] = ___0_sender;
	__d_args[1] = ___1_propertyName;
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___2_callback, (RuntimeObject*)___3_object);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SROptionsPropertyChanged_EndInvoke_mD7173E1847CB61E5A7A394DBC9C2B76E0AB9D66C (SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* __this, RuntimeObject* ___0_result, const RuntimeMethod* method) 
{
	il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___0_result, 0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E UnitySourceGeneratedAssemblyMonoScriptTypes_v1_Get_mBEB95BEB954BB63E9710BBC7AD5E78C4CB0A0033 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____80F16B889816C9E07DCA7BF19ACC6E3E5264FF44E2F83EECB1D18D13B29CAEF2_FieldInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____D88667469C6FCCC9E6D32B2D72E98848BA7A655342BB59B26CAAA782B608D078_FieldInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		il2cpp_codegen_initobj((&V_0), sizeof(MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)((int32_t)421));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = L_0;
		RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 L_2 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____80F16B889816C9E07DCA7BF19ACC6E3E5264FF44E2F83EECB1D18D13B29CAEF2_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B((RuntimeArray*)L_1, L_2, NULL);
		(&V_0)->___FilePathsData = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&(&V_0)->___FilePathsData), (void*)L_1);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)((int32_t)493));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = L_3;
		RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 L_5 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____D88667469C6FCCC9E6D32B2D72E98848BA7A655342BB59B26CAAA782B608D078_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B((RuntimeArray*)L_4, L_5, NULL);
		(&V_0)->___TypesData = L_4;
		Il2CppCodeGenWriteBarrier((void**)(&(&V_0)->___TypesData), (void*)L_4);
		(&V_0)->___TotalFiles = 8;
		(&V_0)->___TotalTypes = ((int32_t)15);
		(&V_0)->___IsEditorOnly = (bool)0;
		MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E L_6 = V_0;
		return L_6;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnitySourceGeneratedAssemblyMonoScriptTypes_v1__ctor_mE70FB23ACC1EA12ABC948AA22C2E78B2D0AA39B1 (UnitySourceGeneratedAssemblyMonoScriptTypes_v1_tC95F24D0C6E6B77389433852BB389F39C692926E* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C void MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E_marshal_pinvoke(const MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E& unmarshaled, MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E_marshaled_pinvoke& marshaled)
{
	marshaled.___FilePathsData = il2cpp_codegen_com_marshal_safe_array(IL2CPP_VT_I1, unmarshaled.___FilePathsData);
	marshaled.___TypesData = il2cpp_codegen_com_marshal_safe_array(IL2CPP_VT_I1, unmarshaled.___TypesData);
	marshaled.___TotalTypes = unmarshaled.___TotalTypes;
	marshaled.___TotalFiles = unmarshaled.___TotalFiles;
	marshaled.___IsEditorOnly = static_cast<int32_t>(unmarshaled.___IsEditorOnly);
}
IL2CPP_EXTERN_C void MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E_marshal_pinvoke_back(const MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E_marshaled_pinvoke& marshaled, MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E& unmarshaled)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	unmarshaled.___FilePathsData = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, marshaled.___FilePathsData);
	Il2CppCodeGenWriteBarrier((void**)(&unmarshaled.___FilePathsData), (void*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, marshaled.___FilePathsData));
	unmarshaled.___TypesData = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, marshaled.___TypesData);
	Il2CppCodeGenWriteBarrier((void**)(&unmarshaled.___TypesData), (void*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, marshaled.___TypesData));
	int32_t unmarshaledTotalTypes_temp_2 = 0;
	unmarshaledTotalTypes_temp_2 = marshaled.___TotalTypes;
	unmarshaled.___TotalTypes = unmarshaledTotalTypes_temp_2;
	int32_t unmarshaledTotalFiles_temp_3 = 0;
	unmarshaledTotalFiles_temp_3 = marshaled.___TotalFiles;
	unmarshaled.___TotalFiles = unmarshaledTotalFiles_temp_3;
	bool unmarshaledIsEditorOnly_temp_4 = false;
	unmarshaledIsEditorOnly_temp_4 = static_cast<bool>(marshaled.___IsEditorOnly);
	unmarshaled.___IsEditorOnly = unmarshaledIsEditorOnly_temp_4;
}
IL2CPP_EXTERN_C void MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E_marshal_pinvoke_cleanup(MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E_marshaled_pinvoke& marshaled)
{
	il2cpp_codegen_com_destroy_safe_array(marshaled.___FilePathsData);
	marshaled.___FilePathsData = NULL;
	il2cpp_codegen_com_destroy_safe_array(marshaled.___TypesData);
	marshaled.___TypesData = NULL;
}
IL2CPP_EXTERN_C void MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E_marshal_com(const MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E& unmarshaled, MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E_marshaled_com& marshaled)
{
	marshaled.___FilePathsData = il2cpp_codegen_com_marshal_safe_array(IL2CPP_VT_I1, unmarshaled.___FilePathsData);
	marshaled.___TypesData = il2cpp_codegen_com_marshal_safe_array(IL2CPP_VT_I1, unmarshaled.___TypesData);
	marshaled.___TotalTypes = unmarshaled.___TotalTypes;
	marshaled.___TotalFiles = unmarshaled.___TotalFiles;
	marshaled.___IsEditorOnly = static_cast<int32_t>(unmarshaled.___IsEditorOnly);
}
IL2CPP_EXTERN_C void MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E_marshal_com_back(const MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E_marshaled_com& marshaled, MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E& unmarshaled)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	unmarshaled.___FilePathsData = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, marshaled.___FilePathsData);
	Il2CppCodeGenWriteBarrier((void**)(&unmarshaled.___FilePathsData), (void*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, marshaled.___FilePathsData));
	unmarshaled.___TypesData = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, marshaled.___TypesData);
	Il2CppCodeGenWriteBarrier((void**)(&unmarshaled.___TypesData), (void*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_il2cpp_TypeInfo_var, marshaled.___TypesData));
	int32_t unmarshaledTotalTypes_temp_2 = 0;
	unmarshaledTotalTypes_temp_2 = marshaled.___TotalTypes;
	unmarshaled.___TotalTypes = unmarshaledTotalTypes_temp_2;
	int32_t unmarshaledTotalFiles_temp_3 = 0;
	unmarshaledTotalFiles_temp_3 = marshaled.___TotalFiles;
	unmarshaled.___TotalFiles = unmarshaledTotalFiles_temp_3;
	bool unmarshaledIsEditorOnly_temp_4 = false;
	unmarshaledIsEditorOnly_temp_4 = static_cast<bool>(marshaled.___IsEditorOnly);
	unmarshaled.___IsEditorOnly = unmarshaledIsEditorOnly_temp_4;
}
IL2CPP_EXTERN_C void MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E_marshal_com_cleanup(MonoScriptData_t8F50E352855B96FFFC1D9CB07EACC90C99D73A3E_marshaled_com& marshaled)
{
	il2cpp_codegen_com_destroy_safe_array(marshaled.___FilePathsData);
	marshaled.___FilePathsData = NULL;
	il2cpp_codegen_com_destroy_safe_array(marshaled.___TypesData);
	marshaled.___TypesData = NULL;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t EquineScheduler_IUpdateFacade_AddTimeLimitUpdatorMethod_m15B2379017FC0B281E153C1EC7794097105B10D0 (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, float ___0_interval, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ___1_updateHandler, RuntimeObject* ___2_param, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IntHashtable_1_set_Item_mE8F2A507CD5AA919580B1B5ED50E6FB95125765C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC94C277BA0A3F63AE2448B986F92E23DD20CAEED);
		s_Il2CppMethodInitialized = true;
	}
	TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* V_0 = NULL;
	int32_t V_1 = 0;
	{
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_0 = ___1_updateHandler;
		if (L_0)
		{
			goto IL_000f;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_LogError_mB00B2B4468EF3CAF041B038D840820FB84C924B2(_stringLiteralC94C277BA0A3F63AE2448B986F92E23DD20CAEED, NULL);
		return 0;
	}

IL_000f:
	{
		il2cpp_codegen_runtime_class_init_inline(TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var);
		TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* L_1;
		L_1 = TimeLimitUpdator_Allocate_m3B2CF35DEA77C1FCC1ACA7BA8E43FD87E0EF6AC6(NULL);
		V_0 = L_1;
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		int32_t L_2 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____globalId;
		int32_t L_3 = L_2;
		((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____globalId = ((int32_t)il2cpp_codegen_add(L_3, 1));
		V_1 = L_3;
		TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* L_4 = V_0;
		int32_t L_5 = V_1;
		NullCheck(L_4);
		BaseLimitUpdator_set_id_mB1C069E5930897FC57398002DB6DD1051D7AF8C5_inline(L_4, L_5, NULL);
		TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* L_6 = V_0;
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_7 = ___1_updateHandler;
		float L_8 = ___0_interval;
		RuntimeObject* L_9 = ___2_param;
		NullCheck(L_6);
		TimeLimitUpdator_Start_m5F76BAD87DD040FC820F1945F0843C363BA58AEB(L_6, L_7, L_8, L_9, (bool)0, NULL);
		IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7* L_10 = __this->____updatorMap;
		int32_t L_11 = V_1;
		TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* L_12 = V_0;
		NullCheck(L_10);
		IntHashtable_1_set_Item_mE8F2A507CD5AA919580B1B5ED50E6FB95125765C(L_10, L_11, L_12, IntHashtable_1_set_Item_mE8F2A507CD5AA919580B1B5ED50E6FB95125765C_RuntimeMethod_var);
		int32_t L_13 = V_1;
		return L_13;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t EquineScheduler_IUpdateFacade_CallOnceMethod_m8845C82D1E1CCBE96E6E6C92772BC0F91E729585 (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, int32_t ___0_delayFrames, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ___1_updateHandler, RuntimeObject* ___2_param, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IntHashtable_1_set_Item_mE8F2A507CD5AA919580B1B5ED50E6FB95125765C_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* V_0 = NULL;
	int32_t V_1 = 0;
	{
		il2cpp_codegen_runtime_class_init_inline(FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var);
		FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* L_0;
		L_0 = FrameLimitUpdator_Allocate_m7783EDB49B3EA53A56F09A218B0D31AE7F15DAAA(NULL);
		V_0 = L_0;
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		int32_t L_1 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____globalId;
		int32_t L_2 = L_1;
		((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____globalId = ((int32_t)il2cpp_codegen_add(L_2, 1));
		V_1 = L_2;
		FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* L_3 = V_0;
		int32_t L_4 = V_1;
		NullCheck(L_3);
		BaseLimitUpdator_set_id_mB1C069E5930897FC57398002DB6DD1051D7AF8C5_inline(L_3, L_4, NULL);
		FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* L_5 = V_0;
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_6 = ___1_updateHandler;
		int32_t L_7 = ___0_delayFrames;
		RuntimeObject* L_8 = ___2_param;
		NullCheck(L_5);
		FrameLimitUpdator_Start_m4E7618B39D780976865282B501647494837CA9B3(L_5, L_6, L_7, L_8, (bool)1, NULL);
		IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7* L_9 = __this->____updatorMap;
		int32_t L_10 = V_1;
		FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* L_11 = V_0;
		NullCheck(L_9);
		IntHashtable_1_set_Item_mE8F2A507CD5AA919580B1B5ED50E6FB95125765C(L_9, L_10, L_11, IntHashtable_1_set_Item_mE8F2A507CD5AA919580B1B5ED50E6FB95125765C_RuntimeMethod_var);
		int32_t L_12 = V_1;
		return L_12;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t EquineScheduler_IUpdateFacade_AddFrameLimitUpdatorMethod_mC5C2DD0959E9838426AB7C4ADAC9977D8E4B90EE (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, int32_t ___0_interval, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ___1_updateHandler, RuntimeObject* ___2_param, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IntHashtable_1_set_Item_mE8F2A507CD5AA919580B1B5ED50E6FB95125765C_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* V_0 = NULL;
	int32_t V_1 = 0;
	{
		il2cpp_codegen_runtime_class_init_inline(FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var);
		FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* L_0;
		L_0 = FrameLimitUpdator_Allocate_m7783EDB49B3EA53A56F09A218B0D31AE7F15DAAA(NULL);
		V_0 = L_0;
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		int32_t L_1 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____globalId;
		int32_t L_2 = L_1;
		((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____globalId = ((int32_t)il2cpp_codegen_add(L_2, 1));
		V_1 = L_2;
		FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* L_3 = V_0;
		int32_t L_4 = V_1;
		NullCheck(L_3);
		BaseLimitUpdator_set_id_mB1C069E5930897FC57398002DB6DD1051D7AF8C5_inline(L_3, L_4, NULL);
		FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* L_5 = V_0;
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_6 = ___1_updateHandler;
		int32_t L_7 = ___0_interval;
		RuntimeObject* L_8 = ___2_param;
		NullCheck(L_5);
		FrameLimitUpdator_Start_m4E7618B39D780976865282B501647494837CA9B3(L_5, L_6, L_7, L_8, (bool)0, NULL);
		IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7* L_9 = __this->____updatorMap;
		int32_t L_10 = V_1;
		FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* L_11 = V_0;
		NullCheck(L_9);
		IntHashtable_1_set_Item_mE8F2A507CD5AA919580B1B5ED50E6FB95125765C(L_9, L_10, L_11, IntHashtable_1_set_Item_mE8F2A507CD5AA919580B1B5ED50E6FB95125765C_RuntimeMethod_var);
		int32_t L_12 = V_1;
		return L_12;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t EquineScheduler_IUpdateFacade_CallOnceMethod_m9F6E50FAA2C1278022E823C598CBB46BD82AE6E9 (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, float ___0_delayTimes, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ___1_updateHandler, RuntimeObject* ___2_param, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IntHashtable_1_set_Item_mE8F2A507CD5AA919580B1B5ED50E6FB95125765C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC94C277BA0A3F63AE2448B986F92E23DD20CAEED);
		s_Il2CppMethodInitialized = true;
	}
	TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* V_0 = NULL;
	int32_t V_1 = 0;
	{
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_0 = ___1_updateHandler;
		if (L_0)
		{
			goto IL_000f;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_LogError_mB00B2B4468EF3CAF041B038D840820FB84C924B2(_stringLiteralC94C277BA0A3F63AE2448B986F92E23DD20CAEED, NULL);
		return 0;
	}

IL_000f:
	{
		il2cpp_codegen_runtime_class_init_inline(TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var);
		TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* L_1;
		L_1 = TimeLimitUpdator_Allocate_m3B2CF35DEA77C1FCC1ACA7BA8E43FD87E0EF6AC6(NULL);
		V_0 = L_1;
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		int32_t L_2 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____globalId;
		int32_t L_3 = L_2;
		((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____globalId = ((int32_t)il2cpp_codegen_add(L_3, 1));
		V_1 = L_3;
		TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* L_4 = V_0;
		int32_t L_5 = V_1;
		NullCheck(L_4);
		BaseLimitUpdator_set_id_mB1C069E5930897FC57398002DB6DD1051D7AF8C5_inline(L_4, L_5, NULL);
		TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* L_6 = V_0;
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_7 = ___1_updateHandler;
		float L_8 = ___0_delayTimes;
		RuntimeObject* L_9 = ___2_param;
		NullCheck(L_6);
		TimeLimitUpdator_Start_m5F76BAD87DD040FC820F1945F0843C363BA58AEB(L_6, L_7, L_8, L_9, (bool)1, NULL);
		IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7* L_10 = __this->____updatorMap;
		int32_t L_11 = V_1;
		TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* L_12 = V_0;
		NullCheck(L_10);
		IntHashtable_1_set_Item_mE8F2A507CD5AA919580B1B5ED50E6FB95125765C(L_10, L_11, L_12, IntHashtable_1_set_Item_mE8F2A507CD5AA919580B1B5ED50E6FB95125765C_RuntimeMethod_var);
		int32_t L_13 = V_1;
		return L_13;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_IUpdateFacade_RemoveLimitUpdatorMethod_m1F7FB7E3268C4B5CC38D5069E081AE571D73E475 (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, int32_t ___0_id, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IntHashtable_1_get_Item_m35BE2466A07F288C6AC3196E60FBA36EE3539A70_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* V_0 = NULL;
	{
		IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7* L_0 = __this->____updatorMap;
		int32_t L_1 = ___0_id;
		NullCheck(L_0);
		BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* L_2;
		L_2 = IntHashtable_1_get_Item_m35BE2466A07F288C6AC3196E60FBA36EE3539A70(L_0, L_1, IntHashtable_1_get_Item_m35BE2466A07F288C6AC3196E60FBA36EE3539A70_RuntimeMethod_var);
		V_0 = L_2;
		BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* L_3 = V_0;
		if (!L_3)
		{
			goto IL_0016;
		}
	}
	{
		BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* L_4 = V_0;
		NullCheck(L_4);
		VirtualActionInvoker0::Invoke(5, L_4);
	}

IL_0016:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool EquineScheduler_IUpdateFacade_IsValid_mCE61507733C25F90712518E3CB7AF4E157BF5726 (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, int32_t ___0_id, const RuntimeMethod* method) 
{
	{
		IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7* L_0 = __this->____updatorMap;
		int32_t L_1 = ___0_id;
		NullCheck(L_0);
		bool L_2;
		L_2 = VirtualFuncInvoker1< bool, int32_t >::Invoke(7, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_IUpdateFacade_SetActive_mF9CD90D24908C4A41CD1F3798A15DFAC12A47D0E (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, int32_t ___0_id, bool ___1_active, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IntHashtable_1_get_Item_m35BE2466A07F288C6AC3196E60FBA36EE3539A70_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* V_0 = NULL;
	{
		IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7* L_0 = __this->____updatorMap;
		int32_t L_1 = ___0_id;
		NullCheck(L_0);
		BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* L_2;
		L_2 = IntHashtable_1_get_Item_m35BE2466A07F288C6AC3196E60FBA36EE3539A70(L_0, L_1, IntHashtable_1_get_Item_m35BE2466A07F288C6AC3196E60FBA36EE3539A70_RuntimeMethod_var);
		V_0 = L_2;
		BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* L_3 = V_0;
		if (!L_3)
		{
			goto IL_0017;
		}
	}
	{
		BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* L_4 = V_0;
		bool L_5 = ___1_active;
		NullCheck(L_4);
		BaseLimitUpdator_set_active_m7879D0C8CB8E0C90D01F8DD7CFCDD49B4AD2544D_inline(L_4, L_5, NULL);
	}

IL_0017:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_add_updateEvent_mBBB672CA722F0AF108B571206656EE3E85B80ED0 (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___0_value, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = __this->____updateDelegate;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = ___0_value;
		Delegate_t* L_2;
		L_2 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_0, L_1, NULL);
		__this->____updateDelegate = ((Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)CastclassSealed((RuntimeObject*)L_2, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var));
		Il2CppCodeGenWriteBarrier((void**)(&__this->____updateDelegate), (void*)((Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)CastclassSealed((RuntimeObject*)L_2, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var)));
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_remove_updateEvent_m11222883F7F5BD1EC683A0CF759A86604AABAB95 (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___0_value, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = __this->____updateDelegate;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = ___0_value;
		Delegate_t* L_2;
		L_2 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_0, L_1, NULL);
		__this->____updateDelegate = ((Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)CastclassSealed((RuntimeObject*)L_2, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var));
		Il2CppCodeGenWriteBarrier((void**)(&__this->____updateDelegate), (void*)((Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)CastclassSealed((RuntimeObject*)L_2, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var)));
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_Awake_m9875C047D7002596729E97E578C24147A32948D0 (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_0 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605(L_0, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		if (!L_1)
		{
			goto IL_0043;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance = __this;
		Il2CppCodeGenWriteBarrier((void**)(&((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance), (void*)__this);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_2;
		L_2 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		Object_DontDestroyOnLoad_m4B70C3AEF886C176543D1295507B6455C9DCAEA7(L_2, NULL);
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_3;
		L_3 = Thread_get_CurrentThread_m6D4719F4993DB9200490531FF02D4076FF9CA9BD(NULL);
		NullCheck(L_3);
		int32_t L_4;
		L_4 = Thread_get_ManagedThreadId_m74ACB74A574EE535C2B00B7D64F203A62E796B05(L_3, NULL);
		((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____mainThreadId = L_4;
		UniqueMonoEventListener_t608C75BB5859C7C58DBD298123D78BAF8D15FD22* L_5;
		L_5 = UniqueMonoEventListener_get_instance_m4F0312B5F10159646AE36AC94C37FE9B65068146(NULL);
		NullCheck(L_5);
		UpdateTimeInfo_tCC8E1C8131E776D226406C9D1F4FFE8E99577B22 L_6;
		L_6 = UniqueMonoEventListener_get_currentUpdateTimeInfo_m76901A493509552678DD377961BA7AEAE38DAFCB_inline(L_5, NULL);
		((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____currentFrameUpdateTimeInfo = L_6;
		VirtualActionInvoker0::Invoke(11, __this);
		return;
	}

IL_0043:
	{
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_7;
		L_7 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		Object_Destroy_mE97D0A766419A81296E8D4E5C23D01D3FE91ACBB(L_7, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_DoAwake_m809EB9F401AD92CEB4428A7CD87ED5E5EC0D06FC (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, const RuntimeMethod* method) 
{
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_ClearAll_mEDFD88260253593CCDAAEFC4652700C28A03960E (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Clear_m344AD90676A608EA37B9DF93050BA9F80C23D17E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_0 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602(L_0, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		if (!L_1)
		{
			goto IL_0036;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_2 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		NullCheck(L_2);
		L_2->____updateDelegate = (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&L_2->____updateDelegate), (void*)(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)NULL);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_3 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		NullCheck(L_3);
		List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_4 = L_3->____pendingRunnableQueue;
		NullCheck(L_4);
		List_1_Clear_m344AD90676A608EA37B9DF93050BA9F80C23D17E_inline(L_4, List_1_Clear_m344AD90676A608EA37B9DF93050BA9F80C23D17E_RuntimeMethod_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_5 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		NullCheck(L_5);
		List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_6 = L_5->____cachedRunnableQueue;
		NullCheck(L_6);
		List_1_Clear_m344AD90676A608EA37B9DF93050BA9F80C23D17E_inline(L_6, List_1_Clear_m344AD90676A608EA37B9DF93050BA9F80C23D17E_RuntimeMethod_var);
	}

IL_0036:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t EquineScheduler_AddTimeLimitUpdator_m7464A5B041276A50FDC18CF602AB804705AAEF74 (float ___0_interval, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ___1_updateHandler, RuntimeObject* ___2_param, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_0 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		float L_1 = ___0_interval;
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_2 = ___1_updateHandler;
		RuntimeObject* L_3 = ___2_param;
		NullCheck(L_0);
		int32_t L_4;
		L_4 = InterfaceFuncInvoker3< int32_t, float, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87*, RuntimeObject* >::Invoke(0, IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var, L_0, L_1, L_2, L_3);
		return L_4;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t EquineScheduler_CallOnce_m28D118B033BBFEF46F1ABBF5B6BF0BD42392C286 (float ___0_delayTime, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ___1_updateHandler, RuntimeObject* ___2_param, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_0 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		float L_1 = ___0_delayTime;
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_2 = ___1_updateHandler;
		RuntimeObject* L_3 = ___2_param;
		NullCheck(L_0);
		int32_t L_4;
		L_4 = InterfaceFuncInvoker3< int32_t, float, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87*, RuntimeObject* >::Invoke(3, IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var, L_0, L_1, L_2, L_3);
		return L_4;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t EquineScheduler_AddFrameLimitUpdator_mDD2D7C77FA1B0384E99EE721E31E3C69D259C5A4 (int32_t ___0_interval, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ___1_updateHandler, RuntimeObject* ___2_param, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_0 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		int32_t L_1 = ___0_interval;
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_2 = ___1_updateHandler;
		RuntimeObject* L_3 = ___2_param;
		NullCheck(L_0);
		int32_t L_4;
		L_4 = InterfaceFuncInvoker3< int32_t, int32_t, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87*, RuntimeObject* >::Invoke(1, IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var, L_0, L_1, L_2, L_3);
		return L_4;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t EquineScheduler_CallOnceFrame_m368BCE7EC959B282A308541E0548034715075746 (int32_t ___0_delayFrames, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ___1_updateHandler, RuntimeObject* ___2_param, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_0 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		int32_t L_1 = ___0_delayFrames;
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_2 = ___1_updateHandler;
		RuntimeObject* L_3 = ___2_param;
		NullCheck(L_0);
		int32_t L_4;
		L_4 = InterfaceFuncInvoker3< int32_t, int32_t, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87*, RuntimeObject* >::Invoke(2, IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var, L_0, L_1, L_2, L_3);
		return L_4;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_RemoveLimitUpdator_m9FBEF86055525CCE7D7C165C6D41CD3AB53AC059 (int32_t* ___0_id, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t* L_0 = ___0_id;
		int32_t L_1 = *((int32_t*)L_0);
		if ((((int32_t)L_1) <= ((int32_t)0)))
		{
			goto IL_0014;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_2 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		int32_t* L_3 = ___0_id;
		int32_t L_4 = *((int32_t*)L_3);
		NullCheck(L_2);
		InterfaceActionInvoker1< int32_t >::Invoke(4, IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var, L_2, L_4);
		int32_t* L_5 = ___0_id;
		*((int32_t*)L_5) = (int32_t)0;
	}

IL_0014:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool EquineScheduler_IsValid_m4A2C0D8B6E61FA0B852086C62703DA98DA0CA9FD (int32_t ___0_id, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		int32_t L_0 = ___0_id;
		if ((((int32_t)L_0) <= ((int32_t)0)))
		{
			goto IL_0010;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_1 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		int32_t L_2 = ___0_id;
		NullCheck(L_1);
		bool L_3;
		L_3 = InterfaceFuncInvoker1< bool, int32_t >::Invoke(5, IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var, L_1, L_2);
		return L_3;
	}

IL_0010:
	{
		return (bool)0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_SetActive_mFB47247445B1DD8011F28FA04D2B983622DD138D (int32_t ___0_id, bool ___1_active, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_0 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		int32_t L_1 = ___0_id;
		bool L_2 = ___1_active;
		NullCheck(L_0);
		InterfaceActionInvoker2< int32_t, bool >::Invoke(6, IUpdateFacade_tA823D17369789CD6EE53068F3A3C67398BBDDBC5_il2cpp_TypeInfo_var, L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* EquineScheduler_StartYieldCoroutine_m3964914523D45903CCC582B760D847DF4ED693A8 (RuntimeObject* ___0_coroutine, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_0 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		RuntimeObject* L_1 = ___0_coroutine;
		NullCheck(L_0);
		Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* L_2;
		L_2 = MonoBehaviour_StartCoroutine_m4CAFF732AA28CD3BDC5363B44A863575530EC812(L_0, L_1, NULL);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_StopYieldCoroutine_mE4C0F244DBA9CC51D28CF335F5E650A378685951 (Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* ___0_coroutine, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_0 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* L_1 = ___0_coroutine;
		NullCheck(L_0);
		MonoBehaviour_StopCoroutine_mB0FC91BE84203BD8E360B3FBAE5B958B4C5ED22A(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_StopAllYieldCoroutine_mFBA8E6C0327D747AADB7689B53F5D30FD1C28B48 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_0 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		NullCheck(L_0);
		MonoBehaviour_StopAllCoroutines_m872033451D42013A99867D09337490017E9ED318(L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_RunToMainThread_mA46B2F74C0D9FCA8B73B335F98648A2A67F394D5 (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___0_action, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		int32_t L_0 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____mainThreadId;
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_1;
		L_1 = Thread_get_CurrentThread_m6D4719F4993DB9200490531FF02D4076FF9CA9BD(NULL);
		NullCheck(L_1);
		int32_t L_2;
		L_2 = Thread_get_ManagedThreadId_m74ACB74A574EE535C2B00B7D64F203A62E796B05(L_1, NULL);
		if ((!(((uint32_t)L_0) == ((uint32_t)L_2))))
		{
			goto IL_0018;
		}
	}
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_3 = ___0_action;
		NullCheck(L_3);
		Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline(L_3, NULL);
		return;
	}

IL_0018:
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_4 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_5 = ___0_action;
		NullCheck(L_4);
		EquineScheduler_DoRunToMainThread_m02504EF3C5F142D5ABE95B85C46EB5CC5BF3F81C(L_4, L_5, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_DoRunToMainThread_m02504EF3C5F142D5ABE95B85C46EB5CC5BF3F81C (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___0_action, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_m5B99D67CB378BFA8A1142343F9DB44D94322EAD3_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	List_1_tDB72209F35D56F62A287633F9450978E90B90987* V_0 = NULL;
	bool V_1 = false;
	{
		List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_0 = __this->____pendingRunnableQueue;
		V_0 = L_0;
		V_1 = (bool)0;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_001f:
			{
				{
					bool L_1 = V_1;
					if (!L_1)
					{
						goto IL_0028;
					}
				}
				{
					List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_2 = V_0;
					Monitor_Exit_m05B2CF037E2214B3208198C282490A2A475653FA(L_2, NULL);
				}

IL_0028:
				{
					return;
				}
			}
		});
		try
		{
			List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_3 = V_0;
			Monitor_Enter_m3CDB589DA1300B513D55FDCFB52B63E879794149(L_3, (&V_1), NULL);
			List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_4 = __this->____pendingRunnableQueue;
			Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_5 = ___0_action;
			NullCheck(L_4);
			List_1_Add_m5B99D67CB378BFA8A1142343F9DB44D94322EAD3_inline(L_4, L_5, List_1_Add_m5B99D67CB378BFA8A1142343F9DB44D94322EAD3_RuntimeMethod_var);
			goto IL_0029;
		}
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_0029:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_LateUpdate_m110E73533ACD670C20855776A00331BAA8F8AAC8 (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_AddRange_m475DC02C782750D4036B11E287BC01ECB8313D1D_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Clear_m344AD90676A608EA37B9DF93050BA9F80C23D17E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Count_m5E7FCE3DF7B23B6D88C14A04177C1DCD15063858_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Item_m8A119323481338039197B73D82916BB46DEE3C2D_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	List_1_tDB72209F35D56F62A287633F9450978E90B90987* V_2 = NULL;
	bool V_3 = false;
	int32_t V_4 = 0;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_5 = NULL;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		UniqueMonoEventListener_t608C75BB5859C7C58DBD298123D78BAF8D15FD22* L_0;
		L_0 = UniqueMonoEventListener_get_instance_m4F0312B5F10159646AE36AC94C37FE9B65068146(NULL);
		NullCheck(L_0);
		UpdateTimeInfo_tCC8E1C8131E776D226406C9D1F4FFE8E99577B22 L_1;
		L_1 = UniqueMonoEventListener_get_currentUpdateTimeInfo_m76901A493509552678DD377961BA7AEAE38DAFCB_inline(L_0, NULL);
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____currentFrameUpdateTimeInfo = L_1;
		List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_2 = __this->____cachedRunnableQueue;
		NullCheck(L_2);
		int32_t L_3;
		L_3 = List_1_get_Count_m5E7FCE3DF7B23B6D88C14A04177C1DCD15063858_inline(L_2, List_1_get_Count_m5E7FCE3DF7B23B6D88C14A04177C1DCD15063858_RuntimeMethod_var);
		V_0 = L_3;
		List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_4 = __this->____pendingRunnableQueue;
		V_2 = L_4;
		V_3 = (bool)0;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_004a:
			{
				{
					bool L_5 = V_3;
					if (!L_5)
					{
						goto IL_0053;
					}
				}
				{
					List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_6 = V_2;
					Monitor_Exit_m05B2CF037E2214B3208198C282490A2A475653FA(L_6, NULL);
				}

IL_0053:
				{
					return;
				}
			}
		});
		try
		{
			List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_7 = V_2;
			Monitor_Enter_m3CDB589DA1300B513D55FDCFB52B63E879794149(L_7, (&V_3), NULL);
			List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_8 = __this->____cachedRunnableQueue;
			List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_9 = __this->____pendingRunnableQueue;
			NullCheck(L_8);
			List_1_AddRange_m475DC02C782750D4036B11E287BC01ECB8313D1D(L_8, L_9, List_1_AddRange_m475DC02C782750D4036B11E287BC01ECB8313D1D_RuntimeMethod_var);
			List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_10 = __this->____pendingRunnableQueue;
			NullCheck(L_10);
			List_1_Clear_m344AD90676A608EA37B9DF93050BA9F80C23D17E_inline(L_10, List_1_Clear_m344AD90676A608EA37B9DF93050BA9F80C23D17E_RuntimeMethod_var);
			goto IL_0054;
		}
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_0054:
	{
		List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_11 = __this->____cachedRunnableQueue;
		NullCheck(L_11);
		int32_t L_12;
		L_12 = List_1_get_Count_m5E7FCE3DF7B23B6D88C14A04177C1DCD15063858_inline(L_11, List_1_get_Count_m5E7FCE3DF7B23B6D88C14A04177C1DCD15063858_RuntimeMethod_var);
		V_1 = L_12;
		int32_t L_13 = V_1;
		int32_t L_14 = V_0;
		if ((((int32_t)L_13) <= ((int32_t)L_14)))
		{
			goto IL_00a0;
		}
	}
	{
		int32_t L_15 = V_0;
		V_4 = L_15;
		goto IL_008e;
	}

IL_0069:
	{
		List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_16 = __this->____cachedRunnableQueue;
		int32_t L_17 = V_4;
		NullCheck(L_16);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_18;
		L_18 = List_1_get_Item_m8A119323481338039197B73D82916BB46DEE3C2D(L_16, L_17, List_1_get_Item_m8A119323481338039197B73D82916BB46DEE3C2D_RuntimeMethod_var);
		V_5 = L_18;
	}
	try
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_19 = V_5;
		NullCheck(L_19);
		Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline(L_19, NULL);
		goto IL_0088;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Exception_t_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0081;
		}
		throw e;
	}

CATCH_0081:
	{
		Exception_t* L_20 = ((Exception_t*)IL2CPP_GET_ACTIVE_EXCEPTION(Exception_t*));;
		il2cpp_codegen_runtime_class_init_inline(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var)));
		Debug_LogException_mAB3F4DC7297ED8FBB49DAA718B70E59A6B0171B0(L_20, NULL);
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0088;
	}

IL_0088:
	{
		int32_t L_21 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add(L_21, 1));
	}

IL_008e:
	{
		int32_t L_22 = V_4;
		int32_t L_23 = V_1;
		if ((((int32_t)L_22) < ((int32_t)L_23)))
		{
			goto IL_0069;
		}
	}
	{
		List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_24 = __this->____cachedRunnableQueue;
		NullCheck(L_24);
		List_1_Clear_m344AD90676A608EA37B9DF93050BA9F80C23D17E_inline(L_24, List_1_Clear_m344AD90676A608EA37B9DF93050BA9F80C23D17E_RuntimeMethod_var);
		goto IL_00af;
	}

IL_00a0:
	{
		int32_t L_25 = V_0;
		if ((((int32_t)L_25) <= ((int32_t)0)))
		{
			goto IL_00af;
		}
	}
	{
		List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_26 = __this->____cachedRunnableQueue;
		NullCheck(L_26);
		List_1_Clear_m344AD90676A608EA37B9DF93050BA9F80C23D17E_inline(L_26, List_1_Clear_m344AD90676A608EA37B9DF93050BA9F80C23D17E_RuntimeMethod_var);
	}

IL_00af:
	{
		VirtualActionInvoker0::Invoke(12, __this);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler_DoLateUpdate_m080B41E83EB1A17DC7773EA9950BDAC804C42423 (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, const RuntimeMethod* method) 
{
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = __this->____updateDelegate;
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = __this->____updateDelegate;
		NullCheck(L_1);
		Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline(L_1, NULL);
	}

IL_0013:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler__ctor_mF2EB04491D7BC7784296714AB262C3CB403E8D71 (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IntHashtable_1__ctor_m18015E230A511EE02627075413DCD4DB2AC32520_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_mBFD6DF02E045EDF3C322E2112C922457016C8212_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_tDB72209F35D56F62A287633F9450978E90B90987_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7* L_0 = (IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7*)il2cpp_codegen_object_new(IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7_il2cpp_TypeInfo_var);
		IntHashtable_1__ctor_m18015E230A511EE02627075413DCD4DB2AC32520(L_0, ((int32_t)20), IntHashtable_1__ctor_m18015E230A511EE02627075413DCD4DB2AC32520_RuntimeMethod_var);
		__this->____updatorMap = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____updatorMap), (void*)L_0);
		List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_1 = (List_1_tDB72209F35D56F62A287633F9450978E90B90987*)il2cpp_codegen_object_new(List_1_tDB72209F35D56F62A287633F9450978E90B90987_il2cpp_TypeInfo_var);
		List_1__ctor_mBFD6DF02E045EDF3C322E2112C922457016C8212(L_1, List_1__ctor_mBFD6DF02E045EDF3C322E2112C922457016C8212_RuntimeMethod_var);
		__this->____pendingRunnableQueue = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____pendingRunnableQueue), (void*)L_1);
		List_1_tDB72209F35D56F62A287633F9450978E90B90987* L_2 = (List_1_tDB72209F35D56F62A287633F9450978E90B90987*)il2cpp_codegen_object_new(List_1_tDB72209F35D56F62A287633F9450978E90B90987_il2cpp_TypeInfo_var);
		List_1__ctor_mBFD6DF02E045EDF3C322E2112C922457016C8212(L_2, List_1__ctor_mBFD6DF02E045EDF3C322E2112C922457016C8212_RuntimeMethod_var);
		__this->____cachedRunnableQueue = L_2;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____cachedRunnableQueue), (void*)L_2);
		MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EquineScheduler__cctor_m7D6637C13286211F6D88652CCC909C1151C6D41B (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____globalId = 1;
		((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance = (EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance), (void*)(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF*)NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t BaseLimitUpdator_get_id_m3D5E38624A00972BFA083F2375D493AE0A3CE26E (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CidU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BaseLimitUpdator_set_id_mB1C069E5930897FC57398002DB6DD1051D7AF8C5 (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_value;
		__this->___U3CidU3Ek__BackingField = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool BaseLimitUpdator_get_active_mF70E508BDFE68081D15C2BB15351A207FA2D5AE1 (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CactiveU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BaseLimitUpdator_set_active_m7879D0C8CB8E0C90D01F8DD7CFCDD49B4AD2544D (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, bool ___0_value, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___0_value;
		__this->___U3CactiveU3Ek__BackingField = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BaseLimitUpdator__ctor_m80CDE6F678884981954749212D5A82DB3105D852 (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)il2cpp_codegen_object_new(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var);
		Action__ctor_mBDC7B0B4A3F583B64C2896F01BDED360772F67DC(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 4)), NULL);
		__this->____updateProxyHandler = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____updateProxyHandler), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BaseLimitUpdator_ResetVal_m3379690CAAF1297AE3A6290D522C2E6F8DDA90AC (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ___0_target, RuntimeObject* ___1_targetParam, bool ___2_once, const RuntimeMethod* method) 
{
	{
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_0 = ___0_target;
		__this->____updateHandler = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____updateHandler), (void*)L_0);
		RuntimeObject* L_1 = ___1_targetParam;
		__this->____param = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____param), (void*)L_1);
		bool L_2 = ___2_once;
		__this->____once = L_2;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BaseLimitUpdator_Dispose_mCB697B37892E33B5721E0CD13520FF81547CB972 (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, const RuntimeMethod* method) 
{
	{
		__this->____updateHandler = (Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____updateHandler), (void*)(Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87*)NULL);
		__this->____param = NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____param), (void*)NULL);
		__this->____once = (bool)0;
		BaseLimitUpdator_set_active_m7879D0C8CB8E0C90D01F8DD7CFCDD49B4AD2544D_inline(__this, (bool)0, NULL);
		BaseLimitUpdator_set_id_mB1C069E5930897FC57398002DB6DD1051D7AF8C5_inline(__this, 0, NULL);
		int32_t L_0 = __this->____disposeTimes;
		__this->____disposeTimes = ((int32_t)il2cpp_codegen_add(L_0, 1));
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TimeLimitUpdator__ctor_mFD10EC99ACA0AF4BBBF49AE3368B2916F9250700 (TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* __this, const RuntimeMethod* method) 
{
	{
		BaseLimitUpdator__ctor_m80CDE6F678884981954749212D5A82DB3105D852(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* TimeLimitUpdator_Allocate_m3B2CF35DEA77C1FCC1ACA7BA8E43FD87E0EF6AC6 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stack_1_Pop_m4FAF28A63461E2F308410C48D9F849FF58C620CB_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stack_1_get_Count_m4873716797859474506B12AC03816C475F318082_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* V_0 = NULL;
	{
		V_0 = (TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286*)NULL;
		il2cpp_codegen_runtime_class_init_inline(TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var);
		Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81* L_0 = ((TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_StaticFields*)il2cpp_codegen_static_fields_for(TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var))->____timeLimitUpdatorStack;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = Stack_1_get_Count_m4873716797859474506B12AC03816C475F318082_inline(L_0, Stack_1_get_Count_m4873716797859474506B12AC03816C475F318082_RuntimeMethod_var);
		if ((((int32_t)L_1) <= ((int32_t)0)))
		{
			goto IL_0023;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var);
		Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81* L_2 = ((TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_StaticFields*)il2cpp_codegen_static_fields_for(TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var))->____timeLimitUpdatorStack;
		NullCheck(L_2);
		TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* L_3;
		L_3 = Stack_1_Pop_m4FAF28A63461E2F308410C48D9F849FF58C620CB(L_2, Stack_1_Pop_m4FAF28A63461E2F308410C48D9F849FF58C620CB_RuntimeMethod_var);
		V_0 = L_3;
		TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* L_4 = V_0;
		NullCheck(L_4);
		L_4->____inPool = (bool)0;
		goto IL_0029;
	}

IL_0023:
	{
		TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* L_5 = (TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286*)il2cpp_codegen_object_new(TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var);
		TimeLimitUpdator__ctor_mFD10EC99ACA0AF4BBBF49AE3368B2916F9250700(L_5, NULL);
		V_0 = L_5;
	}

IL_0029:
	{
		TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* L_6 = V_0;
		return L_6;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TimeLimitUpdator_Start_m5F76BAD87DD040FC820F1945F0843C363BA58AEB (TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* __this, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ___0_updateHandler, float ___1_interval, RuntimeObject* ___2_param, bool ___3_once, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_0 = ___0_updateHandler;
		RuntimeObject* L_1 = ___2_param;
		bool L_2 = ___3_once;
		BaseLimitUpdator_ResetVal_m3379690CAAF1297AE3A6290D522C2E6F8DDA90AC(__this, L_0, L_1, L_2, NULL);
		float L_3 = ___1_interval;
		__this->____interval = L_3;
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		float L_4 = (&((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____currentFrameUpdateTimeInfo)->___realtimeSinceStartup;
		__this->____lastTime = ((double)L_4);
		RuntimeObject* L_5 = ___2_param;
		((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____param = L_5;
		Il2CppCodeGenWriteBarrier((void**)(&((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____param), (void*)L_5);
		BaseLimitUpdator_set_active_m7879D0C8CB8E0C90D01F8DD7CFCDD49B4AD2544D_inline(__this, (bool)1, NULL);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_6 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_7 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____updateProxyHandler;
		NullCheck(L_6);
		EquineScheduler_add_updateEvent_mBBB672CA722F0AF108B571206656EE3E85B80ED0(L_6, L_7, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TimeLimitUpdator_UpdateProxyHandler_m74B207A5F8A854BC9E688D548D41579489051812 (TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		bool L_0;
		L_0 = BaseLimitUpdator_get_active_mF70E508BDFE68081D15C2BB15351A207FA2D5AE1_inline(__this, NULL);
		if (!L_0)
		{
			goto IL_0083;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		float L_1 = (&((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____currentFrameUpdateTimeInfo)->___realtimeSinceStartup;
		double L_2 = __this->____lastTime;
		float L_3 = __this->____interval;
		if ((!(((double)((double)il2cpp_codegen_subtract(((double)L_1), L_2))) >= ((double)((double)L_3)))))
		{
			goto IL_0083;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		float L_4 = (&((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____currentFrameUpdateTimeInfo)->___realtimeSinceStartup;
		__this->____lastTime = ((double)L_4);
		bool L_5 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____once;
		if (!L_5)
		{
			goto IL_0072;
		}
	}
	{
		int32_t L_6 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____disposeTimes;
		V_0 = L_6;
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_7 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____updateHandler;
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_8 = L_7;
		RuntimeObject* L_9 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____param;
		NullCheck(L_8);
		Action_1_Invoke_mF2422B2DD29F74CE66F791C3F68E288EC7C3DB9E_inline(L_8, L_9, NULL);
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_10 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____updateHandler;
		bool L_11;
		L_11 = Delegate_op_Equality_m8B96593B665536587FFD27DE233442C075971C32(L_8, L_10, NULL);
		if (!L_11)
		{
			goto IL_0083;
		}
	}
	{
		int32_t L_12 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____disposeTimes;
		int32_t L_13 = V_0;
		if ((!(((uint32_t)L_12) == ((uint32_t)L_13))))
		{
			goto IL_0083;
		}
	}
	{
		VirtualActionInvoker0::Invoke(5, __this);
		return;
	}

IL_0072:
	{
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_14 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____updateHandler;
		RuntimeObject* L_15 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____param;
		NullCheck(L_14);
		Action_1_Invoke_mF2422B2DD29F74CE66F791C3F68E288EC7C3DB9E_inline(L_14, L_15, NULL);
	}

IL_0083:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TimeLimitUpdator_Dispose_m90C99ADDC03EE3E9053C0EA7BAD69F0C0FF3036B (TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stack_1_Push_m9AC476B9994A6B99BDFEEA6D9083964E6E675247_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		bool L_0 = __this->____inPool;
		if (L_0)
		{
			goto IL_0046;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_1 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		NullCheck(L_1);
		IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7* L_2 = L_1->____updatorMap;
		int32_t L_3;
		L_3 = BaseLimitUpdator_get_id_m3D5E38624A00972BFA083F2375D493AE0A3CE26E_inline(__this, NULL);
		NullCheck(L_2);
		BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* L_4;
		L_4 = VirtualFuncInvoker1< BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*, int32_t >::Invoke(10, L_2, L_3);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_5 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_6 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____updateProxyHandler;
		NullCheck(L_5);
		EquineScheduler_remove_updateEvent_m11222883F7F5BD1EC683A0CF759A86604AABAB95(L_5, L_6, NULL);
		BaseLimitUpdator_Dispose_mCB697B37892E33B5721E0CD13520FF81547CB972(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var);
		Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81* L_7 = ((TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_StaticFields*)il2cpp_codegen_static_fields_for(TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var))->____timeLimitUpdatorStack;
		NullCheck(L_7);
		Stack_1_Push_m9AC476B9994A6B99BDFEEA6D9083964E6E675247(L_7, __this, Stack_1_Push_m9AC476B9994A6B99BDFEEA6D9083964E6E675247_RuntimeMethod_var);
		__this->____inPool = (bool)1;
	}

IL_0046:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void TimeLimitUpdator__cctor_mD70D11EFDFFE19BD66C03D44A0C33EBA5333DBF9 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stack_1__ctor_mF4E396597BA5F70792292CD405F863A411F5EC0E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81* L_0 = (Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81*)il2cpp_codegen_object_new(Stack_1_t1782963B0D92B430AC6B7E833B564D07C528ED81_il2cpp_TypeInfo_var);
		Stack_1__ctor_mF4E396597BA5F70792292CD405F863A411F5EC0E(L_0, Stack_1__ctor_mF4E396597BA5F70792292CD405F863A411F5EC0E_RuntimeMethod_var);
		((TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_StaticFields*)il2cpp_codegen_static_fields_for(TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var))->____timeLimitUpdatorStack = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_StaticFields*)il2cpp_codegen_static_fields_for(TimeLimitUpdator_tDED14630B5700C9089B59DC45219660B98B87286_il2cpp_TypeInfo_var))->____timeLimitUpdatorStack), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FrameLimitUpdator__ctor_mEEC55CAD1CB3D01834DB863BCE8CDE2F665B6D36 (FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* __this, const RuntimeMethod* method) 
{
	{
		BaseLimitUpdator__ctor_m80CDE6F678884981954749212D5A82DB3105D852(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* FrameLimitUpdator_Allocate_m7783EDB49B3EA53A56F09A218B0D31AE7F15DAAA (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stack_1_Pop_m4211BBED271E0EF23575C2E725EC27B70EC67FF4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stack_1_get_Count_m5EA24311FD8233421583A3D592432402CC0752DA_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* V_0 = NULL;
	{
		V_0 = (FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6*)NULL;
		il2cpp_codegen_runtime_class_init_inline(FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var);
		Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82* L_0 = ((FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_StaticFields*)il2cpp_codegen_static_fields_for(FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var))->____frameLimitUpdatorStack;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = Stack_1_get_Count_m5EA24311FD8233421583A3D592432402CC0752DA_inline(L_0, Stack_1_get_Count_m5EA24311FD8233421583A3D592432402CC0752DA_RuntimeMethod_var);
		if ((((int32_t)L_1) <= ((int32_t)0)))
		{
			goto IL_0023;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var);
		Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82* L_2 = ((FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_StaticFields*)il2cpp_codegen_static_fields_for(FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var))->____frameLimitUpdatorStack;
		NullCheck(L_2);
		FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* L_3;
		L_3 = Stack_1_Pop_m4211BBED271E0EF23575C2E725EC27B70EC67FF4(L_2, Stack_1_Pop_m4211BBED271E0EF23575C2E725EC27B70EC67FF4_RuntimeMethod_var);
		V_0 = L_3;
		FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* L_4 = V_0;
		NullCheck(L_4);
		L_4->____inPool = (bool)0;
		goto IL_0029;
	}

IL_0023:
	{
		FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* L_5 = (FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6*)il2cpp_codegen_object_new(FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var);
		FrameLimitUpdator__ctor_mEEC55CAD1CB3D01834DB863BCE8CDE2F665B6D36(L_5, NULL);
		V_0 = L_5;
	}

IL_0029:
	{
		FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* L_6 = V_0;
		return L_6;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FrameLimitUpdator_Start_m4E7618B39D780976865282B501647494837CA9B3 (FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* __this, Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* ___0_updateHandler, int32_t ___1_interval, RuntimeObject* ___2_param, bool ___3_once, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_0 = ___0_updateHandler;
		RuntimeObject* L_1 = ___2_param;
		bool L_2 = ___3_once;
		BaseLimitUpdator_ResetVal_m3379690CAAF1297AE3A6290D522C2E6F8DDA90AC(__this, L_0, L_1, L_2, NULL);
		int32_t L_3 = ___1_interval;
		__this->____interval = L_3;
		int32_t L_4;
		L_4 = Time_get_frameCount_m4A42E558A71301A216BDC49EC402D62F19C79667(NULL);
		__this->____lastFrame = L_4;
		BaseLimitUpdator_set_active_m7879D0C8CB8E0C90D01F8DD7CFCDD49B4AD2544D_inline(__this, (bool)1, NULL);
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_5 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_6 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____updateProxyHandler;
		NullCheck(L_5);
		EquineScheduler_add_updateEvent_mBBB672CA722F0AF108B571206656EE3E85B80ED0(L_5, L_6, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FrameLimitUpdator_UpdateProxyHandler_m8A8B221638058684A501C66D9175733116FBB2A1 (FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		bool L_0;
		L_0 = BaseLimitUpdator_get_active_mF70E508BDFE68081D15C2BB15351A207FA2D5AE1_inline(__this, NULL);
		if (!L_0)
		{
			goto IL_0076;
		}
	}
	{
		int32_t L_1;
		L_1 = Time_get_frameCount_m4A42E558A71301A216BDC49EC402D62F19C79667(NULL);
		int32_t L_2 = __this->____lastFrame;
		int32_t L_3 = __this->____interval;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract(L_1, L_2))) < ((int32_t)L_3)))
		{
			goto IL_0076;
		}
	}
	{
		int32_t L_4;
		L_4 = Time_get_frameCount_m4A42E558A71301A216BDC49EC402D62F19C79667(NULL);
		__this->____lastFrame = L_4;
		bool L_5 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____once;
		if (!L_5)
		{
			goto IL_0065;
		}
	}
	{
		int32_t L_6 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____disposeTimes;
		V_0 = L_6;
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_7 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____updateHandler;
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_8 = L_7;
		RuntimeObject* L_9 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____param;
		NullCheck(L_8);
		Action_1_Invoke_mF2422B2DD29F74CE66F791C3F68E288EC7C3DB9E_inline(L_8, L_9, NULL);
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_10 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____updateHandler;
		bool L_11;
		L_11 = Delegate_op_Equality_m8B96593B665536587FFD27DE233442C075971C32(L_8, L_10, NULL);
		if (!L_11)
		{
			goto IL_0076;
		}
	}
	{
		int32_t L_12 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____disposeTimes;
		int32_t L_13 = V_0;
		if ((!(((uint32_t)L_12) == ((uint32_t)L_13))))
		{
			goto IL_0076;
		}
	}
	{
		VirtualActionInvoker0::Invoke(5, __this);
		return;
	}

IL_0065:
	{
		Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* L_14 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____updateHandler;
		RuntimeObject* L_15 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____param;
		NullCheck(L_14);
		Action_1_Invoke_mF2422B2DD29F74CE66F791C3F68E288EC7C3DB9E_inline(L_14, L_15, NULL);
	}

IL_0076:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FrameLimitUpdator_Dispose_mB45C869E9B7E138C777DDD7CF30DFC48C72C17FA (FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stack_1_Push_m74B0B4001B47D54122FAD47F9A15CAE6999BE999_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		bool L_0 = __this->____inPool;
		if (L_0)
		{
			goto IL_0046;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_1 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		NullCheck(L_1);
		IntHashtable_1_tB7F4B7865A27CBF94D4258DCDACF973D07FA27F7* L_2 = L_1->____updatorMap;
		int32_t L_3;
		L_3 = BaseLimitUpdator_get_id_m3D5E38624A00972BFA083F2375D493AE0A3CE26E_inline(__this, NULL);
		NullCheck(L_2);
		BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* L_4;
		L_4 = VirtualFuncInvoker1< BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*, int32_t >::Invoke(10, L_2, L_3);
		EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF* L_5 = ((EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_StaticFields*)il2cpp_codegen_static_fields_for(EquineScheduler_t587A79306ADBAA5882E1A52CB6AB5A1EBA4FF0CF_il2cpp_TypeInfo_var))->____instance;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_6 = ((BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA*)__this)->____updateProxyHandler;
		NullCheck(L_5);
		EquineScheduler_remove_updateEvent_m11222883F7F5BD1EC683A0CF759A86604AABAB95(L_5, L_6, NULL);
		BaseLimitUpdator_Dispose_mCB697B37892E33B5721E0CD13520FF81547CB972(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var);
		Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82* L_7 = ((FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_StaticFields*)il2cpp_codegen_static_fields_for(FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var))->____frameLimitUpdatorStack;
		NullCheck(L_7);
		Stack_1_Push_m74B0B4001B47D54122FAD47F9A15CAE6999BE999(L_7, __this, Stack_1_Push_m74B0B4001B47D54122FAD47F9A15CAE6999BE999_RuntimeMethod_var);
		__this->____inPool = (bool)1;
	}

IL_0046:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FrameLimitUpdator__cctor_m1268909163B985D1AE5AEBD295578C8A62A6AEB7 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stack_1__ctor_m1CD70C0A52FF57609719F8D154189A2D46D761E9_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82* L_0 = (Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82*)il2cpp_codegen_object_new(Stack_1_tE20ED8976245D6D4F168780EB61F4DE9961A2C82_il2cpp_TypeInfo_var);
		Stack_1__ctor_m1CD70C0A52FF57609719F8D154189A2D46D761E9(L_0, Stack_1__ctor_m1CD70C0A52FF57609719F8D154189A2D46D761E9_RuntimeMethod_var);
		((FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_StaticFields*)il2cpp_codegen_static_fields_for(FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var))->____frameLimitUpdatorStack = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_StaticFields*)il2cpp_codegen_static_fields_for(FrameLimitUpdator_t6A6A59183314EF91649ECFF225BC9E0AF46F86C6_il2cpp_TypeInfo_var))->____frameLimitUpdatorStack), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t SROptions_get_LevelId_mABDC5D192F16C09282ADF4A06036DD1CDBFDF076_inline (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CLevelIdU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t SROptions_get_GoldNumber_m2F2D8C12482B6A284F19F1D8D49A16962F413EE0_inline (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CGoldNumberU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t SROptions_get_RemainTime_mF071B277830D566567DA56B760460E7B2583C5D8_inline (SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CRemainTimeU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* SROptions_get_Current_m297117B6D80C587A2A12BC79EFD5ADE46D591C4B_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F* L_0 = ((SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F_StaticFields*)il2cpp_codegen_static_fields_for(SROptions_t00DA5107C80F05EB2730577E1FCA535FAD5F4A6F_il2cpp_TypeInfo_var))->____current;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void SROptionsPropertyChanged_Invoke_mBED662C3470F04FCEA839FE5D39A86BF62C22CFF_inline (SROptionsPropertyChanged_t53B79AE547753261AFBD1916519E6A1074669CA7* __this, RuntimeObject* ___0_sender, String_t* ___1_propertyName, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, String_t*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_sender, ___1_propertyName, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PropertyChangedEventHandler_Invoke_m040B3056C279FDDC4EC678519D5D415771905298_inline (PropertyChangedEventHandler_tF1250C146BE6FB43477D29C5D18A10B6329419DA* __this, RuntimeObject* ___0_sender, PropertyChangedEventArgs_tFA01343D8F2BD799951B40A3EBF4A6B38EE63321* ___1_e, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, PropertyChangedEventArgs_tFA01343D8F2BD799951B40A3EBF4A6B38EE63321*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_sender, ___1_e, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void BaseLimitUpdator_set_id_mB1C069E5930897FC57398002DB6DD1051D7AF8C5_inline (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_value;
		__this->___U3CidU3Ek__BackingField = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void BaseLimitUpdator_set_active_m7879D0C8CB8E0C90D01F8DD7CFCDD49B4AD2544D_inline (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, bool ___0_value, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___0_value;
		__this->___U3CactiveU3Ek__BackingField = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR UpdateTimeInfo_tCC8E1C8131E776D226406C9D1F4FFE8E99577B22 UniqueMonoEventListener_get_currentUpdateTimeInfo_m76901A493509552678DD377961BA7AEAE38DAFCB_inline (UniqueMonoEventListener_t608C75BB5859C7C58DBD298123D78BAF8D15FD22* __this, const RuntimeMethod* method) 
{
	{
		UpdateTimeInfo_tCC8E1C8131E776D226406C9D1F4FFE8E99577B22 L_0 = __this->___U3CcurrentUpdateTimeInfoU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* __this, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool BaseLimitUpdator_get_active_mF70E508BDFE68081D15C2BB15351A207FA2D5AE1_inline (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CactiveU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t BaseLimitUpdator_get_id_m3D5E38624A00972BFA083F2375D493AE0A3CE26E_inline (BaseLimitUpdator_tF41263616F50872869B431FA3523827DFFF16CEA* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CidU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void List_1_Add_mEBCF994CC3814631017F46A387B1A192ED6C85C7_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, RuntimeObject* ___0_item, const RuntimeMethod* method) 
{
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* V_0 = NULL;
	int32_t V_1 = 0;
	{
		int32_t L_0 = __this->____version;
		__this->____version = ((int32_t)il2cpp_codegen_add(L_0, 1));
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_1 = __this->____items;
		V_0 = L_1;
		int32_t L_2 = __this->____size;
		V_1 = L_2;
		int32_t L_3 = V_1;
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_4 = V_0;
		NullCheck(L_4);
		if ((!(((uint32_t)L_3) < ((uint32_t)((int32_t)(((RuntimeArray*)L_4)->max_length))))))
		{
			goto IL_0034;
		}
	}
	{
		int32_t L_5 = V_1;
		__this->____size = ((int32_t)il2cpp_codegen_add(L_5, 1));
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_6 = V_0;
		int32_t L_7 = V_1;
		RuntimeObject* L_8 = ___0_item;
		NullCheck(L_6);
		(L_6)->SetAt(static_cast<il2cpp_array_size_t>(L_7), (RuntimeObject*)L_8);
		return;
	}

IL_0034:
	{
		RuntimeObject* L_9 = ___0_item;
		List_1_AddWithResize_m79A9BF770BEF9C06BE40D5401E55E375F2726CC4(__this, L_9, il2cpp_rgctx_method(method->klass->rgctx_data, 14));
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void List_1_Clear_m16C1F2C61FED5955F10EB36BC1CB2DF34B128994_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = __this->____version;
		__this->____version = ((int32_t)il2cpp_codegen_add(L_0, 1));
	}
	{
		int32_t L_1 = __this->____size;
		V_0 = L_1;
		__this->____size = 0;
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) <= ((int32_t)0)))
		{
			goto IL_003c;
		}
	}
	{
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_3 = __this->____items;
		int32_t L_4 = V_0;
		Array_Clear_m50BAA3751899858B097D3FF2ED31F284703FE5CB((RuntimeArray*)L_3, 0, L_4, NULL);
		return;
	}

IL_003c:
	{
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_m4407E4C389F22B8CEC282C15D56516658746C383_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->____size;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Stack_1_get_Count_mD08AE71D49787D30DDD9D484BCD323D646744D2E_gshared_inline (Stack_1_tAD790A47551563636908E21E4F08C54C0C323EB5* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->____size;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_1_Invoke_mF2422B2DD29F74CE66F791C3F68E288EC7C3DB9E_gshared_inline (Action_1_t6F9EB113EB3F16226AEF811A2744F4111C116C87* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_obj, reinterpret_cast<RuntimeMethod*>(__this->___method));
}

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
template <typename T1, typename T2, typename T3>
struct VirtualActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
template <typename R>
struct VirtualFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
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
template <typename R, typename T1, typename T2, typename T3>
struct VirtualFuncInvoker3
{
	typedef R (*Func)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
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
template <typename R, typename T1, typename T2, typename T3, typename T4, typename T5, typename T6>
struct InterfaceFuncInvoker6
{
	typedef R (*Func)(void*, T1, T2, T3, T4, T5, T6, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, invokeData.method);
	}
};
template <typename R, typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7>
struct InterfaceFuncInvoker7
{
	typedef R (*Func)(void*, T1, T2, T3, T4, T5, T6, T7, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, invokeData.method);
	}
};

struct Dictionary_2_t87EDE08B2E48F793A22DE50D6B3CC2E7EBB2DB54;
struct Func_1_tAD57E0E3EDDE20EC12439DA534F1722A9D24EF5D;
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
struct UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83;
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263;
struct ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129;
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C;
struct CodePageDataItem_t52460FA30AE37F4F26ACB81055E58002262F19F2;
struct DecoderFallback_t7324102215E4ED41EC065C02EB501CB0BC23CD90;
struct Delegate_t;
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
struct EncoderFallback_tD2C40CE114AA9D8E1F7196608B2D088548015293;
struct Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095;
struct EndOfStreamException_t6B6A2609418A69523CBEF305228B18E0E5778028;
struct IAsyncResult_t7B9B5A0ECB35DCEC31B8A8122C37D687369253B5;
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
struct ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50;
struct InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB;
struct LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF;
struct MethodInfo_t;
struct NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A;
struct Safe32LZ4Service_t6C465065F50F51FE51B7CC5377CC242FFD50D5A5;
struct Safe64LZ4Service_tB68E69D87E25EA3EFF8D49FB05A091BB50A80F0B;
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
struct SemaphoreSlim_t0D5CB5685D9BFA5BF95CEC6E7395490F933E8DB2;
struct Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE;
struct String_t;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
struct Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97;
struct LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A;
struct ReadWriteTask_t0821BF49EE38596C7734E86E1A6A39D769BE2C05;

IL2CPP_EXTERN_C RuntimeClass* Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* CompressionMode_t840C8957CF84ACFBF5C43E48AEAEB9DB5E64F3C5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* EndOfStreamException_t6B6A2609418A69523CBEF305228B18E0E5778028_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Func_1_tAD57E0E3EDDE20EC12439DA534F1722A9D24EF5D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* RuntimeObject_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeField* U3CPrivateImplementationDetailsU3EU7BF0F453ADU2D4DD4U2D4EFBU2D816CU2D6D223090545FU7D_t93196623BC479309CE2F3090E7B954A494E7AF33____U24U24method0x600007fU2D1_FieldInfo_var;
IL2CPP_EXTERN_C RuntimeField* U3CPrivateImplementationDetailsU3EU7BF0F453ADU2D4DD4U2D4EFBU2D816CU2D6D223090545FU7D_t93196623BC479309CE2F3090E7B954A494E7AF33____U24U24method0x600007fU2D2_FieldInfo_var;
IL2CPP_EXTERN_C RuntimeField* U3CPrivateImplementationDetailsU3EU7BF0F453ADU2D4DD4U2D4EFBU2D816CU2D6D223090545FU7D_t93196623BC479309CE2F3090E7B954A494E7AF33____U24U24method0x600007fU2D3_FieldInfo_var;
IL2CPP_EXTERN_C RuntimeField* U3CPrivateImplementationDetailsU3EU7BF0F453ADU2D4DD4U2D4EFBU2D816CU2D6D223090545FU7D_t93196623BC479309CE2F3090E7B954A494E7AF33____U24U24method0x600007fU2D4_FieldInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral0126FEA21D5814A5884E5E87A041F0816F5BAFA6;
IL2CPP_EXTERN_C String_t* _stringLiteral15088A7C50E83E49058833A4287B3C2F1CD730D2;
IL2CPP_EXTERN_C String_t* _stringLiteral22562BDC01CC82A45F171035D855E64E7772E317;
IL2CPP_EXTERN_C String_t* _stringLiteral4ABCE38F42187F9B00C8BCC57A24823C3F0AF438;
IL2CPP_EXTERN_C String_t* _stringLiteral4B9666A386862724B514C7436163D61E1497067A;
IL2CPP_EXTERN_C String_t* _stringLiteral5F400FF009A7EE014B6122DA67077EC44B887858;
IL2CPP_EXTERN_C String_t* _stringLiteral687B0943A9A3524003E9BA508C255E8D60725E9D;
IL2CPP_EXTERN_C String_t* _stringLiteral71443AC7CF5CC108984A138188DE915E32441BB2;
IL2CPP_EXTERN_C String_t* _stringLiteral75C670EA0F7AE5A776E170D1A225F267CA674091;
IL2CPP_EXTERN_C String_t* _stringLiteral93CA867C317E4F858EA7A54249C457EF7083A591;
IL2CPP_EXTERN_C String_t* _stringLiteral9AA547017F907F3267372CFA8352F5C48C4942F7;
IL2CPP_EXTERN_C String_t* _stringLiteralA620EDDDF34131E84DF5BB1E5EF8EE3294176550;
IL2CPP_EXTERN_C String_t* _stringLiteralA6B02B723395681F874F9897DEDC56A228BC2667;
IL2CPP_EXTERN_C String_t* _stringLiteralAFF7EC42D2B43A4238039905BC7A17628F5DE772;
IL2CPP_EXTERN_C String_t* _stringLiteralB0DC6E48DD877538156865D4EC4FE974175E5766;
IL2CPP_EXTERN_C String_t* _stringLiteralB7CA6B7A7F82DA89BFD1F6A227BE9102B12D67B3;
IL2CPP_EXTERN_C String_t* _stringLiteralB9B1E2FE6B9DEAA858C78D6320932A5865FF2D1E;
IL2CPP_EXTERN_C String_t* _stringLiteralC013226DF137B7010B5FE9B6BEB26EF8127E5B47;
IL2CPP_EXTERN_C String_t* _stringLiteralD2022A52A84F41328946F27774BA456C970BB16D;
IL2CPP_EXTERN_C String_t* _stringLiteralD35359F121CDCC5B189869B755512639BD3AA30E;
IL2CPP_EXTERN_C String_t* _stringLiteralDA771D37A1B200C0992D03FBC0D2312E434F44C8;
IL2CPP_EXTERN_C String_t* _stringLiteralEA11839FFA673044FF4EB9A4F59B3BC47F4144AE;
IL2CPP_EXTERN_C String_t* _stringLiteralF485E45E4151BA2CB0606C4893544827F6ED5D84;
IL2CPP_EXTERN_C String_t* _stringLiteralF9204BE5A412814B29E1EAA785E472800DE24BDF;
IL2CPP_EXTERN_C String_t* _stringLiteralF94AA613862F53AAD0F034DAF760AFDD9509B693;
IL2CPP_EXTERN_C String_t* _stringLiteralFAD353B75E80AD61913B4FBBC2ADCBD997209B05;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Assert_mE21E5B79F26A7CB5E53524E035130DE04498CA44_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_CheckArguments_mA1457668496B6000785246D759B22DE47C86017C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Decode32_m832B8B1A560DE796C82D736499F29100139AD330_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Decode32_mD775EF89F609454DA26E01E021868A6BA0C43214_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Decode64_m3C186439F19EFC1FDC0CF27BCB8518808BF7A401_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Decode64_mEEC2538613C3020B944EFCBD6897709B1F2F2F55_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Decode_m775B077FBCADC4FDFFE1FF5ED79B76897449517C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Encode32HC_m80BBE7D1B1CE9DD3EFF618DA93FA2AE69467343C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Encode32_m8CBC9C95E306C14C16D7AE8224FB1640CAB6CA8F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Encode64HC_m5A87CA8E7088911ADE4AA601748361AA29981B99_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Encode64_m791C00422ABEE5CC1154CF5B163F865A21EE618E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_EncodeHC_mC95383E6688E960B92088BF0B02885BC02E753A7_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Encode_m4AA8DA0B60EA929B5CBD5C2F044523CBDE939855_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Has2010Runtime_m12032B2FFCBBBA3FEF01C4EE988B1A4A1C0BE3F0_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_InitializeLZ4cc_m31E3406932DFA777DF898179A9EC8A39C86A09E3_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_InitializeLZ4mm_m14C1305C69ACB9B663D07A8CFE4FEED4204F6130_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_InitializeLZ4n_m53DC33F1EDDC538B845072A0321E9CDEF5A6D14A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_InitializeLZ4s_m4EC9AFFF8DD01160779275C1643D29A882CD5E00_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_LZ4HC_CommonLength_64_mAE63F3344241A76E2830869103C2C44987101F3B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_LZ4HC_InsertAndGetWiderMatch_64_m65A1CF1BBFC339D3CCB377BA92B4CE21D1B131D0_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_LZ4_compress64kCtx_safe64_m0B1F935369022A7FF506A9C3AF21AE4331F7ECF3_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_LZ4_compressCtx_safe64_mCBD100E3B1B719762E9AF276BFB48D6C47684828_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_TryService_TisSafe32LZ4Service_t6C465065F50F51FE51B7CC5377CC242FFD50D5A5_m289E6121B7096157393CEBA6037EC24C71BE4882_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_TryService_TisSafe64LZ4Service_tB68E69D87E25EA3EFF8D49FB05A091BB50A80F0B_m89CAA0025A8BA51962C72DEC45A6A248F3E23F7B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Try_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m6E86D4ECD4E84B32E2566725E326A05A2E4E1E74_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Unwrap_m18EAB28CE68D7548D67DE8DF353468B7AF271C94_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec_Wrap_m98B72AEB25379FC783BFD660A218720C91D3E73B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Codec__cctor_m39C467FDA4B7A84F38C8A5A1562B3B5E54561DE2_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Stream_AcquireNextChunk_mB2AFE8A394C7E4C943D768E5A6789F1D62D45F59_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Stream_ReadByte_mEA9A1AF52429EFADA3821606420CE353346C027E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Stream_ReadVarInt_m20F01F26A0EA4C2E3B07C4DF304A6F48E09B99BE_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Stream_Read_m7CE9AC5BD4F978BC58FE6E1709BA8898E9C6AADC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Stream_Seek_m63BC2D4E046E34C55FD0846BE2BF311712DDEE19_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Stream_SetLength_m9AB6A8945A36652E275F31563F38A465A664C0E1_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Stream_ToLZ4StreamMode_m0D51E395EC217ABE5CA45352CAEA99D49934B48F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Stream_TryReadVarInt_m98E1AC815BFD87BCB413B26908D77119B3678F05_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Stream_WriteByte_m34097C9CA98157F0BD83727FA39B1D084A9DB776_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Stream_Write_mE9D030B08A7B40BE1F50C5943E347BF28E175511_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* LZ4Stream_set_Position_mA42750CADBED4B284E7D0D4D72FE8F46D5A1FED8_RuntimeMethod_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
struct UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct U3CModuleU3E_t20D8C53C4A6551CC3247C5303606B53E3A23360D 
{
};
struct U3CPrivateImplementationDetailsU3EU7BF0F453ADU2D4DD4U2D4EFBU2D816CU2D6D223090545FU7D_t93196623BC479309CE2F3090E7B954A494E7AF33  : public RuntimeObject
{
};
struct Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095  : public RuntimeObject
{
	int32_t ___m_codePage;
	CodePageDataItem_t52460FA30AE37F4F26ACB81055E58002262F19F2* ___dataItem;
	bool ___m_deserializedFromEverett;
	bool ___m_isReadOnly;
	EncoderFallback_tD2C40CE114AA9D8E1F7196608B2D088548015293* ___encoderFallback;
	DecoderFallback_t7324102215E4ED41EC065C02EB501CB0BC23CD90* ___decoderFallback;
};
struct LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1  : public RuntimeObject
{
};
struct LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A  : public RuntimeObject
{
};
struct MarshalByRefObject_t8C2F4C5854177FD60439EB1FCCFC1B3CFAFE8DCE  : public RuntimeObject
{
	RuntimeObject* ____identity;
};
struct MarshalByRefObject_t8C2F4C5854177FD60439EB1FCCFC1B3CFAFE8DCE_marshaled_pinvoke
{
	Il2CppIUnknown* ____identity;
};
struct MarshalByRefObject_t8C2F4C5854177FD60439EB1FCCFC1B3CFAFE8DCE_marshaled_com
{
	Il2CppIUnknown* ____identity;
};
struct Safe32LZ4Service_t6C465065F50F51FE51B7CC5377CC242FFD50D5A5  : public RuntimeObject
{
};
struct Safe64LZ4Service_tB68E69D87E25EA3EFF8D49FB05A091BB50A80F0B  : public RuntimeObject
{
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
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
struct LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A  : public RuntimeObject
{
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___src;
	int32_t ___src_base;
	int32_t ___src_end;
	int32_t ___src_LASTLITERALS;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___dst;
	int32_t ___dst_base;
	int32_t ___dst_len;
	int32_t ___dst_end;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___hashTable;
	UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* ___chainTable;
	int32_t ___nextToUpdate;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value;
};
struct Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3 
{
	uint8_t ___m_value;
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2  : public ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_pinvoke
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_com
{
};
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	int32_t ___m_value;
};
struct Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3 
{
	int64_t ___m_value;
};
struct IntPtr_t 
{
	void* ___m_value;
};
struct Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE  : public MarshalByRefObject_t8C2F4C5854177FD60439EB1FCCFC1B3CFAFE8DCE
{
	ReadWriteTask_t0821BF49EE38596C7734E86E1A6A39D769BE2C05* ____activeReadWriteTask;
	SemaphoreSlim_t0D5CB5685D9BFA5BF95CEC6E7395490F933E8DB2* ____asyncActiveSemaphore;
};
struct UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455 
{
	uint16_t ___m_value;
};
struct UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B 
{
	uint32_t ___m_value;
};
struct UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF 
{
	uint64_t ___m_value;
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
struct __StaticArrayInitTypeSizeU3D128_t30B3B412C9A1CF85B635B3081396D5CE0EE8BBB9 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D128_t30B3B412C9A1CF85B635B3081396D5CE0EE8BBB9__padding[128];
	};
};
#pragma pack(pop, tp)
#pragma pack(push, tp, 1)
struct __StaticArrayInitTypeSizeU3D256_t010E7A161455C5085B09E5C66E3B131E130B40E1 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D256_t010E7A161455C5085B09E5C66E3B131E130B40E1__padding[256];
	};
};
#pragma pack(pop, tp)
#pragma pack(push, tp, 1)
struct __StaticArrayInitTypeSizeU3D32_t4A0FDCBA84230227B244E4A79188657485263EBE 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D32_t4A0FDCBA84230227B244E4A79188657485263EBE__padding[32];
	};
};
#pragma pack(pop, tp)
struct CompressionMode_t840C8957CF84ACFBF5C43E48AEAEB9DB5E64F3C5 
{
	int32_t ___value__;
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
struct LZ4StreamFlags_t4DA79858E140A224B43FEBBBA7C48F24DCC6143C 
{
	int32_t ___value__;
};
struct LZ4StreamMode_tD8B987757FEAAED5E842F0C9808A3E2766F04091 
{
	int32_t ___value__;
};
struct RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 
{
	intptr_t ___value;
};
struct SeekOrigin_t7EB9AD0EDF26368A40F48FA2098F02160B1E8000 
{
	int32_t ___value__;
};
struct ChunkFlags_t21701C9BECA5B2FCE44FD5B9CB26655145F512A6 
{
	int32_t ___value__;
};
struct LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF  : public Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE
{
	Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* ____innerStream;
	int32_t ____compressionMode;
	bool ____highCompression;
	bool ____interactiveRead;
	bool ____isolateInnerStream;
	int32_t ____blockSize;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ____buffer;
	int32_t ____bufferLength;
	int32_t ____bufferOffset;
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
struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};
struct Func_1_tAD57E0E3EDDE20EC12439DA534F1722A9D24EF5D  : public MulticastDelegate_t
{
};
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
	String_t* ____paramName;
};
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C  : public MulticastDelegate_t
{
};
struct IOException_t5D599190B003D41D45D4839A9B6B9AB53A755910  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};
struct InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};
struct NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};
struct Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97  : public MulticastDelegate_t
{
};
struct ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129  : public ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263
{
};
struct EndOfStreamException_t6B6A2609418A69523CBEF305228B18E0E5778028  : public IOException_t5D599190B003D41D45D4839A9B6B9AB53A755910
{
};
struct U3CPrivateImplementationDetailsU3EU7BF0F453ADU2D4DD4U2D4EFBU2D816CU2D6D223090545FU7D_t93196623BC479309CE2F3090E7B954A494E7AF33_StaticFields
{
	__StaticArrayInitTypeSizeU3D32_t4A0FDCBA84230227B244E4A79188657485263EBE ___U24U24method0x600007fU2D1;
	__StaticArrayInitTypeSizeU3D32_t4A0FDCBA84230227B244E4A79188657485263EBE ___U24U24method0x600007fU2D2;
	__StaticArrayInitTypeSizeU3D128_t30B3B412C9A1CF85B635B3081396D5CE0EE8BBB9 ___U24U24method0x600007fU2D3;
	__StaticArrayInitTypeSizeU3D256_t010E7A161455C5085B09E5C66E3B131E130B40E1 ___U24U24method0x600007fU2D4;
};
struct Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095_StaticFields
{
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___defaultEncoding;
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___unicodeEncoding;
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___bigEndianUnicode;
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___utf7Encoding;
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___utf8Encoding;
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___utf32Encoding;
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___asciiEncoding;
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___latin1Encoding;
	Dictionary_2_t87EDE08B2E48F793A22DE50D6B3CC2E7EBB2DB54* ___encodings;
	RuntimeObject* ___s_InternalSyncObject;
};
struct LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields
{
	RuntimeObject* ___Encoder;
	RuntimeObject* ___EncoderHC;
	RuntimeObject* ___Decoder;
	RuntimeObject* ____service_MM32;
	RuntimeObject* ____service_MM64;
	RuntimeObject* ____service_CC32;
	RuntimeObject* ____service_CC64;
	RuntimeObject* ____service_N32;
	RuntimeObject* ____service_N64;
	RuntimeObject* ____service_S32;
	RuntimeObject* ____service_S64;
};
struct LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields
{
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___DECODER_TABLE_32;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___DECODER_TABLE_64;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___DEBRUIJN_TABLE_32;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___DEBRUIJN_TABLE_64;
};
struct String_t_StaticFields
{
	String_t* ___Empty;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString;
	String_t* ___FalseString;
};
struct IntPtr_t_StaticFields
{
	intptr_t ___Zero;
};
struct Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE_StaticFields
{
	Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* ___Null;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
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
struct UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83  : public RuntimeArray
{
	ALIGN_FIELD (8) uint16_t m_Items[1];

	inline uint16_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint16_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint16_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint16_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint16_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint16_t value)
	{
		m_Items[index] = value;
	}
};
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C  : public RuntimeArray
{
	ALIGN_FIELD (8) int32_t m_Items[1];

	inline int32_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline int32_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, int32_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline int32_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline int32_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, int32_t value)
	{
		m_Items[index] = value;
	}
};
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


IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Func_1__ctor_m56E1CF05BB8790B37A7CA230D46C9F900021FE72_gshared (Func_1_tAD57E0E3EDDE20EC12439DA534F1722A9D24EF5D* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_NO_INLINE IL2CPP_METHOD_ATTR bool LZ4Codec_Try_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m6E86D4ECD4E84B32E2566725E326A05A2E4E1E74_gshared (Func_1_tAD57E0E3EDDE20EC12439DA534F1722A9D24EF5D* ___0_method, bool ___1_defaultValue, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_NO_INLINE IL2CPP_METHOD_ATTR RuntimeObject* LZ4Codec_TryService_TisRuntimeObject_mC40DB877AC094F513AA6B78091526C4C0C85F762_gshared (const RuntimeMethod* method) ;

IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* __this, String_t* ___0_paramName, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465 (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* __this, String_t* ___0_message, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358 (RuntimeArray* ___0_src, int32_t ___1_srcOffset, RuntimeArray* ___2_dst, int32_t ___3_dstOffset, int32_t ___4_count, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_CheckArguments_mA1457668496B6000785246D759B22DE47C86017C (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t* ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t* ___5_outputLength, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compress64kCtx_safe32_m673F7EC888DEAA590569AE1F7CAEACA2575B1573 (UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* ___0_hash_table, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___2_dst, int32_t ___3_src_0, int32_t ___4_dst_0, int32_t ___5_src_len, int32_t ___6_dst_maxlen, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compressCtx_safe32_m38260443EFAEA8FB3E74B4E443B1CCC15A14C0F3 (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___0_hash_table, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___2_dst, int32_t ___3_src_0, int32_t ___4_dst_0, int32_t ___5_src_len, int32_t ___6_dst_maxlen, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_MaximumOutputLength_m619DE1622B852103C3F70E3008B4BCC623C1E6DD (int32_t ___0_inputLength, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Encode32_m0853FFD223239CC99ADEF3BCD85413F90B9D166A (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162 (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* __this, String_t* ___0_message, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compress64kCtx_safe64_m0B1F935369022A7FF506A9C3AF21AE4331F7ECF3 (UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* ___0_hash_table, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___2_dst, int32_t ___3_src_0, int32_t ___4_dst_0, int32_t ___5_src_len, int32_t ___6_dst_maxlen, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compressCtx_safe64_mCBD100E3B1B719762E9AF276BFB48D6C47684828 (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___0_hash_table, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___2_dst, int32_t ___3_src_0, int32_t ___4_dst_0, int32_t ___5_src_len, int32_t ___6_dst_maxlen, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Encode64_m0834480EE01F94270BEFA9C101DDD498AB46402A (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_uncompress_safe32_m3FC0A591BB2EA8741B716213BE1364901C653D98 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_dst, int32_t ___2_src_0, int32_t ___3_dst_0, int32_t ___4_dst_len, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_uncompress_unknownOutputSize_safe32_m70BEAA0964145EC18E8EFE6DC6D9A6B0D745A456 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_dst, int32_t ___2_src_0, int32_t ___3_dst_0, int32_t ___4_src_len, int32_t ___5_dst_maxlen, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Decode32_mD775EF89F609454DA26E01E021868A6BA0C43214 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, bool ___6_knownOutputLength, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_uncompress_safe64_mF952DEBD155A8549AAAD0A8D265F7799C70E6B14 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_dst, int32_t ___2_src_0, int32_t ___3_dst_0, int32_t ___4_dst_len, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_uncompress_unknownOutputSize_safe64_mA60DF40EE0906DD2443C4E2018117F515A3BCD25 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_dst, int32_t ___2_src_0, int32_t ___3_dst_0, int32_t ___4_src_len, int32_t ___5_dst_maxlen, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Decode64_m3C186439F19EFC1FDC0CF27BCB8518808BF7A401 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, bool ___6_knownOutputLength, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4HC_Data_Structure__ctor_m5E8B7F4BD2B0BA48BCD08EFD2063130779B84D18 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* LZ4Codec_LZ4HC_Create_mF6B1BA8490BA3DA19388B710CC15A1033D9A13D2 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_src, int32_t ___1_src_0, int32_t ___2_src_len, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_dst, int32_t ___4_dst_0, int32_t ___5_dst_len, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compressHCCtx_32_m080C9306A42AEF78E3E577950B54A4881DF59BE6 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compressHC_32_m4D9EC4B23F40E86BE3B8D036ACC1BA7AF7622BE9 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Encode32HC_mE7B695E89746BC0A8AEB434AA894BA084A0A815F (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compressHCCtx_64_m0037ABA747959A480DCBB84290F6337E11C01CBD (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compressHC_64_mAF06F27F55DA1BD7655B088A4C211F8730FC461A (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Encode64HC_mBDD028D90BB74FB1CCE146FAB90A39116BBB4C05 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset1, int32_t ___2_offset2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_src, int32_t ___1_src_0, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___2_dst, int32_t ___3_dst_0, int32_t ___4_len, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_WildCopy_mE6E7FF3DC7D46D37614FDE84DDDEA5D03B0B5F94 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_src, int32_t ___1_src_0, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___2_dst, int32_t ___3_dst_0, int32_t ___4_dst_end, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_Poke2_mA9D6096893521372F0C65B006AE5A25C59E869E1 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset, uint16_t ___2_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t LZ4Codec_Xor4_mECF76BD60591364408CC4E94D6F913291AC4B8CB (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset1, int32_t ___2_offset2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LZ4Codec_Equal2_m05C0F8A90FA336B8EFA50F98F2485EAF9A00FEF6 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset1, int32_t ___2_offset2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint16_t LZ4Codec_Peek2_mE549DAC6B7C81F35C5B34C25AD3A6EDA5F44C008 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_Copy4_m184A9377DC0EC985A8AF55E386A3F04D2F8C3F5F (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buf, int32_t ___1_src, int32_t ___2_dst, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_SecureCopy_mD8B329836718DBDA10089588161AC3F72D9C88A4 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_src, int32_t ___2_dst, int32_t ___3_dst_end, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_LZ4HC_Insert_32_m9D23BA633ACDC44213F130DF95DC82BB1AA200A6 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_src_p, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4HC_CommonLength_32_m3D0F5D5E7EAFB40FDACA9CFC53B3B82448E0E1A5 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_p1, int32_t ___2_p2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4HC_InsertAndFindBestMatch_32_mE1611C8BEB496B25C87D4ECC4ABB02F95B76FF70 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_src_p, int32_t* ___2_src_match, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4HC_InsertAndGetWiderMatch_32_mA128B9BA0971EF5D7C371E959A3339D3E2730826 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_src_p, int32_t ___2_startLimit, int32_t ___3_longest, int32_t* ___4_matchpos, int32_t* ___5_startpos, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_encodeSequence_32_m961041D1CC42128E9D32E2F73F9E841AE125E316 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t* ___1_src_p, int32_t* ___2_dst_p, int32_t* ___3_src_anchor, int32_t ___4_matchLength, int32_t ___5_src_ref, int32_t ___6_dst_end, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t LZ4Codec_Xor8_m4A7619EA57DCCFC5B2A17F222C94BE01C57E50BD (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset1, int32_t ___2_offset2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_Copy8_m55B8E8EE46B0571AC2D3710470CE639F02F6EC3D (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buf, int32_t ___1_src, int32_t ___2_dst, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_LZ4HC_Insert_64_m88809B5C1FB9ADDCF2E7FAA7BA30A729D907F415 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_src_p, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4HC_CommonLength_64_mAE63F3344241A76E2830869103C2C44987101F3B (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_p1, int32_t ___2_p2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4HC_InsertAndFindBestMatch_64_mF27AC8EADD1C62F6D705D63F861A60C701A2CB9B (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_src_p, int32_t* ___2_matchpos, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4HC_InsertAndGetWiderMatch_64_m65A1CF1BBFC339D3CCB377BA92B4CE21D1B131D0 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_src_p, int32_t ___2_startLimit, int32_t ___3_longest, int32_t* ___4_matchpos, int32_t* ___5_startpos, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_encodeSequence_64_m19A79EA21D56581CFD3149E776B57A11A52AFD41 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t* ___1_src_p, int32_t* ___2_dst_p, int32_t* ___3_src_anchor, int32_t ___4_matchLength, int32_t ___5_src_ref, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B (RuntimeArray* ___0_array, RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 ___1_fldHandle, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
inline void Func_1__ctor_m56E1CF05BB8790B37A7CA230D46C9F900021FE72 (Func_1_tAD57E0E3EDDE20EC12439DA534F1722A9D24EF5D* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method)
{
	((  void (*) (Func_1_tAD57E0E3EDDE20EC12439DA534F1722A9D24EF5D*, RuntimeObject*, intptr_t, const RuntimeMethod*))Func_1__ctor_m56E1CF05BB8790B37A7CA230D46C9F900021FE72_gshared)(__this, ___0_object, ___1_method, method);
}
inline bool LZ4Codec_Try_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m6E86D4ECD4E84B32E2566725E326A05A2E4E1E74 (Func_1_tAD57E0E3EDDE20EC12439DA534F1722A9D24EF5D* ___0_method, bool ___1_defaultValue, const RuntimeMethod* method)
{
	return ((  bool (*) (Func_1_tAD57E0E3EDDE20EC12439DA534F1722A9D24EF5D*, bool, const RuntimeMethod*))LZ4Codec_Try_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m6E86D4ECD4E84B32E2566725E326A05A2E4E1E74_gshared)(___0_method, ___1_defaultValue, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action__ctor_mA303A98BFE7D11C2D04A004FD6C69D154B3782FB (Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_NO_INLINE IL2CPP_METHOD_ATTR void LZ4Codec_Try_m1E504E6EBEFF72CC9A684B60A28F776ED921DE85 (Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* ___0_method, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_SelectCodec_m4CD78DED1420D05EED0E06FAAEA6B27BBC50888C (RuntimeObject** ___0_encoder, RuntimeObject** ___1_decoder, RuntimeObject** ___2_encoderHC, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* __this, String_t* ___0_message, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t IntPtr_get_Size_m1FAAA59DA73D7E32BB1AB55DD92A90AFE3251DBE (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* Encoding_get_UTF8_m9FA98A53CE96FD6D02982625C5246DD36C1235C9 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_MaximumOutputLength_mDAA64101B4C4E6AFD835EDF5175CF6A8B1972126 (int32_t ___0_inputLength, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_op_Inequality_m8C940F3CFC42866709D7CA931B3D77B4BE94BCB6 (String_t* ___0_a, String_t* ___1_b, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_Invoke_m6693C0B4B386A694967A120B24AC4323B2C48405_inline (Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Format_mA0534D6E2AE4D67A6BD8D45B3321323930EB930C (String_t* ___0_format, RuntimeObject* ___1_arg0, RuntimeObject* ___2_arg1, RuntimeObject* ___3_arg2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Encode_m95700861B517937C3B5CC74DCA9CA8002E2BB12B (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_EncodeHC_m462A61B698E8E2B338A0332DA00FB64EBFC8F82C (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Decode_m9A778AF80843CC473CB2DC1E68F04451742071B9 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, bool ___6_knownOutputLength, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Math_Min_m53C488772A34D53917BCA2A491E79A0A5356ED52 (int32_t ___0_val1, int32_t ___1_val2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_Poke4_m12CBAC9FD91CA8B3B8BDD99AEE3BFF145843F2B6 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset, uint32_t ___2_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* LZ4Codec_Wrap_m98B72AEB25379FC783BFD660A218720C91D3E73B (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_inputBuffer, int32_t ___1_inputOffset, int32_t ___2_inputLength, bool ___3_highCompression, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t LZ4Codec_Peek4_m5F02DCE552F8A75D8DBE3861ACA4FD73438F1D40 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset, const RuntimeMethod* method) ;
inline RuntimeObject* LZ4Codec_TryService_TisSafe32LZ4Service_t6C465065F50F51FE51B7CC5377CC242FFD50D5A5_m289E6121B7096157393CEBA6037EC24C71BE4882 (const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (const RuntimeMethod*))LZ4Codec_TryService_TisRuntimeObject_mC40DB877AC094F513AA6B78091526C4C0C85F762_gshared)(method);
}
inline RuntimeObject* LZ4Codec_TryService_TisSafe64LZ4Service_tB68E69D87E25EA3EFF8D49FB05A091BB50A80F0B_m89CAA0025A8BA51962C72DEC45A6A248F3E23F7B (const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (const RuntimeMethod*))LZ4Codec_TryService_TisRuntimeObject_mC40DB877AC094F513AA6B78091526C4C0C85F762_gshared)(method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Stream__ctor_mE8B074A0EBEB026FFF14062AB4B8A78E17EFFBF0 (Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Math_Max_m530EBA549AFD98CFC2BD29FE86C6376E67DF11CF (int32_t ___0_val1, int32_t ___1_val2, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Format_mA8DBB4C2516B9723C5A41E6CB1E2FAF4BBE96DD8 (String_t* ___0_format, RuntimeObject* ___1_arg0, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EndOfStreamException__ctor_m5629E1A514051A3D56052BD6D2D50C054308CCA4 (EndOfStreamException_t6B6A2609418A69523CBEF305228B18E0E5778028* __this, String_t* ___0_message, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR EndOfStreamException_t6B6A2609418A69523CBEF305228B18E0E5778028* LZ4Stream_EndOfStream_m868620C08A32DFEB1846D11C8F0E4B2B6D2D4A09 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LZ4Stream_TryReadVarInt_m98E1AC815BFD87BCB413B26908D77119B3678F05 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, uint64_t* ___0_result, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream_WriteVarInt_m48CBECCBE2470EF86965274DE22DB43141EFD642 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, uint64_t ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t LZ4Stream_ReadVarInt_m20F01F26A0EA4C2E3B07C4DF304A6F48E09B99BE (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Stream_ReadBlock_m023A6DE7D6164E281F15FAD297038C374C263E76 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset, int32_t ___2_length, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream_FlushCurrentChunk_m228E2273C1A6B40673F48806C59615A57DFF0B98 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* LZ4Stream_NotSupported_m65D89ADBD25DB5B852E14AE1D09E5F72B10BBFE3 (String_t* ___0_operationName, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LZ4Stream_AcquireNextChunk_mB2AFE8A394C7E4C943D768E5A6789F1D62D45F59 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Stream_Dispose_mCDB42F32A17541CCA6D3A5906827A401570B07A8 (Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Stream_Dispose_m9B37BD21A57F8F2BD20EE353DE14405700810C5C (Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* __this, bool ___0_disposing, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Stream_ToLZ4StreamMode_m0D51E395EC217ABE5CA45352CAEA99D49934B48F (int32_t ___0_compressionMode, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Stream_CombineLZ4Flags_m893A68D7D9486557D2753C0D6FEA961786691D83 (bool ___0_highCompression, bool ___1_interactiveRead, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream__ctor_m403377F2E66DCB170D98C5518C606FB11AA5AB10 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* ___0_innerStream, int32_t ___1_compressionMode, int32_t ___2_compressionFlags, int32_t ___3_blockSize, const RuntimeMethod* method) ;
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_MaximumOutputLength_m619DE1622B852103C3F70E3008B4BCC623C1E6DD (int32_t ___0_inputLength, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_inputLength;
		int32_t L_1 = ___0_inputLength;
		return ((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_0, ((int32_t)(L_1/((int32_t)255))))), ((int32_t)16)));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_CheckArguments_mA1457668496B6000785246D759B22DE47C86017C (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t* ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t* ___5_outputLength, const RuntimeMethod* method) 
{
	{
		int32_t* L_0 = ___2_inputLength;
		int32_t L_1 = *((int32_t*)L_0);
		if ((((int32_t)L_1) >= ((int32_t)0)))
		{
			goto IL_000c;
		}
	}
	{
		int32_t* L_2 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___0_input;
		NullCheck(L_3);
		int32_t L_4 = ___1_inputOffset;
		*((int32_t*)L_2) = (int32_t)((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_3)->max_length)), L_4));
	}

IL_000c:
	{
		int32_t* L_5 = ___2_inputLength;
		int32_t L_6 = *((int32_t*)L_5);
		if (L_6)
		{
			goto IL_0015;
		}
	}
	{
		int32_t* L_7 = ___5_outputLength;
		*((int32_t*)L_7) = (int32_t)0;
		return;
	}

IL_0015:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_input;
		if (L_8)
		{
			goto IL_0023;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_9 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_9, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral15088A7C50E83E49058833A4287B3C2F1CD730D2)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_9, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_CheckArguments_mA1457668496B6000785246D759B22DE47C86017C_RuntimeMethod_var)));
	}

IL_0023:
	{
		int32_t L_10 = ___1_inputOffset;
		if ((((int32_t)L_10) < ((int32_t)0)))
		{
			goto IL_0030;
		}
	}
	{
		int32_t L_11 = ___1_inputOffset;
		int32_t* L_12 = ___2_inputLength;
		int32_t L_13 = *((int32_t*)L_12);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_14 = ___0_input;
		NullCheck(L_14);
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_11, L_13))) <= ((int32_t)((int32_t)(((RuntimeArray*)L_14)->max_length)))))
		{
			goto IL_003b;
		}
	}

IL_0030:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_15 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_15, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralB0DC6E48DD877538156865D4EC4FE974175E5766)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_15, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_CheckArguments_mA1457668496B6000785246D759B22DE47C86017C_RuntimeMethod_var)));
	}

IL_003b:
	{
		int32_t* L_16 = ___5_outputLength;
		int32_t L_17 = *((int32_t*)L_16);
		if ((((int32_t)L_17) >= ((int32_t)0)))
		{
			goto IL_004a;
		}
	}
	{
		int32_t* L_18 = ___5_outputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_19 = ___3_output;
		NullCheck(L_19);
		int32_t L_20 = ___4_outputOffset;
		*((int32_t*)L_18) = (int32_t)((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_19)->max_length)), L_20));
	}

IL_004a:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_21 = ___3_output;
		if (L_21)
		{
			goto IL_0058;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_22 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_22, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral71443AC7CF5CC108984A138188DE915E32441BB2)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_22, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_CheckArguments_mA1457668496B6000785246D759B22DE47C86017C_RuntimeMethod_var)));
	}

IL_0058:
	{
		int32_t L_23 = ___4_outputOffset;
		if ((((int32_t)L_23) < ((int32_t)0)))
		{
			goto IL_0068;
		}
	}
	{
		int32_t L_24 = ___4_outputOffset;
		int32_t* L_25 = ___5_outputLength;
		int32_t L_26 = *((int32_t*)L_25);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_27 = ___3_output;
		NullCheck(L_27);
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_24, L_26))) <= ((int32_t)((int32_t)(((RuntimeArray*)L_27)->max_length)))))
		{
			goto IL_0073;
		}
	}

IL_0068:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_28 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_28, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral93CA867C317E4F858EA7A54249C457EF7083A591)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_28, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_CheckArguments_mA1457668496B6000785246D759B22DE47C86017C_RuntimeMethod_var)));
	}

IL_0073:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_Assert_mE21E5B79F26A7CB5E53524E035130DE04498CA44 (bool ___0_condition, String_t* ___1_errorMessage, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___0_condition;
		if (L_0)
		{
			goto IL_000a;
		}
	}
	{
		String_t* L_1 = ___1_errorMessage;
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_2 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_2, L_1, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Assert_mE21E5B79F26A7CB5E53524E035130DE04498CA44_RuntimeMethod_var)));
	}

IL_000a:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_Poke2_mA9D6096893521372F0C65B006AE5A25C59E869E1 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset, uint16_t ___2_value, const RuntimeMethod* method) 
{
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_buffer;
		int32_t L_1 = ___1_offset;
		uint16_t L_2 = ___2_value;
		NullCheck(L_0);
		(L_0)->SetAt(static_cast<il2cpp_array_size_t>(L_1), (uint8_t)((int32_t)(uint8_t)L_2));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___0_buffer;
		int32_t L_4 = ___1_offset;
		uint16_t L_5 = ___2_value;
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_4, 1))), (uint8_t)((int32_t)(uint8_t)((int32_t)((int32_t)L_5>>8))));
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint16_t LZ4Codec_Peek2_mE549DAC6B7C81F35C5B34C25AD3A6EDA5F44C008 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset, const RuntimeMethod* method) 
{
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_buffer;
		int32_t L_1 = ___1_offset;
		NullCheck(L_0);
		int32_t L_2 = L_1;
		uint8_t L_3 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = ___0_buffer;
		int32_t L_5 = ___1_offset;
		NullCheck(L_4);
		int32_t L_6 = ((int32_t)il2cpp_codegen_add(L_5, 1));
		uint8_t L_7 = (L_4)->GetAt(static_cast<il2cpp_array_size_t>(L_6));
		return (uint16_t)((int32_t)(uint16_t)((int32_t)((int32_t)L_3|((int32_t)((int32_t)L_7<<8)))));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset, const RuntimeMethod* method) 
{
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_buffer;
		int32_t L_1 = ___1_offset;
		NullCheck(L_0);
		int32_t L_2 = L_1;
		uint8_t L_3 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = ___0_buffer;
		int32_t L_5 = ___1_offset;
		NullCheck(L_4);
		int32_t L_6 = ((int32_t)il2cpp_codegen_add(L_5, 1));
		uint8_t L_7 = (L_4)->GetAt(static_cast<il2cpp_array_size_t>(L_6));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_buffer;
		int32_t L_9 = ___1_offset;
		NullCheck(L_8);
		int32_t L_10 = ((int32_t)il2cpp_codegen_add(L_9, 2));
		uint8_t L_11 = (L_8)->GetAt(static_cast<il2cpp_array_size_t>(L_10));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___0_buffer;
		int32_t L_13 = ___1_offset;
		NullCheck(L_12);
		int32_t L_14 = ((int32_t)il2cpp_codegen_add(L_13, 3));
		uint8_t L_15 = (L_12)->GetAt(static_cast<il2cpp_array_size_t>(L_14));
		return ((int32_t)(((int32_t)(((int32_t)((int32_t)L_3|((int32_t)((int32_t)L_7<<8))))|((int32_t)((int32_t)L_11<<((int32_t)16)))))|((int32_t)((int32_t)L_15<<((int32_t)24)))));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t LZ4Codec_Xor4_mECF76BD60591364408CC4E94D6F913291AC4B8CB (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset1, int32_t ___2_offset2, const RuntimeMethod* method) 
{
	uint32_t V_0 = 0;
	uint32_t V_1 = 0;
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_buffer;
		int32_t L_1 = ___1_offset1;
		NullCheck(L_0);
		int32_t L_2 = L_1;
		uint8_t L_3 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = ___0_buffer;
		int32_t L_5 = ___1_offset1;
		NullCheck(L_4);
		int32_t L_6 = ((int32_t)il2cpp_codegen_add(L_5, 1));
		uint8_t L_7 = (L_4)->GetAt(static_cast<il2cpp_array_size_t>(L_6));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_buffer;
		int32_t L_9 = ___1_offset1;
		NullCheck(L_8);
		int32_t L_10 = ((int32_t)il2cpp_codegen_add(L_9, 2));
		uint8_t L_11 = (L_8)->GetAt(static_cast<il2cpp_array_size_t>(L_10));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___0_buffer;
		int32_t L_13 = ___1_offset1;
		NullCheck(L_12);
		int32_t L_14 = ((int32_t)il2cpp_codegen_add(L_13, 3));
		uint8_t L_15 = (L_12)->GetAt(static_cast<il2cpp_array_size_t>(L_14));
		V_0 = ((int32_t)(((int32_t)(((int32_t)((int32_t)L_3|((int32_t)((int32_t)L_7<<8))))|((int32_t)((int32_t)L_11<<((int32_t)16)))))|((int32_t)((int32_t)L_15<<((int32_t)24)))));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = ___0_buffer;
		int32_t L_17 = ___2_offset2;
		NullCheck(L_16);
		int32_t L_18 = L_17;
		uint8_t L_19 = (L_16)->GetAt(static_cast<il2cpp_array_size_t>(L_18));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_20 = ___0_buffer;
		int32_t L_21 = ___2_offset2;
		NullCheck(L_20);
		int32_t L_22 = ((int32_t)il2cpp_codegen_add(L_21, 1));
		uint8_t L_23 = (L_20)->GetAt(static_cast<il2cpp_array_size_t>(L_22));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = ___0_buffer;
		int32_t L_25 = ___2_offset2;
		NullCheck(L_24);
		int32_t L_26 = ((int32_t)il2cpp_codegen_add(L_25, 2));
		uint8_t L_27 = (L_24)->GetAt(static_cast<il2cpp_array_size_t>(L_26));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_28 = ___0_buffer;
		int32_t L_29 = ___2_offset2;
		NullCheck(L_28);
		int32_t L_30 = ((int32_t)il2cpp_codegen_add(L_29, 3));
		uint8_t L_31 = (L_28)->GetAt(static_cast<il2cpp_array_size_t>(L_30));
		V_1 = ((int32_t)(((int32_t)(((int32_t)((int32_t)L_19|((int32_t)((int32_t)L_23<<8))))|((int32_t)((int32_t)L_27<<((int32_t)16)))))|((int32_t)((int32_t)L_31<<((int32_t)24)))));
		uint32_t L_32 = V_0;
		uint32_t L_33 = V_1;
		return ((int32_t)((int32_t)L_32^(int32_t)L_33));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t LZ4Codec_Xor8_m4A7619EA57DCCFC5B2A17F222C94BE01C57E50BD (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset1, int32_t ___2_offset2, const RuntimeMethod* method) 
{
	uint64_t V_0 = 0;
	uint64_t V_1 = 0;
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_buffer;
		int32_t L_1 = ___1_offset1;
		NullCheck(L_0);
		int32_t L_2 = L_1;
		uint8_t L_3 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = ___0_buffer;
		int32_t L_5 = ___1_offset1;
		NullCheck(L_4);
		int32_t L_6 = ((int32_t)il2cpp_codegen_add(L_5, 1));
		uint8_t L_7 = (L_4)->GetAt(static_cast<il2cpp_array_size_t>(L_6));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_buffer;
		int32_t L_9 = ___1_offset1;
		NullCheck(L_8);
		int32_t L_10 = ((int32_t)il2cpp_codegen_add(L_9, 2));
		uint8_t L_11 = (L_8)->GetAt(static_cast<il2cpp_array_size_t>(L_10));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___0_buffer;
		int32_t L_13 = ___1_offset1;
		NullCheck(L_12);
		int32_t L_14 = ((int32_t)il2cpp_codegen_add(L_13, 3));
		uint8_t L_15 = (L_12)->GetAt(static_cast<il2cpp_array_size_t>(L_14));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = ___0_buffer;
		int32_t L_17 = ___1_offset1;
		NullCheck(L_16);
		int32_t L_18 = ((int32_t)il2cpp_codegen_add(L_17, 4));
		uint8_t L_19 = (L_16)->GetAt(static_cast<il2cpp_array_size_t>(L_18));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_20 = ___0_buffer;
		int32_t L_21 = ___1_offset1;
		NullCheck(L_20);
		int32_t L_22 = ((int32_t)il2cpp_codegen_add(L_21, 5));
		uint8_t L_23 = (L_20)->GetAt(static_cast<il2cpp_array_size_t>(L_22));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = ___0_buffer;
		int32_t L_25 = ___1_offset1;
		NullCheck(L_24);
		int32_t L_26 = ((int32_t)il2cpp_codegen_add(L_25, 6));
		uint8_t L_27 = (L_24)->GetAt(static_cast<il2cpp_array_size_t>(L_26));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_28 = ___0_buffer;
		int32_t L_29 = ___1_offset1;
		NullCheck(L_28);
		int32_t L_30 = ((int32_t)il2cpp_codegen_add(L_29, 7));
		uint8_t L_31 = (L_28)->GetAt(static_cast<il2cpp_array_size_t>(L_30));
		V_0 = ((int64_t)(((int64_t)(((int64_t)(((int64_t)(((int64_t)(((int64_t)(((int64_t)(((int64_t)(uint64_t)L_3)|((int64_t)(((int64_t)(uint64_t)L_7)<<8))))|((int64_t)(((int64_t)(uint64_t)L_11)<<((int32_t)16)))))|((int64_t)(((int64_t)(uint64_t)L_15)<<((int32_t)24)))))|((int64_t)(((int64_t)(uint64_t)L_19)<<((int32_t)32)))))|((int64_t)(((int64_t)(uint64_t)L_23)<<((int32_t)40)))))|((int64_t)(((int64_t)(uint64_t)L_27)<<((int32_t)48)))))|((int64_t)(((int64_t)(uint64_t)L_31)<<((int32_t)56)))));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_32 = ___0_buffer;
		int32_t L_33 = ___2_offset2;
		NullCheck(L_32);
		int32_t L_34 = L_33;
		uint8_t L_35 = (L_32)->GetAt(static_cast<il2cpp_array_size_t>(L_34));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_36 = ___0_buffer;
		int32_t L_37 = ___2_offset2;
		NullCheck(L_36);
		int32_t L_38 = ((int32_t)il2cpp_codegen_add(L_37, 1));
		uint8_t L_39 = (L_36)->GetAt(static_cast<il2cpp_array_size_t>(L_38));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_40 = ___0_buffer;
		int32_t L_41 = ___2_offset2;
		NullCheck(L_40);
		int32_t L_42 = ((int32_t)il2cpp_codegen_add(L_41, 2));
		uint8_t L_43 = (L_40)->GetAt(static_cast<il2cpp_array_size_t>(L_42));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_44 = ___0_buffer;
		int32_t L_45 = ___2_offset2;
		NullCheck(L_44);
		int32_t L_46 = ((int32_t)il2cpp_codegen_add(L_45, 3));
		uint8_t L_47 = (L_44)->GetAt(static_cast<il2cpp_array_size_t>(L_46));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_48 = ___0_buffer;
		int32_t L_49 = ___2_offset2;
		NullCheck(L_48);
		int32_t L_50 = ((int32_t)il2cpp_codegen_add(L_49, 4));
		uint8_t L_51 = (L_48)->GetAt(static_cast<il2cpp_array_size_t>(L_50));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_52 = ___0_buffer;
		int32_t L_53 = ___2_offset2;
		NullCheck(L_52);
		int32_t L_54 = ((int32_t)il2cpp_codegen_add(L_53, 5));
		uint8_t L_55 = (L_52)->GetAt(static_cast<il2cpp_array_size_t>(L_54));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_56 = ___0_buffer;
		int32_t L_57 = ___2_offset2;
		NullCheck(L_56);
		int32_t L_58 = ((int32_t)il2cpp_codegen_add(L_57, 6));
		uint8_t L_59 = (L_56)->GetAt(static_cast<il2cpp_array_size_t>(L_58));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_60 = ___0_buffer;
		int32_t L_61 = ___2_offset2;
		NullCheck(L_60);
		int32_t L_62 = ((int32_t)il2cpp_codegen_add(L_61, 7));
		uint8_t L_63 = (L_60)->GetAt(static_cast<il2cpp_array_size_t>(L_62));
		V_1 = ((int64_t)(((int64_t)(((int64_t)(((int64_t)(((int64_t)(((int64_t)(((int64_t)(((int64_t)(uint64_t)L_35)|((int64_t)(((int64_t)(uint64_t)L_39)<<8))))|((int64_t)(((int64_t)(uint64_t)L_43)<<((int32_t)16)))))|((int64_t)(((int64_t)(uint64_t)L_47)<<((int32_t)24)))))|((int64_t)(((int64_t)(uint64_t)L_51)<<((int32_t)32)))))|((int64_t)(((int64_t)(uint64_t)L_55)<<((int32_t)40)))))|((int64_t)(((int64_t)(uint64_t)L_59)<<((int32_t)48)))))|((int64_t)(((int64_t)(uint64_t)L_63)<<((int32_t)56)))));
		uint64_t L_64 = V_0;
		uint64_t L_65 = V_1;
		return ((int64_t)((int64_t)L_64^(int64_t)L_65));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LZ4Codec_Equal2_m05C0F8A90FA336B8EFA50F98F2485EAF9A00FEF6 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset1, int32_t ___2_offset2, const RuntimeMethod* method) 
{
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_buffer;
		int32_t L_1 = ___1_offset1;
		NullCheck(L_0);
		int32_t L_2 = L_1;
		uint8_t L_3 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = ___0_buffer;
		int32_t L_5 = ___2_offset2;
		NullCheck(L_4);
		int32_t L_6 = L_5;
		uint8_t L_7 = (L_4)->GetAt(static_cast<il2cpp_array_size_t>(L_6));
		if ((((int32_t)L_3) == ((int32_t)L_7)))
		{
			goto IL_000a;
		}
	}
	{
		return (bool)0;
	}

IL_000a:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_buffer;
		int32_t L_9 = ___1_offset1;
		NullCheck(L_8);
		int32_t L_10 = ((int32_t)il2cpp_codegen_add(L_9, 1));
		uint8_t L_11 = (L_8)->GetAt(static_cast<il2cpp_array_size_t>(L_10));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___0_buffer;
		int32_t L_13 = ___2_offset2;
		NullCheck(L_12);
		int32_t L_14 = ((int32_t)il2cpp_codegen_add(L_13, 1));
		uint8_t L_15 = (L_12)->GetAt(static_cast<il2cpp_array_size_t>(L_14));
		return (bool)((((int32_t)L_11) == ((int32_t)L_15))? 1 : 0);
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset1, int32_t ___2_offset2, const RuntimeMethod* method) 
{
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_buffer;
		int32_t L_1 = ___1_offset1;
		NullCheck(L_0);
		int32_t L_2 = L_1;
		uint8_t L_3 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = ___0_buffer;
		int32_t L_5 = ___2_offset2;
		NullCheck(L_4);
		int32_t L_6 = L_5;
		uint8_t L_7 = (L_4)->GetAt(static_cast<il2cpp_array_size_t>(L_6));
		if ((((int32_t)L_3) == ((int32_t)L_7)))
		{
			goto IL_000a;
		}
	}
	{
		return (bool)0;
	}

IL_000a:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_buffer;
		int32_t L_9 = ___1_offset1;
		NullCheck(L_8);
		int32_t L_10 = ((int32_t)il2cpp_codegen_add(L_9, 1));
		uint8_t L_11 = (L_8)->GetAt(static_cast<il2cpp_array_size_t>(L_10));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___0_buffer;
		int32_t L_13 = ___2_offset2;
		NullCheck(L_12);
		int32_t L_14 = ((int32_t)il2cpp_codegen_add(L_13, 1));
		uint8_t L_15 = (L_12)->GetAt(static_cast<il2cpp_array_size_t>(L_14));
		if ((((int32_t)L_11) == ((int32_t)L_15)))
		{
			goto IL_0018;
		}
	}
	{
		return (bool)0;
	}

IL_0018:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = ___0_buffer;
		int32_t L_17 = ___1_offset1;
		NullCheck(L_16);
		int32_t L_18 = ((int32_t)il2cpp_codegen_add(L_17, 2));
		uint8_t L_19 = (L_16)->GetAt(static_cast<il2cpp_array_size_t>(L_18));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_20 = ___0_buffer;
		int32_t L_21 = ___2_offset2;
		NullCheck(L_20);
		int32_t L_22 = ((int32_t)il2cpp_codegen_add(L_21, 2));
		uint8_t L_23 = (L_20)->GetAt(static_cast<il2cpp_array_size_t>(L_22));
		if ((((int32_t)L_19) == ((int32_t)L_23)))
		{
			goto IL_0026;
		}
	}
	{
		return (bool)0;
	}

IL_0026:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = ___0_buffer;
		int32_t L_25 = ___1_offset1;
		NullCheck(L_24);
		int32_t L_26 = ((int32_t)il2cpp_codegen_add(L_25, 3));
		uint8_t L_27 = (L_24)->GetAt(static_cast<il2cpp_array_size_t>(L_26));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_28 = ___0_buffer;
		int32_t L_29 = ___2_offset2;
		NullCheck(L_28);
		int32_t L_30 = ((int32_t)il2cpp_codegen_add(L_29, 3));
		uint8_t L_31 = (L_28)->GetAt(static_cast<il2cpp_array_size_t>(L_30));
		return (bool)((((int32_t)L_27) == ((int32_t)L_31))? 1 : 0);
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_Copy4_m184A9377DC0EC985A8AF55E386A3F04D2F8C3F5F (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buf, int32_t ___1_src, int32_t ___2_dst, const RuntimeMethod* method) 
{
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_buf;
		int32_t L_1 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___0_buf;
		int32_t L_3 = ___1_src;
		NullCheck(L_2);
		int32_t L_4 = ((int32_t)il2cpp_codegen_add(L_3, 3));
		uint8_t L_5 = (L_2)->GetAt(static_cast<il2cpp_array_size_t>(L_4));
		NullCheck(L_0);
		(L_0)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_1, 3))), (uint8_t)L_5);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = ___0_buf;
		int32_t L_7 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_buf;
		int32_t L_9 = ___1_src;
		NullCheck(L_8);
		int32_t L_10 = ((int32_t)il2cpp_codegen_add(L_9, 2));
		uint8_t L_11 = (L_8)->GetAt(static_cast<il2cpp_array_size_t>(L_10));
		NullCheck(L_6);
		(L_6)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_7, 2))), (uint8_t)L_11);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___0_buf;
		int32_t L_13 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_14 = ___0_buf;
		int32_t L_15 = ___1_src;
		NullCheck(L_14);
		int32_t L_16 = ((int32_t)il2cpp_codegen_add(L_15, 1));
		uint8_t L_17 = (L_14)->GetAt(static_cast<il2cpp_array_size_t>(L_16));
		NullCheck(L_12);
		(L_12)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_13, 1))), (uint8_t)L_17);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_18 = ___0_buf;
		int32_t L_19 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_20 = ___0_buf;
		int32_t L_21 = ___1_src;
		NullCheck(L_20);
		int32_t L_22 = L_21;
		uint8_t L_23 = (L_20)->GetAt(static_cast<il2cpp_array_size_t>(L_22));
		NullCheck(L_18);
		(L_18)->SetAt(static_cast<il2cpp_array_size_t>(L_19), (uint8_t)L_23);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_Copy8_m55B8E8EE46B0571AC2D3710470CE639F02F6EC3D (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buf, int32_t ___1_src, int32_t ___2_dst, const RuntimeMethod* method) 
{
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_buf;
		int32_t L_1 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___0_buf;
		int32_t L_3 = ___1_src;
		NullCheck(L_2);
		int32_t L_4 = ((int32_t)il2cpp_codegen_add(L_3, 7));
		uint8_t L_5 = (L_2)->GetAt(static_cast<il2cpp_array_size_t>(L_4));
		NullCheck(L_0);
		(L_0)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_1, 7))), (uint8_t)L_5);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = ___0_buf;
		int32_t L_7 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_buf;
		int32_t L_9 = ___1_src;
		NullCheck(L_8);
		int32_t L_10 = ((int32_t)il2cpp_codegen_add(L_9, 6));
		uint8_t L_11 = (L_8)->GetAt(static_cast<il2cpp_array_size_t>(L_10));
		NullCheck(L_6);
		(L_6)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_7, 6))), (uint8_t)L_11);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___0_buf;
		int32_t L_13 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_14 = ___0_buf;
		int32_t L_15 = ___1_src;
		NullCheck(L_14);
		int32_t L_16 = ((int32_t)il2cpp_codegen_add(L_15, 5));
		uint8_t L_17 = (L_14)->GetAt(static_cast<il2cpp_array_size_t>(L_16));
		NullCheck(L_12);
		(L_12)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_13, 5))), (uint8_t)L_17);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_18 = ___0_buf;
		int32_t L_19 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_20 = ___0_buf;
		int32_t L_21 = ___1_src;
		NullCheck(L_20);
		int32_t L_22 = ((int32_t)il2cpp_codegen_add(L_21, 4));
		uint8_t L_23 = (L_20)->GetAt(static_cast<il2cpp_array_size_t>(L_22));
		NullCheck(L_18);
		(L_18)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_19, 4))), (uint8_t)L_23);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = ___0_buf;
		int32_t L_25 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_26 = ___0_buf;
		int32_t L_27 = ___1_src;
		NullCheck(L_26);
		int32_t L_28 = ((int32_t)il2cpp_codegen_add(L_27, 3));
		uint8_t L_29 = (L_26)->GetAt(static_cast<il2cpp_array_size_t>(L_28));
		NullCheck(L_24);
		(L_24)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_25, 3))), (uint8_t)L_29);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_30 = ___0_buf;
		int32_t L_31 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_32 = ___0_buf;
		int32_t L_33 = ___1_src;
		NullCheck(L_32);
		int32_t L_34 = ((int32_t)il2cpp_codegen_add(L_33, 2));
		uint8_t L_35 = (L_32)->GetAt(static_cast<il2cpp_array_size_t>(L_34));
		NullCheck(L_30);
		(L_30)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_31, 2))), (uint8_t)L_35);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_36 = ___0_buf;
		int32_t L_37 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_38 = ___0_buf;
		int32_t L_39 = ___1_src;
		NullCheck(L_38);
		int32_t L_40 = ((int32_t)il2cpp_codegen_add(L_39, 1));
		uint8_t L_41 = (L_38)->GetAt(static_cast<il2cpp_array_size_t>(L_40));
		NullCheck(L_36);
		(L_36)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_37, 1))), (uint8_t)L_41);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_42 = ___0_buf;
		int32_t L_43 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_44 = ___0_buf;
		int32_t L_45 = ___1_src;
		NullCheck(L_44);
		int32_t L_46 = L_45;
		uint8_t L_47 = (L_44)->GetAt(static_cast<il2cpp_array_size_t>(L_46));
		NullCheck(L_42);
		(L_42)->SetAt(static_cast<il2cpp_array_size_t>(L_43), (uint8_t)L_47);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_src, int32_t ___1_src_0, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___2_dst, int32_t ___3_dst_0, int32_t ___4_len, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___4_len;
		if ((((int32_t)L_0) < ((int32_t)((int32_t)16))))
		{
			goto IL_006e;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___0_src;
		int32_t L_2 = ___1_src_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___2_dst;
		int32_t L_4 = ___3_dst_0;
		int32_t L_5 = ___4_len;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_1, L_2, (RuntimeArray*)L_3, L_4, L_5, NULL);
		return;
	}

IL_0012:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = ___2_dst;
		int32_t L_7 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_src;
		int32_t L_9 = ___1_src_0;
		NullCheck(L_8);
		int32_t L_10 = L_9;
		uint8_t L_11 = (L_8)->GetAt(static_cast<il2cpp_array_size_t>(L_10));
		NullCheck(L_6);
		(L_6)->SetAt(static_cast<il2cpp_array_size_t>(L_7), (uint8_t)L_11);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___2_dst;
		int32_t L_13 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_14 = ___0_src;
		int32_t L_15 = ___1_src_0;
		NullCheck(L_14);
		int32_t L_16 = ((int32_t)il2cpp_codegen_add(L_15, 1));
		uint8_t L_17 = (L_14)->GetAt(static_cast<il2cpp_array_size_t>(L_16));
		NullCheck(L_12);
		(L_12)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_13, 1))), (uint8_t)L_17);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_18 = ___2_dst;
		int32_t L_19 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_20 = ___0_src;
		int32_t L_21 = ___1_src_0;
		NullCheck(L_20);
		int32_t L_22 = ((int32_t)il2cpp_codegen_add(L_21, 2));
		uint8_t L_23 = (L_20)->GetAt(static_cast<il2cpp_array_size_t>(L_22));
		NullCheck(L_18);
		(L_18)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_19, 2))), (uint8_t)L_23);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = ___2_dst;
		int32_t L_25 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_26 = ___0_src;
		int32_t L_27 = ___1_src_0;
		NullCheck(L_26);
		int32_t L_28 = ((int32_t)il2cpp_codegen_add(L_27, 3));
		uint8_t L_29 = (L_26)->GetAt(static_cast<il2cpp_array_size_t>(L_28));
		NullCheck(L_24);
		(L_24)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_25, 3))), (uint8_t)L_29);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_30 = ___2_dst;
		int32_t L_31 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_32 = ___0_src;
		int32_t L_33 = ___1_src_0;
		NullCheck(L_32);
		int32_t L_34 = ((int32_t)il2cpp_codegen_add(L_33, 4));
		uint8_t L_35 = (L_32)->GetAt(static_cast<il2cpp_array_size_t>(L_34));
		NullCheck(L_30);
		(L_30)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_31, 4))), (uint8_t)L_35);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_36 = ___2_dst;
		int32_t L_37 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_38 = ___0_src;
		int32_t L_39 = ___1_src_0;
		NullCheck(L_38);
		int32_t L_40 = ((int32_t)il2cpp_codegen_add(L_39, 5));
		uint8_t L_41 = (L_38)->GetAt(static_cast<il2cpp_array_size_t>(L_40));
		NullCheck(L_36);
		(L_36)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_37, 5))), (uint8_t)L_41);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_42 = ___2_dst;
		int32_t L_43 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_44 = ___0_src;
		int32_t L_45 = ___1_src_0;
		NullCheck(L_44);
		int32_t L_46 = ((int32_t)il2cpp_codegen_add(L_45, 6));
		uint8_t L_47 = (L_44)->GetAt(static_cast<il2cpp_array_size_t>(L_46));
		NullCheck(L_42);
		(L_42)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_43, 6))), (uint8_t)L_47);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_48 = ___2_dst;
		int32_t L_49 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_50 = ___0_src;
		int32_t L_51 = ___1_src_0;
		NullCheck(L_50);
		int32_t L_52 = ((int32_t)il2cpp_codegen_add(L_51, 7));
		uint8_t L_53 = (L_50)->GetAt(static_cast<il2cpp_array_size_t>(L_52));
		NullCheck(L_48);
		(L_48)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_49, 7))), (uint8_t)L_53);
		int32_t L_54 = ___4_len;
		___4_len = ((int32_t)il2cpp_codegen_subtract(L_54, 8));
		int32_t L_55 = ___1_src_0;
		___1_src_0 = ((int32_t)il2cpp_codegen_add(L_55, 8));
		int32_t L_56 = ___3_dst_0;
		___3_dst_0 = ((int32_t)il2cpp_codegen_add(L_56, 8));
	}

IL_006e:
	{
		int32_t L_57 = ___4_len;
		if ((((int32_t)L_57) >= ((int32_t)8)))
		{
			goto IL_0012;
		}
	}
	{
		goto IL_00a9;
	}

IL_0075:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_58 = ___2_dst;
		int32_t L_59 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_60 = ___0_src;
		int32_t L_61 = ___1_src_0;
		NullCheck(L_60);
		int32_t L_62 = L_61;
		uint8_t L_63 = (L_60)->GetAt(static_cast<il2cpp_array_size_t>(L_62));
		NullCheck(L_58);
		(L_58)->SetAt(static_cast<il2cpp_array_size_t>(L_59), (uint8_t)L_63);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_64 = ___2_dst;
		int32_t L_65 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_66 = ___0_src;
		int32_t L_67 = ___1_src_0;
		NullCheck(L_66);
		int32_t L_68 = ((int32_t)il2cpp_codegen_add(L_67, 1));
		uint8_t L_69 = (L_66)->GetAt(static_cast<il2cpp_array_size_t>(L_68));
		NullCheck(L_64);
		(L_64)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_65, 1))), (uint8_t)L_69);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_70 = ___2_dst;
		int32_t L_71 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_72 = ___0_src;
		int32_t L_73 = ___1_src_0;
		NullCheck(L_72);
		int32_t L_74 = ((int32_t)il2cpp_codegen_add(L_73, 2));
		uint8_t L_75 = (L_72)->GetAt(static_cast<il2cpp_array_size_t>(L_74));
		NullCheck(L_70);
		(L_70)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_71, 2))), (uint8_t)L_75);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_76 = ___2_dst;
		int32_t L_77 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_78 = ___0_src;
		int32_t L_79 = ___1_src_0;
		NullCheck(L_78);
		int32_t L_80 = ((int32_t)il2cpp_codegen_add(L_79, 3));
		uint8_t L_81 = (L_78)->GetAt(static_cast<il2cpp_array_size_t>(L_80));
		NullCheck(L_76);
		(L_76)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_77, 3))), (uint8_t)L_81);
		int32_t L_82 = ___4_len;
		___4_len = ((int32_t)il2cpp_codegen_subtract(L_82, 4));
		int32_t L_83 = ___1_src_0;
		___1_src_0 = ((int32_t)il2cpp_codegen_add(L_83, 4));
		int32_t L_84 = ___3_dst_0;
		___3_dst_0 = ((int32_t)il2cpp_codegen_add(L_84, 4));
	}

IL_00a9:
	{
		int32_t L_85 = ___4_len;
		if ((((int32_t)L_85) >= ((int32_t)4)))
		{
			goto IL_0075;
		}
	}
	{
		goto IL_00c0;
	}

IL_00b0:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_86 = ___2_dst;
		int32_t L_87 = ___3_dst_0;
		int32_t L_88 = L_87;
		___3_dst_0 = ((int32_t)il2cpp_codegen_add(L_88, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_89 = ___0_src;
		int32_t L_90 = ___1_src_0;
		int32_t L_91 = L_90;
		___1_src_0 = ((int32_t)il2cpp_codegen_add(L_91, 1));
		NullCheck(L_89);
		int32_t L_92 = L_91;
		uint8_t L_93 = (L_89)->GetAt(static_cast<il2cpp_array_size_t>(L_92));
		NullCheck(L_86);
		(L_86)->SetAt(static_cast<il2cpp_array_size_t>(L_88), (uint8_t)L_93);
	}

IL_00c0:
	{
		int32_t L_94 = ___4_len;
		int32_t L_95 = L_94;
		___4_len = ((int32_t)il2cpp_codegen_subtract(L_95, 1));
		if ((((int32_t)L_95) > ((int32_t)0)))
		{
			goto IL_00b0;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_WildCopy_mE6E7FF3DC7D46D37614FDE84DDDEA5D03B0B5F94 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_src, int32_t ___1_src_0, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___2_dst, int32_t ___3_dst_0, int32_t ___4_dst_end, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = ___4_dst_end;
		int32_t L_1 = ___3_dst_0;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_0, L_1));
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) < ((int32_t)((int32_t)16))))
		{
			goto IL_0048;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___0_src;
		int32_t L_4 = ___1_src_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = ___2_dst;
		int32_t L_6 = ___3_dst_0;
		int32_t L_7 = V_0;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_3, L_4, (RuntimeArray*)L_5, L_6, L_7, NULL);
		goto IL_0066;
	}

IL_0016:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___2_dst;
		int32_t L_9 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_10 = ___0_src;
		int32_t L_11 = ___1_src_0;
		NullCheck(L_10);
		int32_t L_12 = L_11;
		uint8_t L_13 = (L_10)->GetAt(static_cast<il2cpp_array_size_t>(L_12));
		NullCheck(L_8);
		(L_8)->SetAt(static_cast<il2cpp_array_size_t>(L_9), (uint8_t)L_13);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_14 = ___2_dst;
		int32_t L_15 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = ___0_src;
		int32_t L_17 = ___1_src_0;
		NullCheck(L_16);
		int32_t L_18 = ((int32_t)il2cpp_codegen_add(L_17, 1));
		uint8_t L_19 = (L_16)->GetAt(static_cast<il2cpp_array_size_t>(L_18));
		NullCheck(L_14);
		(L_14)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_15, 1))), (uint8_t)L_19);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_20 = ___2_dst;
		int32_t L_21 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_22 = ___0_src;
		int32_t L_23 = ___1_src_0;
		NullCheck(L_22);
		int32_t L_24 = ((int32_t)il2cpp_codegen_add(L_23, 2));
		uint8_t L_25 = (L_22)->GetAt(static_cast<il2cpp_array_size_t>(L_24));
		NullCheck(L_20);
		(L_20)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_21, 2))), (uint8_t)L_25);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_26 = ___2_dst;
		int32_t L_27 = ___3_dst_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_28 = ___0_src;
		int32_t L_29 = ___1_src_0;
		NullCheck(L_28);
		int32_t L_30 = ((int32_t)il2cpp_codegen_add(L_29, 3));
		uint8_t L_31 = (L_28)->GetAt(static_cast<il2cpp_array_size_t>(L_30));
		NullCheck(L_26);
		(L_26)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_27, 3))), (uint8_t)L_31);
		int32_t L_32 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_32, 4));
		int32_t L_33 = ___1_src_0;
		___1_src_0 = ((int32_t)il2cpp_codegen_add(L_33, 4));
		int32_t L_34 = ___3_dst_0;
		___3_dst_0 = ((int32_t)il2cpp_codegen_add(L_34, 4));
	}

IL_0048:
	{
		int32_t L_35 = V_0;
		if ((((int32_t)L_35) >= ((int32_t)4)))
		{
			goto IL_0016;
		}
	}
	{
		goto IL_005e;
	}

IL_004e:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_36 = ___2_dst;
		int32_t L_37 = ___3_dst_0;
		int32_t L_38 = L_37;
		___3_dst_0 = ((int32_t)il2cpp_codegen_add(L_38, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_39 = ___0_src;
		int32_t L_40 = ___1_src_0;
		int32_t L_41 = L_40;
		___1_src_0 = ((int32_t)il2cpp_codegen_add(L_41, 1));
		NullCheck(L_39);
		int32_t L_42 = L_41;
		uint8_t L_43 = (L_39)->GetAt(static_cast<il2cpp_array_size_t>(L_42));
		NullCheck(L_36);
		(L_36)->SetAt(static_cast<il2cpp_array_size_t>(L_38), (uint8_t)L_43);
	}

IL_005e:
	{
		int32_t L_44 = V_0;
		int32_t L_45 = L_44;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_45, 1));
		if ((((int32_t)L_45) > ((int32_t)0)))
		{
			goto IL_004e;
		}
	}

IL_0066:
	{
		int32_t L_46 = V_0;
		return L_46;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_SecureCopy_mD8B329836718DBDA10089588161AC3F72D9C88A4 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_src, int32_t ___2_dst, int32_t ___3_dst_end, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	{
		int32_t L_0 = ___2_dst;
		int32_t L_1 = ___1_src;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_0, L_1));
		int32_t L_2 = ___3_dst_end;
		int32_t L_3 = ___2_dst;
		V_1 = ((int32_t)il2cpp_codegen_subtract(L_2, L_3));
		int32_t L_4 = V_1;
		V_2 = L_4;
		int32_t L_5 = V_0;
		if ((((int32_t)L_5) < ((int32_t)((int32_t)16))))
		{
			goto IL_006f;
		}
	}
	{
		int32_t L_6 = V_0;
		int32_t L_7 = V_1;
		if ((((int32_t)L_6) < ((int32_t)L_7)))
		{
			goto IL_001f;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_buffer;
		int32_t L_9 = ___1_src;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_10 = ___0_buffer;
		int32_t L_11 = ___2_dst;
		int32_t L_12 = V_1;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_8, L_9, (RuntimeArray*)L_10, L_11, L_12, NULL);
		int32_t L_13 = V_1;
		return L_13;
	}

IL_001f:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_14 = ___0_buffer;
		int32_t L_15 = ___1_src;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = ___0_buffer;
		int32_t L_17 = ___2_dst;
		int32_t L_18 = V_0;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_14, L_15, (RuntimeArray*)L_16, L_17, L_18, NULL);
		int32_t L_19 = ___1_src;
		int32_t L_20 = V_0;
		___1_src = ((int32_t)il2cpp_codegen_add(L_19, L_20));
		int32_t L_21 = ___2_dst;
		int32_t L_22 = V_0;
		___2_dst = ((int32_t)il2cpp_codegen_add(L_21, L_22));
		int32_t L_23 = V_2;
		int32_t L_24 = V_0;
		V_2 = ((int32_t)il2cpp_codegen_subtract(L_23, L_24));
		int32_t L_25 = V_2;
		int32_t L_26 = V_0;
		if ((((int32_t)L_25) >= ((int32_t)L_26)))
		{
			goto IL_001f;
		}
	}
	{
		goto IL_006f;
	}

IL_003d:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_27 = ___0_buffer;
		int32_t L_28 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_29 = ___0_buffer;
		int32_t L_30 = ___1_src;
		NullCheck(L_29);
		int32_t L_31 = L_30;
		uint8_t L_32 = (L_29)->GetAt(static_cast<il2cpp_array_size_t>(L_31));
		NullCheck(L_27);
		(L_27)->SetAt(static_cast<il2cpp_array_size_t>(L_28), (uint8_t)L_32);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_33 = ___0_buffer;
		int32_t L_34 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_35 = ___0_buffer;
		int32_t L_36 = ___1_src;
		NullCheck(L_35);
		int32_t L_37 = ((int32_t)il2cpp_codegen_add(L_36, 1));
		uint8_t L_38 = (L_35)->GetAt(static_cast<il2cpp_array_size_t>(L_37));
		NullCheck(L_33);
		(L_33)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_34, 1))), (uint8_t)L_38);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_39 = ___0_buffer;
		int32_t L_40 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_41 = ___0_buffer;
		int32_t L_42 = ___1_src;
		NullCheck(L_41);
		int32_t L_43 = ((int32_t)il2cpp_codegen_add(L_42, 2));
		uint8_t L_44 = (L_41)->GetAt(static_cast<il2cpp_array_size_t>(L_43));
		NullCheck(L_39);
		(L_39)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_40, 2))), (uint8_t)L_44);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_45 = ___0_buffer;
		int32_t L_46 = ___2_dst;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_47 = ___0_buffer;
		int32_t L_48 = ___1_src;
		NullCheck(L_47);
		int32_t L_49 = ((int32_t)il2cpp_codegen_add(L_48, 3));
		uint8_t L_50 = (L_47)->GetAt(static_cast<il2cpp_array_size_t>(L_49));
		NullCheck(L_45);
		(L_45)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_46, 3))), (uint8_t)L_50);
		int32_t L_51 = ___2_dst;
		___2_dst = ((int32_t)il2cpp_codegen_add(L_51, 4));
		int32_t L_52 = ___1_src;
		___1_src = ((int32_t)il2cpp_codegen_add(L_52, 4));
		int32_t L_53 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_subtract(L_53, 4));
	}

IL_006f:
	{
		int32_t L_54 = V_2;
		if ((((int32_t)L_54) >= ((int32_t)4)))
		{
			goto IL_003d;
		}
	}
	{
		goto IL_0085;
	}

IL_0075:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_55 = ___0_buffer;
		int32_t L_56 = ___2_dst;
		int32_t L_57 = L_56;
		___2_dst = ((int32_t)il2cpp_codegen_add(L_57, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_58 = ___0_buffer;
		int32_t L_59 = ___1_src;
		int32_t L_60 = L_59;
		___1_src = ((int32_t)il2cpp_codegen_add(L_60, 1));
		NullCheck(L_58);
		int32_t L_61 = L_60;
		uint8_t L_62 = (L_58)->GetAt(static_cast<il2cpp_array_size_t>(L_61));
		NullCheck(L_55);
		(L_55)->SetAt(static_cast<il2cpp_array_size_t>(L_57), (uint8_t)L_62);
	}

IL_0085:
	{
		int32_t L_63 = V_2;
		int32_t L_64 = L_63;
		V_2 = ((int32_t)il2cpp_codegen_subtract(L_64, 1));
		if ((((int32_t)L_64) > ((int32_t)0)))
		{
			goto IL_0075;
		}
	}
	{
		int32_t L_65 = V_1;
		return L_65;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Encode32_m0853FFD223239CC99ADEF3BCD85413F90B9D166A (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* V_0 = NULL;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_1 = NULL;
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_input;
		int32_t L_1 = ___1_inputOffset;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___3_output;
		int32_t L_3 = ___4_outputOffset;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_CheckArguments_mA1457668496B6000785246D759B22DE47C86017C(L_0, L_1, (&___2_inputLength), L_2, L_3, (&___5_outputLength), NULL);
		int32_t L_4 = ___5_outputLength;
		if (L_4)
		{
			goto IL_0014;
		}
	}
	{
		return 0;
	}

IL_0014:
	{
		int32_t L_5 = ___2_inputLength;
		if ((((int32_t)L_5) >= ((int32_t)((int32_t)65547))))
		{
			goto IL_0036;
		}
	}
	{
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_6 = (UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83*)(UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83*)SZArrayNew(UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83_il2cpp_TypeInfo_var, (uint32_t)((int32_t)8192));
		V_0 = L_6;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_7 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_input;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_9 = ___3_output;
		int32_t L_10 = ___1_inputOffset;
		int32_t L_11 = ___4_outputOffset;
		int32_t L_12 = ___2_inputLength;
		int32_t L_13 = ___5_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_14;
		L_14 = LZ4Codec_LZ4_compress64kCtx_safe32_m673F7EC888DEAA590569AE1F7CAEACA2575B1573(L_7, L_8, L_9, L_10, L_11, L_12, L_13, NULL);
		return L_14;
	}

IL_0036:
	{
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_15 = (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)SZArrayNew(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var, (uint32_t)((int32_t)4096));
		V_1 = L_15;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_16 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = ___0_input;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_18 = ___3_output;
		int32_t L_19 = ___1_inputOffset;
		int32_t L_20 = ___4_outputOffset;
		int32_t L_21 = ___2_inputLength;
		int32_t L_22 = ___5_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_23;
		L_23 = LZ4Codec_LZ4_compressCtx_safe32_m38260443EFAEA8FB3E74B4E443B1CCC15A14C0F3(L_16, L_17, L_18, L_19, L_20, L_21, L_22, NULL);
		return L_23;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* LZ4Codec_Encode32_m8CBC9C95E306C14C16D7AE8224FB1640CAB6CA8F (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	int32_t V_1 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_2 = NULL;
	{
		int32_t L_0 = ___2_inputLength;
		if ((((int32_t)L_0) >= ((int32_t)0)))
		{
			goto IL_000b;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___0_input;
		NullCheck(L_1);
		int32_t L_2 = ___1_inputOffset;
		___2_inputLength = ((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_1)->max_length)), L_2));
	}

IL_000b:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___0_input;
		if (L_3)
		{
			goto IL_0019;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_4 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral15088A7C50E83E49058833A4287B3C2F1CD730D2)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Encode32_m8CBC9C95E306C14C16D7AE8224FB1640CAB6CA8F_RuntimeMethod_var)));
	}

IL_0019:
	{
		int32_t L_5 = ___1_inputOffset;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_0025;
		}
	}
	{
		int32_t L_6 = ___1_inputOffset;
		int32_t L_7 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_input;
		NullCheck(L_8);
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_6, L_7))) <= ((int32_t)((int32_t)(((RuntimeArray*)L_8)->max_length)))))
		{
			goto IL_0030;
		}
	}

IL_0025:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_9 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_9, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralB0DC6E48DD877538156865D4EC4FE974175E5766)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_9, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Encode32_m8CBC9C95E306C14C16D7AE8224FB1640CAB6CA8F_RuntimeMethod_var)));
	}

IL_0030:
	{
		int32_t L_10 = ___2_inputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_11;
		L_11 = LZ4Codec_MaximumOutputLength_m619DE1622B852103C3F70E3008B4BCC623C1E6DD(L_10, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_11);
		V_0 = L_12;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_13 = ___0_input;
		int32_t L_14 = ___1_inputOffset;
		int32_t L_15 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = V_0;
		NullCheck(L_17);
		int32_t L_18;
		L_18 = LZ4Codec_Encode32_m0853FFD223239CC99ADEF3BCD85413F90B9D166A(L_13, L_14, L_15, L_16, 0, ((int32_t)(((RuntimeArray*)L_17)->max_length)), NULL);
		V_1 = L_18;
		int32_t L_19 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_20 = V_0;
		NullCheck(L_20);
		if ((((int32_t)L_19) == ((int32_t)((int32_t)(((RuntimeArray*)L_20)->max_length)))))
		{
			goto IL_0072;
		}
	}
	{
		int32_t L_21 = V_1;
		if ((((int32_t)L_21) >= ((int32_t)0)))
		{
			goto IL_005f;
		}
	}
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_22 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_22, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral22562BDC01CC82A45F171035D855E64E7772E317)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_22, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Encode32_m8CBC9C95E306C14C16D7AE8224FB1640CAB6CA8F_RuntimeMethod_var)));
	}

IL_005f:
	{
		int32_t L_23 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_23);
		V_2 = L_24;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_25 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_26 = V_2;
		int32_t L_27 = V_1;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_25, 0, (RuntimeArray*)L_26, 0, L_27, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_28 = V_2;
		return L_28;
	}

IL_0072:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_29 = V_0;
		return L_29;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Encode64_m0834480EE01F94270BEFA9C101DDD498AB46402A (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* V_0 = NULL;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_1 = NULL;
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_input;
		int32_t L_1 = ___1_inputOffset;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___3_output;
		int32_t L_3 = ___4_outputOffset;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_CheckArguments_mA1457668496B6000785246D759B22DE47C86017C(L_0, L_1, (&___2_inputLength), L_2, L_3, (&___5_outputLength), NULL);
		int32_t L_4 = ___5_outputLength;
		if (L_4)
		{
			goto IL_0014;
		}
	}
	{
		return 0;
	}

IL_0014:
	{
		int32_t L_5 = ___2_inputLength;
		if ((((int32_t)L_5) >= ((int32_t)((int32_t)65547))))
		{
			goto IL_0036;
		}
	}
	{
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_6 = (UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83*)(UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83*)SZArrayNew(UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83_il2cpp_TypeInfo_var, (uint32_t)((int32_t)8192));
		V_0 = L_6;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_7 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_input;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_9 = ___3_output;
		int32_t L_10 = ___1_inputOffset;
		int32_t L_11 = ___4_outputOffset;
		int32_t L_12 = ___2_inputLength;
		int32_t L_13 = ___5_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_14;
		L_14 = LZ4Codec_LZ4_compress64kCtx_safe64_m0B1F935369022A7FF506A9C3AF21AE4331F7ECF3(L_7, L_8, L_9, L_10, L_11, L_12, L_13, NULL);
		return L_14;
	}

IL_0036:
	{
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_15 = (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)SZArrayNew(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var, (uint32_t)((int32_t)4096));
		V_1 = L_15;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_16 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = ___0_input;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_18 = ___3_output;
		int32_t L_19 = ___1_inputOffset;
		int32_t L_20 = ___4_outputOffset;
		int32_t L_21 = ___2_inputLength;
		int32_t L_22 = ___5_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_23;
		L_23 = LZ4Codec_LZ4_compressCtx_safe64_mCBD100E3B1B719762E9AF276BFB48D6C47684828(L_16, L_17, L_18, L_19, L_20, L_21, L_22, NULL);
		return L_23;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* LZ4Codec_Encode64_m791C00422ABEE5CC1154CF5B163F865A21EE618E (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	int32_t V_1 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_2 = NULL;
	{
		int32_t L_0 = ___2_inputLength;
		if ((((int32_t)L_0) >= ((int32_t)0)))
		{
			goto IL_000b;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___0_input;
		NullCheck(L_1);
		int32_t L_2 = ___1_inputOffset;
		___2_inputLength = ((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_1)->max_length)), L_2));
	}

IL_000b:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___0_input;
		if (L_3)
		{
			goto IL_0019;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_4 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral15088A7C50E83E49058833A4287B3C2F1CD730D2)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Encode64_m791C00422ABEE5CC1154CF5B163F865A21EE618E_RuntimeMethod_var)));
	}

IL_0019:
	{
		int32_t L_5 = ___1_inputOffset;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_0025;
		}
	}
	{
		int32_t L_6 = ___1_inputOffset;
		int32_t L_7 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_input;
		NullCheck(L_8);
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_6, L_7))) <= ((int32_t)((int32_t)(((RuntimeArray*)L_8)->max_length)))))
		{
			goto IL_0030;
		}
	}

IL_0025:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_9 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_9, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralB0DC6E48DD877538156865D4EC4FE974175E5766)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_9, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Encode64_m791C00422ABEE5CC1154CF5B163F865A21EE618E_RuntimeMethod_var)));
	}

IL_0030:
	{
		int32_t L_10 = ___2_inputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_11;
		L_11 = LZ4Codec_MaximumOutputLength_m619DE1622B852103C3F70E3008B4BCC623C1E6DD(L_10, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_11);
		V_0 = L_12;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_13 = ___0_input;
		int32_t L_14 = ___1_inputOffset;
		int32_t L_15 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = V_0;
		NullCheck(L_17);
		int32_t L_18;
		L_18 = LZ4Codec_Encode64_m0834480EE01F94270BEFA9C101DDD498AB46402A(L_13, L_14, L_15, L_16, 0, ((int32_t)(((RuntimeArray*)L_17)->max_length)), NULL);
		V_1 = L_18;
		int32_t L_19 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_20 = V_0;
		NullCheck(L_20);
		if ((((int32_t)L_19) == ((int32_t)((int32_t)(((RuntimeArray*)L_20)->max_length)))))
		{
			goto IL_0072;
		}
	}
	{
		int32_t L_21 = V_1;
		if ((((int32_t)L_21) >= ((int32_t)0)))
		{
			goto IL_005f;
		}
	}
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_22 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_22, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral22562BDC01CC82A45F171035D855E64E7772E317)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_22, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Encode64_m791C00422ABEE5CC1154CF5B163F865A21EE618E_RuntimeMethod_var)));
	}

IL_005f:
	{
		int32_t L_23 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_23);
		V_2 = L_24;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_25 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_26 = V_2;
		int32_t L_27 = V_1;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_25, 0, (RuntimeArray*)L_26, 0, L_27, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_28 = V_2;
		return L_28;
	}

IL_0072:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_29 = V_0;
		return L_29;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Decode32_mD775EF89F609454DA26E01E021868A6BA0C43214 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, bool ___6_knownOutputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_input;
		int32_t L_1 = ___1_inputOffset;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___3_output;
		int32_t L_3 = ___4_outputOffset;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_CheckArguments_mA1457668496B6000785246D759B22DE47C86017C(L_0, L_1, (&___2_inputLength), L_2, L_3, (&___5_outputLength), NULL);
		int32_t L_4 = ___5_outputLength;
		if (L_4)
		{
			goto IL_0014;
		}
	}
	{
		return 0;
	}

IL_0014:
	{
		bool L_5 = ___6_knownOutputLength;
		if (!L_5)
		{
			goto IL_0037;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = ___0_input;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = ___3_output;
		int32_t L_8 = ___1_inputOffset;
		int32_t L_9 = ___4_outputOffset;
		int32_t L_10 = ___5_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_11;
		L_11 = LZ4Codec_LZ4_uncompress_safe32_m3FC0A591BB2EA8741B716213BE1364901C653D98(L_6, L_7, L_8, L_9, L_10, NULL);
		V_0 = L_11;
		int32_t L_12 = V_0;
		int32_t L_13 = ___2_inputLength;
		if ((((int32_t)L_12) == ((int32_t)L_13)))
		{
			goto IL_0034;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_14 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_14, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralDA771D37A1B200C0992D03FBC0D2312E434F44C8)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_14, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Decode32_mD775EF89F609454DA26E01E021868A6BA0C43214_RuntimeMethod_var)));
	}

IL_0034:
	{
		int32_t L_15 = ___5_outputLength;
		return L_15;
	}

IL_0037:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = ___0_input;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = ___3_output;
		int32_t L_18 = ___1_inputOffset;
		int32_t L_19 = ___4_outputOffset;
		int32_t L_20 = ___2_inputLength;
		int32_t L_21 = ___5_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_22;
		L_22 = LZ4Codec_LZ4_uncompress_unknownOutputSize_safe32_m70BEAA0964145EC18E8EFE6DC6D9A6B0D745A456(L_16, L_17, L_18, L_19, L_20, L_21, NULL);
		V_1 = L_22;
		int32_t L_23 = V_1;
		if ((((int32_t)L_23) >= ((int32_t)0)))
		{
			goto IL_0054;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_24 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_24, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralDA771D37A1B200C0992D03FBC0D2312E434F44C8)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_24, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Decode32_mD775EF89F609454DA26E01E021868A6BA0C43214_RuntimeMethod_var)));
	}

IL_0054:
	{
		int32_t L_25 = V_1;
		return L_25;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* LZ4Codec_Decode32_m832B8B1A560DE796C82D736499F29100139AD330 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, int32_t ___3_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	int32_t V_1 = 0;
	{
		int32_t L_0 = ___2_inputLength;
		if ((((int32_t)L_0) >= ((int32_t)0)))
		{
			goto IL_000b;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___0_input;
		NullCheck(L_1);
		int32_t L_2 = ___1_inputOffset;
		___2_inputLength = ((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_1)->max_length)), L_2));
	}

IL_000b:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___0_input;
		if (L_3)
		{
			goto IL_0019;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_4 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral15088A7C50E83E49058833A4287B3C2F1CD730D2)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Decode32_m832B8B1A560DE796C82D736499F29100139AD330_RuntimeMethod_var)));
	}

IL_0019:
	{
		int32_t L_5 = ___1_inputOffset;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_0025;
		}
	}
	{
		int32_t L_6 = ___1_inputOffset;
		int32_t L_7 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_input;
		NullCheck(L_8);
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_6, L_7))) <= ((int32_t)((int32_t)(((RuntimeArray*)L_8)->max_length)))))
		{
			goto IL_0030;
		}
	}

IL_0025:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_9 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_9, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralB0DC6E48DD877538156865D4EC4FE974175E5766)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_9, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Decode32_m832B8B1A560DE796C82D736499F29100139AD330_RuntimeMethod_var)));
	}

IL_0030:
	{
		int32_t L_10 = ___3_outputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_11 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_10);
		V_0 = L_11;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___0_input;
		int32_t L_13 = ___1_inputOffset;
		int32_t L_14 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_15 = V_0;
		int32_t L_16 = ___3_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_17;
		L_17 = LZ4Codec_Decode32_mD775EF89F609454DA26E01E021868A6BA0C43214(L_12, L_13, L_14, L_15, 0, L_16, (bool)1, NULL);
		V_1 = L_17;
		int32_t L_18 = V_1;
		int32_t L_19 = ___3_outputLength;
		if ((((int32_t)L_18) == ((int32_t)L_19)))
		{
			goto IL_0053;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_20 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_20, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralD2022A52A84F41328946F27774BA456C970BB16D)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_20, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Decode32_m832B8B1A560DE796C82D736499F29100139AD330_RuntimeMethod_var)));
	}

IL_0053:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_21 = V_0;
		return L_21;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Decode64_m3C186439F19EFC1FDC0CF27BCB8518808BF7A401 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, bool ___6_knownOutputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_input;
		int32_t L_1 = ___1_inputOffset;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___3_output;
		int32_t L_3 = ___4_outputOffset;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_CheckArguments_mA1457668496B6000785246D759B22DE47C86017C(L_0, L_1, (&___2_inputLength), L_2, L_3, (&___5_outputLength), NULL);
		int32_t L_4 = ___5_outputLength;
		if (L_4)
		{
			goto IL_0014;
		}
	}
	{
		return 0;
	}

IL_0014:
	{
		bool L_5 = ___6_knownOutputLength;
		if (!L_5)
		{
			goto IL_0037;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = ___0_input;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = ___3_output;
		int32_t L_8 = ___1_inputOffset;
		int32_t L_9 = ___4_outputOffset;
		int32_t L_10 = ___5_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_11;
		L_11 = LZ4Codec_LZ4_uncompress_safe64_mF952DEBD155A8549AAAD0A8D265F7799C70E6B14(L_6, L_7, L_8, L_9, L_10, NULL);
		V_0 = L_11;
		int32_t L_12 = V_0;
		int32_t L_13 = ___2_inputLength;
		if ((((int32_t)L_12) == ((int32_t)L_13)))
		{
			goto IL_0034;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_14 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_14, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralDA771D37A1B200C0992D03FBC0D2312E434F44C8)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_14, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Decode64_m3C186439F19EFC1FDC0CF27BCB8518808BF7A401_RuntimeMethod_var)));
	}

IL_0034:
	{
		int32_t L_15 = ___5_outputLength;
		return L_15;
	}

IL_0037:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = ___0_input;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = ___3_output;
		int32_t L_18 = ___1_inputOffset;
		int32_t L_19 = ___4_outputOffset;
		int32_t L_20 = ___2_inputLength;
		int32_t L_21 = ___5_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_22;
		L_22 = LZ4Codec_LZ4_uncompress_unknownOutputSize_safe64_mA60DF40EE0906DD2443C4E2018117F515A3BCD25(L_16, L_17, L_18, L_19, L_20, L_21, NULL);
		V_1 = L_22;
		int32_t L_23 = V_1;
		if ((((int32_t)L_23) >= ((int32_t)0)))
		{
			goto IL_0054;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_24 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_24, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralDA771D37A1B200C0992D03FBC0D2312E434F44C8)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_24, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Decode64_m3C186439F19EFC1FDC0CF27BCB8518808BF7A401_RuntimeMethod_var)));
	}

IL_0054:
	{
		int32_t L_25 = V_1;
		return L_25;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* LZ4Codec_Decode64_mEEC2538613C3020B944EFCBD6897709B1F2F2F55 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, int32_t ___3_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	int32_t V_1 = 0;
	{
		int32_t L_0 = ___2_inputLength;
		if ((((int32_t)L_0) >= ((int32_t)0)))
		{
			goto IL_000b;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___0_input;
		NullCheck(L_1);
		int32_t L_2 = ___1_inputOffset;
		___2_inputLength = ((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_1)->max_length)), L_2));
	}

IL_000b:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___0_input;
		if (L_3)
		{
			goto IL_0019;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_4 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral15088A7C50E83E49058833A4287B3C2F1CD730D2)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Decode64_mEEC2538613C3020B944EFCBD6897709B1F2F2F55_RuntimeMethod_var)));
	}

IL_0019:
	{
		int32_t L_5 = ___1_inputOffset;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_0025;
		}
	}
	{
		int32_t L_6 = ___1_inputOffset;
		int32_t L_7 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_input;
		NullCheck(L_8);
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_6, L_7))) <= ((int32_t)((int32_t)(((RuntimeArray*)L_8)->max_length)))))
		{
			goto IL_0030;
		}
	}

IL_0025:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_9 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_9, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralB0DC6E48DD877538156865D4EC4FE974175E5766)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_9, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Decode64_mEEC2538613C3020B944EFCBD6897709B1F2F2F55_RuntimeMethod_var)));
	}

IL_0030:
	{
		int32_t L_10 = ___3_outputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_11 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_10);
		V_0 = L_11;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___0_input;
		int32_t L_13 = ___1_inputOffset;
		int32_t L_14 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_15 = V_0;
		int32_t L_16 = ___3_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_17;
		L_17 = LZ4Codec_Decode64_m3C186439F19EFC1FDC0CF27BCB8518808BF7A401(L_12, L_13, L_14, L_15, 0, L_16, (bool)1, NULL);
		V_1 = L_17;
		int32_t L_18 = V_1;
		int32_t L_19 = ___3_outputLength;
		if ((((int32_t)L_18) == ((int32_t)L_19)))
		{
			goto IL_0053;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_20 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_20, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralD2022A52A84F41328946F27774BA456C970BB16D)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_20, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Decode64_mEEC2538613C3020B944EFCBD6897709B1F2F2F55_RuntimeMethod_var)));
	}

IL_0053:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_21 = V_0;
		return L_21;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* LZ4Codec_LZ4HC_Create_mF6B1BA8490BA3DA19388B710CC15A1033D9A13D2 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_src, int32_t ___1_src_0, int32_t ___2_src_len, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_dst, int32_t ___4_dst_0, int32_t ___5_dst_len, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* V_0 = NULL;
	UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* V_1 = NULL;
	int32_t V_2 = 0;
	LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* V_3 = NULL;
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_0 = (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A*)il2cpp_codegen_object_new(LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A_il2cpp_TypeInfo_var);
		LZ4HC_Data_Structure__ctor_m5E8B7F4BD2B0BA48BCD08EFD2063130779B84D18(L_0, NULL);
		V_3 = L_0;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_1 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___0_src;
		NullCheck(L_1);
		L_1->___src = L_2;
		Il2CppCodeGenWriteBarrier((void**)(&L_1->___src), (void*)L_2);
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_3 = V_3;
		int32_t L_4 = ___1_src_0;
		NullCheck(L_3);
		L_3->___src_base = L_4;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_5 = V_3;
		int32_t L_6 = ___1_src_0;
		int32_t L_7 = ___2_src_len;
		NullCheck(L_5);
		L_5->___src_end = ((int32_t)il2cpp_codegen_add(L_6, L_7));
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_8 = V_3;
		int32_t L_9 = ___1_src_0;
		int32_t L_10 = ___2_src_len;
		NullCheck(L_8);
		L_8->___src_LASTLITERALS = ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_9, L_10)), 5));
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_11 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___3_dst;
		NullCheck(L_11);
		L_11->___dst = L_12;
		Il2CppCodeGenWriteBarrier((void**)(&L_11->___dst), (void*)L_12);
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_13 = V_3;
		int32_t L_14 = ___4_dst_0;
		NullCheck(L_13);
		L_13->___dst_base = L_14;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_15 = V_3;
		int32_t L_16 = ___5_dst_len;
		NullCheck(L_15);
		L_15->___dst_len = L_16;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_17 = V_3;
		int32_t L_18 = ___4_dst_0;
		int32_t L_19 = ___5_dst_len;
		NullCheck(L_17);
		L_17->___dst_end = ((int32_t)il2cpp_codegen_add(L_18, L_19));
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_20 = V_3;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_21 = (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)SZArrayNew(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var, (uint32_t)((int32_t)32768));
		NullCheck(L_20);
		L_20->___hashTable = L_21;
		Il2CppCodeGenWriteBarrier((void**)(&L_20->___hashTable), (void*)L_21);
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_22 = V_3;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_23 = (UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83*)(UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83*)SZArrayNew(UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83_il2cpp_TypeInfo_var, (uint32_t)((int32_t)65536));
		NullCheck(L_22);
		L_22->___chainTable = L_23;
		Il2CppCodeGenWriteBarrier((void**)(&L_22->___chainTable), (void*)L_23);
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_24 = V_3;
		int32_t L_25 = ___1_src_0;
		NullCheck(L_24);
		L_24->___nextToUpdate = ((int32_t)il2cpp_codegen_add(L_25, 1));
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_26 = V_3;
		V_0 = L_26;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_27 = V_0;
		NullCheck(L_27);
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_28 = L_27->___chainTable;
		V_1 = L_28;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_29 = V_1;
		NullCheck(L_29);
		V_2 = ((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_29)->max_length)), 1));
		goto IL_0090;
	}

IL_0084:
	{
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_30 = V_1;
		int32_t L_31 = V_2;
		NullCheck(L_30);
		(L_30)->SetAt(static_cast<il2cpp_array_size_t>(L_31), (uint16_t)((int32_t)65535));
		int32_t L_32 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_subtract(L_32, 1));
	}

IL_0090:
	{
		int32_t L_33 = V_2;
		if ((((int32_t)L_33) >= ((int32_t)0)))
		{
			goto IL_0084;
		}
	}
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_34 = V_0;
		return L_34;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compressHC_32_m4D9EC4B23F40E86BE3B8D036ACC1BA7AF7622BE9 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_input;
		int32_t L_1 = ___1_inputOffset;
		int32_t L_2 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___3_output;
		int32_t L_4 = ___4_outputOffset;
		int32_t L_5 = ___5_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_6;
		L_6 = LZ4Codec_LZ4HC_Create_mF6B1BA8490BA3DA19388B710CC15A1033D9A13D2(L_0, L_1, L_2, L_3, L_4, L_5, NULL);
		int32_t L_7;
		L_7 = LZ4Codec_LZ4_compressHCCtx_32_m080C9306A42AEF78E3E577950B54A4881DF59BE6(L_6, NULL);
		return L_7;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Encode32HC_mE7B695E89746BC0A8AEB434AA894BA084A0A815F (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		int32_t L_0 = ___2_inputLength;
		if (L_0)
		{
			goto IL_0005;
		}
	}
	{
		return 0;
	}

IL_0005:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___0_input;
		int32_t L_2 = ___1_inputOffset;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___3_output;
		int32_t L_4 = ___4_outputOffset;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_CheckArguments_mA1457668496B6000785246D759B22DE47C86017C(L_1, L_2, (&___2_inputLength), L_3, L_4, (&___5_outputLength), NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = ___0_input;
		int32_t L_6 = ___1_inputOffset;
		int32_t L_7 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___3_output;
		int32_t L_9 = ___4_outputOffset;
		int32_t L_10 = ___5_outputLength;
		int32_t L_11;
		L_11 = LZ4Codec_LZ4_compressHC_32_m4D9EC4B23F40E86BE3B8D036ACC1BA7AF7622BE9(L_5, L_6, L_7, L_8, L_9, L_10, NULL);
		V_0 = L_11;
		int32_t L_12 = V_0;
		if ((((int32_t)L_12) <= ((int32_t)0)))
		{
			goto IL_0027;
		}
	}
	{
		int32_t L_13 = V_0;
		return L_13;
	}

IL_0027:
	{
		return (-1);
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* LZ4Codec_Encode32HC_m80BBE7D1B1CE9DD3EFF618DA93FA2AE69467343C (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_1 = NULL;
	int32_t V_2 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_3 = NULL;
	{
		int32_t L_0 = ___2_inputLength;
		if (L_0)
		{
			goto IL_000a;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)0);
		return L_1;
	}

IL_000a:
	{
		int32_t L_2 = ___2_inputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_3;
		L_3 = LZ4Codec_MaximumOutputLength_m619DE1622B852103C3F70E3008B4BCC623C1E6DD(L_2, NULL);
		V_0 = L_3;
		int32_t L_4 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_4);
		V_1 = L_5;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = ___0_input;
		int32_t L_7 = ___1_inputOffset;
		int32_t L_8 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_9 = V_1;
		int32_t L_10 = V_0;
		int32_t L_11;
		L_11 = LZ4Codec_Encode32HC_mE7B695E89746BC0A8AEB434AA894BA084A0A815F(L_6, L_7, L_8, L_9, 0, L_10, NULL);
		V_2 = L_11;
		int32_t L_12 = V_2;
		if ((((int32_t)L_12) >= ((int32_t)0)))
		{
			goto IL_0033;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_13 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_13, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralD35359F121CDCC5B189869B755512639BD3AA30E)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_13, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Encode32HC_m80BBE7D1B1CE9DD3EFF618DA93FA2AE69467343C_RuntimeMethod_var)));
	}

IL_0033:
	{
		int32_t L_14 = V_2;
		int32_t L_15 = V_0;
		if ((((int32_t)L_14) == ((int32_t)L_15)))
		{
			goto IL_004a;
		}
	}
	{
		int32_t L_16 = V_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_16);
		V_3 = L_17;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_18 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_19 = V_3;
		int32_t L_20 = V_2;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_18, 0, (RuntimeArray*)L_19, 0, L_20, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_21 = V_3;
		V_1 = L_21;
	}

IL_004a:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_22 = V_1;
		return L_22;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compressHC_64_mAF06F27F55DA1BD7655B088A4C211F8730FC461A (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_input;
		int32_t L_1 = ___1_inputOffset;
		int32_t L_2 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___3_output;
		int32_t L_4 = ___4_outputOffset;
		int32_t L_5 = ___5_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_6;
		L_6 = LZ4Codec_LZ4HC_Create_mF6B1BA8490BA3DA19388B710CC15A1033D9A13D2(L_0, L_1, L_2, L_3, L_4, L_5, NULL);
		int32_t L_7;
		L_7 = LZ4Codec_LZ4_compressHCCtx_64_m0037ABA747959A480DCBB84290F6337E11C01CBD(L_6, NULL);
		return L_7;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Encode64HC_mBDD028D90BB74FB1CCE146FAB90A39116BBB4C05 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		int32_t L_0 = ___2_inputLength;
		if (L_0)
		{
			goto IL_0005;
		}
	}
	{
		return 0;
	}

IL_0005:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___0_input;
		int32_t L_2 = ___1_inputOffset;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___3_output;
		int32_t L_4 = ___4_outputOffset;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_CheckArguments_mA1457668496B6000785246D759B22DE47C86017C(L_1, L_2, (&___2_inputLength), L_3, L_4, (&___5_outputLength), NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = ___0_input;
		int32_t L_6 = ___1_inputOffset;
		int32_t L_7 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___3_output;
		int32_t L_9 = ___4_outputOffset;
		int32_t L_10 = ___5_outputLength;
		int32_t L_11;
		L_11 = LZ4Codec_LZ4_compressHC_64_mAF06F27F55DA1BD7655B088A4C211F8730FC461A(L_5, L_6, L_7, L_8, L_9, L_10, NULL);
		V_0 = L_11;
		int32_t L_12 = V_0;
		if ((((int32_t)L_12) <= ((int32_t)0)))
		{
			goto IL_0027;
		}
	}
	{
		int32_t L_13 = V_0;
		return L_13;
	}

IL_0027:
	{
		return (-1);
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* LZ4Codec_Encode64HC_m5A87CA8E7088911ADE4AA601748361AA29981B99 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_1 = NULL;
	int32_t V_2 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_3 = NULL;
	{
		int32_t L_0 = ___2_inputLength;
		if (L_0)
		{
			goto IL_000a;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)0);
		return L_1;
	}

IL_000a:
	{
		int32_t L_2 = ___2_inputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_3;
		L_3 = LZ4Codec_MaximumOutputLength_m619DE1622B852103C3F70E3008B4BCC623C1E6DD(L_2, NULL);
		V_0 = L_3;
		int32_t L_4 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_4);
		V_1 = L_5;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = ___0_input;
		int32_t L_7 = ___1_inputOffset;
		int32_t L_8 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_9 = V_1;
		int32_t L_10 = V_0;
		int32_t L_11;
		L_11 = LZ4Codec_Encode64HC_mBDD028D90BB74FB1CCE146FAB90A39116BBB4C05(L_6, L_7, L_8, L_9, 0, L_10, NULL);
		V_2 = L_11;
		int32_t L_12 = V_2;
		if ((((int32_t)L_12) >= ((int32_t)0)))
		{
			goto IL_0033;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_13 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_13, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralD35359F121CDCC5B189869B755512639BD3AA30E)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_13, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Encode64HC_m5A87CA8E7088911ADE4AA601748361AA29981B99_RuntimeMethod_var)));
	}

IL_0033:
	{
		int32_t L_14 = V_2;
		int32_t L_15 = V_0;
		if ((((int32_t)L_14) == ((int32_t)L_15)))
		{
			goto IL_004a;
		}
	}
	{
		int32_t L_16 = V_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_16);
		V_3 = L_17;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_18 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_19 = V_3;
		int32_t L_20 = V_2;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_18, 0, (RuntimeArray*)L_19, 0, L_20, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_21 = V_3;
		V_1 = L_21;
	}

IL_004a:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_22 = V_1;
		return L_22;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compressCtx_safe32_m38260443EFAEA8FB3E74B4E443B1CCC15A14C0F3 (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___0_hash_table, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___2_dst, int32_t ___3_src_0, int32_t ___4_dst_0, int32_t ___5_src_len, int32_t ___6_dst_maxlen, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	int32_t V_13 = 0;
	int32_t V_14 = 0;
	uint32_t V_15 = 0;
	uint32_t V_16 = 0;
	int32_t V_17 = 0;
	int32_t V_18 = 0;
	int32_t V_19 = 0;
	int32_t V_20 = 0;
	int32_t V_21 = 0;
	int32_t V_22 = 0;
	int32_t V_23 = 0;
	int32_t V_24 = 0;
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_0 = ((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DEBRUIJN_TABLE_32;
		V_0 = L_0;
		int32_t L_1 = ___3_src_0;
		V_2 = L_1;
		int32_t L_2 = ___3_src_0;
		V_3 = L_2;
		int32_t L_3 = V_2;
		V_4 = L_3;
		int32_t L_4 = V_2;
		int32_t L_5 = ___5_src_len;
		V_5 = ((int32_t)il2cpp_codegen_add(L_4, L_5));
		int32_t L_6 = V_5;
		V_6 = ((int32_t)il2cpp_codegen_subtract(L_6, ((int32_t)12)));
		int32_t L_7 = ___4_dst_0;
		V_7 = L_7;
		int32_t L_8 = V_7;
		int32_t L_9 = ___6_dst_maxlen;
		V_8 = ((int32_t)il2cpp_codegen_add(L_8, L_9));
		int32_t L_10 = V_5;
		V_9 = ((int32_t)il2cpp_codegen_subtract(L_10, 5));
		int32_t L_11 = V_9;
		V_10 = ((int32_t)il2cpp_codegen_subtract(L_11, 1));
		int32_t L_12 = V_9;
		V_11 = ((int32_t)il2cpp_codegen_subtract(L_12, 3));
		int32_t L_13 = V_8;
		V_12 = ((int32_t)il2cpp_codegen_subtract(L_13, 6));
		int32_t L_14 = V_8;
		V_13 = ((int32_t)il2cpp_codegen_subtract(L_14, 8));
		int32_t L_15 = ___5_src_len;
		if ((((int32_t)L_15) < ((int32_t)((int32_t)13))))
		{
			goto IL_0375;
		}
	}
	{
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_16 = ___0_hash_table;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = ___1_src;
		int32_t L_18 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_19;
		L_19 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_17, L_18, NULL);
		int32_t L_20 = V_2;
		int32_t L_21 = V_3;
		NullCheck(L_16);
		(L_16)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_19, ((int32_t)-1640531535)))>>((int32_t)20))))), (int32_t)((int32_t)il2cpp_codegen_subtract(L_20, L_21)));
		int32_t L_22 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_22, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_23 = ___1_src;
		int32_t L_24 = V_2;
		uint32_t L_25;
		L_25 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_23, L_24, NULL);
		V_16 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_25, ((int32_t)-1640531535)))>>((int32_t)20)));
	}

IL_0078:
	{
		V_17 = ((int32_t)67);
		int32_t L_26 = V_2;
		V_18 = L_26;
	}

IL_007f:
	{
		uint32_t L_27 = V_16;
		V_15 = L_27;
		int32_t L_28 = V_17;
		int32_t L_29 = L_28;
		V_17 = ((int32_t)il2cpp_codegen_add(L_29, 1));
		V_21 = ((int32_t)(L_29>>6));
		int32_t L_30 = V_18;
		V_2 = L_30;
		int32_t L_31 = V_2;
		int32_t L_32 = V_21;
		V_18 = ((int32_t)il2cpp_codegen_add(L_31, L_32));
		int32_t L_33 = V_18;
		int32_t L_34 = V_6;
		if ((((int32_t)L_33) > ((int32_t)L_34)))
		{
			goto IL_0375;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_35 = ___1_src;
		int32_t L_36 = V_18;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_37;
		L_37 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_35, L_36, NULL);
		V_16 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_37, ((int32_t)-1640531535)))>>((int32_t)20)));
		int32_t L_38 = V_3;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_39 = ___0_hash_table;
		uint32_t L_40 = V_15;
		NullCheck(L_39);
		uintptr_t L_41 = ((uintptr_t)L_40);
		int32_t L_42 = (L_39)->GetAt(static_cast<il2cpp_array_size_t>(L_41));
		V_19 = ((int32_t)il2cpp_codegen_add(L_38, L_42));
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_43 = ___0_hash_table;
		uint32_t L_44 = V_15;
		int32_t L_45 = V_2;
		int32_t L_46 = V_3;
		NullCheck(L_43);
		(L_43)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)L_44)), (int32_t)((int32_t)il2cpp_codegen_subtract(L_45, L_46)));
		int32_t L_47 = V_19;
		int32_t L_48 = V_2;
		if ((((int32_t)L_47) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_48, ((int32_t)65535))))))
		{
			goto IL_007f;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_49 = ___1_src;
		int32_t L_50 = V_19;
		int32_t L_51 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_52;
		L_52 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_49, L_50, L_51, NULL);
		if (!L_52)
		{
			goto IL_007f;
		}
	}
	{
		goto IL_00e6;
	}

IL_00dc:
	{
		int32_t L_53 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_subtract(L_53, 1));
		int32_t L_54 = V_19;
		V_19 = ((int32_t)il2cpp_codegen_subtract(L_54, 1));
	}

IL_00e6:
	{
		int32_t L_55 = V_2;
		int32_t L_56 = V_4;
		if ((((int32_t)L_55) <= ((int32_t)L_56)))
		{
			goto IL_00fd;
		}
	}
	{
		int32_t L_57 = V_19;
		int32_t L_58 = ___3_src_0;
		if ((((int32_t)L_57) <= ((int32_t)L_58)))
		{
			goto IL_00fd;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_59 = ___1_src;
		int32_t L_60 = V_2;
		NullCheck(L_59);
		int32_t L_61 = ((int32_t)il2cpp_codegen_subtract(L_60, 1));
		uint8_t L_62 = (L_59)->GetAt(static_cast<il2cpp_array_size_t>(L_61));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_63 = ___1_src;
		int32_t L_64 = V_19;
		NullCheck(L_63);
		int32_t L_65 = ((int32_t)il2cpp_codegen_subtract(L_64, 1));
		uint8_t L_66 = (L_63)->GetAt(static_cast<il2cpp_array_size_t>(L_65));
		if ((((int32_t)L_62) == ((int32_t)L_66)))
		{
			goto IL_00dc;
		}
	}

IL_00fd:
	{
		int32_t L_67 = V_2;
		int32_t L_68 = V_4;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_67, L_68));
		int32_t L_69 = V_7;
		int32_t L_70 = L_69;
		V_7 = ((int32_t)il2cpp_codegen_add(L_70, 1));
		V_20 = L_70;
		int32_t L_71 = V_7;
		int32_t L_72 = V_14;
		int32_t L_73 = V_14;
		int32_t L_74 = V_13;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_71, L_72)), ((int32_t)(L_73>>8))))) <= ((int32_t)L_74)))
		{
			goto IL_011c;
		}
	}
	{
		return 0;
	}

IL_011c:
	{
		int32_t L_75 = V_14;
		if ((((int32_t)L_75) < ((int32_t)((int32_t)15))))
		{
			goto IL_018c;
		}
	}
	{
		int32_t L_76 = V_14;
		V_22 = ((int32_t)il2cpp_codegen_subtract(L_76, ((int32_t)15)));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_77 = ___2_dst;
		int32_t L_78 = V_20;
		NullCheck(L_77);
		(L_77)->SetAt(static_cast<il2cpp_array_size_t>(L_78), (uint8_t)((int32_t)240));
		int32_t L_79 = V_22;
		if ((((int32_t)L_79) <= ((int32_t)((int32_t)254))))
		{
			goto IL_017e;
		}
	}

IL_013b:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_80 = ___2_dst;
		int32_t L_81 = V_7;
		int32_t L_82 = L_81;
		V_7 = ((int32_t)il2cpp_codegen_add(L_82, 1));
		NullCheck(L_80);
		(L_80)->SetAt(static_cast<il2cpp_array_size_t>(L_82), (uint8_t)((int32_t)255));
		int32_t L_83 = V_22;
		V_22 = ((int32_t)il2cpp_codegen_subtract(L_83, ((int32_t)255)));
		int32_t L_84 = V_22;
		if ((((int32_t)L_84) > ((int32_t)((int32_t)254))))
		{
			goto IL_013b;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_85 = ___2_dst;
		int32_t L_86 = V_7;
		int32_t L_87 = L_86;
		V_7 = ((int32_t)il2cpp_codegen_add(L_87, 1));
		int32_t L_88 = V_22;
		NullCheck(L_85);
		(L_85)->SetAt(static_cast<il2cpp_array_size_t>(L_87), (uint8_t)((int32_t)(uint8_t)L_88));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_89 = ___1_src;
		int32_t L_90 = V_4;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_91 = ___2_dst;
		int32_t L_92 = V_7;
		int32_t L_93 = V_14;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D(L_89, L_90, L_91, L_92, L_93, NULL);
		int32_t L_94 = V_7;
		int32_t L_95 = V_14;
		V_7 = ((int32_t)il2cpp_codegen_add(L_94, L_95));
		goto IL_01b0;
	}

IL_017e:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_96 = ___2_dst;
		int32_t L_97 = V_7;
		int32_t L_98 = L_97;
		V_7 = ((int32_t)il2cpp_codegen_add(L_98, 1));
		int32_t L_99 = V_22;
		NullCheck(L_96);
		(L_96)->SetAt(static_cast<il2cpp_array_size_t>(L_98), (uint8_t)((int32_t)(uint8_t)L_99));
		goto IL_0195;
	}

IL_018c:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_100 = ___2_dst;
		int32_t L_101 = V_20;
		int32_t L_102 = V_14;
		NullCheck(L_100);
		(L_100)->SetAt(static_cast<il2cpp_array_size_t>(L_101), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_102<<4))));
	}

IL_0195:
	{
		int32_t L_103 = V_14;
		if ((((int32_t)L_103) <= ((int32_t)0)))
		{
			goto IL_01b0;
		}
	}
	{
		int32_t L_104 = V_7;
		int32_t L_105 = V_14;
		V_1 = ((int32_t)il2cpp_codegen_add(L_104, L_105));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_106 = ___1_src;
		int32_t L_107 = V_4;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_108 = ___2_dst;
		int32_t L_109 = V_7;
		int32_t L_110 = V_1;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_111;
		L_111 = LZ4Codec_WildCopy_mE6E7FF3DC7D46D37614FDE84DDDEA5D03B0B5F94(L_106, L_107, L_108, L_109, L_110, NULL);
		int32_t L_112 = V_1;
		V_7 = L_112;
	}

IL_01b0:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_113 = ___2_dst;
		int32_t L_114 = V_7;
		int32_t L_115 = V_2;
		int32_t L_116 = V_19;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_Poke2_mA9D6096893521372F0C65B006AE5A25C59E869E1(L_113, L_114, (uint16_t)((int32_t)(uint16_t)((int32_t)il2cpp_codegen_subtract(L_115, L_116))), NULL);
		int32_t L_117 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add(L_117, 2));
		int32_t L_118 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_118, 4));
		int32_t L_119 = V_19;
		V_19 = ((int32_t)il2cpp_codegen_add(L_119, 4));
		int32_t L_120 = V_2;
		V_4 = L_120;
		goto IL_0204;
	}

IL_01d2:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_121 = ___1_src;
		int32_t L_122 = V_19;
		int32_t L_123 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_124;
		L_124 = LZ4Codec_Xor4_mECF76BD60591364408CC4E94D6F913291AC4B8CB(L_121, L_122, L_123, NULL);
		V_23 = L_124;
		int32_t L_125 = V_23;
		if (L_125)
		{
			goto IL_01ed;
		}
	}
	{
		int32_t L_126 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_126, 4));
		int32_t L_127 = V_19;
		V_19 = ((int32_t)il2cpp_codegen_add(L_127, 4));
		goto IL_0204;
	}

IL_01ed:
	{
		int32_t L_128 = V_2;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_129 = V_0;
		int32_t L_130 = V_23;
		int32_t L_131 = V_23;
		NullCheck(L_129);
		uintptr_t L_132 = ((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply(((int32_t)(L_130&((-L_131)))), ((int32_t)125613361)))>>((int32_t)27))));
		int32_t L_133 = (L_129)->GetAt(static_cast<il2cpp_array_size_t>(L_132));
		V_2 = ((int32_t)il2cpp_codegen_add(L_128, L_133));
		goto IL_0235;
	}

IL_0204:
	{
		int32_t L_134 = V_2;
		int32_t L_135 = V_11;
		if ((((int32_t)L_134) < ((int32_t)L_135)))
		{
			goto IL_01d2;
		}
	}
	{
		int32_t L_136 = V_2;
		int32_t L_137 = V_10;
		if ((((int32_t)L_136) >= ((int32_t)L_137)))
		{
			goto IL_0223;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_138 = ___1_src;
		int32_t L_139 = V_19;
		int32_t L_140 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_141;
		L_141 = LZ4Codec_Equal2_m05C0F8A90FA336B8EFA50F98F2485EAF9A00FEF6(L_138, L_139, L_140, NULL);
		if (!L_141)
		{
			goto IL_0223;
		}
	}
	{
		int32_t L_142 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_142, 2));
		int32_t L_143 = V_19;
		V_19 = ((int32_t)il2cpp_codegen_add(L_143, 2));
	}

IL_0223:
	{
		int32_t L_144 = V_2;
		int32_t L_145 = V_9;
		if ((((int32_t)L_144) >= ((int32_t)L_145)))
		{
			goto IL_0235;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_146 = ___1_src;
		int32_t L_147 = V_19;
		NullCheck(L_146);
		int32_t L_148 = L_147;
		uint8_t L_149 = (L_146)->GetAt(static_cast<il2cpp_array_size_t>(L_148));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_150 = ___1_src;
		int32_t L_151 = V_2;
		NullCheck(L_150);
		int32_t L_152 = L_151;
		uint8_t L_153 = (L_150)->GetAt(static_cast<il2cpp_array_size_t>(L_152));
		if ((!(((uint32_t)L_149) == ((uint32_t)L_153))))
		{
			goto IL_0235;
		}
	}
	{
		int32_t L_154 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_154, 1));
	}

IL_0235:
	{
		int32_t L_155 = V_2;
		int32_t L_156 = V_4;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_155, L_156));
		int32_t L_157 = V_7;
		int32_t L_158 = V_14;
		int32_t L_159 = V_12;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_157, ((int32_t)(L_158>>8))))) <= ((int32_t)L_159)))
		{
			goto IL_0248;
		}
	}
	{
		return 0;
	}

IL_0248:
	{
		int32_t L_160 = V_14;
		if ((((int32_t)L_160) < ((int32_t)((int32_t)15))))
		{
			goto IL_02cc;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_161 = ___2_dst;
		int32_t L_162 = V_20;
		NullCheck(L_161);
		uint8_t* L_163 = ((L_161)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_162)));
		uint8_t L_164 = (*(uint8_t*)L_163);
		*(uint8_t*)L_163 = (uint8_t)((int32_t)(uint8_t)((int32_t)il2cpp_codegen_add((int32_t)L_164, ((int32_t)15))));
		int32_t L_165 = V_14;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_165, ((int32_t)15)));
		goto IL_0294;
	}

IL_026e:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_166 = ___2_dst;
		int32_t L_167 = V_7;
		int32_t L_168 = L_167;
		V_7 = ((int32_t)il2cpp_codegen_add(L_168, 1));
		NullCheck(L_166);
		(L_166)->SetAt(static_cast<il2cpp_array_size_t>(L_168), (uint8_t)((int32_t)255));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_169 = ___2_dst;
		int32_t L_170 = V_7;
		int32_t L_171 = L_170;
		V_7 = ((int32_t)il2cpp_codegen_add(L_171, 1));
		NullCheck(L_169);
		(L_169)->SetAt(static_cast<il2cpp_array_size_t>(L_171), (uint8_t)((int32_t)255));
		int32_t L_172 = V_14;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_172, ((int32_t)510)));
	}

IL_0294:
	{
		int32_t L_173 = V_14;
		if ((((int32_t)L_173) > ((int32_t)((int32_t)509))))
		{
			goto IL_026e;
		}
	}
	{
		int32_t L_174 = V_14;
		if ((((int32_t)L_174) <= ((int32_t)((int32_t)254))))
		{
			goto IL_02be;
		}
	}
	{
		int32_t L_175 = V_14;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_175, ((int32_t)255)));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_176 = ___2_dst;
		int32_t L_177 = V_7;
		int32_t L_178 = L_177;
		V_7 = ((int32_t)il2cpp_codegen_add(L_178, 1));
		NullCheck(L_176);
		(L_176)->SetAt(static_cast<il2cpp_array_size_t>(L_178), (uint8_t)((int32_t)255));
	}

IL_02be:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_179 = ___2_dst;
		int32_t L_180 = V_7;
		int32_t L_181 = L_180;
		V_7 = ((int32_t)il2cpp_codegen_add(L_181, 1));
		int32_t L_182 = V_14;
		NullCheck(L_179);
		(L_179)->SetAt(static_cast<il2cpp_array_size_t>(L_181), (uint8_t)((int32_t)(uint8_t)L_182));
		goto IL_02e4;
	}

IL_02cc:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_183 = ___2_dst;
		int32_t L_184 = V_20;
		NullCheck(L_183);
		uint8_t* L_185 = ((L_183)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_184)));
		uint8_t L_186 = (*(uint8_t*)L_185);
		int32_t L_187 = V_14;
		*(uint8_t*)L_185 = (uint8_t)((int32_t)(uint8_t)((int32_t)il2cpp_codegen_add((int32_t)L_186, ((int32_t)(uint8_t)L_187))));
	}

IL_02e4:
	{
		int32_t L_188 = V_2;
		int32_t L_189 = V_6;
		if ((((int32_t)L_188) <= ((int32_t)L_189)))
		{
			goto IL_02f1;
		}
	}
	{
		int32_t L_190 = V_2;
		V_4 = L_190;
		goto IL_0375;
	}

IL_02f1:
	{
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_191 = ___0_hash_table;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_192 = ___1_src;
		int32_t L_193 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_194;
		L_194 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_192, ((int32_t)il2cpp_codegen_subtract(L_193, 2)), NULL);
		int32_t L_195 = V_2;
		int32_t L_196 = V_3;
		NullCheck(L_191);
		(L_191)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_194, ((int32_t)-1640531535)))>>((int32_t)20))))), (int32_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_subtract(L_195, 2)), L_196)));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_197 = ___1_src;
		int32_t L_198 = V_2;
		uint32_t L_199;
		L_199 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_197, L_198, NULL);
		V_15 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_199, ((int32_t)-1640531535)))>>((int32_t)20)));
		int32_t L_200 = V_3;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_201 = ___0_hash_table;
		uint32_t L_202 = V_15;
		NullCheck(L_201);
		uintptr_t L_203 = ((uintptr_t)L_202);
		int32_t L_204 = (L_201)->GetAt(static_cast<il2cpp_array_size_t>(L_203));
		V_19 = ((int32_t)il2cpp_codegen_add(L_200, L_204));
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_205 = ___0_hash_table;
		uint32_t L_206 = V_15;
		int32_t L_207 = V_2;
		int32_t L_208 = V_3;
		NullCheck(L_205);
		(L_205)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)L_206)), (int32_t)((int32_t)il2cpp_codegen_subtract(L_207, L_208)));
		int32_t L_209 = V_19;
		int32_t L_210 = V_2;
		if ((((int32_t)L_209) <= ((int32_t)((int32_t)il2cpp_codegen_subtract(L_210, ((int32_t)65536))))))
		{
			goto IL_0357;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_211 = ___1_src;
		int32_t L_212 = V_19;
		int32_t L_213 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_214;
		L_214 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_211, L_212, L_213, NULL);
		if (!L_214)
		{
			goto IL_0357;
		}
	}
	{
		int32_t L_215 = V_7;
		int32_t L_216 = L_215;
		V_7 = ((int32_t)il2cpp_codegen_add(L_216, 1));
		V_20 = L_216;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_217 = ___2_dst;
		int32_t L_218 = V_20;
		NullCheck(L_217);
		(L_217)->SetAt(static_cast<il2cpp_array_size_t>(L_218), (uint8_t)0);
		goto IL_01b0;
	}

IL_0357:
	{
		int32_t L_219 = V_2;
		int32_t L_220 = L_219;
		V_2 = ((int32_t)il2cpp_codegen_add(L_220, 1));
		V_4 = L_220;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_221 = ___1_src;
		int32_t L_222 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_223;
		L_223 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_221, L_222, NULL);
		V_16 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_223, ((int32_t)-1640531535)))>>((int32_t)20)));
		goto IL_0078;
	}

IL_0375:
	{
		int32_t L_224 = V_5;
		int32_t L_225 = V_4;
		V_24 = ((int32_t)il2cpp_codegen_subtract(L_224, L_225));
		int32_t L_226 = V_7;
		int32_t L_227 = V_24;
		int32_t L_228 = V_24;
		int32_t L_229 = V_8;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_226, L_227)), 1)), ((int32_t)(((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_228, ((int32_t)255))), ((int32_t)15)))/((int32_t)255)))))) <= ((int32_t)L_229)))
		{
			goto IL_039b;
		}
	}
	{
		return 0;
	}

IL_039b:
	{
		int32_t L_230 = V_24;
		if ((((int32_t)L_230) < ((int32_t)((int32_t)15))))
		{
			goto IL_03e7;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_231 = ___2_dst;
		int32_t L_232 = V_7;
		int32_t L_233 = L_232;
		V_7 = ((int32_t)il2cpp_codegen_add(L_233, 1));
		NullCheck(L_231);
		(L_231)->SetAt(static_cast<il2cpp_array_size_t>(L_233), (uint8_t)((int32_t)240));
		int32_t L_234 = V_24;
		V_24 = ((int32_t)il2cpp_codegen_subtract(L_234, ((int32_t)15)));
		goto IL_03d0;
	}

IL_03b8:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_235 = ___2_dst;
		int32_t L_236 = V_7;
		int32_t L_237 = L_236;
		V_7 = ((int32_t)il2cpp_codegen_add(L_237, 1));
		NullCheck(L_235);
		(L_235)->SetAt(static_cast<il2cpp_array_size_t>(L_237), (uint8_t)((int32_t)255));
		int32_t L_238 = V_24;
		V_24 = ((int32_t)il2cpp_codegen_subtract(L_238, ((int32_t)255)));
	}

IL_03d0:
	{
		int32_t L_239 = V_24;
		if ((((int32_t)L_239) > ((int32_t)((int32_t)254))))
		{
			goto IL_03b8;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_240 = ___2_dst;
		int32_t L_241 = V_7;
		int32_t L_242 = L_241;
		V_7 = ((int32_t)il2cpp_codegen_add(L_242, 1));
		int32_t L_243 = V_24;
		NullCheck(L_240);
		(L_240)->SetAt(static_cast<il2cpp_array_size_t>(L_242), (uint8_t)((int32_t)(uint8_t)L_243));
		goto IL_03f5;
	}

IL_03e7:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_244 = ___2_dst;
		int32_t L_245 = V_7;
		int32_t L_246 = L_245;
		V_7 = ((int32_t)il2cpp_codegen_add(L_246, 1));
		int32_t L_247 = V_24;
		NullCheck(L_244);
		(L_244)->SetAt(static_cast<il2cpp_array_size_t>(L_246), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_247<<4))));
	}

IL_03f5:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_248 = ___1_src;
		int32_t L_249 = V_4;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_250 = ___2_dst;
		int32_t L_251 = V_7;
		int32_t L_252 = V_5;
		int32_t L_253 = V_4;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D(L_248, L_249, L_250, L_251, ((int32_t)il2cpp_codegen_subtract(L_252, L_253)), NULL);
		int32_t L_254 = V_7;
		int32_t L_255 = V_5;
		int32_t L_256 = V_4;
		V_7 = ((int32_t)il2cpp_codegen_add(L_254, ((int32_t)il2cpp_codegen_subtract(L_255, L_256))));
		int32_t L_257 = V_7;
		int32_t L_258 = ___4_dst_0;
		return ((int32_t)il2cpp_codegen_subtract(L_257, L_258));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compress64kCtx_safe32_m673F7EC888DEAA590569AE1F7CAEACA2575B1573 (UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* ___0_hash_table, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___2_dst, int32_t ___3_src_0, int32_t ___4_dst_0, int32_t ___5_src_len, int32_t ___6_dst_maxlen, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	int32_t V_13 = 0;
	int32_t V_14 = 0;
	int32_t V_15 = 0;
	uint32_t V_16 = 0;
	uint32_t V_17 = 0;
	int32_t V_18 = 0;
	int32_t V_19 = 0;
	int32_t V_20 = 0;
	int32_t V_21 = 0;
	int32_t V_22 = 0;
	int32_t V_23 = 0;
	int32_t V_24 = 0;
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_0 = ((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DEBRUIJN_TABLE_32;
		V_0 = L_0;
		int32_t L_1 = ___3_src_0;
		V_2 = L_1;
		int32_t L_2 = V_2;
		V_3 = L_2;
		int32_t L_3 = V_2;
		V_4 = L_3;
		int32_t L_4 = V_2;
		int32_t L_5 = ___5_src_len;
		V_5 = ((int32_t)il2cpp_codegen_add(L_4, L_5));
		int32_t L_6 = V_5;
		V_6 = ((int32_t)il2cpp_codegen_subtract(L_6, ((int32_t)12)));
		int32_t L_7 = ___4_dst_0;
		V_7 = L_7;
		int32_t L_8 = V_7;
		int32_t L_9 = ___6_dst_maxlen;
		V_8 = ((int32_t)il2cpp_codegen_add(L_8, L_9));
		int32_t L_10 = V_5;
		V_9 = ((int32_t)il2cpp_codegen_subtract(L_10, 5));
		int32_t L_11 = V_9;
		V_10 = ((int32_t)il2cpp_codegen_subtract(L_11, 1));
		int32_t L_12 = V_9;
		V_11 = ((int32_t)il2cpp_codegen_subtract(L_12, 3));
		int32_t L_13 = V_8;
		V_12 = ((int32_t)il2cpp_codegen_subtract(L_13, 6));
		int32_t L_14 = V_8;
		V_13 = ((int32_t)il2cpp_codegen_subtract(L_14, 8));
		int32_t L_15 = ___5_src_len;
		if ((((int32_t)L_15) < ((int32_t)((int32_t)13))))
		{
			goto IL_0346;
		}
	}
	{
		int32_t L_16 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_16, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = ___1_src;
		int32_t L_18 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_19;
		L_19 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_17, L_18, NULL);
		V_17 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_19, ((int32_t)-1640531535)))>>((int32_t)19)));
	}

IL_0062:
	{
		V_18 = ((int32_t)67);
		int32_t L_20 = V_2;
		V_19 = L_20;
	}

IL_0069:
	{
		uint32_t L_21 = V_17;
		V_16 = L_21;
		int32_t L_22 = V_18;
		int32_t L_23 = L_22;
		V_18 = ((int32_t)il2cpp_codegen_add(L_23, 1));
		V_22 = ((int32_t)(L_23>>6));
		int32_t L_24 = V_19;
		V_2 = L_24;
		int32_t L_25 = V_2;
		int32_t L_26 = V_22;
		V_19 = ((int32_t)il2cpp_codegen_add(L_25, L_26));
		int32_t L_27 = V_19;
		int32_t L_28 = V_6;
		if ((((int32_t)L_27) > ((int32_t)L_28)))
		{
			goto IL_0346;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_29 = ___1_src;
		int32_t L_30 = V_19;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_31;
		L_31 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_29, L_30, NULL);
		V_17 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_31, ((int32_t)-1640531535)))>>((int32_t)19)));
		int32_t L_32 = V_4;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_33 = ___0_hash_table;
		uint32_t L_34 = V_16;
		NullCheck(L_33);
		uintptr_t L_35 = ((uintptr_t)L_34);
		uint16_t L_36 = (L_33)->GetAt(static_cast<il2cpp_array_size_t>(L_35));
		V_20 = ((int32_t)il2cpp_codegen_add(L_32, (int32_t)L_36));
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_37 = ___0_hash_table;
		uint32_t L_38 = V_16;
		int32_t L_39 = V_2;
		int32_t L_40 = V_4;
		NullCheck(L_37);
		(L_37)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)L_38)), (uint16_t)((int32_t)(uint16_t)((int32_t)il2cpp_codegen_subtract(L_39, L_40))));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_41 = ___1_src;
		int32_t L_42 = V_20;
		int32_t L_43 = V_2;
		bool L_44;
		L_44 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_41, L_42, L_43, NULL);
		if (!L_44)
		{
			goto IL_0069;
		}
	}
	{
		goto IL_00c8;
	}

IL_00be:
	{
		int32_t L_45 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_subtract(L_45, 1));
		int32_t L_46 = V_20;
		V_20 = ((int32_t)il2cpp_codegen_subtract(L_46, 1));
	}

IL_00c8:
	{
		int32_t L_47 = V_2;
		int32_t L_48 = V_3;
		if ((((int32_t)L_47) <= ((int32_t)L_48)))
		{
			goto IL_00de;
		}
	}
	{
		int32_t L_49 = V_20;
		int32_t L_50 = ___3_src_0;
		if ((((int32_t)L_49) <= ((int32_t)L_50)))
		{
			goto IL_00de;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_51 = ___1_src;
		int32_t L_52 = V_2;
		NullCheck(L_51);
		int32_t L_53 = ((int32_t)il2cpp_codegen_subtract(L_52, 1));
		uint8_t L_54 = (L_51)->GetAt(static_cast<il2cpp_array_size_t>(L_53));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_55 = ___1_src;
		int32_t L_56 = V_20;
		NullCheck(L_55);
		int32_t L_57 = ((int32_t)il2cpp_codegen_subtract(L_56, 1));
		uint8_t L_58 = (L_55)->GetAt(static_cast<il2cpp_array_size_t>(L_57));
		if ((((int32_t)L_54) == ((int32_t)L_58)))
		{
			goto IL_00be;
		}
	}

IL_00de:
	{
		int32_t L_59 = V_2;
		int32_t L_60 = V_3;
		V_15 = ((int32_t)il2cpp_codegen_subtract(L_59, L_60));
		int32_t L_61 = V_7;
		int32_t L_62 = L_61;
		V_7 = ((int32_t)il2cpp_codegen_add(L_62, 1));
		V_21 = L_62;
		int32_t L_63 = V_7;
		int32_t L_64 = V_15;
		int32_t L_65 = V_15;
		int32_t L_66 = V_13;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_63, L_64)), ((int32_t)(L_65>>8))))) <= ((int32_t)L_66)))
		{
			goto IL_00fc;
		}
	}
	{
		return 0;
	}

IL_00fc:
	{
		int32_t L_67 = V_15;
		if ((((int32_t)L_67) < ((int32_t)((int32_t)15))))
		{
			goto IL_016b;
		}
	}
	{
		int32_t L_68 = V_15;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_68, ((int32_t)15)));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_69 = ___2_dst;
		int32_t L_70 = V_21;
		NullCheck(L_69);
		(L_69)->SetAt(static_cast<il2cpp_array_size_t>(L_70), (uint8_t)((int32_t)240));
		int32_t L_71 = V_14;
		if ((((int32_t)L_71) <= ((int32_t)((int32_t)254))))
		{
			goto IL_015d;
		}
	}

IL_011b:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_72 = ___2_dst;
		int32_t L_73 = V_7;
		int32_t L_74 = L_73;
		V_7 = ((int32_t)il2cpp_codegen_add(L_74, 1));
		NullCheck(L_72);
		(L_72)->SetAt(static_cast<il2cpp_array_size_t>(L_74), (uint8_t)((int32_t)255));
		int32_t L_75 = V_14;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_75, ((int32_t)255)));
		int32_t L_76 = V_14;
		if ((((int32_t)L_76) > ((int32_t)((int32_t)254))))
		{
			goto IL_011b;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_77 = ___2_dst;
		int32_t L_78 = V_7;
		int32_t L_79 = L_78;
		V_7 = ((int32_t)il2cpp_codegen_add(L_79, 1));
		int32_t L_80 = V_14;
		NullCheck(L_77);
		(L_77)->SetAt(static_cast<il2cpp_array_size_t>(L_79), (uint8_t)((int32_t)(uint8_t)L_80));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_81 = ___1_src;
		int32_t L_82 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_83 = ___2_dst;
		int32_t L_84 = V_7;
		int32_t L_85 = V_15;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D(L_81, L_82, L_83, L_84, L_85, NULL);
		int32_t L_86 = V_7;
		int32_t L_87 = V_15;
		V_7 = ((int32_t)il2cpp_codegen_add(L_86, L_87));
		goto IL_018e;
	}

IL_015d:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_88 = ___2_dst;
		int32_t L_89 = V_7;
		int32_t L_90 = L_89;
		V_7 = ((int32_t)il2cpp_codegen_add(L_90, 1));
		int32_t L_91 = V_14;
		NullCheck(L_88);
		(L_88)->SetAt(static_cast<il2cpp_array_size_t>(L_90), (uint8_t)((int32_t)(uint8_t)L_91));
		goto IL_0174;
	}

IL_016b:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_92 = ___2_dst;
		int32_t L_93 = V_21;
		int32_t L_94 = V_15;
		NullCheck(L_92);
		(L_92)->SetAt(static_cast<il2cpp_array_size_t>(L_93), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_94<<4))));
	}

IL_0174:
	{
		int32_t L_95 = V_15;
		if ((((int32_t)L_95) <= ((int32_t)0)))
		{
			goto IL_018e;
		}
	}
	{
		int32_t L_96 = V_7;
		int32_t L_97 = V_15;
		V_1 = ((int32_t)il2cpp_codegen_add(L_96, L_97));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_98 = ___1_src;
		int32_t L_99 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_100 = ___2_dst;
		int32_t L_101 = V_7;
		int32_t L_102 = V_1;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_103;
		L_103 = LZ4Codec_WildCopy_mE6E7FF3DC7D46D37614FDE84DDDEA5D03B0B5F94(L_98, L_99, L_100, L_101, L_102, NULL);
		int32_t L_104 = V_1;
		V_7 = L_104;
	}

IL_018e:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_105 = ___2_dst;
		int32_t L_106 = V_7;
		int32_t L_107 = V_2;
		int32_t L_108 = V_20;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_Poke2_mA9D6096893521372F0C65B006AE5A25C59E869E1(L_105, L_106, (uint16_t)((int32_t)(uint16_t)((int32_t)il2cpp_codegen_subtract(L_107, L_108))), NULL);
		int32_t L_109 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add(L_109, 2));
		int32_t L_110 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_110, 4));
		int32_t L_111 = V_20;
		V_20 = ((int32_t)il2cpp_codegen_add(L_111, 4));
		int32_t L_112 = V_2;
		V_3 = L_112;
		goto IL_01e1;
	}

IL_01af:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_113 = ___1_src;
		int32_t L_114 = V_20;
		int32_t L_115 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_116;
		L_116 = LZ4Codec_Xor4_mECF76BD60591364408CC4E94D6F913291AC4B8CB(L_113, L_114, L_115, NULL);
		V_23 = L_116;
		int32_t L_117 = V_23;
		if (L_117)
		{
			goto IL_01ca;
		}
	}
	{
		int32_t L_118 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_118, 4));
		int32_t L_119 = V_20;
		V_20 = ((int32_t)il2cpp_codegen_add(L_119, 4));
		goto IL_01e1;
	}

IL_01ca:
	{
		int32_t L_120 = V_2;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_121 = V_0;
		int32_t L_122 = V_23;
		int32_t L_123 = V_23;
		NullCheck(L_121);
		uintptr_t L_124 = ((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply(((int32_t)(L_122&((-L_123)))), ((int32_t)125613361)))>>((int32_t)27))));
		int32_t L_125 = (L_121)->GetAt(static_cast<il2cpp_array_size_t>(L_124));
		V_2 = ((int32_t)il2cpp_codegen_add(L_120, L_125));
		goto IL_0212;
	}

IL_01e1:
	{
		int32_t L_126 = V_2;
		int32_t L_127 = V_11;
		if ((((int32_t)L_126) < ((int32_t)L_127)))
		{
			goto IL_01af;
		}
	}
	{
		int32_t L_128 = V_2;
		int32_t L_129 = V_10;
		if ((((int32_t)L_128) >= ((int32_t)L_129)))
		{
			goto IL_0200;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_130 = ___1_src;
		int32_t L_131 = V_20;
		int32_t L_132 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_133;
		L_133 = LZ4Codec_Equal2_m05C0F8A90FA336B8EFA50F98F2485EAF9A00FEF6(L_130, L_131, L_132, NULL);
		if (!L_133)
		{
			goto IL_0200;
		}
	}
	{
		int32_t L_134 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_134, 2));
		int32_t L_135 = V_20;
		V_20 = ((int32_t)il2cpp_codegen_add(L_135, 2));
	}

IL_0200:
	{
		int32_t L_136 = V_2;
		int32_t L_137 = V_9;
		if ((((int32_t)L_136) >= ((int32_t)L_137)))
		{
			goto IL_0212;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_138 = ___1_src;
		int32_t L_139 = V_20;
		NullCheck(L_138);
		int32_t L_140 = L_139;
		uint8_t L_141 = (L_138)->GetAt(static_cast<il2cpp_array_size_t>(L_140));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_142 = ___1_src;
		int32_t L_143 = V_2;
		NullCheck(L_142);
		int32_t L_144 = L_143;
		uint8_t L_145 = (L_142)->GetAt(static_cast<il2cpp_array_size_t>(L_144));
		if ((!(((uint32_t)L_141) == ((uint32_t)L_145))))
		{
			goto IL_0212;
		}
	}
	{
		int32_t L_146 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_146, 1));
	}

IL_0212:
	{
		int32_t L_147 = V_2;
		int32_t L_148 = V_3;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_147, L_148));
		int32_t L_149 = V_7;
		int32_t L_150 = V_14;
		int32_t L_151 = V_12;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_149, ((int32_t)(L_150>>8))))) <= ((int32_t)L_151)))
		{
			goto IL_0224;
		}
	}
	{
		return 0;
	}

IL_0224:
	{
		int32_t L_152 = V_14;
		if ((((int32_t)L_152) < ((int32_t)((int32_t)15))))
		{
			goto IL_02a8;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_153 = ___2_dst;
		int32_t L_154 = V_21;
		NullCheck(L_153);
		uint8_t* L_155 = ((L_153)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_154)));
		uint8_t L_156 = (*(uint8_t*)L_155);
		*(uint8_t*)L_155 = (uint8_t)((int32_t)(uint8_t)((int32_t)il2cpp_codegen_add((int32_t)L_156, ((int32_t)15))));
		int32_t L_157 = V_14;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_157, ((int32_t)15)));
		goto IL_0270;
	}

IL_024a:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_158 = ___2_dst;
		int32_t L_159 = V_7;
		int32_t L_160 = L_159;
		V_7 = ((int32_t)il2cpp_codegen_add(L_160, 1));
		NullCheck(L_158);
		(L_158)->SetAt(static_cast<il2cpp_array_size_t>(L_160), (uint8_t)((int32_t)255));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_161 = ___2_dst;
		int32_t L_162 = V_7;
		int32_t L_163 = L_162;
		V_7 = ((int32_t)il2cpp_codegen_add(L_163, 1));
		NullCheck(L_161);
		(L_161)->SetAt(static_cast<il2cpp_array_size_t>(L_163), (uint8_t)((int32_t)255));
		int32_t L_164 = V_14;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_164, ((int32_t)510)));
	}

IL_0270:
	{
		int32_t L_165 = V_14;
		if ((((int32_t)L_165) > ((int32_t)((int32_t)509))))
		{
			goto IL_024a;
		}
	}
	{
		int32_t L_166 = V_14;
		if ((((int32_t)L_166) <= ((int32_t)((int32_t)254))))
		{
			goto IL_029a;
		}
	}
	{
		int32_t L_167 = V_14;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_167, ((int32_t)255)));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_168 = ___2_dst;
		int32_t L_169 = V_7;
		int32_t L_170 = L_169;
		V_7 = ((int32_t)il2cpp_codegen_add(L_170, 1));
		NullCheck(L_168);
		(L_168)->SetAt(static_cast<il2cpp_array_size_t>(L_170), (uint8_t)((int32_t)255));
	}

IL_029a:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_171 = ___2_dst;
		int32_t L_172 = V_7;
		int32_t L_173 = L_172;
		V_7 = ((int32_t)il2cpp_codegen_add(L_173, 1));
		int32_t L_174 = V_14;
		NullCheck(L_171);
		(L_171)->SetAt(static_cast<il2cpp_array_size_t>(L_173), (uint8_t)((int32_t)(uint8_t)L_174));
		goto IL_02c0;
	}

IL_02a8:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_175 = ___2_dst;
		int32_t L_176 = V_21;
		NullCheck(L_175);
		uint8_t* L_177 = ((L_175)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_176)));
		uint8_t L_178 = (*(uint8_t*)L_177);
		int32_t L_179 = V_14;
		*(uint8_t*)L_177 = (uint8_t)((int32_t)(uint8_t)((int32_t)il2cpp_codegen_add((int32_t)L_178, ((int32_t)(uint8_t)L_179))));
	}

IL_02c0:
	{
		int32_t L_180 = V_2;
		int32_t L_181 = V_6;
		if ((((int32_t)L_180) <= ((int32_t)L_181)))
		{
			goto IL_02c9;
		}
	}
	{
		int32_t L_182 = V_2;
		V_3 = L_182;
		goto IL_0346;
	}

IL_02c9:
	{
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_183 = ___0_hash_table;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_184 = ___1_src;
		int32_t L_185 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_186;
		L_186 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_184, ((int32_t)il2cpp_codegen_subtract(L_185, 2)), NULL);
		int32_t L_187 = V_2;
		int32_t L_188 = V_4;
		NullCheck(L_183);
		(L_183)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_186, ((int32_t)-1640531535)))>>((int32_t)19))))), (uint16_t)((int32_t)(uint16_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_subtract(L_187, 2)), L_188))));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_189 = ___1_src;
		int32_t L_190 = V_2;
		uint32_t L_191;
		L_191 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_189, L_190, NULL);
		V_16 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_191, ((int32_t)-1640531535)))>>((int32_t)19)));
		int32_t L_192 = V_4;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_193 = ___0_hash_table;
		uint32_t L_194 = V_16;
		NullCheck(L_193);
		uintptr_t L_195 = ((uintptr_t)L_194);
		uint16_t L_196 = (L_193)->GetAt(static_cast<il2cpp_array_size_t>(L_195));
		V_20 = ((int32_t)il2cpp_codegen_add(L_192, (int32_t)L_196));
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_197 = ___0_hash_table;
		uint32_t L_198 = V_16;
		int32_t L_199 = V_2;
		int32_t L_200 = V_4;
		NullCheck(L_197);
		(L_197)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)L_198)), (uint16_t)((int32_t)(uint16_t)((int32_t)il2cpp_codegen_subtract(L_199, L_200))));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_201 = ___1_src;
		int32_t L_202 = V_20;
		int32_t L_203 = V_2;
		bool L_204;
		L_204 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_201, L_202, L_203, NULL);
		if (!L_204)
		{
			goto IL_0329;
		}
	}
	{
		int32_t L_205 = V_7;
		int32_t L_206 = L_205;
		V_7 = ((int32_t)il2cpp_codegen_add(L_206, 1));
		V_21 = L_206;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_207 = ___2_dst;
		int32_t L_208 = V_21;
		NullCheck(L_207);
		(L_207)->SetAt(static_cast<il2cpp_array_size_t>(L_208), (uint8_t)0);
		goto IL_018e;
	}

IL_0329:
	{
		int32_t L_209 = V_2;
		int32_t L_210 = L_209;
		V_2 = ((int32_t)il2cpp_codegen_add(L_210, 1));
		V_3 = L_210;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_211 = ___1_src;
		int32_t L_212 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_213;
		L_213 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_211, L_212, NULL);
		V_17 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_213, ((int32_t)-1640531535)))>>((int32_t)19)));
		goto IL_0062;
	}

IL_0346:
	{
		int32_t L_214 = V_5;
		int32_t L_215 = V_3;
		V_24 = ((int32_t)il2cpp_codegen_subtract(L_214, L_215));
		int32_t L_216 = V_7;
		int32_t L_217 = V_24;
		int32_t L_218 = V_24;
		int32_t L_219 = V_8;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_216, L_217)), 1)), ((int32_t)(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_subtract(L_218, ((int32_t)15))), ((int32_t)255)))/((int32_t)255)))))) <= ((int32_t)L_219)))
		{
			goto IL_036b;
		}
	}
	{
		return 0;
	}

IL_036b:
	{
		int32_t L_220 = V_24;
		if ((((int32_t)L_220) < ((int32_t)((int32_t)15))))
		{
			goto IL_03b7;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_221 = ___2_dst;
		int32_t L_222 = V_7;
		int32_t L_223 = L_222;
		V_7 = ((int32_t)il2cpp_codegen_add(L_223, 1));
		NullCheck(L_221);
		(L_221)->SetAt(static_cast<il2cpp_array_size_t>(L_223), (uint8_t)((int32_t)240));
		int32_t L_224 = V_24;
		V_24 = ((int32_t)il2cpp_codegen_subtract(L_224, ((int32_t)15)));
		goto IL_03a0;
	}

IL_0388:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_225 = ___2_dst;
		int32_t L_226 = V_7;
		int32_t L_227 = L_226;
		V_7 = ((int32_t)il2cpp_codegen_add(L_227, 1));
		NullCheck(L_225);
		(L_225)->SetAt(static_cast<il2cpp_array_size_t>(L_227), (uint8_t)((int32_t)255));
		int32_t L_228 = V_24;
		V_24 = ((int32_t)il2cpp_codegen_subtract(L_228, ((int32_t)255)));
	}

IL_03a0:
	{
		int32_t L_229 = V_24;
		if ((((int32_t)L_229) > ((int32_t)((int32_t)254))))
		{
			goto IL_0388;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_230 = ___2_dst;
		int32_t L_231 = V_7;
		int32_t L_232 = L_231;
		V_7 = ((int32_t)il2cpp_codegen_add(L_232, 1));
		int32_t L_233 = V_24;
		NullCheck(L_230);
		(L_230)->SetAt(static_cast<il2cpp_array_size_t>(L_232), (uint8_t)((int32_t)(uint8_t)L_233));
		goto IL_03c5;
	}

IL_03b7:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_234 = ___2_dst;
		int32_t L_235 = V_7;
		int32_t L_236 = L_235;
		V_7 = ((int32_t)il2cpp_codegen_add(L_236, 1));
		int32_t L_237 = V_24;
		NullCheck(L_234);
		(L_234)->SetAt(static_cast<il2cpp_array_size_t>(L_236), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_237<<4))));
	}

IL_03c5:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_238 = ___1_src;
		int32_t L_239 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_240 = ___2_dst;
		int32_t L_241 = V_7;
		int32_t L_242 = V_5;
		int32_t L_243 = V_3;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D(L_238, L_239, L_240, L_241, ((int32_t)il2cpp_codegen_subtract(L_242, L_243)), NULL);
		int32_t L_244 = V_7;
		int32_t L_245 = V_5;
		int32_t L_246 = V_3;
		V_7 = ((int32_t)il2cpp_codegen_add(L_244, ((int32_t)il2cpp_codegen_subtract(L_245, L_246))));
		int32_t L_247 = V_7;
		int32_t L_248 = ___4_dst_0;
		return ((int32_t)il2cpp_codegen_subtract(L_247, L_248));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_uncompress_safe32_m3FC0A591BB2EA8741B716213BE1364901C653D98 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_dst, int32_t ___2_src_0, int32_t ___3_dst_0, int32_t ___4_dst_len, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	uint8_t V_10 = 0x0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_0 = ((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DECODER_TABLE_32;
		V_0 = L_0;
		int32_t L_1 = ___2_src_0;
		V_2 = L_1;
		int32_t L_2 = ___3_dst_0;
		V_4 = L_2;
		int32_t L_3 = V_4;
		int32_t L_4 = ___4_dst_len;
		V_5 = ((int32_t)il2cpp_codegen_add(L_3, L_4));
		int32_t L_5 = V_5;
		V_7 = ((int32_t)il2cpp_codegen_subtract(L_5, 5));
		int32_t L_6 = V_5;
		V_8 = ((int32_t)il2cpp_codegen_subtract(L_6, 8));
		int32_t L_7 = V_5;
		V_9 = ((int32_t)il2cpp_codegen_subtract(L_7, 8));
	}

IL_0024:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_src;
		int32_t L_9 = V_2;
		int32_t L_10 = L_9;
		V_2 = ((int32_t)il2cpp_codegen_add(L_10, 1));
		NullCheck(L_8);
		int32_t L_11 = L_10;
		uint8_t L_12 = (L_8)->GetAt(static_cast<il2cpp_array_size_t>(L_11));
		V_10 = L_12;
		uint8_t L_13 = V_10;
		int32_t L_14 = ((int32_t)((int32_t)L_13>>4));
		V_11 = L_14;
		if ((!(((uint32_t)L_14) == ((uint32_t)((int32_t)15)))))
		{
			goto IL_005c;
		}
	}
	{
		goto IL_0044;
	}

IL_003a:
	{
		int32_t L_15 = V_11;
		V_11 = ((int32_t)il2cpp_codegen_add(L_15, ((int32_t)255)));
	}

IL_0044:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = ___0_src;
		int32_t L_17 = V_2;
		int32_t L_18 = L_17;
		V_2 = ((int32_t)il2cpp_codegen_add(L_18, 1));
		NullCheck(L_16);
		int32_t L_19 = L_18;
		uint8_t L_20 = (L_16)->GetAt(static_cast<il2cpp_array_size_t>(L_19));
		uint8_t L_21 = L_20;
		V_12 = L_21;
		if ((((int32_t)L_21) == ((int32_t)((int32_t)255))))
		{
			goto IL_003a;
		}
	}
	{
		int32_t L_22 = V_11;
		int32_t L_23 = V_12;
		V_11 = ((int32_t)il2cpp_codegen_add(L_22, L_23));
	}

IL_005c:
	{
		int32_t L_24 = V_4;
		int32_t L_25 = V_11;
		V_6 = ((int32_t)il2cpp_codegen_add(L_24, L_25));
		int32_t L_26 = V_6;
		int32_t L_27 = V_8;
		if ((((int32_t)L_26) <= ((int32_t)L_27)))
		{
			goto IL_0088;
		}
	}
	{
		int32_t L_28 = V_6;
		int32_t L_29 = V_5;
		if ((!(((uint32_t)L_28) == ((uint32_t)L_29))))
		{
			goto IL_01ce;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_30 = ___0_src;
		int32_t L_31 = V_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_32 = ___1_dst;
		int32_t L_33 = V_4;
		int32_t L_34 = V_11;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D(L_30, L_31, L_32, L_33, L_34, NULL);
		int32_t L_35 = V_2;
		int32_t L_36 = V_11;
		V_2 = ((int32_t)il2cpp_codegen_add(L_35, L_36));
		goto IL_01ca;
	}

IL_0088:
	{
		int32_t L_37 = V_4;
		int32_t L_38 = V_6;
		if ((((int32_t)L_37) >= ((int32_t)L_38)))
		{
			goto IL_00a5;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_39 = ___0_src;
		int32_t L_40 = V_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_41 = ___1_dst;
		int32_t L_42 = V_4;
		int32_t L_43 = V_6;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_44;
		L_44 = LZ4Codec_WildCopy_mE6E7FF3DC7D46D37614FDE84DDDEA5D03B0B5F94(L_39, L_40, L_41, L_42, L_43, NULL);
		V_1 = L_44;
		int32_t L_45 = V_2;
		int32_t L_46 = V_1;
		V_2 = ((int32_t)il2cpp_codegen_add(L_45, L_46));
		int32_t L_47 = V_4;
		int32_t L_48 = V_1;
		V_4 = ((int32_t)il2cpp_codegen_add(L_47, L_48));
	}

IL_00a5:
	{
		int32_t L_49 = V_2;
		int32_t L_50 = V_4;
		int32_t L_51 = V_6;
		V_2 = ((int32_t)il2cpp_codegen_subtract(L_49, ((int32_t)il2cpp_codegen_subtract(L_50, L_51))));
		int32_t L_52 = V_6;
		V_4 = L_52;
		int32_t L_53 = V_6;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_54 = ___0_src;
		int32_t L_55 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint16_t L_56;
		L_56 = LZ4Codec_Peek2_mE549DAC6B7C81F35C5B34C25AD3A6EDA5F44C008(L_54, L_55, NULL);
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_53, (int32_t)L_56));
		int32_t L_57 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_57, 2));
		int32_t L_58 = V_3;
		int32_t L_59 = ___3_dst_0;
		if ((((int32_t)L_58) < ((int32_t)L_59)))
		{
			goto IL_01ce;
		}
	}
	{
		uint8_t L_60 = V_10;
		int32_t L_61 = ((int32_t)((int32_t)L_60&((int32_t)15)));
		V_11 = L_61;
		if ((!(((uint32_t)L_61) == ((uint32_t)((int32_t)15)))))
		{
			goto IL_00f9;
		}
	}
	{
		goto IL_00e3;
	}

IL_00d5:
	{
		int32_t L_62 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_62, 1));
		int32_t L_63 = V_11;
		V_11 = ((int32_t)il2cpp_codegen_add(L_63, ((int32_t)255)));
	}

IL_00e3:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_64 = ___0_src;
		int32_t L_65 = V_2;
		NullCheck(L_64);
		int32_t L_66 = L_65;
		uint8_t L_67 = (L_64)->GetAt(static_cast<il2cpp_array_size_t>(L_66));
		if ((((int32_t)L_67) == ((int32_t)((int32_t)255))))
		{
			goto IL_00d5;
		}
	}
	{
		int32_t L_68 = V_11;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_69 = ___0_src;
		int32_t L_70 = V_2;
		int32_t L_71 = L_70;
		V_2 = ((int32_t)il2cpp_codegen_add(L_71, 1));
		NullCheck(L_69);
		int32_t L_72 = L_71;
		uint8_t L_73 = (L_69)->GetAt(static_cast<il2cpp_array_size_t>(L_72));
		V_11 = ((int32_t)il2cpp_codegen_add(L_68, (int32_t)L_73));
	}

IL_00f9:
	{
		int32_t L_74 = V_4;
		int32_t L_75 = V_3;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract(L_74, L_75))) >= ((int32_t)4)))
		{
			goto IL_014c;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_76 = ___1_dst;
		int32_t L_77 = V_4;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_78 = ___1_dst;
		int32_t L_79 = V_3;
		NullCheck(L_78);
		int32_t L_80 = L_79;
		uint8_t L_81 = (L_78)->GetAt(static_cast<il2cpp_array_size_t>(L_80));
		NullCheck(L_76);
		(L_76)->SetAt(static_cast<il2cpp_array_size_t>(L_77), (uint8_t)L_81);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_82 = ___1_dst;
		int32_t L_83 = V_4;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_84 = ___1_dst;
		int32_t L_85 = V_3;
		NullCheck(L_84);
		int32_t L_86 = ((int32_t)il2cpp_codegen_add(L_85, 1));
		uint8_t L_87 = (L_84)->GetAt(static_cast<il2cpp_array_size_t>(L_86));
		NullCheck(L_82);
		(L_82)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_83, 1))), (uint8_t)L_87);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_88 = ___1_dst;
		int32_t L_89 = V_4;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_90 = ___1_dst;
		int32_t L_91 = V_3;
		NullCheck(L_90);
		int32_t L_92 = ((int32_t)il2cpp_codegen_add(L_91, 2));
		uint8_t L_93 = (L_90)->GetAt(static_cast<il2cpp_array_size_t>(L_92));
		NullCheck(L_88);
		(L_88)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_89, 2))), (uint8_t)L_93);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_94 = ___1_dst;
		int32_t L_95 = V_4;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_96 = ___1_dst;
		int32_t L_97 = V_3;
		NullCheck(L_96);
		int32_t L_98 = ((int32_t)il2cpp_codegen_add(L_97, 3));
		uint8_t L_99 = (L_96)->GetAt(static_cast<il2cpp_array_size_t>(L_98));
		NullCheck(L_94);
		(L_94)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_95, 3))), (uint8_t)L_99);
		int32_t L_100 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add(L_100, 4));
		int32_t L_101 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_101, 4));
		int32_t L_102 = V_3;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_103 = V_0;
		int32_t L_104 = V_4;
		int32_t L_105 = V_3;
		NullCheck(L_103);
		int32_t L_106 = ((int32_t)il2cpp_codegen_subtract(L_104, L_105));
		int32_t L_107 = (L_103)->GetAt(static_cast<il2cpp_array_size_t>(L_106));
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_102, L_107));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_108 = ___1_dst;
		int32_t L_109 = V_3;
		int32_t L_110 = V_4;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_Copy4_m184A9377DC0EC985A8AF55E386A3F04D2F8C3F5F(L_108, L_109, L_110, NULL);
		int32_t L_111 = V_4;
		V_4 = L_111;
		int32_t L_112 = V_3;
		V_3 = L_112;
		goto IL_015f;
	}

IL_014c:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_113 = ___1_dst;
		int32_t L_114 = V_3;
		int32_t L_115 = V_4;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_Copy4_m184A9377DC0EC985A8AF55E386A3F04D2F8C3F5F(L_113, L_114, L_115, NULL);
		int32_t L_116 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add(L_116, 4));
		int32_t L_117 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_117, 4));
	}

IL_015f:
	{
		int32_t L_118 = V_4;
		int32_t L_119 = V_11;
		V_6 = ((int32_t)il2cpp_codegen_add(L_118, L_119));
		int32_t L_120 = V_6;
		int32_t L_121 = V_9;
		if ((((int32_t)L_120) <= ((int32_t)L_121)))
		{
			goto IL_01af;
		}
	}
	{
		int32_t L_122 = V_6;
		int32_t L_123 = V_7;
		if ((((int32_t)L_122) > ((int32_t)L_123)))
		{
			goto IL_01ce;
		}
	}
	{
		int32_t L_124 = V_4;
		int32_t L_125 = V_8;
		if ((((int32_t)L_124) >= ((int32_t)L_125)))
		{
			goto IL_01a0;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_126 = ___1_dst;
		int32_t L_127 = V_3;
		int32_t L_128 = V_4;
		int32_t L_129 = V_8;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_130;
		L_130 = LZ4Codec_SecureCopy_mD8B329836718DBDA10089588161AC3F72D9C88A4(L_126, L_127, L_128, L_129, NULL);
		V_1 = L_130;
		int32_t L_131 = V_3;
		int32_t L_132 = V_1;
		V_3 = ((int32_t)il2cpp_codegen_add(L_131, L_132));
		int32_t L_133 = V_4;
		int32_t L_134 = V_1;
		V_4 = ((int32_t)il2cpp_codegen_add(L_133, L_134));
		goto IL_01a0;
	}

IL_0190:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_135 = ___1_dst;
		int32_t L_136 = V_4;
		int32_t L_137 = L_136;
		V_4 = ((int32_t)il2cpp_codegen_add(L_137, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_138 = ___1_dst;
		int32_t L_139 = V_3;
		int32_t L_140 = L_139;
		V_3 = ((int32_t)il2cpp_codegen_add(L_140, 1));
		NullCheck(L_138);
		int32_t L_141 = L_140;
		uint8_t L_142 = (L_138)->GetAt(static_cast<il2cpp_array_size_t>(L_141));
		NullCheck(L_135);
		(L_135)->SetAt(static_cast<il2cpp_array_size_t>(L_137), (uint8_t)L_142);
	}

IL_01a0:
	{
		int32_t L_143 = V_4;
		int32_t L_144 = V_6;
		if ((((int32_t)L_143) < ((int32_t)L_144)))
		{
			goto IL_0190;
		}
	}
	{
		int32_t L_145 = V_6;
		V_4 = L_145;
		goto IL_0024;
	}

IL_01af:
	{
		int32_t L_146 = V_4;
		int32_t L_147 = V_6;
		if ((((int32_t)L_146) >= ((int32_t)L_147)))
		{
			goto IL_01c1;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_148 = ___1_dst;
		int32_t L_149 = V_3;
		int32_t L_150 = V_4;
		int32_t L_151 = V_6;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_152;
		L_152 = LZ4Codec_SecureCopy_mD8B329836718DBDA10089588161AC3F72D9C88A4(L_148, L_149, L_150, L_151, NULL);
	}

IL_01c1:
	{
		int32_t L_153 = V_6;
		V_4 = L_153;
		goto IL_0024;
	}

IL_01ca:
	{
		int32_t L_154 = V_2;
		int32_t L_155 = ___2_src_0;
		return ((int32_t)il2cpp_codegen_subtract(L_154, L_155));
	}

IL_01ce:
	{
		int32_t L_156 = V_2;
		int32_t L_157 = ___2_src_0;
		return ((-((int32_t)il2cpp_codegen_subtract(L_156, L_157))));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_uncompress_unknownOutputSize_safe32_m70BEAA0964145EC18E8EFE6DC6D9A6B0D745A456 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_dst, int32_t ___2_src_0, int32_t ___3_dst_0, int32_t ___4_src_len, int32_t ___5_dst_maxlen, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	int32_t V_13 = 0;
	uint8_t V_14 = 0x0;
	int32_t V_15 = 0;
	int32_t V_16 = 0;
	int32_t V_17 = 0;
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_0 = ((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DECODER_TABLE_32;
		V_0 = L_0;
		int32_t L_1 = ___2_src_0;
		V_2 = L_1;
		int32_t L_2 = V_2;
		int32_t L_3 = ___4_src_len;
		V_3 = ((int32_t)il2cpp_codegen_add(L_2, L_3));
		int32_t L_4 = ___3_dst_0;
		V_5 = L_4;
		int32_t L_5 = V_5;
		int32_t L_6 = ___5_dst_maxlen;
		V_6 = ((int32_t)il2cpp_codegen_add(L_5, L_6));
		int32_t L_7 = V_3;
		V_8 = ((int32_t)il2cpp_codegen_subtract(L_7, 8));
		int32_t L_8 = V_3;
		V_9 = ((int32_t)il2cpp_codegen_subtract(L_8, 6));
		int32_t L_9 = V_6;
		V_10 = ((int32_t)il2cpp_codegen_subtract(L_9, 8));
		int32_t L_10 = V_6;
		V_11 = ((int32_t)il2cpp_codegen_subtract(L_10, 8));
		int32_t L_11 = V_6;
		V_12 = ((int32_t)il2cpp_codegen_subtract(L_11, 5));
		int32_t L_12 = V_6;
		V_13 = ((int32_t)il2cpp_codegen_subtract(L_12, ((int32_t)12)));
		int32_t L_13 = V_2;
		int32_t L_14 = V_3;
		if ((((int32_t)L_13) == ((int32_t)L_14)))
		{
			goto IL_0213;
		}
	}

IL_0041:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_15 = ___0_src;
		int32_t L_16 = V_2;
		int32_t L_17 = L_16;
		V_2 = ((int32_t)il2cpp_codegen_add(L_17, 1));
		NullCheck(L_15);
		int32_t L_18 = L_17;
		uint8_t L_19 = (L_15)->GetAt(static_cast<il2cpp_array_size_t>(L_18));
		V_14 = L_19;
		uint8_t L_20 = V_14;
		int32_t L_21 = ((int32_t)((int32_t)L_20>>4));
		V_15 = L_21;
		if ((!(((uint32_t)L_21) == ((uint32_t)((int32_t)15)))))
		{
			goto IL_007a;
		}
	}
	{
		V_16 = ((int32_t)255);
		goto IL_006d;
	}

IL_005e:
	{
		int32_t L_22 = V_15;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_23 = ___0_src;
		int32_t L_24 = V_2;
		int32_t L_25 = L_24;
		V_2 = ((int32_t)il2cpp_codegen_add(L_25, 1));
		NullCheck(L_23);
		int32_t L_26 = L_25;
		uint8_t L_27 = (L_23)->GetAt(static_cast<il2cpp_array_size_t>(L_26));
		uint8_t L_28 = L_27;
		V_16 = L_28;
		V_15 = ((int32_t)il2cpp_codegen_add(L_22, (int32_t)L_28));
	}

IL_006d:
	{
		int32_t L_29 = V_2;
		int32_t L_30 = V_3;
		if ((((int32_t)L_29) >= ((int32_t)L_30)))
		{
			goto IL_007a;
		}
	}
	{
		int32_t L_31 = V_16;
		if ((((int32_t)L_31) == ((int32_t)((int32_t)255))))
		{
			goto IL_005e;
		}
	}

IL_007a:
	{
		int32_t L_32 = V_5;
		int32_t L_33 = V_15;
		V_7 = ((int32_t)il2cpp_codegen_add(L_32, L_33));
		int32_t L_34 = V_7;
		int32_t L_35 = V_13;
		if ((((int32_t)L_34) > ((int32_t)L_35)))
		{
			goto IL_008f;
		}
	}
	{
		int32_t L_36 = V_2;
		int32_t L_37 = V_15;
		int32_t L_38 = V_8;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_36, L_37))) <= ((int32_t)L_38)))
		{
			goto IL_00ba;
		}
	}

IL_008f:
	{
		int32_t L_39 = V_7;
		int32_t L_40 = V_6;
		if ((((int32_t)L_39) > ((int32_t)L_40)))
		{
			goto IL_0213;
		}
	}
	{
		int32_t L_41 = V_2;
		int32_t L_42 = V_15;
		int32_t L_43 = V_3;
		if ((!(((uint32_t)((int32_t)il2cpp_codegen_add(L_41, L_42))) == ((uint32_t)L_43))))
		{
			goto IL_0213;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_44 = ___0_src;
		int32_t L_45 = V_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_46 = ___1_dst;
		int32_t L_47 = V_5;
		int32_t L_48 = V_15;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D(L_44, L_45, L_46, L_47, L_48, NULL);
		int32_t L_49 = V_5;
		int32_t L_50 = V_15;
		V_5 = ((int32_t)il2cpp_codegen_add(L_49, L_50));
		goto IL_020e;
	}

IL_00ba:
	{
		int32_t L_51 = V_5;
		int32_t L_52 = V_7;
		if ((((int32_t)L_51) >= ((int32_t)L_52)))
		{
			goto IL_00d7;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_53 = ___0_src;
		int32_t L_54 = V_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_55 = ___1_dst;
		int32_t L_56 = V_5;
		int32_t L_57 = V_7;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_58;
		L_58 = LZ4Codec_WildCopy_mE6E7FF3DC7D46D37614FDE84DDDEA5D03B0B5F94(L_53, L_54, L_55, L_56, L_57, NULL);
		V_1 = L_58;
		int32_t L_59 = V_2;
		int32_t L_60 = V_1;
		V_2 = ((int32_t)il2cpp_codegen_add(L_59, L_60));
		int32_t L_61 = V_5;
		int32_t L_62 = V_1;
		V_5 = ((int32_t)il2cpp_codegen_add(L_61, L_62));
	}

IL_00d7:
	{
		int32_t L_63 = V_2;
		int32_t L_64 = V_5;
		int32_t L_65 = V_7;
		V_2 = ((int32_t)il2cpp_codegen_subtract(L_63, ((int32_t)il2cpp_codegen_subtract(L_64, L_65))));
		int32_t L_66 = V_7;
		V_5 = L_66;
		int32_t L_67 = V_7;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_68 = ___0_src;
		int32_t L_69 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint16_t L_70;
		L_70 = LZ4Codec_Peek2_mE549DAC6B7C81F35C5B34C25AD3A6EDA5F44C008(L_68, L_69, NULL);
		V_4 = ((int32_t)il2cpp_codegen_subtract(L_67, (int32_t)L_70));
		int32_t L_71 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_71, 2));
		int32_t L_72 = V_4;
		int32_t L_73 = ___3_dst_0;
		if ((((int32_t)L_72) < ((int32_t)L_73)))
		{
			goto IL_0213;
		}
	}
	{
		uint8_t L_74 = V_14;
		int32_t L_75 = ((int32_t)((int32_t)L_74&((int32_t)15)));
		V_15 = L_75;
		if ((!(((uint32_t)L_75) == ((uint32_t)((int32_t)15)))))
		{
			goto IL_0127;
		}
	}
	{
		goto IL_0122;
	}

IL_0109:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_76 = ___0_src;
		int32_t L_77 = V_2;
		int32_t L_78 = L_77;
		V_2 = ((int32_t)il2cpp_codegen_add(L_78, 1));
		NullCheck(L_76);
		int32_t L_79 = L_78;
		uint8_t L_80 = (L_76)->GetAt(static_cast<il2cpp_array_size_t>(L_79));
		V_17 = L_80;
		int32_t L_81 = V_15;
		int32_t L_82 = V_17;
		V_15 = ((int32_t)il2cpp_codegen_add(L_81, L_82));
		int32_t L_83 = V_17;
		if ((!(((uint32_t)L_83) == ((uint32_t)((int32_t)255)))))
		{
			goto IL_0127;
		}
	}

IL_0122:
	{
		int32_t L_84 = V_2;
		int32_t L_85 = V_9;
		if ((((int32_t)L_84) < ((int32_t)L_85)))
		{
			goto IL_0109;
		}
	}

IL_0127:
	{
		int32_t L_86 = V_5;
		int32_t L_87 = V_4;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract(L_86, L_87))) >= ((int32_t)4)))
		{
			goto IL_0187;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_88 = ___1_dst;
		int32_t L_89 = V_5;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_90 = ___1_dst;
		int32_t L_91 = V_4;
		NullCheck(L_90);
		int32_t L_92 = L_91;
		uint8_t L_93 = (L_90)->GetAt(static_cast<il2cpp_array_size_t>(L_92));
		NullCheck(L_88);
		(L_88)->SetAt(static_cast<il2cpp_array_size_t>(L_89), (uint8_t)L_93);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_94 = ___1_dst;
		int32_t L_95 = V_5;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_96 = ___1_dst;
		int32_t L_97 = V_4;
		NullCheck(L_96);
		int32_t L_98 = ((int32_t)il2cpp_codegen_add(L_97, 1));
		uint8_t L_99 = (L_96)->GetAt(static_cast<il2cpp_array_size_t>(L_98));
		NullCheck(L_94);
		(L_94)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_95, 1))), (uint8_t)L_99);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_100 = ___1_dst;
		int32_t L_101 = V_5;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_102 = ___1_dst;
		int32_t L_103 = V_4;
		NullCheck(L_102);
		int32_t L_104 = ((int32_t)il2cpp_codegen_add(L_103, 2));
		uint8_t L_105 = (L_102)->GetAt(static_cast<il2cpp_array_size_t>(L_104));
		NullCheck(L_100);
		(L_100)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_101, 2))), (uint8_t)L_105);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_106 = ___1_dst;
		int32_t L_107 = V_5;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_108 = ___1_dst;
		int32_t L_109 = V_4;
		NullCheck(L_108);
		int32_t L_110 = ((int32_t)il2cpp_codegen_add(L_109, 3));
		uint8_t L_111 = (L_108)->GetAt(static_cast<il2cpp_array_size_t>(L_110));
		NullCheck(L_106);
		(L_106)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_107, 3))), (uint8_t)L_111);
		int32_t L_112 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_112, 4));
		int32_t L_113 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add(L_113, 4));
		int32_t L_114 = V_4;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_115 = V_0;
		int32_t L_116 = V_5;
		int32_t L_117 = V_4;
		NullCheck(L_115);
		int32_t L_118 = ((int32_t)il2cpp_codegen_subtract(L_116, L_117));
		int32_t L_119 = (L_115)->GetAt(static_cast<il2cpp_array_size_t>(L_118));
		V_4 = ((int32_t)il2cpp_codegen_subtract(L_114, L_119));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_120 = ___1_dst;
		int32_t L_121 = V_4;
		int32_t L_122 = V_5;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_Copy4_m184A9377DC0EC985A8AF55E386A3F04D2F8C3F5F(L_120, L_121, L_122, NULL);
		int32_t L_123 = V_5;
		V_5 = L_123;
		int32_t L_124 = V_4;
		V_4 = L_124;
		goto IL_019d;
	}

IL_0187:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_125 = ___1_dst;
		int32_t L_126 = V_4;
		int32_t L_127 = V_5;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_Copy4_m184A9377DC0EC985A8AF55E386A3F04D2F8C3F5F(L_125, L_126, L_127, NULL);
		int32_t L_128 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_128, 4));
		int32_t L_129 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add(L_129, 4));
	}

IL_019d:
	{
		int32_t L_130 = V_5;
		int32_t L_131 = V_15;
		V_7 = ((int32_t)il2cpp_codegen_add(L_130, L_131));
		int32_t L_132 = V_7;
		int32_t L_133 = V_11;
		if ((((int32_t)L_132) <= ((int32_t)L_133)))
		{
			goto IL_01f2;
		}
	}
	{
		int32_t L_134 = V_7;
		int32_t L_135 = V_12;
		if ((((int32_t)L_134) > ((int32_t)L_135)))
		{
			goto IL_0213;
		}
	}
	{
		int32_t L_136 = V_5;
		int32_t L_137 = V_10;
		if ((((int32_t)L_136) >= ((int32_t)L_137)))
		{
			goto IL_01e3;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_138 = ___1_dst;
		int32_t L_139 = V_4;
		int32_t L_140 = V_5;
		int32_t L_141 = V_10;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_142;
		L_142 = LZ4Codec_SecureCopy_mD8B329836718DBDA10089588161AC3F72D9C88A4(L_138, L_139, L_140, L_141, NULL);
		V_1 = L_142;
		int32_t L_143 = V_4;
		int32_t L_144 = V_1;
		V_4 = ((int32_t)il2cpp_codegen_add(L_143, L_144));
		int32_t L_145 = V_5;
		int32_t L_146 = V_1;
		V_5 = ((int32_t)il2cpp_codegen_add(L_145, L_146));
		goto IL_01e3;
	}

IL_01d1:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_147 = ___1_dst;
		int32_t L_148 = V_5;
		int32_t L_149 = L_148;
		V_5 = ((int32_t)il2cpp_codegen_add(L_149, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_150 = ___1_dst;
		int32_t L_151 = V_4;
		int32_t L_152 = L_151;
		V_4 = ((int32_t)il2cpp_codegen_add(L_152, 1));
		NullCheck(L_150);
		int32_t L_153 = L_152;
		uint8_t L_154 = (L_150)->GetAt(static_cast<il2cpp_array_size_t>(L_153));
		NullCheck(L_147);
		(L_147)->SetAt(static_cast<il2cpp_array_size_t>(L_149), (uint8_t)L_154);
	}

IL_01e3:
	{
		int32_t L_155 = V_5;
		int32_t L_156 = V_7;
		if ((((int32_t)L_155) < ((int32_t)L_156)))
		{
			goto IL_01d1;
		}
	}
	{
		int32_t L_157 = V_7;
		V_5 = L_157;
		goto IL_0041;
	}

IL_01f2:
	{
		int32_t L_158 = V_5;
		int32_t L_159 = V_7;
		if ((((int32_t)L_158) >= ((int32_t)L_159)))
		{
			goto IL_0205;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_160 = ___1_dst;
		int32_t L_161 = V_4;
		int32_t L_162 = V_5;
		int32_t L_163 = V_7;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_164;
		L_164 = LZ4Codec_SecureCopy_mD8B329836718DBDA10089588161AC3F72D9C88A4(L_160, L_161, L_162, L_163, NULL);
	}

IL_0205:
	{
		int32_t L_165 = V_7;
		V_5 = L_165;
		goto IL_0041;
	}

IL_020e:
	{
		int32_t L_166 = V_5;
		int32_t L_167 = ___3_dst_0;
		return ((int32_t)il2cpp_codegen_subtract(L_166, L_167));
	}

IL_0213:
	{
		int32_t L_168 = V_2;
		int32_t L_169 = ___2_src_0;
		return ((-((int32_t)il2cpp_codegen_subtract(L_168, L_169))));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_LZ4HC_Insert_32_m9D23BA633ACDC44213F130DF95DC82BB1AA200A6 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_src_p, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* V_0 = NULL;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_1 = NULL;
	int32_t V_2 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_3 = NULL;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_0 = ___0_ctx;
		NullCheck(L_0);
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_1 = L_0->___chainTable;
		V_0 = L_1;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_2 = ___0_ctx;
		NullCheck(L_2);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_3 = L_2->___hashTable;
		V_1 = L_3;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_4 = ___0_ctx;
		NullCheck(L_4);
		int32_t L_5 = L_4->___nextToUpdate;
		V_2 = L_5;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_6 = ___0_ctx;
		NullCheck(L_6);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = L_6->___src;
		V_3 = L_7;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_8 = ___0_ctx;
		NullCheck(L_8);
		int32_t L_9 = L_8->___src_base;
		V_4 = L_9;
		goto IL_007f;
	}

IL_0026:
	{
		int32_t L_10 = V_2;
		V_5 = L_10;
		int32_t L_11 = V_5;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_12 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_13 = V_3;
		int32_t L_14 = V_5;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_15;
		L_15 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_13, L_14, NULL);
		NullCheck(L_12);
		uintptr_t L_16 = ((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_15, ((int32_t)-1640531535)))>>((int32_t)17))));
		int32_t L_17 = (L_12)->GetAt(static_cast<il2cpp_array_size_t>(L_16));
		int32_t L_18 = V_4;
		V_6 = ((int32_t)il2cpp_codegen_subtract(L_11, ((int32_t)il2cpp_codegen_add(L_17, L_18))));
		int32_t L_19 = V_6;
		if ((((int32_t)L_19) <= ((int32_t)((int32_t)65535))))
		{
			goto IL_0055;
		}
	}
	{
		V_6 = ((int32_t)65535);
	}

IL_0055:
	{
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_20 = V_0;
		int32_t L_21 = V_5;
		int32_t L_22 = V_6;
		NullCheck(L_20);
		(L_20)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)(L_21&((int32_t)65535)))), (uint16_t)((int32_t)(uint16_t)L_22));
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_23 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = V_3;
		int32_t L_25 = V_5;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_26;
		L_26 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_24, L_25, NULL);
		int32_t L_27 = V_5;
		int32_t L_28 = V_4;
		NullCheck(L_23);
		(L_23)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_26, ((int32_t)-1640531535)))>>((int32_t)17))))), (int32_t)((int32_t)il2cpp_codegen_subtract(L_27, L_28)));
		int32_t L_29 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_29, 1));
	}

IL_007f:
	{
		int32_t L_30 = V_2;
		int32_t L_31 = ___1_src_p;
		if ((((int32_t)L_30) < ((int32_t)L_31)))
		{
			goto IL_0026;
		}
	}
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_32 = ___0_ctx;
		int32_t L_33 = V_2;
		NullCheck(L_32);
		L_32->___nextToUpdate = L_33;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4HC_CommonLength_32_m3D0F5D5E7EAFB40FDACA9CFC53B3B82448E0E1A5 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_p1, int32_t ___2_p2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_0 = NULL;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_0 = ((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DEBRUIJN_TABLE_32;
		V_0 = L_0;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_1 = ___0_ctx;
		NullCheck(L_1);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = L_1->___src;
		V_1 = L_2;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_3 = ___0_ctx;
		NullCheck(L_3);
		int32_t L_4 = L_3->___src_LASTLITERALS;
		V_2 = L_4;
		int32_t L_5 = ___1_p1;
		V_3 = L_5;
		goto IL_004a;
	}

IL_0018:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = V_1;
		int32_t L_7 = ___2_p2;
		int32_t L_8 = V_3;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_9;
		L_9 = LZ4Codec_Xor4_mECF76BD60591364408CC4E94D6F913291AC4B8CB(L_6, L_7, L_8, NULL);
		V_4 = L_9;
		int32_t L_10 = V_4;
		if (L_10)
		{
			goto IL_0031;
		}
	}
	{
		int32_t L_11 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_11, 4));
		int32_t L_12 = ___2_p2;
		___2_p2 = ((int32_t)il2cpp_codegen_add(L_12, 4));
		goto IL_004a;
	}

IL_0031:
	{
		int32_t L_13 = V_3;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_14 = V_0;
		int32_t L_15 = V_4;
		int32_t L_16 = V_4;
		NullCheck(L_14);
		uintptr_t L_17 = ((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply(((int32_t)(L_15&((-L_16)))), ((int32_t)125613361)))>>((int32_t)27))));
		int32_t L_18 = (L_14)->GetAt(static_cast<il2cpp_array_size_t>(L_17));
		V_3 = ((int32_t)il2cpp_codegen_add(L_13, L_18));
		int32_t L_19 = V_3;
		int32_t L_20 = ___1_p1;
		return ((int32_t)il2cpp_codegen_subtract(L_19, L_20));
	}

IL_004a:
	{
		int32_t L_21 = V_3;
		int32_t L_22 = V_2;
		if ((((int32_t)L_21) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_22, 3)))))
		{
			goto IL_0018;
		}
	}
	{
		int32_t L_23 = V_3;
		int32_t L_24 = V_2;
		if ((((int32_t)L_23) >= ((int32_t)((int32_t)il2cpp_codegen_subtract(L_24, 1)))))
		{
			goto IL_0069;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_25 = V_1;
		int32_t L_26 = ___2_p2;
		int32_t L_27 = V_3;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_28;
		L_28 = LZ4Codec_Equal2_m05C0F8A90FA336B8EFA50F98F2485EAF9A00FEF6(L_25, L_26, L_27, NULL);
		if (!L_28)
		{
			goto IL_0069;
		}
	}
	{
		int32_t L_29 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_29, 2));
		int32_t L_30 = ___2_p2;
		___2_p2 = ((int32_t)il2cpp_codegen_add(L_30, 2));
	}

IL_0069:
	{
		int32_t L_31 = V_3;
		int32_t L_32 = V_2;
		if ((((int32_t)L_31) >= ((int32_t)L_32)))
		{
			goto IL_0079;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_33 = V_1;
		int32_t L_34 = ___2_p2;
		NullCheck(L_33);
		int32_t L_35 = L_34;
		uint8_t L_36 = (L_33)->GetAt(static_cast<il2cpp_array_size_t>(L_35));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_37 = V_1;
		int32_t L_38 = V_3;
		NullCheck(L_37);
		int32_t L_39 = L_38;
		uint8_t L_40 = (L_37)->GetAt(static_cast<il2cpp_array_size_t>(L_39));
		if ((!(((uint32_t)L_36) == ((uint32_t)L_40))))
		{
			goto IL_0079;
		}
	}
	{
		int32_t L_41 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_41, 1));
	}

IL_0079:
	{
		int32_t L_42 = V_3;
		int32_t L_43 = ___1_p1;
		return ((int32_t)il2cpp_codegen_subtract(L_42, L_43));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4HC_InsertAndFindBestMatch_32_mE1611C8BEB496B25C87D4ECC4ABB02F95B76FF70 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_src_p, int32_t* ___2_src_match, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* V_0 = NULL;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_1 = NULL;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	uint16_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_0 = ___0_ctx;
		NullCheck(L_0);
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_1 = L_0->___chainTable;
		V_0 = L_1;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_2 = ___0_ctx;
		NullCheck(L_2);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_3 = L_2->___hashTable;
		V_1 = L_3;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_4 = ___0_ctx;
		NullCheck(L_4);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = L_4->___src;
		V_2 = L_5;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_6 = ___0_ctx;
		NullCheck(L_6);
		int32_t L_7 = L_6->___src_base;
		V_3 = L_7;
		V_4 = ((int32_t)256);
		V_5 = 0;
		V_6 = 0;
		V_7 = (uint16_t)0;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_8 = ___0_ctx;
		int32_t L_9 = ___1_src_p;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_LZ4HC_Insert_32_m9D23BA633ACDC44213F130DF95DC82BB1AA200A6(L_8, L_9, NULL);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_10 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_11 = V_2;
		int32_t L_12 = ___1_src_p;
		uint32_t L_13;
		L_13 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_11, L_12, NULL);
		NullCheck(L_10);
		uintptr_t L_14 = ((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_13, ((int32_t)-1640531535)))>>((int32_t)17))));
		int32_t L_15 = (L_10)->GetAt(static_cast<il2cpp_array_size_t>(L_14));
		int32_t L_16 = V_3;
		V_8 = ((int32_t)il2cpp_codegen_add(L_15, L_16));
		int32_t L_17 = V_8;
		int32_t L_18 = ___1_src_p;
		if ((((int32_t)L_17) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_18, 4)))))
		{
			goto IL_00dd;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_19 = V_2;
		int32_t L_20 = V_8;
		int32_t L_21 = ___1_src_p;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_22;
		L_22 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_19, L_20, L_21, NULL);
		if (!L_22)
		{
			goto IL_007e;
		}
	}
	{
		int32_t L_23 = ___1_src_p;
		int32_t L_24 = V_8;
		V_7 = (uint16_t)((int32_t)(uint16_t)((int32_t)il2cpp_codegen_subtract(L_23, L_24)));
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_25 = ___0_ctx;
		int32_t L_26 = ___1_src_p;
		int32_t L_27 = V_8;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_28;
		L_28 = LZ4Codec_LZ4HC_CommonLength_32_m3D0F5D5E7EAFB40FDACA9CFC53B3B82448E0E1A5(L_25, ((int32_t)il2cpp_codegen_add(L_26, 4)), ((int32_t)il2cpp_codegen_add(L_27, 4)), NULL);
		int32_t L_29 = ((int32_t)il2cpp_codegen_add(L_28, 4));
		V_6 = L_29;
		V_5 = L_29;
		int32_t* L_30 = ___2_src_match;
		int32_t L_31 = V_8;
		*((int32_t*)L_30) = (int32_t)L_31;
	}

IL_007e:
	{
		int32_t L_32 = V_8;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_33 = V_0;
		int32_t L_34 = V_8;
		NullCheck(L_33);
		int32_t L_35 = ((int32_t)(L_34&((int32_t)65535)));
		uint16_t L_36 = (L_33)->GetAt(static_cast<il2cpp_array_size_t>(L_35));
		V_8 = ((int32_t)il2cpp_codegen_subtract(L_32, (int32_t)L_36));
		goto IL_00dd;
	}

IL_008f:
	{
		int32_t L_37 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_subtract(L_37, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_38 = V_2;
		int32_t L_39 = V_8;
		int32_t L_40 = V_6;
		NullCheck(L_38);
		int32_t L_41 = ((int32_t)il2cpp_codegen_add(L_39, L_40));
		uint8_t L_42 = (L_38)->GetAt(static_cast<il2cpp_array_size_t>(L_41));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_43 = V_2;
		int32_t L_44 = ___1_src_p;
		int32_t L_45 = V_6;
		NullCheck(L_43);
		int32_t L_46 = ((int32_t)il2cpp_codegen_add(L_44, L_45));
		uint8_t L_47 = (L_43)->GetAt(static_cast<il2cpp_array_size_t>(L_46));
		if ((!(((uint32_t)L_42) == ((uint32_t)L_47))))
		{
			goto IL_00ce;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_48 = V_2;
		int32_t L_49 = V_8;
		int32_t L_50 = ___1_src_p;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_51;
		L_51 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_48, L_49, L_50, NULL);
		if (!L_51)
		{
			goto IL_00ce;
		}
	}
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_52 = ___0_ctx;
		int32_t L_53 = ___1_src_p;
		int32_t L_54 = V_8;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_55;
		L_55 = LZ4Codec_LZ4HC_CommonLength_32_m3D0F5D5E7EAFB40FDACA9CFC53B3B82448E0E1A5(L_52, ((int32_t)il2cpp_codegen_add(L_53, 4)), ((int32_t)il2cpp_codegen_add(L_54, 4)), NULL);
		V_9 = ((int32_t)il2cpp_codegen_add(L_55, 4));
		int32_t L_56 = V_9;
		int32_t L_57 = V_6;
		if ((((int32_t)L_56) <= ((int32_t)L_57)))
		{
			goto IL_00ce;
		}
	}
	{
		int32_t L_58 = V_9;
		V_6 = L_58;
		int32_t* L_59 = ___2_src_match;
		int32_t L_60 = V_8;
		*((int32_t*)L_59) = (int32_t)L_60;
	}

IL_00ce:
	{
		int32_t L_61 = V_8;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_62 = V_0;
		int32_t L_63 = V_8;
		NullCheck(L_62);
		int32_t L_64 = ((int32_t)(L_63&((int32_t)65535)));
		uint16_t L_65 = (L_62)->GetAt(static_cast<il2cpp_array_size_t>(L_64));
		V_8 = ((int32_t)il2cpp_codegen_subtract(L_61, (int32_t)L_65));
	}

IL_00dd:
	{
		int32_t L_66 = V_8;
		int32_t L_67 = ___1_src_p;
		if ((((int32_t)L_66) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_67, ((int32_t)65535))))))
		{
			goto IL_00ec;
		}
	}
	{
		int32_t L_68 = V_4;
		if (L_68)
		{
			goto IL_008f;
		}
	}

IL_00ec:
	{
		int32_t L_69 = V_5;
		if (!L_69)
		{
			goto IL_0150;
		}
	}
	{
		int32_t L_70 = ___1_src_p;
		V_10 = L_70;
		int32_t L_71 = ___1_src_p;
		int32_t L_72 = V_5;
		V_11 = ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_71, L_72)), 3));
		goto IL_010f;
	}

IL_00fd:
	{
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_73 = V_0;
		int32_t L_74 = V_10;
		uint16_t L_75 = V_7;
		NullCheck(L_73);
		(L_73)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)(L_74&((int32_t)65535)))), (uint16_t)L_75);
		int32_t L_76 = V_10;
		V_10 = ((int32_t)il2cpp_codegen_add(L_76, 1));
	}

IL_010f:
	{
		int32_t L_77 = V_10;
		int32_t L_78 = V_11;
		uint16_t L_79 = V_7;
		if ((((int32_t)L_77) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_78, (int32_t)L_79)))))
		{
			goto IL_00fd;
		}
	}

IL_0118:
	{
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_80 = V_0;
		int32_t L_81 = V_10;
		uint16_t L_82 = V_7;
		NullCheck(L_80);
		(L_80)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)(L_81&((int32_t)65535)))), (uint16_t)L_82);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_83 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_84 = V_2;
		int32_t L_85 = V_10;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_86;
		L_86 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_84, L_85, NULL);
		int32_t L_87 = V_10;
		int32_t L_88 = V_3;
		NullCheck(L_83);
		(L_83)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_86, ((int32_t)-1640531535)))>>((int32_t)17))))), (int32_t)((int32_t)il2cpp_codegen_subtract(L_87, L_88)));
		int32_t L_89 = V_10;
		V_10 = ((int32_t)il2cpp_codegen_add(L_89, 1));
		int32_t L_90 = V_10;
		int32_t L_91 = V_11;
		if ((((int32_t)L_90) < ((int32_t)L_91)))
		{
			goto IL_0118;
		}
	}
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_92 = ___0_ctx;
		int32_t L_93 = V_11;
		NullCheck(L_92);
		L_92->___nextToUpdate = L_93;
	}

IL_0150:
	{
		int32_t L_94 = V_6;
		return L_94;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4HC_InsertAndGetWiderMatch_32_mA128B9BA0971EF5D7C371E959A3339D3E2730826 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_src_p, int32_t ___2_startLimit, int32_t ___3_longest, int32_t* ___4_matchpos, int32_t* ___5_startpos, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* V_0 = NULL;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_1 = NULL;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_5 = NULL;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_0 = ___0_ctx;
		NullCheck(L_0);
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_1 = L_0->___chainTable;
		V_0 = L_1;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_2 = ___0_ctx;
		NullCheck(L_2);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_3 = L_2->___hashTable;
		V_1 = L_3;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_4 = ___0_ctx;
		NullCheck(L_4);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = L_4->___src;
		V_2 = L_5;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_6 = ___0_ctx;
		NullCheck(L_6);
		int32_t L_7 = L_6->___src_base;
		V_3 = L_7;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_8 = ___0_ctx;
		NullCheck(L_8);
		int32_t L_9 = L_8->___src_LASTLITERALS;
		V_4 = L_9;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_10 = ((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DEBRUIJN_TABLE_32;
		V_5 = L_10;
		V_6 = ((int32_t)256);
		int32_t L_11 = ___1_src_p;
		int32_t L_12 = ___2_startLimit;
		V_7 = ((int32_t)il2cpp_codegen_subtract(L_11, L_12));
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_13 = ___0_ctx;
		int32_t L_14 = ___1_src_p;
		LZ4Codec_LZ4HC_Insert_32_m9D23BA633ACDC44213F130DF95DC82BB1AA200A6(L_13, L_14, NULL);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_15 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = V_2;
		int32_t L_17 = ___1_src_p;
		uint32_t L_18;
		L_18 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_16, L_17, NULL);
		NullCheck(L_15);
		uintptr_t L_19 = ((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_18, ((int32_t)-1640531535)))>>((int32_t)17))));
		int32_t L_20 = (L_15)->GetAt(static_cast<il2cpp_array_size_t>(L_19));
		int32_t L_21 = V_3;
		V_8 = ((int32_t)il2cpp_codegen_add(L_20, L_21));
		goto IL_0159;
	}

IL_005a:
	{
		int32_t L_22 = V_6;
		V_6 = ((int32_t)il2cpp_codegen_subtract(L_22, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_23 = V_2;
		int32_t L_24 = ___2_startLimit;
		int32_t L_25 = ___3_longest;
		NullCheck(L_23);
		int32_t L_26 = ((int32_t)il2cpp_codegen_add(L_24, L_25));
		uint8_t L_27 = (L_23)->GetAt(static_cast<il2cpp_array_size_t>(L_26));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_28 = V_2;
		int32_t L_29 = V_8;
		int32_t L_30 = V_7;
		int32_t L_31 = ___3_longest;
		NullCheck(L_28);
		int32_t L_32 = ((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_subtract(L_29, L_30)), L_31));
		uint8_t L_33 = (L_28)->GetAt(static_cast<il2cpp_array_size_t>(L_32));
		if ((!(((uint32_t)L_27) == ((uint32_t)L_33))))
		{
			goto IL_014a;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_34 = V_2;
		int32_t L_35 = V_8;
		int32_t L_36 = ___1_src_p;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_37;
		L_37 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_34, L_35, L_36, NULL);
		if (!L_37)
		{
			goto IL_014a;
		}
	}
	{
		int32_t L_38 = V_8;
		V_9 = ((int32_t)il2cpp_codegen_add(L_38, 4));
		int32_t L_39 = ___1_src_p;
		V_10 = ((int32_t)il2cpp_codegen_add(L_39, 4));
		int32_t L_40 = ___1_src_p;
		V_11 = L_40;
		goto IL_00c9;
	}

IL_0091:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_41 = V_2;
		int32_t L_42 = V_9;
		int32_t L_43 = V_10;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_44;
		L_44 = LZ4Codec_Xor4_mECF76BD60591364408CC4E94D6F913291AC4B8CB(L_41, L_42, L_43, NULL);
		V_12 = L_44;
		int32_t L_45 = V_12;
		if (L_45)
		{
			goto IL_00af;
		}
	}
	{
		int32_t L_46 = V_10;
		V_10 = ((int32_t)il2cpp_codegen_add(L_46, 4));
		int32_t L_47 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_47, 4));
		goto IL_00c9;
	}

IL_00af:
	{
		int32_t L_48 = V_10;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_49 = V_5;
		int32_t L_50 = V_12;
		int32_t L_51 = V_12;
		NullCheck(L_49);
		uintptr_t L_52 = ((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply(((int32_t)(L_50&((-L_51)))), ((int32_t)125613361)))>>((int32_t)27))));
		int32_t L_53 = (L_49)->GetAt(static_cast<il2cpp_array_size_t>(L_52));
		V_10 = ((int32_t)il2cpp_codegen_add(L_48, L_53));
		goto IL_0107;
	}

IL_00c9:
	{
		int32_t L_54 = V_10;
		int32_t L_55 = V_4;
		if ((((int32_t)L_54) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_55, 3)))))
		{
			goto IL_0091;
		}
	}
	{
		int32_t L_56 = V_10;
		int32_t L_57 = V_4;
		if ((((int32_t)L_56) >= ((int32_t)((int32_t)il2cpp_codegen_subtract(L_57, 1)))))
		{
			goto IL_00f1;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_58 = V_2;
		int32_t L_59 = V_9;
		int32_t L_60 = V_10;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_61;
		L_61 = LZ4Codec_Equal2_m05C0F8A90FA336B8EFA50F98F2485EAF9A00FEF6(L_58, L_59, L_60, NULL);
		if (!L_61)
		{
			goto IL_00f1;
		}
	}
	{
		int32_t L_62 = V_10;
		V_10 = ((int32_t)il2cpp_codegen_add(L_62, 2));
		int32_t L_63 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_63, 2));
	}

IL_00f1:
	{
		int32_t L_64 = V_10;
		int32_t L_65 = V_4;
		if ((((int32_t)L_64) >= ((int32_t)L_65)))
		{
			goto IL_0107;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_66 = V_2;
		int32_t L_67 = V_9;
		NullCheck(L_66);
		int32_t L_68 = L_67;
		uint8_t L_69 = (L_66)->GetAt(static_cast<il2cpp_array_size_t>(L_68));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_70 = V_2;
		int32_t L_71 = V_10;
		NullCheck(L_70);
		int32_t L_72 = L_71;
		uint8_t L_73 = (L_70)->GetAt(static_cast<il2cpp_array_size_t>(L_72));
		if ((!(((uint32_t)L_69) == ((uint32_t)L_73))))
		{
			goto IL_0107;
		}
	}
	{
		int32_t L_74 = V_10;
		V_10 = ((int32_t)il2cpp_codegen_add(L_74, 1));
	}

IL_0107:
	{
		int32_t L_75 = V_8;
		V_9 = L_75;
		goto IL_0119;
	}

IL_010d:
	{
		int32_t L_76 = V_11;
		V_11 = ((int32_t)il2cpp_codegen_subtract(L_76, 1));
		int32_t L_77 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_subtract(L_77, 1));
	}

IL_0119:
	{
		int32_t L_78 = V_11;
		int32_t L_79 = ___2_startLimit;
		if ((((int32_t)L_78) <= ((int32_t)L_79)))
		{
			goto IL_0131;
		}
	}
	{
		int32_t L_80 = V_9;
		int32_t L_81 = V_3;
		if ((((int32_t)L_80) <= ((int32_t)L_81)))
		{
			goto IL_0131;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_82 = V_2;
		int32_t L_83 = V_11;
		NullCheck(L_82);
		int32_t L_84 = ((int32_t)il2cpp_codegen_subtract(L_83, 1));
		uint8_t L_85 = (L_82)->GetAt(static_cast<il2cpp_array_size_t>(L_84));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_86 = V_2;
		int32_t L_87 = V_9;
		NullCheck(L_86);
		int32_t L_88 = ((int32_t)il2cpp_codegen_subtract(L_87, 1));
		uint8_t L_89 = (L_86)->GetAt(static_cast<il2cpp_array_size_t>(L_88));
		if ((((int32_t)L_85) == ((int32_t)L_89)))
		{
			goto IL_010d;
		}
	}

IL_0131:
	{
		int32_t L_90 = V_10;
		int32_t L_91 = V_11;
		int32_t L_92 = ___3_longest;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract(L_90, L_91))) <= ((int32_t)L_92)))
		{
			goto IL_014a;
		}
	}
	{
		int32_t L_93 = V_10;
		int32_t L_94 = V_11;
		___3_longest = ((int32_t)il2cpp_codegen_subtract(L_93, L_94));
		int32_t* L_95 = ___4_matchpos;
		int32_t L_96 = V_9;
		*((int32_t*)L_95) = (int32_t)L_96;
		int32_t* L_97 = ___5_startpos;
		int32_t L_98 = V_11;
		*((int32_t*)L_97) = (int32_t)L_98;
	}

IL_014a:
	{
		int32_t L_99 = V_8;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_100 = V_0;
		int32_t L_101 = V_8;
		NullCheck(L_100);
		int32_t L_102 = ((int32_t)(L_101&((int32_t)65535)));
		uint16_t L_103 = (L_100)->GetAt(static_cast<il2cpp_array_size_t>(L_102));
		V_8 = ((int32_t)il2cpp_codegen_subtract(L_99, (int32_t)L_103));
	}

IL_0159:
	{
		int32_t L_104 = V_8;
		int32_t L_105 = ___1_src_p;
		if ((((int32_t)L_104) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_105, ((int32_t)65535))))))
		{
			goto IL_016b;
		}
	}
	{
		int32_t L_106 = V_6;
		if (L_106)
		{
			goto IL_005a;
		}
	}

IL_016b:
	{
		int32_t L_107 = ___3_longest;
		return L_107;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_encodeSequence_32_m961041D1CC42128E9D32E2F73F9E841AE125E316 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t* ___1_src_p, int32_t* ___2_dst_p, int32_t* ___3_src_anchor, int32_t ___4_matchLength, int32_t ___5_src_ref, int32_t ___6_dst_end, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_1 = NULL;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_0 = ___0_ctx;
		NullCheck(L_0);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = L_0->___src;
		V_1 = L_1;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_2 = ___0_ctx;
		NullCheck(L_2);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = L_2->___dst;
		V_2 = L_3;
		int32_t* L_4 = ___1_src_p;
		int32_t L_5 = *((int32_t*)L_4);
		int32_t* L_6 = ___3_src_anchor;
		int32_t L_7 = *((int32_t*)L_6);
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_5, L_7));
		int32_t* L_8 = ___2_dst_p;
		int32_t* L_9 = L_8;
		int32_t L_10 = *((int32_t*)L_9);
		int32_t L_11 = L_10;
		V_6 = L_11;
		*((int32_t*)L_9) = (int32_t)((int32_t)il2cpp_codegen_add(L_11, 1));
		int32_t L_12 = V_6;
		V_4 = L_12;
		int32_t* L_13 = ___2_dst_p;
		int32_t L_14 = *((int32_t*)L_13);
		int32_t L_15 = V_3;
		int32_t L_16 = V_3;
		int32_t L_17 = ___6_dst_end;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_14, L_15)), 8)), ((int32_t)(L_16>>8))))) <= ((int32_t)L_17)))
		{
			goto IL_0031;
		}
	}
	{
		return 1;
	}

IL_0031:
	{
		int32_t L_18 = V_3;
		if ((((int32_t)L_18) < ((int32_t)((int32_t)15))))
		{
			goto IL_0079;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_19 = V_2;
		int32_t L_20 = V_4;
		NullCheck(L_19);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(L_20), (uint8_t)((int32_t)240));
		int32_t L_21 = V_3;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_21, ((int32_t)15)));
		goto IL_0060;
	}

IL_0046:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_22 = V_2;
		int32_t* L_23 = ___2_dst_p;
		int32_t* L_24 = L_23;
		int32_t L_25 = *((int32_t*)L_24);
		int32_t L_26 = L_25;
		V_7 = L_26;
		*((int32_t*)L_24) = (int32_t)((int32_t)il2cpp_codegen_add(L_26, 1));
		int32_t L_27 = V_7;
		NullCheck(L_22);
		(L_22)->SetAt(static_cast<il2cpp_array_size_t>(L_27), (uint8_t)((int32_t)255));
		int32_t L_28 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_28, ((int32_t)255)));
	}

IL_0060:
	{
		int32_t L_29 = V_0;
		if ((((int32_t)L_29) > ((int32_t)((int32_t)254))))
		{
			goto IL_0046;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_30 = V_2;
		int32_t* L_31 = ___2_dst_p;
		int32_t* L_32 = L_31;
		int32_t L_33 = *((int32_t*)L_32);
		int32_t L_34 = L_33;
		V_8 = L_34;
		*((int32_t*)L_32) = (int32_t)((int32_t)il2cpp_codegen_add(L_34, 1));
		int32_t L_35 = V_8;
		int32_t L_36 = V_0;
		NullCheck(L_30);
		(L_30)->SetAt(static_cast<il2cpp_array_size_t>(L_35), (uint8_t)((int32_t)(uint8_t)L_36));
		goto IL_0081;
	}

IL_0079:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_37 = V_2;
		int32_t L_38 = V_4;
		int32_t L_39 = V_3;
		NullCheck(L_37);
		(L_37)->SetAt(static_cast<il2cpp_array_size_t>(L_38), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_39<<4))));
	}

IL_0081:
	{
		int32_t L_40 = V_3;
		if ((((int32_t)L_40) <= ((int32_t)0)))
		{
			goto IL_00a1;
		}
	}
	{
		int32_t* L_41 = ___2_dst_p;
		int32_t L_42 = *((int32_t*)L_41);
		int32_t L_43 = V_3;
		V_5 = ((int32_t)il2cpp_codegen_add(L_42, L_43));
		int32_t* L_44 = ___3_src_anchor;
		int32_t* L_45 = L_44;
		int32_t L_46 = *((int32_t*)L_45);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_47 = V_1;
		int32_t* L_48 = ___3_src_anchor;
		int32_t L_49 = *((int32_t*)L_48);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_50 = V_2;
		int32_t* L_51 = ___2_dst_p;
		int32_t L_52 = *((int32_t*)L_51);
		int32_t L_53 = V_5;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_54;
		L_54 = LZ4Codec_WildCopy_mE6E7FF3DC7D46D37614FDE84DDDEA5D03B0B5F94(L_47, L_49, L_50, L_52, L_53, NULL);
		*((int32_t*)L_45) = (int32_t)((int32_t)il2cpp_codegen_add(L_46, L_54));
		int32_t* L_55 = ___2_dst_p;
		int32_t L_56 = V_5;
		*((int32_t*)L_55) = (int32_t)L_56;
	}

IL_00a1:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_57 = V_2;
		int32_t* L_58 = ___2_dst_p;
		int32_t L_59 = *((int32_t*)L_58);
		int32_t* L_60 = ___1_src_p;
		int32_t L_61 = *((int32_t*)L_60);
		int32_t L_62 = ___5_src_ref;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_Poke2_mA9D6096893521372F0C65B006AE5A25C59E869E1(L_57, L_59, (uint16_t)((int32_t)(uint16_t)((int32_t)il2cpp_codegen_subtract(L_61, L_62))), NULL);
		int32_t* L_63 = ___2_dst_p;
		int32_t* L_64 = L_63;
		int32_t L_65 = *((int32_t*)L_64);
		*((int32_t*)L_64) = (int32_t)((int32_t)il2cpp_codegen_add(L_65, 2));
		int32_t L_66 = ___4_matchLength;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_66, 4));
		int32_t* L_67 = ___2_dst_p;
		int32_t L_68 = *((int32_t*)L_67);
		int32_t L_69 = V_3;
		int32_t L_70 = ___6_dst_end;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_68, 6)), ((int32_t)(L_69>>8))))) <= ((int32_t)L_70)))
		{
			goto IL_00c8;
		}
	}
	{
		return 1;
	}

IL_00c8:
	{
		int32_t L_71 = V_0;
		if ((((int32_t)L_71) < ((int32_t)((int32_t)15))))
		{
			goto IL_0155;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_72 = V_2;
		int32_t L_73 = V_4;
		NullCheck(L_72);
		uint8_t* L_74 = ((L_72)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_73)));
		uint8_t L_75 = (*(uint8_t*)L_74);
		*(uint8_t*)L_74 = (uint8_t)((int32_t)(uint8_t)((int32_t)il2cpp_codegen_add((int32_t)L_75, ((int32_t)15))));
		int32_t L_76 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_76, ((int32_t)15)));
		goto IL_011a;
	}

IL_00ee:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_77 = V_2;
		int32_t* L_78 = ___2_dst_p;
		int32_t* L_79 = L_78;
		int32_t L_80 = *((int32_t*)L_79);
		int32_t L_81 = L_80;
		V_9 = L_81;
		*((int32_t*)L_79) = (int32_t)((int32_t)il2cpp_codegen_add(L_81, 1));
		int32_t L_82 = V_9;
		NullCheck(L_77);
		(L_77)->SetAt(static_cast<il2cpp_array_size_t>(L_82), (uint8_t)((int32_t)255));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_83 = V_2;
		int32_t* L_84 = ___2_dst_p;
		int32_t* L_85 = L_84;
		int32_t L_86 = *((int32_t*)L_85);
		int32_t L_87 = L_86;
		V_10 = L_87;
		*((int32_t*)L_85) = (int32_t)((int32_t)il2cpp_codegen_add(L_87, 1));
		int32_t L_88 = V_10;
		NullCheck(L_83);
		(L_83)->SetAt(static_cast<il2cpp_array_size_t>(L_88), (uint8_t)((int32_t)255));
		int32_t L_89 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_89, ((int32_t)510)));
	}

IL_011a:
	{
		int32_t L_90 = V_0;
		if ((((int32_t)L_90) > ((int32_t)((int32_t)509))))
		{
			goto IL_00ee;
		}
	}
	{
		int32_t L_91 = V_0;
		if ((((int32_t)L_91) <= ((int32_t)((int32_t)254))))
		{
			goto IL_0144;
		}
	}
	{
		int32_t L_92 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_92, ((int32_t)255)));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_93 = V_2;
		int32_t* L_94 = ___2_dst_p;
		int32_t* L_95 = L_94;
		int32_t L_96 = *((int32_t*)L_95);
		int32_t L_97 = L_96;
		V_11 = L_97;
		*((int32_t*)L_95) = (int32_t)((int32_t)il2cpp_codegen_add(L_97, 1));
		int32_t L_98 = V_11;
		NullCheck(L_93);
		(L_93)->SetAt(static_cast<il2cpp_array_size_t>(L_98), (uint8_t)((int32_t)255));
	}

IL_0144:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_99 = V_2;
		int32_t* L_100 = ___2_dst_p;
		int32_t* L_101 = L_100;
		int32_t L_102 = *((int32_t*)L_101);
		int32_t L_103 = L_102;
		V_12 = L_103;
		*((int32_t*)L_101) = (int32_t)((int32_t)il2cpp_codegen_add(L_103, 1));
		int32_t L_104 = V_12;
		int32_t L_105 = V_0;
		NullCheck(L_99);
		(L_99)->SetAt(static_cast<il2cpp_array_size_t>(L_104), (uint8_t)((int32_t)(uint8_t)L_105));
		goto IL_016c;
	}

IL_0155:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_106 = V_2;
		int32_t L_107 = V_4;
		NullCheck(L_106);
		uint8_t* L_108 = ((L_106)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_107)));
		uint8_t L_109 = (*(uint8_t*)L_108);
		int32_t L_110 = V_0;
		*(uint8_t*)L_108 = (uint8_t)((int32_t)(uint8_t)((int32_t)il2cpp_codegen_add((int32_t)L_109, ((int32_t)(uint8_t)L_110))));
	}

IL_016c:
	{
		int32_t* L_111 = ___1_src_p;
		int32_t* L_112 = L_111;
		int32_t L_113 = *((int32_t*)L_112);
		int32_t L_114 = ___4_matchLength;
		*((int32_t*)L_112) = (int32_t)((int32_t)il2cpp_codegen_add(L_113, L_114));
		int32_t* L_115 = ___3_src_anchor;
		int32_t* L_116 = ___1_src_p;
		int32_t L_117 = *((int32_t*)L_116);
		*((int32_t*)L_115) = (int32_t)L_117;
		return 0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compressHCCtx_32_m080C9306A42AEF78E3E577950B54A4881DF59BE6 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	int32_t V_13 = 0;
	int32_t V_14 = 0;
	int32_t V_15 = 0;
	int32_t V_16 = 0;
	int32_t V_17 = 0;
	int32_t V_18 = 0;
	int32_t V_19 = 0;
	int32_t V_20 = 0;
	int32_t V_21 = 0;
	int32_t V_22 = 0;
	int32_t V_23 = 0;
	int32_t V_24 = 0;
	int32_t V_25 = 0;
	int32_t V_26 = 0;
	int32_t G_B7_0 = 0;
	int32_t G_B25_0 = 0;
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_0 = ___0_ctx;
		NullCheck(L_0);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = L_0->___src;
		V_0 = L_1;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_2 = ___0_ctx;
		NullCheck(L_2);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = L_2->___dst;
		V_1 = L_3;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_4 = ___0_ctx;
		NullCheck(L_4);
		int32_t L_5 = L_4->___src_base;
		V_2 = L_5;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_6 = ___0_ctx;
		NullCheck(L_6);
		int32_t L_7 = L_6->___src_end;
		V_3 = L_7;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_8 = ___0_ctx;
		NullCheck(L_8);
		int32_t L_9 = L_8->___dst_base;
		V_4 = L_9;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_10 = ___0_ctx;
		NullCheck(L_10);
		int32_t L_11 = L_10->___dst_len;
		V_5 = L_11;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_12 = ___0_ctx;
		NullCheck(L_12);
		int32_t L_13 = L_12->___dst_end;
		V_6 = L_13;
		int32_t L_14 = V_2;
		V_7 = L_14;
		int32_t L_15 = V_7;
		V_8 = L_15;
		int32_t L_16 = V_3;
		V_9 = ((int32_t)il2cpp_codegen_subtract(L_16, ((int32_t)12)));
		int32_t L_17 = V_4;
		V_10 = L_17;
		V_11 = 0;
		V_12 = 0;
		V_13 = 0;
		V_14 = 0;
		V_15 = 0;
		int32_t L_18 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add(L_18, 1));
		goto IL_02e8;
	}

IL_005f:
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_19 = ___0_ctx;
		int32_t L_20 = V_7;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_21;
		L_21 = LZ4Codec_LZ4HC_InsertAndFindBestMatch_32_mE1611C8BEB496B25C87D4ECC4ABB02F95B76FF70(L_19, L_20, (&V_11), NULL);
		V_16 = L_21;
		int32_t L_22 = V_16;
		if (L_22)
		{
			goto IL_007a;
		}
	}
	{
		int32_t L_23 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add(L_23, 1));
		goto IL_02e8;
	}

IL_007a:
	{
		int32_t L_24 = V_7;
		V_17 = L_24;
		int32_t L_25 = V_11;
		V_18 = L_25;
		int32_t L_26 = V_16;
		V_19 = L_26;
	}

IL_0086:
	{
		int32_t L_27 = V_7;
		int32_t L_28 = V_16;
		int32_t L_29 = V_9;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_27, L_28))) < ((int32_t)L_29)))
		{
			goto IL_0093;
		}
	}
	{
		int32_t L_30 = V_16;
		G_B7_0 = L_30;
		goto IL_00aa;
	}

IL_0093:
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_31 = ___0_ctx;
		int32_t L_32 = V_7;
		int32_t L_33 = V_16;
		int32_t L_34 = V_7;
		int32_t L_35 = V_16;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_36;
		L_36 = LZ4Codec_LZ4HC_InsertAndGetWiderMatch_32_mA128B9BA0971EF5D7C371E959A3339D3E2730826(L_31, ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_32, L_33)), 2)), ((int32_t)il2cpp_codegen_add(L_34, 1)), L_35, (&V_13), (&V_12), NULL);
		G_B7_0 = L_36;
	}

IL_00aa:
	{
		V_20 = G_B7_0;
		int32_t L_37 = V_20;
		int32_t L_38 = V_16;
		if ((!(((uint32_t)L_37) == ((uint32_t)L_38))))
		{
			goto IL_00cb;
		}
	}
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_39 = ___0_ctx;
		int32_t L_40 = V_16;
		int32_t L_41 = V_11;
		int32_t L_42 = V_6;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_43;
		L_43 = LZ4Codec_LZ4_encodeSequence_32_m961041D1CC42128E9D32E2F73F9E841AE125E316(L_39, (&V_7), (&V_10), (&V_8), L_40, L_41, L_42, NULL);
		if (!L_43)
		{
			goto IL_02e8;
		}
	}
	{
		return 0;
	}

IL_00cb:
	{
		int32_t L_44 = V_17;
		int32_t L_45 = V_7;
		if ((((int32_t)L_44) >= ((int32_t)L_45)))
		{
			goto IL_00e6;
		}
	}
	{
		int32_t L_46 = V_12;
		int32_t L_47 = V_7;
		int32_t L_48 = V_19;
		if ((((int32_t)L_46) >= ((int32_t)((int32_t)il2cpp_codegen_add(L_47, L_48)))))
		{
			goto IL_00e6;
		}
	}
	{
		int32_t L_49 = V_17;
		V_7 = L_49;
		int32_t L_50 = V_18;
		V_11 = L_50;
		int32_t L_51 = V_19;
		V_16 = L_51;
	}

IL_00e6:
	{
		int32_t L_52 = V_12;
		int32_t L_53 = V_7;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract(L_52, L_53))) >= ((int32_t)3)))
		{
			goto IL_00fc;
		}
	}
	{
		int32_t L_54 = V_20;
		V_16 = L_54;
		int32_t L_55 = V_12;
		V_7 = L_55;
		int32_t L_56 = V_13;
		V_11 = L_56;
		goto IL_0086;
	}

IL_00fc:
	{
		int32_t L_57 = V_12;
		int32_t L_58 = V_7;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract(L_57, L_58))) >= ((int32_t)((int32_t)18))))
		{
			goto IL_0151;
		}
	}
	{
		int32_t L_59 = V_16;
		V_21 = L_59;
		int32_t L_60 = V_21;
		if ((((int32_t)L_60) <= ((int32_t)((int32_t)18))))
		{
			goto IL_0113;
		}
	}
	{
		V_21 = ((int32_t)18);
	}

IL_0113:
	{
		int32_t L_61 = V_7;
		int32_t L_62 = V_21;
		int32_t L_63 = V_12;
		int32_t L_64 = V_20;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_61, L_62))) <= ((int32_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_63, L_64)), 4)))))
		{
			goto IL_012d;
		}
	}
	{
		int32_t L_65 = V_12;
		int32_t L_66 = V_7;
		int32_t L_67 = V_20;
		V_21 = ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_subtract(L_65, L_66)), L_67)), 4));
	}

IL_012d:
	{
		int32_t L_68 = V_21;
		int32_t L_69 = V_12;
		int32_t L_70 = V_7;
		V_22 = ((int32_t)il2cpp_codegen_subtract(L_68, ((int32_t)il2cpp_codegen_subtract(L_69, L_70))));
		int32_t L_71 = V_22;
		if ((((int32_t)L_71) <= ((int32_t)0)))
		{
			goto IL_0151;
		}
	}
	{
		int32_t L_72 = V_12;
		int32_t L_73 = V_22;
		V_12 = ((int32_t)il2cpp_codegen_add(L_72, L_73));
		int32_t L_74 = V_13;
		int32_t L_75 = V_22;
		V_13 = ((int32_t)il2cpp_codegen_add(L_74, L_75));
		int32_t L_76 = V_20;
		int32_t L_77 = V_22;
		V_20 = ((int32_t)il2cpp_codegen_subtract(L_76, L_77));
	}

IL_0151:
	{
		int32_t L_78 = V_12;
		int32_t L_79 = V_20;
		int32_t L_80 = V_9;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_78, L_79))) < ((int32_t)L_80)))
		{
			goto IL_015e;
		}
	}
	{
		int32_t L_81 = V_20;
		G_B25_0 = L_81;
		goto IL_0173;
	}

IL_015e:
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_82 = ___0_ctx;
		int32_t L_83 = V_12;
		int32_t L_84 = V_20;
		int32_t L_85 = V_12;
		int32_t L_86 = V_20;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_87;
		L_87 = LZ4Codec_LZ4HC_InsertAndGetWiderMatch_32_mA128B9BA0971EF5D7C371E959A3339D3E2730826(L_82, ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_83, L_84)), 3)), L_85, L_86, (&V_15), (&V_14), NULL);
		G_B25_0 = L_87;
	}

IL_0173:
	{
		V_23 = G_B25_0;
		int32_t L_88 = V_23;
		int32_t L_89 = V_20;
		if ((!(((uint32_t)L_88) == ((uint32_t)L_89))))
		{
			goto IL_01be;
		}
	}
	{
		int32_t L_90 = V_12;
		int32_t L_91 = V_7;
		int32_t L_92 = V_16;
		if ((((int32_t)L_90) >= ((int32_t)((int32_t)il2cpp_codegen_add(L_91, L_92)))))
		{
			goto IL_018b;
		}
	}
	{
		int32_t L_93 = V_12;
		int32_t L_94 = V_7;
		V_16 = ((int32_t)il2cpp_codegen_subtract(L_93, L_94));
	}

IL_018b:
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_95 = ___0_ctx;
		int32_t L_96 = V_16;
		int32_t L_97 = V_11;
		int32_t L_98 = V_6;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_99;
		L_99 = LZ4Codec_LZ4_encodeSequence_32_m961041D1CC42128E9D32E2F73F9E841AE125E316(L_95, (&V_7), (&V_10), (&V_8), L_96, L_97, L_98, NULL);
		if (!L_99)
		{
			goto IL_01a1;
		}
	}
	{
		return 0;
	}

IL_01a1:
	{
		int32_t L_100 = V_12;
		V_7 = L_100;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_101 = ___0_ctx;
		int32_t L_102 = V_20;
		int32_t L_103 = V_13;
		int32_t L_104 = V_6;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_105;
		L_105 = LZ4Codec_LZ4_encodeSequence_32_m961041D1CC42128E9D32E2F73F9E841AE125E316(L_101, (&V_7), (&V_10), (&V_8), L_102, L_103, L_104, NULL);
		if (!L_105)
		{
			goto IL_02e8;
		}
	}
	{
		return 0;
	}

IL_01be:
	{
		int32_t L_106 = V_14;
		int32_t L_107 = V_7;
		int32_t L_108 = V_16;
		if ((((int32_t)L_106) >= ((int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_107, L_108)), 3)))))
		{
			goto IL_0252;
		}
	}
	{
		int32_t L_109 = V_14;
		int32_t L_110 = V_7;
		int32_t L_111 = V_16;
		if ((((int32_t)L_109) < ((int32_t)((int32_t)il2cpp_codegen_add(L_110, L_111)))))
		{
			goto IL_0241;
		}
	}
	{
		int32_t L_112 = V_12;
		int32_t L_113 = V_7;
		int32_t L_114 = V_16;
		if ((((int32_t)L_112) >= ((int32_t)((int32_t)il2cpp_codegen_add(L_113, L_114)))))
		{
			goto IL_020e;
		}
	}
	{
		int32_t L_115 = V_7;
		int32_t L_116 = V_16;
		int32_t L_117 = V_12;
		V_24 = ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_115, L_116)), L_117));
		int32_t L_118 = V_12;
		int32_t L_119 = V_24;
		V_12 = ((int32_t)il2cpp_codegen_add(L_118, L_119));
		int32_t L_120 = V_13;
		int32_t L_121 = V_24;
		V_13 = ((int32_t)il2cpp_codegen_add(L_120, L_121));
		int32_t L_122 = V_20;
		int32_t L_123 = V_24;
		V_20 = ((int32_t)il2cpp_codegen_subtract(L_122, L_123));
		int32_t L_124 = V_20;
		if ((((int32_t)L_124) >= ((int32_t)4)))
		{
			goto IL_020e;
		}
	}
	{
		int32_t L_125 = V_14;
		V_12 = L_125;
		int32_t L_126 = V_15;
		V_13 = L_126;
		int32_t L_127 = V_23;
		V_20 = L_127;
	}

IL_020e:
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_128 = ___0_ctx;
		int32_t L_129 = V_16;
		int32_t L_130 = V_11;
		int32_t L_131 = V_6;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_132;
		L_132 = LZ4Codec_LZ4_encodeSequence_32_m961041D1CC42128E9D32E2F73F9E841AE125E316(L_128, (&V_7), (&V_10), (&V_8), L_129, L_130, L_131, NULL);
		if (!L_132)
		{
			goto IL_0224;
		}
	}
	{
		return 0;
	}

IL_0224:
	{
		int32_t L_133 = V_14;
		V_7 = L_133;
		int32_t L_134 = V_15;
		V_11 = L_134;
		int32_t L_135 = V_23;
		V_16 = L_135;
		int32_t L_136 = V_12;
		V_17 = L_136;
		int32_t L_137 = V_13;
		V_18 = L_137;
		int32_t L_138 = V_20;
		V_19 = L_138;
		goto IL_0086;
	}

IL_0241:
	{
		int32_t L_139 = V_14;
		V_12 = L_139;
		int32_t L_140 = V_15;
		V_13 = L_140;
		int32_t L_141 = V_23;
		V_20 = L_141;
		goto IL_00fc;
	}

IL_0252:
	{
		int32_t L_142 = V_12;
		int32_t L_143 = V_7;
		int32_t L_144 = V_16;
		if ((((int32_t)L_142) >= ((int32_t)((int32_t)il2cpp_codegen_add(L_143, L_144)))))
		{
			goto IL_02b5;
		}
	}
	{
		int32_t L_145 = V_12;
		int32_t L_146 = V_7;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract(L_145, L_146))) >= ((int32_t)((int32_t)15))))
		{
			goto IL_02ae;
		}
	}
	{
		int32_t L_147 = V_16;
		if ((((int32_t)L_147) <= ((int32_t)((int32_t)18))))
		{
			goto IL_026e;
		}
	}
	{
		V_16 = ((int32_t)18);
	}

IL_026e:
	{
		int32_t L_148 = V_7;
		int32_t L_149 = V_16;
		int32_t L_150 = V_12;
		int32_t L_151 = V_20;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_148, L_149))) <= ((int32_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_150, L_151)), 4)))))
		{
			goto IL_0288;
		}
	}
	{
		int32_t L_152 = V_12;
		int32_t L_153 = V_7;
		int32_t L_154 = V_20;
		V_16 = ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_subtract(L_152, L_153)), L_154)), 4));
	}

IL_0288:
	{
		int32_t L_155 = V_16;
		int32_t L_156 = V_12;
		int32_t L_157 = V_7;
		V_25 = ((int32_t)il2cpp_codegen_subtract(L_155, ((int32_t)il2cpp_codegen_subtract(L_156, L_157))));
		int32_t L_158 = V_25;
		if ((((int32_t)L_158) <= ((int32_t)0)))
		{
			goto IL_02b5;
		}
	}
	{
		int32_t L_159 = V_12;
		int32_t L_160 = V_25;
		V_12 = ((int32_t)il2cpp_codegen_add(L_159, L_160));
		int32_t L_161 = V_13;
		int32_t L_162 = V_25;
		V_13 = ((int32_t)il2cpp_codegen_add(L_161, L_162));
		int32_t L_163 = V_20;
		int32_t L_164 = V_25;
		V_20 = ((int32_t)il2cpp_codegen_subtract(L_163, L_164));
		goto IL_02b5;
	}

IL_02ae:
	{
		int32_t L_165 = V_12;
		int32_t L_166 = V_7;
		V_16 = ((int32_t)il2cpp_codegen_subtract(L_165, L_166));
	}

IL_02b5:
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_167 = ___0_ctx;
		int32_t L_168 = V_16;
		int32_t L_169 = V_11;
		int32_t L_170 = V_6;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_171;
		L_171 = LZ4Codec_LZ4_encodeSequence_32_m961041D1CC42128E9D32E2F73F9E841AE125E316(L_167, (&V_7), (&V_10), (&V_8), L_168, L_169, L_170, NULL);
		if (!L_171)
		{
			goto IL_02cb;
		}
	}
	{
		return 0;
	}

IL_02cb:
	{
		int32_t L_172 = V_12;
		V_7 = L_172;
		int32_t L_173 = V_13;
		V_11 = L_173;
		int32_t L_174 = V_20;
		V_16 = L_174;
		int32_t L_175 = V_14;
		V_12 = L_175;
		int32_t L_176 = V_15;
		V_13 = L_176;
		int32_t L_177 = V_23;
		V_20 = L_177;
		goto IL_00fc;
	}

IL_02e8:
	{
		int32_t L_178 = V_7;
		int32_t L_179 = V_9;
		if ((((int32_t)L_178) < ((int32_t)L_179)))
		{
			goto IL_005f;
		}
	}
	{
		int32_t L_180 = V_3;
		int32_t L_181 = V_8;
		V_26 = ((int32_t)il2cpp_codegen_subtract(L_180, L_181));
		int32_t L_182 = V_10;
		int32_t L_183 = V_4;
		int32_t L_184 = V_26;
		int32_t L_185 = V_26;
		int32_t L_186 = V_5;
		if ((((int64_t)((int64_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_subtract(L_182, L_183)), L_184)), 1)), ((int32_t)(((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_185, ((int32_t)255))), ((int32_t)15)))/((int32_t)255))))))) <= ((int64_t)((int64_t)(uint64_t)((uint32_t)L_186)))))
		{
			goto IL_031b;
		}
	}
	{
		return 0;
	}

IL_031b:
	{
		int32_t L_187 = V_26;
		if ((((int32_t)L_187) < ((int32_t)((int32_t)15))))
		{
			goto IL_0367;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_188 = V_1;
		int32_t L_189 = V_10;
		int32_t L_190 = L_189;
		V_10 = ((int32_t)il2cpp_codegen_add(L_190, 1));
		NullCheck(L_188);
		(L_188)->SetAt(static_cast<il2cpp_array_size_t>(L_190), (uint8_t)((int32_t)240));
		int32_t L_191 = V_26;
		V_26 = ((int32_t)il2cpp_codegen_subtract(L_191, ((int32_t)15)));
		goto IL_0350;
	}

IL_0338:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_192 = V_1;
		int32_t L_193 = V_10;
		int32_t L_194 = L_193;
		V_10 = ((int32_t)il2cpp_codegen_add(L_194, 1));
		NullCheck(L_192);
		(L_192)->SetAt(static_cast<il2cpp_array_size_t>(L_194), (uint8_t)((int32_t)255));
		int32_t L_195 = V_26;
		V_26 = ((int32_t)il2cpp_codegen_subtract(L_195, ((int32_t)255)));
	}

IL_0350:
	{
		int32_t L_196 = V_26;
		if ((((int32_t)L_196) > ((int32_t)((int32_t)254))))
		{
			goto IL_0338;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_197 = V_1;
		int32_t L_198 = V_10;
		int32_t L_199 = L_198;
		V_10 = ((int32_t)il2cpp_codegen_add(L_199, 1));
		int32_t L_200 = V_26;
		NullCheck(L_197);
		(L_197)->SetAt(static_cast<il2cpp_array_size_t>(L_199), (uint8_t)((int32_t)(uint8_t)L_200));
		goto IL_0375;
	}

IL_0367:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_201 = V_1;
		int32_t L_202 = V_10;
		int32_t L_203 = L_202;
		V_10 = ((int32_t)il2cpp_codegen_add(L_203, 1));
		int32_t L_204 = V_26;
		NullCheck(L_201);
		(L_201)->SetAt(static_cast<il2cpp_array_size_t>(L_203), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_204<<4))));
	}

IL_0375:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_205 = V_0;
		int32_t L_206 = V_8;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_207 = V_1;
		int32_t L_208 = V_10;
		int32_t L_209 = V_3;
		int32_t L_210 = V_8;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D(L_205, L_206, L_207, L_208, ((int32_t)il2cpp_codegen_subtract(L_209, L_210)), NULL);
		int32_t L_211 = V_10;
		int32_t L_212 = V_3;
		int32_t L_213 = V_8;
		V_10 = ((int32_t)il2cpp_codegen_add(L_211, ((int32_t)il2cpp_codegen_subtract(L_212, L_213))));
		int32_t L_214 = V_10;
		int32_t L_215 = V_4;
		return ((int32_t)il2cpp_codegen_subtract(L_214, L_215));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compressCtx_safe64_mCBD100E3B1B719762E9AF276BFB48D6C47684828 (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___0_hash_table, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___2_dst, int32_t ___3_src_0, int32_t ___4_dst_0, int32_t ___5_src_len, int32_t ___6_dst_maxlen, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_LZ4_compressCtx_safe64_mCBD100E3B1B719762E9AF276BFB48D6C47684828_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	int32_t V_13 = 0;
	int32_t V_14 = 0;
	int32_t V_15 = 0;
	uint32_t V_16 = 0;
	uint32_t V_17 = 0;
	int32_t V_18 = 0;
	int32_t V_19 = 0;
	int32_t V_20 = 0;
	int32_t V_21 = 0;
	int32_t V_22 = 0;
	int32_t V_23 = 0;
	int64_t V_24 = 0;
	int32_t V_25 = 0;
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_0 = ((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DEBRUIJN_TABLE_64;
		V_0 = L_0;
		int32_t L_1 = ___3_src_0;
		V_2 = L_1;
		int32_t L_2 = ___3_src_0;
		V_3 = L_2;
		int32_t L_3 = V_2;
		V_4 = L_3;
		int32_t L_4 = V_2;
		int32_t L_5 = ___5_src_len;
		V_5 = ((int32_t)il2cpp_codegen_add(L_4, L_5));
		int32_t L_6 = V_5;
		V_6 = ((int32_t)il2cpp_codegen_subtract(L_6, ((int32_t)12)));
		int32_t L_7 = ___4_dst_0;
		V_7 = L_7;
		int32_t L_8 = V_7;
		int32_t L_9 = ___6_dst_maxlen;
		V_8 = ((int32_t)il2cpp_codegen_add(L_8, L_9));
		int32_t L_10 = V_5;
		V_9 = ((int32_t)il2cpp_codegen_subtract(L_10, 5));
		int32_t L_11 = V_9;
		V_10 = ((int32_t)il2cpp_codegen_subtract(L_11, 1));
		int32_t L_12 = V_9;
		V_11 = ((int32_t)il2cpp_codegen_subtract(L_12, 3));
		int32_t L_13 = V_9;
		V_12 = ((int32_t)il2cpp_codegen_subtract(L_13, 7));
		int32_t L_14 = V_8;
		V_13 = ((int32_t)il2cpp_codegen_subtract(L_14, 6));
		int32_t L_15 = V_8;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_15, 8));
		int32_t L_16 = ___5_src_len;
		if ((((int32_t)L_16) < ((int32_t)((int32_t)13))))
		{
			goto IL_039b;
		}
	}
	{
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_17 = ___0_hash_table;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_18 = ___1_src;
		int32_t L_19 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_20;
		L_20 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_18, L_19, NULL);
		int32_t L_21 = V_2;
		int32_t L_22 = V_3;
		NullCheck(L_17);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_20, ((int32_t)-1640531535)))>>((int32_t)20))))), (int32_t)((int32_t)il2cpp_codegen_subtract(L_21, L_22)));
		int32_t L_23 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_23, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = ___1_src;
		int32_t L_25 = V_2;
		uint32_t L_26;
		L_26 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_24, L_25, NULL);
		V_17 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_26, ((int32_t)-1640531535)))>>((int32_t)20)));
	}

IL_007e:
	{
		V_18 = ((int32_t)67);
		int32_t L_27 = V_2;
		V_19 = L_27;
	}

IL_0085:
	{
		uint32_t L_28 = V_17;
		V_16 = L_28;
		int32_t L_29 = V_18;
		int32_t L_30 = L_29;
		V_18 = ((int32_t)il2cpp_codegen_add(L_30, 1));
		V_22 = ((int32_t)(L_30>>6));
		int32_t L_31 = V_19;
		V_2 = L_31;
		int32_t L_32 = V_2;
		int32_t L_33 = V_22;
		V_19 = ((int32_t)il2cpp_codegen_add(L_32, L_33));
		int32_t L_34 = V_19;
		int32_t L_35 = V_6;
		if ((((int32_t)L_34) > ((int32_t)L_35)))
		{
			goto IL_039b;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_36 = ___1_src;
		int32_t L_37 = V_19;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_38;
		L_38 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_36, L_37, NULL);
		V_17 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_38, ((int32_t)-1640531535)))>>((int32_t)20)));
		int32_t L_39 = V_3;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_40 = ___0_hash_table;
		uint32_t L_41 = V_16;
		NullCheck(L_40);
		uintptr_t L_42 = ((uintptr_t)L_41);
		int32_t L_43 = (L_40)->GetAt(static_cast<il2cpp_array_size_t>(L_42));
		V_20 = ((int32_t)il2cpp_codegen_add(L_39, L_43));
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_44 = ___0_hash_table;
		uint32_t L_45 = V_16;
		int32_t L_46 = V_2;
		int32_t L_47 = V_3;
		NullCheck(L_44);
		(L_44)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)L_45)), (int32_t)((int32_t)il2cpp_codegen_subtract(L_46, L_47)));
		int32_t L_48 = V_20;
		int32_t L_49 = V_2;
		if ((((int32_t)L_48) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_49, ((int32_t)65535))))))
		{
			goto IL_0085;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_50 = ___1_src;
		int32_t L_51 = V_20;
		int32_t L_52 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_53;
		L_53 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_50, L_51, L_52, NULL);
		if (!L_53)
		{
			goto IL_0085;
		}
	}
	{
		goto IL_00ec;
	}

IL_00e2:
	{
		int32_t L_54 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_subtract(L_54, 1));
		int32_t L_55 = V_20;
		V_20 = ((int32_t)il2cpp_codegen_subtract(L_55, 1));
	}

IL_00ec:
	{
		int32_t L_56 = V_2;
		int32_t L_57 = V_4;
		if ((((int32_t)L_56) <= ((int32_t)L_57)))
		{
			goto IL_0103;
		}
	}
	{
		int32_t L_58 = V_20;
		int32_t L_59 = ___3_src_0;
		if ((((int32_t)L_58) <= ((int32_t)L_59)))
		{
			goto IL_0103;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_60 = ___1_src;
		int32_t L_61 = V_2;
		NullCheck(L_60);
		int32_t L_62 = ((int32_t)il2cpp_codegen_subtract(L_61, 1));
		uint8_t L_63 = (L_60)->GetAt(static_cast<il2cpp_array_size_t>(L_62));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_64 = ___1_src;
		int32_t L_65 = V_20;
		NullCheck(L_64);
		int32_t L_66 = ((int32_t)il2cpp_codegen_subtract(L_65, 1));
		uint8_t L_67 = (L_64)->GetAt(static_cast<il2cpp_array_size_t>(L_66));
		if ((((int32_t)L_63) == ((int32_t)L_67)))
		{
			goto IL_00e2;
		}
	}

IL_0103:
	{
		int32_t L_68 = V_2;
		int32_t L_69 = V_4;
		V_15 = ((int32_t)il2cpp_codegen_subtract(L_68, L_69));
		int32_t L_70 = V_7;
		int32_t L_71 = L_70;
		V_7 = ((int32_t)il2cpp_codegen_add(L_71, 1));
		V_21 = L_71;
		int32_t L_72 = V_7;
		int32_t L_73 = V_15;
		int32_t L_74 = V_15;
		int32_t L_75 = V_14;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_72, L_73)), ((int32_t)(L_74>>8))))) <= ((int32_t)L_75)))
		{
			goto IL_0122;
		}
	}
	{
		return 0;
	}

IL_0122:
	{
		int32_t L_76 = V_15;
		if ((((int32_t)L_76) < ((int32_t)((int32_t)15))))
		{
			goto IL_0192;
		}
	}
	{
		int32_t L_77 = V_15;
		V_23 = ((int32_t)il2cpp_codegen_subtract(L_77, ((int32_t)15)));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_78 = ___2_dst;
		int32_t L_79 = V_21;
		NullCheck(L_78);
		(L_78)->SetAt(static_cast<il2cpp_array_size_t>(L_79), (uint8_t)((int32_t)240));
		int32_t L_80 = V_23;
		if ((((int32_t)L_80) <= ((int32_t)((int32_t)254))))
		{
			goto IL_0184;
		}
	}

IL_0141:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_81 = ___2_dst;
		int32_t L_82 = V_7;
		int32_t L_83 = L_82;
		V_7 = ((int32_t)il2cpp_codegen_add(L_83, 1));
		NullCheck(L_81);
		(L_81)->SetAt(static_cast<il2cpp_array_size_t>(L_83), (uint8_t)((int32_t)255));
		int32_t L_84 = V_23;
		V_23 = ((int32_t)il2cpp_codegen_subtract(L_84, ((int32_t)255)));
		int32_t L_85 = V_23;
		if ((((int32_t)L_85) > ((int32_t)((int32_t)254))))
		{
			goto IL_0141;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_86 = ___2_dst;
		int32_t L_87 = V_7;
		int32_t L_88 = L_87;
		V_7 = ((int32_t)il2cpp_codegen_add(L_88, 1));
		int32_t L_89 = V_23;
		NullCheck(L_86);
		(L_86)->SetAt(static_cast<il2cpp_array_size_t>(L_88), (uint8_t)((int32_t)(uint8_t)L_89));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_90 = ___1_src;
		int32_t L_91 = V_4;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_92 = ___2_dst;
		int32_t L_93 = V_7;
		int32_t L_94 = V_15;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D(L_90, L_91, L_92, L_93, L_94, NULL);
		int32_t L_95 = V_7;
		int32_t L_96 = V_15;
		V_7 = ((int32_t)il2cpp_codegen_add(L_95, L_96));
		goto IL_01b6;
	}

IL_0184:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_97 = ___2_dst;
		int32_t L_98 = V_7;
		int32_t L_99 = L_98;
		V_7 = ((int32_t)il2cpp_codegen_add(L_99, 1));
		int32_t L_100 = V_23;
		NullCheck(L_97);
		(L_97)->SetAt(static_cast<il2cpp_array_size_t>(L_99), (uint8_t)((int32_t)(uint8_t)L_100));
		goto IL_019b;
	}

IL_0192:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_101 = ___2_dst;
		int32_t L_102 = V_21;
		int32_t L_103 = V_15;
		NullCheck(L_101);
		(L_101)->SetAt(static_cast<il2cpp_array_size_t>(L_102), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_103<<4))));
	}

IL_019b:
	{
		int32_t L_104 = V_15;
		if ((((int32_t)L_104) <= ((int32_t)0)))
		{
			goto IL_01b6;
		}
	}
	{
		int32_t L_105 = V_7;
		int32_t L_106 = V_15;
		V_1 = ((int32_t)il2cpp_codegen_add(L_105, L_106));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_107 = ___1_src;
		int32_t L_108 = V_4;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_109 = ___2_dst;
		int32_t L_110 = V_7;
		int32_t L_111 = V_1;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_112;
		L_112 = LZ4Codec_WildCopy_mE6E7FF3DC7D46D37614FDE84DDDEA5D03B0B5F94(L_107, L_108, L_109, L_110, L_111, NULL);
		int32_t L_113 = V_1;
		V_7 = L_113;
	}

IL_01b6:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_114 = ___2_dst;
		int32_t L_115 = V_7;
		int32_t L_116 = V_2;
		int32_t L_117 = V_20;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_Poke2_mA9D6096893521372F0C65B006AE5A25C59E869E1(L_114, L_115, (uint16_t)((int32_t)(uint16_t)((int32_t)il2cpp_codegen_subtract(L_116, L_117))), NULL);
		int32_t L_118 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add(L_118, 2));
		int32_t L_119 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_119, 4));
		int32_t L_120 = V_20;
		V_20 = ((int32_t)il2cpp_codegen_add(L_120, 4));
		int32_t L_121 = V_2;
		V_4 = L_121;
		goto IL_0210;
	}

IL_01d8:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_122 = ___1_src;
		int32_t L_123 = V_20;
		int32_t L_124 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint64_t L_125;
		L_125 = LZ4Codec_Xor8_m4A7619EA57DCCFC5B2A17F222C94BE01C57E50BD(L_122, L_123, L_124, NULL);
		V_24 = L_125;
		int64_t L_126 = V_24;
		if ((!(((uint64_t)L_126) == ((uint64_t)((int64_t)0)))))
		{
			goto IL_01f5;
		}
	}
	{
		int32_t L_127 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_127, 8));
		int32_t L_128 = V_20;
		V_20 = ((int32_t)il2cpp_codegen_add(L_128, 8));
		goto IL_0210;
	}

IL_01f5:
	{
		int32_t L_129 = V_2;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_130 = V_0;
		int64_t L_131 = V_24;
		int64_t L_132 = V_24;
		if ((uint64_t)(((int64_t)((uint64_t)((int64_t)il2cpp_codegen_multiply(((int64_t)(L_131&((-L_132)))), ((int64_t)151050438428048703LL)))>>((int32_t)58)))) > INTPTR_MAX) IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), LZ4Codec_LZ4_compressCtx_safe64_mCBD100E3B1B719762E9AF276BFB48D6C47684828_RuntimeMethod_var);
		NullCheck(L_130);
		intptr_t L_133 = ((intptr_t)((int64_t)((uint64_t)((int64_t)il2cpp_codegen_multiply(((int64_t)(L_131&((-L_132)))), ((int64_t)151050438428048703LL)))>>((int32_t)58))));
		int32_t L_134 = (L_130)->GetAt(static_cast<il2cpp_array_size_t>(L_133));
		V_2 = ((int32_t)il2cpp_codegen_add(L_129, L_134));
		goto IL_025b;
	}

IL_0210:
	{
		int32_t L_135 = V_2;
		int32_t L_136 = V_12;
		if ((((int32_t)L_135) < ((int32_t)L_136)))
		{
			goto IL_01d8;
		}
	}
	{
		int32_t L_137 = V_2;
		int32_t L_138 = V_11;
		if ((((int32_t)L_137) >= ((int32_t)L_138)))
		{
			goto IL_022f;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_139 = ___1_src;
		int32_t L_140 = V_20;
		int32_t L_141 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_142;
		L_142 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_139, L_140, L_141, NULL);
		if (!L_142)
		{
			goto IL_022f;
		}
	}
	{
		int32_t L_143 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_143, 4));
		int32_t L_144 = V_20;
		V_20 = ((int32_t)il2cpp_codegen_add(L_144, 4));
	}

IL_022f:
	{
		int32_t L_145 = V_2;
		int32_t L_146 = V_10;
		if ((((int32_t)L_145) >= ((int32_t)L_146)))
		{
			goto IL_0249;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_147 = ___1_src;
		int32_t L_148 = V_20;
		int32_t L_149 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_150;
		L_150 = LZ4Codec_Equal2_m05C0F8A90FA336B8EFA50F98F2485EAF9A00FEF6(L_147, L_148, L_149, NULL);
		if (!L_150)
		{
			goto IL_0249;
		}
	}
	{
		int32_t L_151 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_151, 2));
		int32_t L_152 = V_20;
		V_20 = ((int32_t)il2cpp_codegen_add(L_152, 2));
	}

IL_0249:
	{
		int32_t L_153 = V_2;
		int32_t L_154 = V_9;
		if ((((int32_t)L_153) >= ((int32_t)L_154)))
		{
			goto IL_025b;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_155 = ___1_src;
		int32_t L_156 = V_20;
		NullCheck(L_155);
		int32_t L_157 = L_156;
		uint8_t L_158 = (L_155)->GetAt(static_cast<il2cpp_array_size_t>(L_157));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_159 = ___1_src;
		int32_t L_160 = V_2;
		NullCheck(L_159);
		int32_t L_161 = L_160;
		uint8_t L_162 = (L_159)->GetAt(static_cast<il2cpp_array_size_t>(L_161));
		if ((!(((uint32_t)L_158) == ((uint32_t)L_162))))
		{
			goto IL_025b;
		}
	}
	{
		int32_t L_163 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_163, 1));
	}

IL_025b:
	{
		int32_t L_164 = V_2;
		int32_t L_165 = V_4;
		V_15 = ((int32_t)il2cpp_codegen_subtract(L_164, L_165));
		int32_t L_166 = V_7;
		int32_t L_167 = V_15;
		int32_t L_168 = V_13;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_166, ((int32_t)(L_167>>8))))) <= ((int32_t)L_168)))
		{
			goto IL_026e;
		}
	}
	{
		return 0;
	}

IL_026e:
	{
		int32_t L_169 = V_15;
		if ((((int32_t)L_169) < ((int32_t)((int32_t)15))))
		{
			goto IL_02f2;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_170 = ___2_dst;
		int32_t L_171 = V_21;
		NullCheck(L_170);
		uint8_t* L_172 = ((L_170)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_171)));
		uint8_t L_173 = (*(uint8_t*)L_172);
		*(uint8_t*)L_172 = (uint8_t)((int32_t)(uint8_t)((int32_t)il2cpp_codegen_add((int32_t)L_173, ((int32_t)15))));
		int32_t L_174 = V_15;
		V_15 = ((int32_t)il2cpp_codegen_subtract(L_174, ((int32_t)15)));
		goto IL_02ba;
	}

IL_0294:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_175 = ___2_dst;
		int32_t L_176 = V_7;
		int32_t L_177 = L_176;
		V_7 = ((int32_t)il2cpp_codegen_add(L_177, 1));
		NullCheck(L_175);
		(L_175)->SetAt(static_cast<il2cpp_array_size_t>(L_177), (uint8_t)((int32_t)255));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_178 = ___2_dst;
		int32_t L_179 = V_7;
		int32_t L_180 = L_179;
		V_7 = ((int32_t)il2cpp_codegen_add(L_180, 1));
		NullCheck(L_178);
		(L_178)->SetAt(static_cast<il2cpp_array_size_t>(L_180), (uint8_t)((int32_t)255));
		int32_t L_181 = V_15;
		V_15 = ((int32_t)il2cpp_codegen_subtract(L_181, ((int32_t)510)));
	}

IL_02ba:
	{
		int32_t L_182 = V_15;
		if ((((int32_t)L_182) > ((int32_t)((int32_t)509))))
		{
			goto IL_0294;
		}
	}
	{
		int32_t L_183 = V_15;
		if ((((int32_t)L_183) <= ((int32_t)((int32_t)254))))
		{
			goto IL_02e4;
		}
	}
	{
		int32_t L_184 = V_15;
		V_15 = ((int32_t)il2cpp_codegen_subtract(L_184, ((int32_t)255)));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_185 = ___2_dst;
		int32_t L_186 = V_7;
		int32_t L_187 = L_186;
		V_7 = ((int32_t)il2cpp_codegen_add(L_187, 1));
		NullCheck(L_185);
		(L_185)->SetAt(static_cast<il2cpp_array_size_t>(L_187), (uint8_t)((int32_t)255));
	}

IL_02e4:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_188 = ___2_dst;
		int32_t L_189 = V_7;
		int32_t L_190 = L_189;
		V_7 = ((int32_t)il2cpp_codegen_add(L_190, 1));
		int32_t L_191 = V_15;
		NullCheck(L_188);
		(L_188)->SetAt(static_cast<il2cpp_array_size_t>(L_190), (uint8_t)((int32_t)(uint8_t)L_191));
		goto IL_030a;
	}

IL_02f2:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_192 = ___2_dst;
		int32_t L_193 = V_21;
		NullCheck(L_192);
		uint8_t* L_194 = ((L_192)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_193)));
		uint8_t L_195 = (*(uint8_t*)L_194);
		int32_t L_196 = V_15;
		*(uint8_t*)L_194 = (uint8_t)((int32_t)(uint8_t)((int32_t)il2cpp_codegen_add((int32_t)L_195, ((int32_t)(uint8_t)L_196))));
	}

IL_030a:
	{
		int32_t L_197 = V_2;
		int32_t L_198 = V_6;
		if ((((int32_t)L_197) <= ((int32_t)L_198)))
		{
			goto IL_0317;
		}
	}
	{
		int32_t L_199 = V_2;
		V_4 = L_199;
		goto IL_039b;
	}

IL_0317:
	{
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_200 = ___0_hash_table;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_201 = ___1_src;
		int32_t L_202 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_203;
		L_203 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_201, ((int32_t)il2cpp_codegen_subtract(L_202, 2)), NULL);
		int32_t L_204 = V_2;
		int32_t L_205 = V_3;
		NullCheck(L_200);
		(L_200)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_203, ((int32_t)-1640531535)))>>((int32_t)20))))), (int32_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_subtract(L_204, 2)), L_205)));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_206 = ___1_src;
		int32_t L_207 = V_2;
		uint32_t L_208;
		L_208 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_206, L_207, NULL);
		V_16 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_208, ((int32_t)-1640531535)))>>((int32_t)20)));
		int32_t L_209 = V_3;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_210 = ___0_hash_table;
		uint32_t L_211 = V_16;
		NullCheck(L_210);
		uintptr_t L_212 = ((uintptr_t)L_211);
		int32_t L_213 = (L_210)->GetAt(static_cast<il2cpp_array_size_t>(L_212));
		V_20 = ((int32_t)il2cpp_codegen_add(L_209, L_213));
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_214 = ___0_hash_table;
		uint32_t L_215 = V_16;
		int32_t L_216 = V_2;
		int32_t L_217 = V_3;
		NullCheck(L_214);
		(L_214)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)L_215)), (int32_t)((int32_t)il2cpp_codegen_subtract(L_216, L_217)));
		int32_t L_218 = V_20;
		int32_t L_219 = V_2;
		if ((((int32_t)L_218) <= ((int32_t)((int32_t)il2cpp_codegen_subtract(L_219, ((int32_t)65536))))))
		{
			goto IL_037d;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_220 = ___1_src;
		int32_t L_221 = V_20;
		int32_t L_222 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_223;
		L_223 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_220, L_221, L_222, NULL);
		if (!L_223)
		{
			goto IL_037d;
		}
	}
	{
		int32_t L_224 = V_7;
		int32_t L_225 = L_224;
		V_7 = ((int32_t)il2cpp_codegen_add(L_225, 1));
		V_21 = L_225;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_226 = ___2_dst;
		int32_t L_227 = V_21;
		NullCheck(L_226);
		(L_226)->SetAt(static_cast<il2cpp_array_size_t>(L_227), (uint8_t)0);
		goto IL_01b6;
	}

IL_037d:
	{
		int32_t L_228 = V_2;
		int32_t L_229 = L_228;
		V_2 = ((int32_t)il2cpp_codegen_add(L_229, 1));
		V_4 = L_229;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_230 = ___1_src;
		int32_t L_231 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_232;
		L_232 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_230, L_231, NULL);
		V_17 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_232, ((int32_t)-1640531535)))>>((int32_t)20)));
		goto IL_007e;
	}

IL_039b:
	{
		int32_t L_233 = V_5;
		int32_t L_234 = V_4;
		V_25 = ((int32_t)il2cpp_codegen_subtract(L_233, L_234));
		int32_t L_235 = V_7;
		int32_t L_236 = V_25;
		int32_t L_237 = V_25;
		int32_t L_238 = V_8;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_235, L_236)), 1)), ((int32_t)(((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_237, ((int32_t)255))), ((int32_t)15)))/((int32_t)255)))))) <= ((int32_t)L_238)))
		{
			goto IL_03c1;
		}
	}
	{
		return 0;
	}

IL_03c1:
	{
		int32_t L_239 = V_25;
		if ((((int32_t)L_239) < ((int32_t)((int32_t)15))))
		{
			goto IL_040d;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_240 = ___2_dst;
		int32_t L_241 = V_7;
		int32_t L_242 = L_241;
		V_7 = ((int32_t)il2cpp_codegen_add(L_242, 1));
		NullCheck(L_240);
		(L_240)->SetAt(static_cast<il2cpp_array_size_t>(L_242), (uint8_t)((int32_t)240));
		int32_t L_243 = V_25;
		V_25 = ((int32_t)il2cpp_codegen_subtract(L_243, ((int32_t)15)));
		goto IL_03f6;
	}

IL_03de:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_244 = ___2_dst;
		int32_t L_245 = V_7;
		int32_t L_246 = L_245;
		V_7 = ((int32_t)il2cpp_codegen_add(L_246, 1));
		NullCheck(L_244);
		(L_244)->SetAt(static_cast<il2cpp_array_size_t>(L_246), (uint8_t)((int32_t)255));
		int32_t L_247 = V_25;
		V_25 = ((int32_t)il2cpp_codegen_subtract(L_247, ((int32_t)255)));
	}

IL_03f6:
	{
		int32_t L_248 = V_25;
		if ((((int32_t)L_248) > ((int32_t)((int32_t)254))))
		{
			goto IL_03de;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_249 = ___2_dst;
		int32_t L_250 = V_7;
		int32_t L_251 = L_250;
		V_7 = ((int32_t)il2cpp_codegen_add(L_251, 1));
		int32_t L_252 = V_25;
		NullCheck(L_249);
		(L_249)->SetAt(static_cast<il2cpp_array_size_t>(L_251), (uint8_t)((int32_t)(uint8_t)L_252));
		goto IL_041b;
	}

IL_040d:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_253 = ___2_dst;
		int32_t L_254 = V_7;
		int32_t L_255 = L_254;
		V_7 = ((int32_t)il2cpp_codegen_add(L_255, 1));
		int32_t L_256 = V_25;
		NullCheck(L_253);
		(L_253)->SetAt(static_cast<il2cpp_array_size_t>(L_255), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_256<<4))));
	}

IL_041b:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_257 = ___1_src;
		int32_t L_258 = V_4;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_259 = ___2_dst;
		int32_t L_260 = V_7;
		int32_t L_261 = V_5;
		int32_t L_262 = V_4;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D(L_257, L_258, L_259, L_260, ((int32_t)il2cpp_codegen_subtract(L_261, L_262)), NULL);
		int32_t L_263 = V_7;
		int32_t L_264 = V_5;
		int32_t L_265 = V_4;
		V_7 = ((int32_t)il2cpp_codegen_add(L_263, ((int32_t)il2cpp_codegen_subtract(L_264, L_265))));
		int32_t L_266 = V_7;
		int32_t L_267 = ___4_dst_0;
		return ((int32_t)il2cpp_codegen_subtract(L_266, L_267));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compress64kCtx_safe64_m0B1F935369022A7FF506A9C3AF21AE4331F7ECF3 (UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* ___0_hash_table, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___2_dst, int32_t ___3_src_0, int32_t ___4_dst_0, int32_t ___5_src_len, int32_t ___6_dst_maxlen, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_LZ4_compress64kCtx_safe64_m0B1F935369022A7FF506A9C3AF21AE4331F7ECF3_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	int32_t V_13 = 0;
	int32_t V_14 = 0;
	int32_t V_15 = 0;
	int32_t V_16 = 0;
	uint32_t V_17 = 0;
	uint32_t V_18 = 0;
	int32_t V_19 = 0;
	int32_t V_20 = 0;
	int32_t V_21 = 0;
	int32_t V_22 = 0;
	int32_t V_23 = 0;
	int64_t V_24 = 0;
	int32_t V_25 = 0;
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_0 = ((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DEBRUIJN_TABLE_64;
		V_0 = L_0;
		int32_t L_1 = ___3_src_0;
		V_2 = L_1;
		int32_t L_2 = V_2;
		V_3 = L_2;
		int32_t L_3 = V_2;
		V_4 = L_3;
		int32_t L_4 = V_2;
		int32_t L_5 = ___5_src_len;
		V_5 = ((int32_t)il2cpp_codegen_add(L_4, L_5));
		int32_t L_6 = V_5;
		V_6 = ((int32_t)il2cpp_codegen_subtract(L_6, ((int32_t)12)));
		int32_t L_7 = ___4_dst_0;
		V_7 = L_7;
		int32_t L_8 = V_7;
		int32_t L_9 = ___6_dst_maxlen;
		V_8 = ((int32_t)il2cpp_codegen_add(L_8, L_9));
		int32_t L_10 = V_5;
		V_9 = ((int32_t)il2cpp_codegen_subtract(L_10, 5));
		int32_t L_11 = V_9;
		V_10 = ((int32_t)il2cpp_codegen_subtract(L_11, 1));
		int32_t L_12 = V_9;
		V_11 = ((int32_t)il2cpp_codegen_subtract(L_12, 3));
		int32_t L_13 = V_9;
		V_12 = ((int32_t)il2cpp_codegen_subtract(L_13, 7));
		int32_t L_14 = V_8;
		V_13 = ((int32_t)il2cpp_codegen_subtract(L_14, 6));
		int32_t L_15 = V_8;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_15, 8));
		int32_t L_16 = ___5_src_len;
		if ((((int32_t)L_16) < ((int32_t)((int32_t)13))))
		{
			goto IL_036c;
		}
	}
	{
		int32_t L_17 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_17, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_18 = ___1_src;
		int32_t L_19 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_20;
		L_20 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_18, L_19, NULL);
		V_18 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_20, ((int32_t)-1640531535)))>>((int32_t)19)));
	}

IL_0068:
	{
		V_19 = ((int32_t)67);
		int32_t L_21 = V_2;
		V_20 = L_21;
	}

IL_006f:
	{
		uint32_t L_22 = V_18;
		V_17 = L_22;
		int32_t L_23 = V_19;
		int32_t L_24 = L_23;
		V_19 = ((int32_t)il2cpp_codegen_add(L_24, 1));
		V_23 = ((int32_t)(L_24>>6));
		int32_t L_25 = V_20;
		V_2 = L_25;
		int32_t L_26 = V_2;
		int32_t L_27 = V_23;
		V_20 = ((int32_t)il2cpp_codegen_add(L_26, L_27));
		int32_t L_28 = V_20;
		int32_t L_29 = V_6;
		if ((((int32_t)L_28) > ((int32_t)L_29)))
		{
			goto IL_036c;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_30 = ___1_src;
		int32_t L_31 = V_20;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_32;
		L_32 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_30, L_31, NULL);
		V_18 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_32, ((int32_t)-1640531535)))>>((int32_t)19)));
		int32_t L_33 = V_4;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_34 = ___0_hash_table;
		uint32_t L_35 = V_17;
		NullCheck(L_34);
		uintptr_t L_36 = ((uintptr_t)L_35);
		uint16_t L_37 = (L_34)->GetAt(static_cast<il2cpp_array_size_t>(L_36));
		V_21 = ((int32_t)il2cpp_codegen_add(L_33, (int32_t)L_37));
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_38 = ___0_hash_table;
		uint32_t L_39 = V_17;
		int32_t L_40 = V_2;
		int32_t L_41 = V_4;
		NullCheck(L_38);
		(L_38)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)L_39)), (uint16_t)((int32_t)(uint16_t)((int32_t)il2cpp_codegen_subtract(L_40, L_41))));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_42 = ___1_src;
		int32_t L_43 = V_21;
		int32_t L_44 = V_2;
		bool L_45;
		L_45 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_42, L_43, L_44, NULL);
		if (!L_45)
		{
			goto IL_006f;
		}
	}
	{
		goto IL_00ce;
	}

IL_00c4:
	{
		int32_t L_46 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_subtract(L_46, 1));
		int32_t L_47 = V_21;
		V_21 = ((int32_t)il2cpp_codegen_subtract(L_47, 1));
	}

IL_00ce:
	{
		int32_t L_48 = V_2;
		int32_t L_49 = V_3;
		if ((((int32_t)L_48) <= ((int32_t)L_49)))
		{
			goto IL_00e4;
		}
	}
	{
		int32_t L_50 = V_21;
		int32_t L_51 = ___3_src_0;
		if ((((int32_t)L_50) <= ((int32_t)L_51)))
		{
			goto IL_00e4;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_52 = ___1_src;
		int32_t L_53 = V_2;
		NullCheck(L_52);
		int32_t L_54 = ((int32_t)il2cpp_codegen_subtract(L_53, 1));
		uint8_t L_55 = (L_52)->GetAt(static_cast<il2cpp_array_size_t>(L_54));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_56 = ___1_src;
		int32_t L_57 = V_21;
		NullCheck(L_56);
		int32_t L_58 = ((int32_t)il2cpp_codegen_subtract(L_57, 1));
		uint8_t L_59 = (L_56)->GetAt(static_cast<il2cpp_array_size_t>(L_58));
		if ((((int32_t)L_55) == ((int32_t)L_59)))
		{
			goto IL_00c4;
		}
	}

IL_00e4:
	{
		int32_t L_60 = V_2;
		int32_t L_61 = V_3;
		V_16 = ((int32_t)il2cpp_codegen_subtract(L_60, L_61));
		int32_t L_62 = V_7;
		int32_t L_63 = L_62;
		V_7 = ((int32_t)il2cpp_codegen_add(L_63, 1));
		V_22 = L_63;
		int32_t L_64 = V_7;
		int32_t L_65 = V_16;
		int32_t L_66 = V_16;
		int32_t L_67 = V_14;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_64, L_65)), ((int32_t)(L_66>>8))))) <= ((int32_t)L_67)))
		{
			goto IL_0102;
		}
	}
	{
		return 0;
	}

IL_0102:
	{
		int32_t L_68 = V_16;
		if ((((int32_t)L_68) < ((int32_t)((int32_t)15))))
		{
			goto IL_0171;
		}
	}
	{
		int32_t L_69 = V_16;
		V_15 = ((int32_t)il2cpp_codegen_subtract(L_69, ((int32_t)15)));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_70 = ___2_dst;
		int32_t L_71 = V_22;
		NullCheck(L_70);
		(L_70)->SetAt(static_cast<il2cpp_array_size_t>(L_71), (uint8_t)((int32_t)240));
		int32_t L_72 = V_15;
		if ((((int32_t)L_72) <= ((int32_t)((int32_t)254))))
		{
			goto IL_0163;
		}
	}

IL_0121:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_73 = ___2_dst;
		int32_t L_74 = V_7;
		int32_t L_75 = L_74;
		V_7 = ((int32_t)il2cpp_codegen_add(L_75, 1));
		NullCheck(L_73);
		(L_73)->SetAt(static_cast<il2cpp_array_size_t>(L_75), (uint8_t)((int32_t)255));
		int32_t L_76 = V_15;
		V_15 = ((int32_t)il2cpp_codegen_subtract(L_76, ((int32_t)255)));
		int32_t L_77 = V_15;
		if ((((int32_t)L_77) > ((int32_t)((int32_t)254))))
		{
			goto IL_0121;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_78 = ___2_dst;
		int32_t L_79 = V_7;
		int32_t L_80 = L_79;
		V_7 = ((int32_t)il2cpp_codegen_add(L_80, 1));
		int32_t L_81 = V_15;
		NullCheck(L_78);
		(L_78)->SetAt(static_cast<il2cpp_array_size_t>(L_80), (uint8_t)((int32_t)(uint8_t)L_81));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_82 = ___1_src;
		int32_t L_83 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_84 = ___2_dst;
		int32_t L_85 = V_7;
		int32_t L_86 = V_16;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D(L_82, L_83, L_84, L_85, L_86, NULL);
		int32_t L_87 = V_7;
		int32_t L_88 = V_16;
		V_7 = ((int32_t)il2cpp_codegen_add(L_87, L_88));
		goto IL_0194;
	}

IL_0163:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_89 = ___2_dst;
		int32_t L_90 = V_7;
		int32_t L_91 = L_90;
		V_7 = ((int32_t)il2cpp_codegen_add(L_91, 1));
		int32_t L_92 = V_15;
		NullCheck(L_89);
		(L_89)->SetAt(static_cast<il2cpp_array_size_t>(L_91), (uint8_t)((int32_t)(uint8_t)L_92));
		goto IL_017a;
	}

IL_0171:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_93 = ___2_dst;
		int32_t L_94 = V_22;
		int32_t L_95 = V_16;
		NullCheck(L_93);
		(L_93)->SetAt(static_cast<il2cpp_array_size_t>(L_94), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_95<<4))));
	}

IL_017a:
	{
		int32_t L_96 = V_16;
		if ((((int32_t)L_96) <= ((int32_t)0)))
		{
			goto IL_0194;
		}
	}
	{
		int32_t L_97 = V_7;
		int32_t L_98 = V_16;
		V_1 = ((int32_t)il2cpp_codegen_add(L_97, L_98));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_99 = ___1_src;
		int32_t L_100 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_101 = ___2_dst;
		int32_t L_102 = V_7;
		int32_t L_103 = V_1;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_104;
		L_104 = LZ4Codec_WildCopy_mE6E7FF3DC7D46D37614FDE84DDDEA5D03B0B5F94(L_99, L_100, L_101, L_102, L_103, NULL);
		int32_t L_105 = V_1;
		V_7 = L_105;
	}

IL_0194:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_106 = ___2_dst;
		int32_t L_107 = V_7;
		int32_t L_108 = V_2;
		int32_t L_109 = V_21;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_Poke2_mA9D6096893521372F0C65B006AE5A25C59E869E1(L_106, L_107, (uint16_t)((int32_t)(uint16_t)((int32_t)il2cpp_codegen_subtract(L_108, L_109))), NULL);
		int32_t L_110 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add(L_110, 2));
		int32_t L_111 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_111, 4));
		int32_t L_112 = V_21;
		V_21 = ((int32_t)il2cpp_codegen_add(L_112, 4));
		int32_t L_113 = V_2;
		V_3 = L_113;
		goto IL_01ed;
	}

IL_01b5:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_114 = ___1_src;
		int32_t L_115 = V_21;
		int32_t L_116 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint64_t L_117;
		L_117 = LZ4Codec_Xor8_m4A7619EA57DCCFC5B2A17F222C94BE01C57E50BD(L_114, L_115, L_116, NULL);
		V_24 = L_117;
		int64_t L_118 = V_24;
		if ((!(((uint64_t)L_118) == ((uint64_t)((int64_t)0)))))
		{
			goto IL_01d2;
		}
	}
	{
		int32_t L_119 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_119, 8));
		int32_t L_120 = V_21;
		V_21 = ((int32_t)il2cpp_codegen_add(L_120, 8));
		goto IL_01ed;
	}

IL_01d2:
	{
		int32_t L_121 = V_2;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_122 = V_0;
		int64_t L_123 = V_24;
		int64_t L_124 = V_24;
		if ((uint64_t)(((int64_t)((uint64_t)((int64_t)il2cpp_codegen_multiply(((int64_t)(L_123&((-L_124)))), ((int64_t)151050438428048703LL)))>>((int32_t)58)))) > INTPTR_MAX) IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), LZ4Codec_LZ4_compress64kCtx_safe64_m0B1F935369022A7FF506A9C3AF21AE4331F7ECF3_RuntimeMethod_var);
		NullCheck(L_122);
		intptr_t L_125 = ((intptr_t)((int64_t)((uint64_t)((int64_t)il2cpp_codegen_multiply(((int64_t)(L_123&((-L_124)))), ((int64_t)151050438428048703LL)))>>((int32_t)58))));
		int32_t L_126 = (L_122)->GetAt(static_cast<il2cpp_array_size_t>(L_125));
		V_2 = ((int32_t)il2cpp_codegen_add(L_121, L_126));
		goto IL_0238;
	}

IL_01ed:
	{
		int32_t L_127 = V_2;
		int32_t L_128 = V_12;
		if ((((int32_t)L_127) < ((int32_t)L_128)))
		{
			goto IL_01b5;
		}
	}
	{
		int32_t L_129 = V_2;
		int32_t L_130 = V_11;
		if ((((int32_t)L_129) >= ((int32_t)L_130)))
		{
			goto IL_020c;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_131 = ___1_src;
		int32_t L_132 = V_21;
		int32_t L_133 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_134;
		L_134 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_131, L_132, L_133, NULL);
		if (!L_134)
		{
			goto IL_020c;
		}
	}
	{
		int32_t L_135 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_135, 4));
		int32_t L_136 = V_21;
		V_21 = ((int32_t)il2cpp_codegen_add(L_136, 4));
	}

IL_020c:
	{
		int32_t L_137 = V_2;
		int32_t L_138 = V_10;
		if ((((int32_t)L_137) >= ((int32_t)L_138)))
		{
			goto IL_0226;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_139 = ___1_src;
		int32_t L_140 = V_21;
		int32_t L_141 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_142;
		L_142 = LZ4Codec_Equal2_m05C0F8A90FA336B8EFA50F98F2485EAF9A00FEF6(L_139, L_140, L_141, NULL);
		if (!L_142)
		{
			goto IL_0226;
		}
	}
	{
		int32_t L_143 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_143, 2));
		int32_t L_144 = V_21;
		V_21 = ((int32_t)il2cpp_codegen_add(L_144, 2));
	}

IL_0226:
	{
		int32_t L_145 = V_2;
		int32_t L_146 = V_9;
		if ((((int32_t)L_145) >= ((int32_t)L_146)))
		{
			goto IL_0238;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_147 = ___1_src;
		int32_t L_148 = V_21;
		NullCheck(L_147);
		int32_t L_149 = L_148;
		uint8_t L_150 = (L_147)->GetAt(static_cast<il2cpp_array_size_t>(L_149));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_151 = ___1_src;
		int32_t L_152 = V_2;
		NullCheck(L_151);
		int32_t L_153 = L_152;
		uint8_t L_154 = (L_151)->GetAt(static_cast<il2cpp_array_size_t>(L_153));
		if ((!(((uint32_t)L_150) == ((uint32_t)L_154))))
		{
			goto IL_0238;
		}
	}
	{
		int32_t L_155 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_155, 1));
	}

IL_0238:
	{
		int32_t L_156 = V_2;
		int32_t L_157 = V_3;
		V_15 = ((int32_t)il2cpp_codegen_subtract(L_156, L_157));
		int32_t L_158 = V_7;
		int32_t L_159 = V_15;
		int32_t L_160 = V_13;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_158, ((int32_t)(L_159>>8))))) <= ((int32_t)L_160)))
		{
			goto IL_024a;
		}
	}
	{
		return 0;
	}

IL_024a:
	{
		int32_t L_161 = V_15;
		if ((((int32_t)L_161) < ((int32_t)((int32_t)15))))
		{
			goto IL_02ce;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_162 = ___2_dst;
		int32_t L_163 = V_22;
		NullCheck(L_162);
		uint8_t* L_164 = ((L_162)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_163)));
		uint8_t L_165 = (*(uint8_t*)L_164);
		*(uint8_t*)L_164 = (uint8_t)((int32_t)(uint8_t)((int32_t)il2cpp_codegen_add((int32_t)L_165, ((int32_t)15))));
		int32_t L_166 = V_15;
		V_15 = ((int32_t)il2cpp_codegen_subtract(L_166, ((int32_t)15)));
		goto IL_0296;
	}

IL_0270:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_167 = ___2_dst;
		int32_t L_168 = V_7;
		int32_t L_169 = L_168;
		V_7 = ((int32_t)il2cpp_codegen_add(L_169, 1));
		NullCheck(L_167);
		(L_167)->SetAt(static_cast<il2cpp_array_size_t>(L_169), (uint8_t)((int32_t)255));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_170 = ___2_dst;
		int32_t L_171 = V_7;
		int32_t L_172 = L_171;
		V_7 = ((int32_t)il2cpp_codegen_add(L_172, 1));
		NullCheck(L_170);
		(L_170)->SetAt(static_cast<il2cpp_array_size_t>(L_172), (uint8_t)((int32_t)255));
		int32_t L_173 = V_15;
		V_15 = ((int32_t)il2cpp_codegen_subtract(L_173, ((int32_t)510)));
	}

IL_0296:
	{
		int32_t L_174 = V_15;
		if ((((int32_t)L_174) > ((int32_t)((int32_t)509))))
		{
			goto IL_0270;
		}
	}
	{
		int32_t L_175 = V_15;
		if ((((int32_t)L_175) <= ((int32_t)((int32_t)254))))
		{
			goto IL_02c0;
		}
	}
	{
		int32_t L_176 = V_15;
		V_15 = ((int32_t)il2cpp_codegen_subtract(L_176, ((int32_t)255)));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_177 = ___2_dst;
		int32_t L_178 = V_7;
		int32_t L_179 = L_178;
		V_7 = ((int32_t)il2cpp_codegen_add(L_179, 1));
		NullCheck(L_177);
		(L_177)->SetAt(static_cast<il2cpp_array_size_t>(L_179), (uint8_t)((int32_t)255));
	}

IL_02c0:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_180 = ___2_dst;
		int32_t L_181 = V_7;
		int32_t L_182 = L_181;
		V_7 = ((int32_t)il2cpp_codegen_add(L_182, 1));
		int32_t L_183 = V_15;
		NullCheck(L_180);
		(L_180)->SetAt(static_cast<il2cpp_array_size_t>(L_182), (uint8_t)((int32_t)(uint8_t)L_183));
		goto IL_02e6;
	}

IL_02ce:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_184 = ___2_dst;
		int32_t L_185 = V_22;
		NullCheck(L_184);
		uint8_t* L_186 = ((L_184)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_185)));
		uint8_t L_187 = (*(uint8_t*)L_186);
		int32_t L_188 = V_15;
		*(uint8_t*)L_186 = (uint8_t)((int32_t)(uint8_t)((int32_t)il2cpp_codegen_add((int32_t)L_187, ((int32_t)(uint8_t)L_188))));
	}

IL_02e6:
	{
		int32_t L_189 = V_2;
		int32_t L_190 = V_6;
		if ((((int32_t)L_189) <= ((int32_t)L_190)))
		{
			goto IL_02ef;
		}
	}
	{
		int32_t L_191 = V_2;
		V_3 = L_191;
		goto IL_036c;
	}

IL_02ef:
	{
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_192 = ___0_hash_table;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_193 = ___1_src;
		int32_t L_194 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_195;
		L_195 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_193, ((int32_t)il2cpp_codegen_subtract(L_194, 2)), NULL);
		int32_t L_196 = V_2;
		int32_t L_197 = V_4;
		NullCheck(L_192);
		(L_192)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_195, ((int32_t)-1640531535)))>>((int32_t)19))))), (uint16_t)((int32_t)(uint16_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_subtract(L_196, 2)), L_197))));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_198 = ___1_src;
		int32_t L_199 = V_2;
		uint32_t L_200;
		L_200 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_198, L_199, NULL);
		V_17 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_200, ((int32_t)-1640531535)))>>((int32_t)19)));
		int32_t L_201 = V_4;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_202 = ___0_hash_table;
		uint32_t L_203 = V_17;
		NullCheck(L_202);
		uintptr_t L_204 = ((uintptr_t)L_203);
		uint16_t L_205 = (L_202)->GetAt(static_cast<il2cpp_array_size_t>(L_204));
		V_21 = ((int32_t)il2cpp_codegen_add(L_201, (int32_t)L_205));
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_206 = ___0_hash_table;
		uint32_t L_207 = V_17;
		int32_t L_208 = V_2;
		int32_t L_209 = V_4;
		NullCheck(L_206);
		(L_206)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)L_207)), (uint16_t)((int32_t)(uint16_t)((int32_t)il2cpp_codegen_subtract(L_208, L_209))));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_210 = ___1_src;
		int32_t L_211 = V_21;
		int32_t L_212 = V_2;
		bool L_213;
		L_213 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_210, L_211, L_212, NULL);
		if (!L_213)
		{
			goto IL_034f;
		}
	}
	{
		int32_t L_214 = V_7;
		int32_t L_215 = L_214;
		V_7 = ((int32_t)il2cpp_codegen_add(L_215, 1));
		V_22 = L_215;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_216 = ___2_dst;
		int32_t L_217 = V_22;
		NullCheck(L_216);
		(L_216)->SetAt(static_cast<il2cpp_array_size_t>(L_217), (uint8_t)0);
		goto IL_0194;
	}

IL_034f:
	{
		int32_t L_218 = V_2;
		int32_t L_219 = L_218;
		V_2 = ((int32_t)il2cpp_codegen_add(L_219, 1));
		V_3 = L_219;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_220 = ___1_src;
		int32_t L_221 = V_2;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_222;
		L_222 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_220, L_221, NULL);
		V_18 = ((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_222, ((int32_t)-1640531535)))>>((int32_t)19)));
		goto IL_0068;
	}

IL_036c:
	{
		int32_t L_223 = V_5;
		int32_t L_224 = V_3;
		V_25 = ((int32_t)il2cpp_codegen_subtract(L_223, L_224));
		int32_t L_225 = V_7;
		int32_t L_226 = V_25;
		int32_t L_227 = V_25;
		int32_t L_228 = V_8;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_225, L_226)), 1)), ((int32_t)(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_subtract(L_227, ((int32_t)15))), ((int32_t)255)))/((int32_t)255)))))) <= ((int32_t)L_228)))
		{
			goto IL_0391;
		}
	}
	{
		return 0;
	}

IL_0391:
	{
		int32_t L_229 = V_25;
		if ((((int32_t)L_229) < ((int32_t)((int32_t)15))))
		{
			goto IL_03dd;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_230 = ___2_dst;
		int32_t L_231 = V_7;
		int32_t L_232 = L_231;
		V_7 = ((int32_t)il2cpp_codegen_add(L_232, 1));
		NullCheck(L_230);
		(L_230)->SetAt(static_cast<il2cpp_array_size_t>(L_232), (uint8_t)((int32_t)240));
		int32_t L_233 = V_25;
		V_25 = ((int32_t)il2cpp_codegen_subtract(L_233, ((int32_t)15)));
		goto IL_03c6;
	}

IL_03ae:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_234 = ___2_dst;
		int32_t L_235 = V_7;
		int32_t L_236 = L_235;
		V_7 = ((int32_t)il2cpp_codegen_add(L_236, 1));
		NullCheck(L_234);
		(L_234)->SetAt(static_cast<il2cpp_array_size_t>(L_236), (uint8_t)((int32_t)255));
		int32_t L_237 = V_25;
		V_25 = ((int32_t)il2cpp_codegen_subtract(L_237, ((int32_t)255)));
	}

IL_03c6:
	{
		int32_t L_238 = V_25;
		if ((((int32_t)L_238) > ((int32_t)((int32_t)254))))
		{
			goto IL_03ae;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_239 = ___2_dst;
		int32_t L_240 = V_7;
		int32_t L_241 = L_240;
		V_7 = ((int32_t)il2cpp_codegen_add(L_241, 1));
		int32_t L_242 = V_25;
		NullCheck(L_239);
		(L_239)->SetAt(static_cast<il2cpp_array_size_t>(L_241), (uint8_t)((int32_t)(uint8_t)L_242));
		goto IL_03eb;
	}

IL_03dd:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_243 = ___2_dst;
		int32_t L_244 = V_7;
		int32_t L_245 = L_244;
		V_7 = ((int32_t)il2cpp_codegen_add(L_245, 1));
		int32_t L_246 = V_25;
		NullCheck(L_243);
		(L_243)->SetAt(static_cast<il2cpp_array_size_t>(L_245), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_246<<4))));
	}

IL_03eb:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_247 = ___1_src;
		int32_t L_248 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_249 = ___2_dst;
		int32_t L_250 = V_7;
		int32_t L_251 = V_5;
		int32_t L_252 = V_3;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D(L_247, L_248, L_249, L_250, ((int32_t)il2cpp_codegen_subtract(L_251, L_252)), NULL);
		int32_t L_253 = V_7;
		int32_t L_254 = V_5;
		int32_t L_255 = V_3;
		V_7 = ((int32_t)il2cpp_codegen_add(L_253, ((int32_t)il2cpp_codegen_subtract(L_254, L_255))));
		int32_t L_256 = V_7;
		int32_t L_257 = ___4_dst_0;
		return ((int32_t)il2cpp_codegen_subtract(L_256, L_257));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_uncompress_safe64_mF952DEBD155A8549AAAD0A8D265F7799C70E6B14 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_dst, int32_t ___2_src_0, int32_t ___3_dst_0, int32_t ___4_dst_len, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_0 = NULL;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	uint32_t V_11 = 0;
	int32_t V_12 = 0;
	int32_t V_13 = 0;
	int32_t V_14 = 0;
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_0 = ((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DECODER_TABLE_32;
		V_0 = L_0;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_1 = ((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DECODER_TABLE_64;
		V_1 = L_1;
		int32_t L_2 = ___2_src_0;
		V_3 = L_2;
		int32_t L_3 = ___3_dst_0;
		V_5 = L_3;
		int32_t L_4 = V_5;
		int32_t L_5 = ___4_dst_len;
		V_6 = ((int32_t)il2cpp_codegen_add(L_4, L_5));
		int32_t L_6 = V_6;
		V_8 = ((int32_t)il2cpp_codegen_subtract(L_6, 5));
		int32_t L_7 = V_6;
		V_9 = ((int32_t)il2cpp_codegen_subtract(L_7, 8));
		int32_t L_8 = V_6;
		V_10 = ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_subtract(L_8, 8)), 4));
	}

IL_002c:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_9 = ___0_src;
		int32_t L_10 = V_3;
		int32_t L_11 = L_10;
		V_3 = ((int32_t)il2cpp_codegen_add(L_11, 1));
		NullCheck(L_9);
		int32_t L_12 = L_11;
		uint8_t L_13 = (L_9)->GetAt(static_cast<il2cpp_array_size_t>(L_12));
		V_11 = L_13;
		uint32_t L_14 = V_11;
		int32_t L_15 = ((int32_t)(uint8_t)((int32_t)((uint32_t)L_14>>4)));
		V_12 = L_15;
		if ((!(((uint32_t)L_15) == ((uint32_t)((int32_t)15)))))
		{
			goto IL_0065;
		}
	}
	{
		goto IL_004d;
	}

IL_0043:
	{
		int32_t L_16 = V_12;
		V_12 = ((int32_t)il2cpp_codegen_add(L_16, ((int32_t)255)));
	}

IL_004d:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = ___0_src;
		int32_t L_18 = V_3;
		int32_t L_19 = L_18;
		V_3 = ((int32_t)il2cpp_codegen_add(L_19, 1));
		NullCheck(L_17);
		int32_t L_20 = L_19;
		uint8_t L_21 = (L_17)->GetAt(static_cast<il2cpp_array_size_t>(L_20));
		uint8_t L_22 = L_21;
		V_13 = L_22;
		if ((((int32_t)L_22) == ((int32_t)((int32_t)255))))
		{
			goto IL_0043;
		}
	}
	{
		int32_t L_23 = V_12;
		int32_t L_24 = V_13;
		V_12 = ((int32_t)il2cpp_codegen_add(L_23, L_24));
	}

IL_0065:
	{
		int32_t L_25 = V_5;
		int32_t L_26 = V_12;
		V_7 = ((int32_t)il2cpp_codegen_add(L_25, L_26));
		int32_t L_27 = V_7;
		int32_t L_28 = V_9;
		if ((((int32_t)L_27) <= ((int32_t)L_28)))
		{
			goto IL_0091;
		}
	}
	{
		int32_t L_29 = V_7;
		int32_t L_30 = V_6;
		if ((!(((uint32_t)L_29) == ((uint32_t)L_30))))
		{
			goto IL_0200;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_31 = ___0_src;
		int32_t L_32 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_33 = ___1_dst;
		int32_t L_34 = V_5;
		int32_t L_35 = V_12;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D(L_31, L_32, L_33, L_34, L_35, NULL);
		int32_t L_36 = V_3;
		int32_t L_37 = V_12;
		V_3 = ((int32_t)il2cpp_codegen_add(L_36, L_37));
		goto IL_01fc;
	}

IL_0091:
	{
		int32_t L_38 = V_5;
		int32_t L_39 = V_7;
		if ((((int32_t)L_38) >= ((int32_t)L_39)))
		{
			goto IL_00ae;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_40 = ___0_src;
		int32_t L_41 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_42 = ___1_dst;
		int32_t L_43 = V_5;
		int32_t L_44 = V_7;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_45;
		L_45 = LZ4Codec_WildCopy_mE6E7FF3DC7D46D37614FDE84DDDEA5D03B0B5F94(L_40, L_41, L_42, L_43, L_44, NULL);
		V_2 = L_45;
		int32_t L_46 = V_3;
		int32_t L_47 = V_2;
		V_3 = ((int32_t)il2cpp_codegen_add(L_46, L_47));
		int32_t L_48 = V_5;
		int32_t L_49 = V_2;
		V_5 = ((int32_t)il2cpp_codegen_add(L_48, L_49));
	}

IL_00ae:
	{
		int32_t L_50 = V_3;
		int32_t L_51 = V_5;
		int32_t L_52 = V_7;
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_50, ((int32_t)il2cpp_codegen_subtract(L_51, L_52))));
		int32_t L_53 = V_7;
		V_5 = L_53;
		int32_t L_54 = V_7;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_55 = ___0_src;
		int32_t L_56 = V_3;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint16_t L_57;
		L_57 = LZ4Codec_Peek2_mE549DAC6B7C81F35C5B34C25AD3A6EDA5F44C008(L_55, L_56, NULL);
		V_4 = ((int32_t)il2cpp_codegen_subtract(L_54, (int32_t)L_57));
		int32_t L_58 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_58, 2));
		int32_t L_59 = V_4;
		int32_t L_60 = ___3_dst_0;
		if ((((int32_t)L_59) < ((int32_t)L_60)))
		{
			goto IL_0200;
		}
	}
	{
		uint32_t L_61 = V_11;
		int32_t L_62 = ((int32_t)(uint8_t)((int32_t)((int32_t)L_61&((int32_t)15))));
		V_12 = L_62;
		if ((!(((uint32_t)L_62) == ((uint32_t)((int32_t)15)))))
		{
			goto IL_0105;
		}
	}
	{
		goto IL_00ef;
	}

IL_00e1:
	{
		int32_t L_63 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_63, 1));
		int32_t L_64 = V_12;
		V_12 = ((int32_t)il2cpp_codegen_add(L_64, ((int32_t)255)));
	}

IL_00ef:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_65 = ___0_src;
		int32_t L_66 = V_3;
		NullCheck(L_65);
		int32_t L_67 = L_66;
		uint8_t L_68 = (L_65)->GetAt(static_cast<il2cpp_array_size_t>(L_67));
		if ((((int32_t)L_68) == ((int32_t)((int32_t)255))))
		{
			goto IL_00e1;
		}
	}
	{
		int32_t L_69 = V_12;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_70 = ___0_src;
		int32_t L_71 = V_3;
		int32_t L_72 = L_71;
		V_3 = ((int32_t)il2cpp_codegen_add(L_72, 1));
		NullCheck(L_70);
		int32_t L_73 = L_72;
		uint8_t L_74 = (L_70)->GetAt(static_cast<il2cpp_array_size_t>(L_73));
		V_12 = ((int32_t)il2cpp_codegen_add(L_69, (int32_t)L_74));
	}

IL_0105:
	{
		int32_t L_75 = V_5;
		int32_t L_76 = V_4;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract(L_75, L_76))) >= ((int32_t)8)))
		{
			goto IL_0173;
		}
	}
	{
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_77 = V_1;
		int32_t L_78 = V_5;
		int32_t L_79 = V_4;
		NullCheck(L_77);
		int32_t L_80 = ((int32_t)il2cpp_codegen_subtract(L_78, L_79));
		int32_t L_81 = (L_77)->GetAt(static_cast<il2cpp_array_size_t>(L_80));
		V_14 = L_81;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_82 = ___1_dst;
		int32_t L_83 = V_5;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_84 = ___1_dst;
		int32_t L_85 = V_4;
		NullCheck(L_84);
		int32_t L_86 = L_85;
		uint8_t L_87 = (L_84)->GetAt(static_cast<il2cpp_array_size_t>(L_86));
		NullCheck(L_82);
		(L_82)->SetAt(static_cast<il2cpp_array_size_t>(L_83), (uint8_t)L_87);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_88 = ___1_dst;
		int32_t L_89 = V_5;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_90 = ___1_dst;
		int32_t L_91 = V_4;
		NullCheck(L_90);
		int32_t L_92 = ((int32_t)il2cpp_codegen_add(L_91, 1));
		uint8_t L_93 = (L_90)->GetAt(static_cast<il2cpp_array_size_t>(L_92));
		NullCheck(L_88);
		(L_88)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_89, 1))), (uint8_t)L_93);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_94 = ___1_dst;
		int32_t L_95 = V_5;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_96 = ___1_dst;
		int32_t L_97 = V_4;
		NullCheck(L_96);
		int32_t L_98 = ((int32_t)il2cpp_codegen_add(L_97, 2));
		uint8_t L_99 = (L_96)->GetAt(static_cast<il2cpp_array_size_t>(L_98));
		NullCheck(L_94);
		(L_94)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_95, 2))), (uint8_t)L_99);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_100 = ___1_dst;
		int32_t L_101 = V_5;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_102 = ___1_dst;
		int32_t L_103 = V_4;
		NullCheck(L_102);
		int32_t L_104 = ((int32_t)il2cpp_codegen_add(L_103, 3));
		uint8_t L_105 = (L_102)->GetAt(static_cast<il2cpp_array_size_t>(L_104));
		NullCheck(L_100);
		(L_100)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_101, 3))), (uint8_t)L_105);
		int32_t L_106 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_106, 4));
		int32_t L_107 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add(L_107, 4));
		int32_t L_108 = V_4;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_109 = V_0;
		int32_t L_110 = V_5;
		int32_t L_111 = V_4;
		NullCheck(L_109);
		int32_t L_112 = ((int32_t)il2cpp_codegen_subtract(L_110, L_111));
		int32_t L_113 = (L_109)->GetAt(static_cast<il2cpp_array_size_t>(L_112));
		V_4 = ((int32_t)il2cpp_codegen_subtract(L_108, L_113));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_114 = ___1_dst;
		int32_t L_115 = V_4;
		int32_t L_116 = V_5;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_Copy4_m184A9377DC0EC985A8AF55E386A3F04D2F8C3F5F(L_114, L_115, L_116, NULL);
		int32_t L_117 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_117, 4));
		int32_t L_118 = V_4;
		int32_t L_119 = V_14;
		V_4 = ((int32_t)il2cpp_codegen_subtract(L_118, L_119));
		goto IL_0189;
	}

IL_0173:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_120 = ___1_dst;
		int32_t L_121 = V_4;
		int32_t L_122 = V_5;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_Copy8_m55B8E8EE46B0571AC2D3710470CE639F02F6EC3D(L_120, L_121, L_122, NULL);
		int32_t L_123 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_123, 8));
		int32_t L_124 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add(L_124, 8));
	}

IL_0189:
	{
		int32_t L_125 = V_5;
		int32_t L_126 = V_12;
		V_7 = ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_125, L_126)), 4));
		int32_t L_127 = V_7;
		int32_t L_128 = V_10;
		if ((((int32_t)L_127) <= ((int32_t)L_128)))
		{
			goto IL_01e0;
		}
	}
	{
		int32_t L_129 = V_7;
		int32_t L_130 = V_8;
		if ((((int32_t)L_129) > ((int32_t)L_130)))
		{
			goto IL_0200;
		}
	}
	{
		int32_t L_131 = V_5;
		int32_t L_132 = V_9;
		if ((((int32_t)L_131) >= ((int32_t)L_132)))
		{
			goto IL_01d1;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_133 = ___1_dst;
		int32_t L_134 = V_4;
		int32_t L_135 = V_5;
		int32_t L_136 = V_9;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_137;
		L_137 = LZ4Codec_SecureCopy_mD8B329836718DBDA10089588161AC3F72D9C88A4(L_133, L_134, L_135, L_136, NULL);
		V_2 = L_137;
		int32_t L_138 = V_4;
		int32_t L_139 = V_2;
		V_4 = ((int32_t)il2cpp_codegen_add(L_138, L_139));
		int32_t L_140 = V_5;
		int32_t L_141 = V_2;
		V_5 = ((int32_t)il2cpp_codegen_add(L_140, L_141));
		goto IL_01d1;
	}

IL_01bf:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_142 = ___1_dst;
		int32_t L_143 = V_5;
		int32_t L_144 = L_143;
		V_5 = ((int32_t)il2cpp_codegen_add(L_144, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_145 = ___1_dst;
		int32_t L_146 = V_4;
		int32_t L_147 = L_146;
		V_4 = ((int32_t)il2cpp_codegen_add(L_147, 1));
		NullCheck(L_145);
		int32_t L_148 = L_147;
		uint8_t L_149 = (L_145)->GetAt(static_cast<il2cpp_array_size_t>(L_148));
		NullCheck(L_142);
		(L_142)->SetAt(static_cast<il2cpp_array_size_t>(L_144), (uint8_t)L_149);
	}

IL_01d1:
	{
		int32_t L_150 = V_5;
		int32_t L_151 = V_7;
		if ((((int32_t)L_150) < ((int32_t)L_151)))
		{
			goto IL_01bf;
		}
	}
	{
		int32_t L_152 = V_7;
		V_5 = L_152;
		goto IL_002c;
	}

IL_01e0:
	{
		int32_t L_153 = V_5;
		int32_t L_154 = V_7;
		if ((((int32_t)L_153) >= ((int32_t)L_154)))
		{
			goto IL_01f3;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_155 = ___1_dst;
		int32_t L_156 = V_4;
		int32_t L_157 = V_5;
		int32_t L_158 = V_7;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_159;
		L_159 = LZ4Codec_SecureCopy_mD8B329836718DBDA10089588161AC3F72D9C88A4(L_155, L_156, L_157, L_158, NULL);
	}

IL_01f3:
	{
		int32_t L_160 = V_7;
		V_5 = L_160;
		goto IL_002c;
	}

IL_01fc:
	{
		int32_t L_161 = V_3;
		int32_t L_162 = ___2_src_0;
		return ((int32_t)il2cpp_codegen_subtract(L_161, L_162));
	}

IL_0200:
	{
		int32_t L_163 = V_3;
		int32_t L_164 = ___2_src_0;
		return ((-((int32_t)il2cpp_codegen_subtract(L_163, L_164))));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_uncompress_unknownOutputSize_safe64_mA60DF40EE0906DD2443C4E2018117F515A3BCD25 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_src, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___1_dst, int32_t ___2_src_0, int32_t ___3_dst_0, int32_t ___4_src_len, int32_t ___5_dst_maxlen, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_0 = NULL;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	int32_t V_13 = 0;
	int32_t V_14 = 0;
	uint8_t V_15 = 0x0;
	int32_t V_16 = 0;
	int32_t V_17 = 0;
	int32_t V_18 = 0;
	int32_t V_19 = 0;
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_0 = ((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DECODER_TABLE_32;
		V_0 = L_0;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_1 = ((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DECODER_TABLE_64;
		V_1 = L_1;
		int32_t L_2 = ___2_src_0;
		V_3 = L_2;
		int32_t L_3 = V_3;
		int32_t L_4 = ___4_src_len;
		V_4 = ((int32_t)il2cpp_codegen_add(L_3, L_4));
		int32_t L_5 = ___3_dst_0;
		V_6 = L_5;
		int32_t L_6 = V_6;
		int32_t L_7 = ___5_dst_maxlen;
		V_7 = ((int32_t)il2cpp_codegen_add(L_6, L_7));
		int32_t L_8 = V_4;
		V_9 = ((int32_t)il2cpp_codegen_subtract(L_8, 8));
		int32_t L_9 = V_4;
		V_10 = ((int32_t)il2cpp_codegen_subtract(L_9, 6));
		int32_t L_10 = V_7;
		V_11 = ((int32_t)il2cpp_codegen_subtract(L_10, 8));
		int32_t L_11 = V_7;
		V_12 = ((int32_t)il2cpp_codegen_subtract(L_11, ((int32_t)12)));
		int32_t L_12 = V_7;
		V_13 = ((int32_t)il2cpp_codegen_subtract(L_12, 5));
		int32_t L_13 = V_7;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_13, ((int32_t)12)));
		int32_t L_14 = V_3;
		int32_t L_15 = V_4;
		if ((((int32_t)L_14) == ((int32_t)L_15)))
		{
			goto IL_0230;
		}
	}

IL_004c:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = ___0_src;
		int32_t L_17 = V_3;
		int32_t L_18 = L_17;
		V_3 = ((int32_t)il2cpp_codegen_add(L_18, 1));
		NullCheck(L_16);
		int32_t L_19 = L_18;
		uint8_t L_20 = (L_16)->GetAt(static_cast<il2cpp_array_size_t>(L_19));
		V_15 = L_20;
		uint8_t L_21 = V_15;
		int32_t L_22 = ((int32_t)((int32_t)L_21>>4));
		V_16 = L_22;
		if ((!(((uint32_t)L_22) == ((uint32_t)((int32_t)15)))))
		{
			goto IL_0086;
		}
	}
	{
		V_17 = ((int32_t)255);
		goto IL_0078;
	}

IL_0069:
	{
		int32_t L_23 = V_16;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = ___0_src;
		int32_t L_25 = V_3;
		int32_t L_26 = L_25;
		V_3 = ((int32_t)il2cpp_codegen_add(L_26, 1));
		NullCheck(L_24);
		int32_t L_27 = L_26;
		uint8_t L_28 = (L_24)->GetAt(static_cast<il2cpp_array_size_t>(L_27));
		uint8_t L_29 = L_28;
		V_17 = L_29;
		V_16 = ((int32_t)il2cpp_codegen_add(L_23, (int32_t)L_29));
	}

IL_0078:
	{
		int32_t L_30 = V_3;
		int32_t L_31 = V_4;
		if ((((int32_t)L_30) >= ((int32_t)L_31)))
		{
			goto IL_0086;
		}
	}
	{
		int32_t L_32 = V_17;
		if ((((int32_t)L_32) == ((int32_t)((int32_t)255))))
		{
			goto IL_0069;
		}
	}

IL_0086:
	{
		int32_t L_33 = V_6;
		int32_t L_34 = V_16;
		V_8 = ((int32_t)il2cpp_codegen_add(L_33, L_34));
		int32_t L_35 = V_8;
		int32_t L_36 = V_14;
		if ((((int32_t)L_35) > ((int32_t)L_36)))
		{
			goto IL_009b;
		}
	}
	{
		int32_t L_37 = V_3;
		int32_t L_38 = V_16;
		int32_t L_39 = V_9;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_37, L_38))) <= ((int32_t)L_39)))
		{
			goto IL_00c7;
		}
	}

IL_009b:
	{
		int32_t L_40 = V_8;
		int32_t L_41 = V_7;
		if ((((int32_t)L_40) > ((int32_t)L_41)))
		{
			goto IL_0230;
		}
	}
	{
		int32_t L_42 = V_3;
		int32_t L_43 = V_16;
		int32_t L_44 = V_4;
		if ((!(((uint32_t)((int32_t)il2cpp_codegen_add(L_42, L_43))) == ((uint32_t)L_44))))
		{
			goto IL_0230;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_45 = ___0_src;
		int32_t L_46 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_47 = ___1_dst;
		int32_t L_48 = V_6;
		int32_t L_49 = V_16;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D(L_45, L_46, L_47, L_48, L_49, NULL);
		int32_t L_50 = V_6;
		int32_t L_51 = V_16;
		V_6 = ((int32_t)il2cpp_codegen_add(L_50, L_51));
		goto IL_022b;
	}

IL_00c7:
	{
		int32_t L_52 = V_6;
		int32_t L_53 = V_8;
		if ((((int32_t)L_52) >= ((int32_t)L_53)))
		{
			goto IL_00e4;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_54 = ___0_src;
		int32_t L_55 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_56 = ___1_dst;
		int32_t L_57 = V_6;
		int32_t L_58 = V_8;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_59;
		L_59 = LZ4Codec_WildCopy_mE6E7FF3DC7D46D37614FDE84DDDEA5D03B0B5F94(L_54, L_55, L_56, L_57, L_58, NULL);
		V_2 = L_59;
		int32_t L_60 = V_3;
		int32_t L_61 = V_2;
		V_3 = ((int32_t)il2cpp_codegen_add(L_60, L_61));
		int32_t L_62 = V_6;
		int32_t L_63 = V_2;
		V_6 = ((int32_t)il2cpp_codegen_add(L_62, L_63));
	}

IL_00e4:
	{
		int32_t L_64 = V_3;
		int32_t L_65 = V_6;
		int32_t L_66 = V_8;
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_64, ((int32_t)il2cpp_codegen_subtract(L_65, L_66))));
		int32_t L_67 = V_8;
		V_6 = L_67;
		int32_t L_68 = V_8;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_69 = ___0_src;
		int32_t L_70 = V_3;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint16_t L_71;
		L_71 = LZ4Codec_Peek2_mE549DAC6B7C81F35C5B34C25AD3A6EDA5F44C008(L_69, L_70, NULL);
		V_5 = ((int32_t)il2cpp_codegen_subtract(L_68, (int32_t)L_71));
		int32_t L_72 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_72, 2));
		int32_t L_73 = V_5;
		int32_t L_74 = ___3_dst_0;
		if ((((int32_t)L_73) < ((int32_t)L_74)))
		{
			goto IL_0230;
		}
	}
	{
		uint8_t L_75 = V_15;
		int32_t L_76 = ((int32_t)((int32_t)L_75&((int32_t)15)));
		V_16 = L_76;
		if ((!(((uint32_t)L_76) == ((uint32_t)((int32_t)15)))))
		{
			goto IL_0134;
		}
	}
	{
		goto IL_012f;
	}

IL_0116:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_77 = ___0_src;
		int32_t L_78 = V_3;
		int32_t L_79 = L_78;
		V_3 = ((int32_t)il2cpp_codegen_add(L_79, 1));
		NullCheck(L_77);
		int32_t L_80 = L_79;
		uint8_t L_81 = (L_77)->GetAt(static_cast<il2cpp_array_size_t>(L_80));
		V_18 = L_81;
		int32_t L_82 = V_16;
		int32_t L_83 = V_18;
		V_16 = ((int32_t)il2cpp_codegen_add(L_82, L_83));
		int32_t L_84 = V_18;
		if ((!(((uint32_t)L_84) == ((uint32_t)((int32_t)255)))))
		{
			goto IL_0134;
		}
	}

IL_012f:
	{
		int32_t L_85 = V_3;
		int32_t L_86 = V_10;
		if ((((int32_t)L_85) < ((int32_t)L_86)))
		{
			goto IL_0116;
		}
	}

IL_0134:
	{
		int32_t L_87 = V_6;
		int32_t L_88 = V_5;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract(L_87, L_88))) >= ((int32_t)8)))
		{
			goto IL_01a2;
		}
	}
	{
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_89 = V_1;
		int32_t L_90 = V_6;
		int32_t L_91 = V_5;
		NullCheck(L_89);
		int32_t L_92 = ((int32_t)il2cpp_codegen_subtract(L_90, L_91));
		int32_t L_93 = (L_89)->GetAt(static_cast<il2cpp_array_size_t>(L_92));
		V_19 = L_93;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_94 = ___1_dst;
		int32_t L_95 = V_6;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_96 = ___1_dst;
		int32_t L_97 = V_5;
		NullCheck(L_96);
		int32_t L_98 = L_97;
		uint8_t L_99 = (L_96)->GetAt(static_cast<il2cpp_array_size_t>(L_98));
		NullCheck(L_94);
		(L_94)->SetAt(static_cast<il2cpp_array_size_t>(L_95), (uint8_t)L_99);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_100 = ___1_dst;
		int32_t L_101 = V_6;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_102 = ___1_dst;
		int32_t L_103 = V_5;
		NullCheck(L_102);
		int32_t L_104 = ((int32_t)il2cpp_codegen_add(L_103, 1));
		uint8_t L_105 = (L_102)->GetAt(static_cast<il2cpp_array_size_t>(L_104));
		NullCheck(L_100);
		(L_100)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_101, 1))), (uint8_t)L_105);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_106 = ___1_dst;
		int32_t L_107 = V_6;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_108 = ___1_dst;
		int32_t L_109 = V_5;
		NullCheck(L_108);
		int32_t L_110 = ((int32_t)il2cpp_codegen_add(L_109, 2));
		uint8_t L_111 = (L_108)->GetAt(static_cast<il2cpp_array_size_t>(L_110));
		NullCheck(L_106);
		(L_106)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_107, 2))), (uint8_t)L_111);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_112 = ___1_dst;
		int32_t L_113 = V_6;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_114 = ___1_dst;
		int32_t L_115 = V_5;
		NullCheck(L_114);
		int32_t L_116 = ((int32_t)il2cpp_codegen_add(L_115, 3));
		uint8_t L_117 = (L_114)->GetAt(static_cast<il2cpp_array_size_t>(L_116));
		NullCheck(L_112);
		(L_112)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_113, 3))), (uint8_t)L_117);
		int32_t L_118 = V_6;
		V_6 = ((int32_t)il2cpp_codegen_add(L_118, 4));
		int32_t L_119 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_119, 4));
		int32_t L_120 = V_5;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_121 = V_0;
		int32_t L_122 = V_6;
		int32_t L_123 = V_5;
		NullCheck(L_121);
		int32_t L_124 = ((int32_t)il2cpp_codegen_subtract(L_122, L_123));
		int32_t L_125 = (L_121)->GetAt(static_cast<il2cpp_array_size_t>(L_124));
		V_5 = ((int32_t)il2cpp_codegen_subtract(L_120, L_125));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_126 = ___1_dst;
		int32_t L_127 = V_5;
		int32_t L_128 = V_6;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_Copy4_m184A9377DC0EC985A8AF55E386A3F04D2F8C3F5F(L_126, L_127, L_128, NULL);
		int32_t L_129 = V_6;
		V_6 = ((int32_t)il2cpp_codegen_add(L_129, 4));
		int32_t L_130 = V_5;
		int32_t L_131 = V_19;
		V_5 = ((int32_t)il2cpp_codegen_subtract(L_130, L_131));
		goto IL_01b8;
	}

IL_01a2:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_132 = ___1_dst;
		int32_t L_133 = V_5;
		int32_t L_134 = V_6;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_Copy8_m55B8E8EE46B0571AC2D3710470CE639F02F6EC3D(L_132, L_133, L_134, NULL);
		int32_t L_135 = V_6;
		V_6 = ((int32_t)il2cpp_codegen_add(L_135, 8));
		int32_t L_136 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_136, 8));
	}

IL_01b8:
	{
		int32_t L_137 = V_6;
		int32_t L_138 = V_16;
		V_8 = ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_137, L_138)), 4));
		int32_t L_139 = V_8;
		int32_t L_140 = V_12;
		if ((((int32_t)L_139) <= ((int32_t)L_140)))
		{
			goto IL_020f;
		}
	}
	{
		int32_t L_141 = V_8;
		int32_t L_142 = V_13;
		if ((((int32_t)L_141) > ((int32_t)L_142)))
		{
			goto IL_0230;
		}
	}
	{
		int32_t L_143 = V_6;
		int32_t L_144 = V_11;
		if ((((int32_t)L_143) >= ((int32_t)L_144)))
		{
			goto IL_0200;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_145 = ___1_dst;
		int32_t L_146 = V_5;
		int32_t L_147 = V_6;
		int32_t L_148 = V_11;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_149;
		L_149 = LZ4Codec_SecureCopy_mD8B329836718DBDA10089588161AC3F72D9C88A4(L_145, L_146, L_147, L_148, NULL);
		V_2 = L_149;
		int32_t L_150 = V_5;
		int32_t L_151 = V_2;
		V_5 = ((int32_t)il2cpp_codegen_add(L_150, L_151));
		int32_t L_152 = V_6;
		int32_t L_153 = V_2;
		V_6 = ((int32_t)il2cpp_codegen_add(L_152, L_153));
		goto IL_0200;
	}

IL_01ee:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_154 = ___1_dst;
		int32_t L_155 = V_6;
		int32_t L_156 = L_155;
		V_6 = ((int32_t)il2cpp_codegen_add(L_156, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_157 = ___1_dst;
		int32_t L_158 = V_5;
		int32_t L_159 = L_158;
		V_5 = ((int32_t)il2cpp_codegen_add(L_159, 1));
		NullCheck(L_157);
		int32_t L_160 = L_159;
		uint8_t L_161 = (L_157)->GetAt(static_cast<il2cpp_array_size_t>(L_160));
		NullCheck(L_154);
		(L_154)->SetAt(static_cast<il2cpp_array_size_t>(L_156), (uint8_t)L_161);
	}

IL_0200:
	{
		int32_t L_162 = V_6;
		int32_t L_163 = V_8;
		if ((((int32_t)L_162) < ((int32_t)L_163)))
		{
			goto IL_01ee;
		}
	}
	{
		int32_t L_164 = V_8;
		V_6 = L_164;
		goto IL_004c;
	}

IL_020f:
	{
		int32_t L_165 = V_6;
		int32_t L_166 = V_8;
		if ((((int32_t)L_165) >= ((int32_t)L_166)))
		{
			goto IL_0222;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_167 = ___1_dst;
		int32_t L_168 = V_5;
		int32_t L_169 = V_6;
		int32_t L_170 = V_8;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_171;
		L_171 = LZ4Codec_SecureCopy_mD8B329836718DBDA10089588161AC3F72D9C88A4(L_167, L_168, L_169, L_170, NULL);
	}

IL_0222:
	{
		int32_t L_172 = V_8;
		V_6 = L_172;
		goto IL_004c;
	}

IL_022b:
	{
		int32_t L_173 = V_6;
		int32_t L_174 = ___3_dst_0;
		return ((int32_t)il2cpp_codegen_subtract(L_173, L_174));
	}

IL_0230:
	{
		int32_t L_175 = V_3;
		int32_t L_176 = ___2_src_0;
		return ((-((int32_t)il2cpp_codegen_subtract(L_175, L_176))));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_LZ4HC_Insert_64_m88809B5C1FB9ADDCF2E7FAA7BA30A729D907F415 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_src_p, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* V_0 = NULL;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_1 = NULL;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_0 = ___0_ctx;
		NullCheck(L_0);
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_1 = L_0->___chainTable;
		V_0 = L_1;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_2 = ___0_ctx;
		NullCheck(L_2);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_3 = L_2->___hashTable;
		V_1 = L_3;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_4 = ___0_ctx;
		NullCheck(L_4);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = L_4->___src;
		V_2 = L_5;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_6 = ___0_ctx;
		NullCheck(L_6);
		int32_t L_7 = L_6->___src_base;
		V_3 = L_7;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_8 = ___0_ctx;
		NullCheck(L_8);
		int32_t L_9 = L_8->___nextToUpdate;
		V_4 = L_9;
		goto IL_0080;
	}

IL_0026:
	{
		int32_t L_10 = V_4;
		V_5 = L_10;
		int32_t L_11 = V_5;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_12 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_13 = V_2;
		int32_t L_14 = V_5;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_15;
		L_15 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_13, L_14, NULL);
		NullCheck(L_12);
		uintptr_t L_16 = ((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_15, ((int32_t)-1640531535)))>>((int32_t)17))));
		int32_t L_17 = (L_12)->GetAt(static_cast<il2cpp_array_size_t>(L_16));
		int32_t L_18 = V_3;
		V_6 = ((int32_t)il2cpp_codegen_subtract(L_11, ((int32_t)il2cpp_codegen_add(L_17, L_18))));
		int32_t L_19 = V_6;
		if ((((int32_t)L_19) <= ((int32_t)((int32_t)65535))))
		{
			goto IL_0055;
		}
	}
	{
		V_6 = ((int32_t)65535);
	}

IL_0055:
	{
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_20 = V_0;
		int32_t L_21 = V_5;
		int32_t L_22 = V_6;
		NullCheck(L_20);
		(L_20)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)(L_21&((int32_t)65535)))), (uint16_t)((int32_t)(uint16_t)L_22));
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_23 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = V_2;
		int32_t L_25 = V_5;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_26;
		L_26 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_24, L_25, NULL);
		int32_t L_27 = V_5;
		int32_t L_28 = V_3;
		NullCheck(L_23);
		(L_23)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_26, ((int32_t)-1640531535)))>>((int32_t)17))))), (int32_t)((int32_t)il2cpp_codegen_subtract(L_27, L_28)));
		int32_t L_29 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_add(L_29, 1));
	}

IL_0080:
	{
		int32_t L_30 = V_4;
		int32_t L_31 = ___1_src_p;
		if ((((int32_t)L_30) < ((int32_t)L_31)))
		{
			goto IL_0026;
		}
	}
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_32 = ___0_ctx;
		int32_t L_33 = V_4;
		NullCheck(L_32);
		L_32->___nextToUpdate = L_33;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4HC_CommonLength_64_mAE63F3344241A76E2830869103C2C44987101F3B (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_p1, int32_t ___2_p2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_LZ4HC_CommonLength_64_mAE63F3344241A76E2830869103C2C44987101F3B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_0 = NULL;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int64_t V_4 = 0;
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_0 = ((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DEBRUIJN_TABLE_64;
		V_0 = L_0;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_1 = ___0_ctx;
		NullCheck(L_1);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = L_1->___src;
		V_1 = L_2;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_3 = ___0_ctx;
		NullCheck(L_3);
		int32_t L_4 = L_3->___src_LASTLITERALS;
		V_2 = L_4;
		int32_t L_5 = ___1_p1;
		V_3 = L_5;
		goto IL_0050;
	}

IL_0018:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = V_1;
		int32_t L_7 = ___2_p2;
		int32_t L_8 = V_3;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint64_t L_9;
		L_9 = LZ4Codec_Xor8_m4A7619EA57DCCFC5B2A17F222C94BE01C57E50BD(L_6, L_7, L_8, NULL);
		V_4 = L_9;
		int64_t L_10 = V_4;
		if ((!(((uint64_t)L_10) == ((uint64_t)((int64_t)0)))))
		{
			goto IL_0033;
		}
	}
	{
		int32_t L_11 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_11, 8));
		int32_t L_12 = ___2_p2;
		___2_p2 = ((int32_t)il2cpp_codegen_add(L_12, 8));
		goto IL_0050;
	}

IL_0033:
	{
		int32_t L_13 = V_3;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_14 = V_0;
		int64_t L_15 = V_4;
		int64_t L_16 = V_4;
		if ((uint64_t)(((int64_t)((uint64_t)((int64_t)il2cpp_codegen_multiply(((int64_t)(L_15&((-L_16)))), ((int64_t)151050438428048703LL)))>>((int32_t)58)))) > INTPTR_MAX) IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), LZ4Codec_LZ4HC_CommonLength_64_mAE63F3344241A76E2830869103C2C44987101F3B_RuntimeMethod_var);
		NullCheck(L_14);
		intptr_t L_17 = ((intptr_t)((int64_t)((uint64_t)((int64_t)il2cpp_codegen_multiply(((int64_t)(L_15&((-L_16)))), ((int64_t)151050438428048703LL)))>>((int32_t)58))));
		int32_t L_18 = (L_14)->GetAt(static_cast<il2cpp_array_size_t>(L_17));
		V_3 = ((int32_t)il2cpp_codegen_add(L_13, L_18));
		int32_t L_19 = V_3;
		int32_t L_20 = ___1_p1;
		return ((int32_t)il2cpp_codegen_subtract(L_19, L_20));
	}

IL_0050:
	{
		int32_t L_21 = V_3;
		int32_t L_22 = V_2;
		if ((((int32_t)L_21) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_22, 7)))))
		{
			goto IL_0018;
		}
	}
	{
		int32_t L_23 = V_3;
		int32_t L_24 = V_2;
		if ((((int32_t)L_23) >= ((int32_t)((int32_t)il2cpp_codegen_subtract(L_24, 3)))))
		{
			goto IL_006f;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_25 = V_1;
		int32_t L_26 = ___2_p2;
		int32_t L_27 = V_3;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_28;
		L_28 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_25, L_26, L_27, NULL);
		if (!L_28)
		{
			goto IL_006f;
		}
	}
	{
		int32_t L_29 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_29, 4));
		int32_t L_30 = ___2_p2;
		___2_p2 = ((int32_t)il2cpp_codegen_add(L_30, 4));
	}

IL_006f:
	{
		int32_t L_31 = V_3;
		int32_t L_32 = V_2;
		if ((((int32_t)L_31) >= ((int32_t)((int32_t)il2cpp_codegen_subtract(L_32, 1)))))
		{
			goto IL_0088;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_33 = V_1;
		int32_t L_34 = ___2_p2;
		int32_t L_35 = V_3;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_36;
		L_36 = LZ4Codec_Equal2_m05C0F8A90FA336B8EFA50F98F2485EAF9A00FEF6(L_33, L_34, L_35, NULL);
		if (!L_36)
		{
			goto IL_0088;
		}
	}
	{
		int32_t L_37 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_37, 2));
		int32_t L_38 = ___2_p2;
		___2_p2 = ((int32_t)il2cpp_codegen_add(L_38, 2));
	}

IL_0088:
	{
		int32_t L_39 = V_3;
		int32_t L_40 = V_2;
		if ((((int32_t)L_39) >= ((int32_t)L_40)))
		{
			goto IL_0098;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_41 = V_1;
		int32_t L_42 = ___2_p2;
		NullCheck(L_41);
		int32_t L_43 = L_42;
		uint8_t L_44 = (L_41)->GetAt(static_cast<il2cpp_array_size_t>(L_43));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_45 = V_1;
		int32_t L_46 = V_3;
		NullCheck(L_45);
		int32_t L_47 = L_46;
		uint8_t L_48 = (L_45)->GetAt(static_cast<il2cpp_array_size_t>(L_47));
		if ((!(((uint32_t)L_44) == ((uint32_t)L_48))))
		{
			goto IL_0098;
		}
	}
	{
		int32_t L_49 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_49, 1));
	}

IL_0098:
	{
		int32_t L_50 = V_3;
		int32_t L_51 = ___1_p1;
		return ((int32_t)il2cpp_codegen_subtract(L_50, L_51));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4HC_InsertAndFindBestMatch_64_mF27AC8EADD1C62F6D705D63F861A60C701A2CB9B (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_src_p, int32_t* ___2_matchpos, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* V_0 = NULL;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_1 = NULL;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	uint16_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_0 = ___0_ctx;
		NullCheck(L_0);
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_1 = L_0->___chainTable;
		V_0 = L_1;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_2 = ___0_ctx;
		NullCheck(L_2);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_3 = L_2->___hashTable;
		V_1 = L_3;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_4 = ___0_ctx;
		NullCheck(L_4);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = L_4->___src;
		V_2 = L_5;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_6 = ___0_ctx;
		NullCheck(L_6);
		int32_t L_7 = L_6->___src_base;
		V_3 = L_7;
		V_4 = ((int32_t)256);
		V_5 = 0;
		V_6 = 0;
		V_7 = (uint16_t)0;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_8 = ___0_ctx;
		int32_t L_9 = ___1_src_p;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_LZ4HC_Insert_64_m88809B5C1FB9ADDCF2E7FAA7BA30A729D907F415(L_8, L_9, NULL);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_10 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_11 = V_2;
		int32_t L_12 = ___1_src_p;
		uint32_t L_13;
		L_13 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_11, L_12, NULL);
		NullCheck(L_10);
		uintptr_t L_14 = ((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_13, ((int32_t)-1640531535)))>>((int32_t)17))));
		int32_t L_15 = (L_10)->GetAt(static_cast<il2cpp_array_size_t>(L_14));
		int32_t L_16 = V_3;
		V_8 = ((int32_t)il2cpp_codegen_add(L_15, L_16));
		int32_t L_17 = V_8;
		int32_t L_18 = ___1_src_p;
		if ((((int32_t)L_17) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_18, 4)))))
		{
			goto IL_00dd;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_19 = V_2;
		int32_t L_20 = V_8;
		int32_t L_21 = ___1_src_p;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_22;
		L_22 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_19, L_20, L_21, NULL);
		if (!L_22)
		{
			goto IL_007e;
		}
	}
	{
		int32_t L_23 = ___1_src_p;
		int32_t L_24 = V_8;
		V_7 = (uint16_t)((int32_t)(uint16_t)((int32_t)il2cpp_codegen_subtract(L_23, L_24)));
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_25 = ___0_ctx;
		int32_t L_26 = ___1_src_p;
		int32_t L_27 = V_8;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_28;
		L_28 = LZ4Codec_LZ4HC_CommonLength_64_mAE63F3344241A76E2830869103C2C44987101F3B(L_25, ((int32_t)il2cpp_codegen_add(L_26, 4)), ((int32_t)il2cpp_codegen_add(L_27, 4)), NULL);
		int32_t L_29 = ((int32_t)il2cpp_codegen_add(L_28, 4));
		V_6 = L_29;
		V_5 = L_29;
		int32_t* L_30 = ___2_matchpos;
		int32_t L_31 = V_8;
		*((int32_t*)L_30) = (int32_t)L_31;
	}

IL_007e:
	{
		int32_t L_32 = V_8;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_33 = V_0;
		int32_t L_34 = V_8;
		NullCheck(L_33);
		int32_t L_35 = ((int32_t)(L_34&((int32_t)65535)));
		uint16_t L_36 = (L_33)->GetAt(static_cast<il2cpp_array_size_t>(L_35));
		V_8 = ((int32_t)il2cpp_codegen_subtract(L_32, (int32_t)L_36));
		goto IL_00dd;
	}

IL_008f:
	{
		int32_t L_37 = V_4;
		V_4 = ((int32_t)il2cpp_codegen_subtract(L_37, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_38 = V_2;
		int32_t L_39 = V_8;
		int32_t L_40 = V_6;
		NullCheck(L_38);
		int32_t L_41 = ((int32_t)il2cpp_codegen_add(L_39, L_40));
		uint8_t L_42 = (L_38)->GetAt(static_cast<il2cpp_array_size_t>(L_41));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_43 = V_2;
		int32_t L_44 = ___1_src_p;
		int32_t L_45 = V_6;
		NullCheck(L_43);
		int32_t L_46 = ((int32_t)il2cpp_codegen_add(L_44, L_45));
		uint8_t L_47 = (L_43)->GetAt(static_cast<il2cpp_array_size_t>(L_46));
		if ((!(((uint32_t)L_42) == ((uint32_t)L_47))))
		{
			goto IL_00ce;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_48 = V_2;
		int32_t L_49 = V_8;
		int32_t L_50 = ___1_src_p;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_51;
		L_51 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_48, L_49, L_50, NULL);
		if (!L_51)
		{
			goto IL_00ce;
		}
	}
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_52 = ___0_ctx;
		int32_t L_53 = ___1_src_p;
		int32_t L_54 = V_8;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_55;
		L_55 = LZ4Codec_LZ4HC_CommonLength_64_mAE63F3344241A76E2830869103C2C44987101F3B(L_52, ((int32_t)il2cpp_codegen_add(L_53, 4)), ((int32_t)il2cpp_codegen_add(L_54, 4)), NULL);
		V_9 = ((int32_t)il2cpp_codegen_add(L_55, 4));
		int32_t L_56 = V_9;
		int32_t L_57 = V_6;
		if ((((int32_t)L_56) <= ((int32_t)L_57)))
		{
			goto IL_00ce;
		}
	}
	{
		int32_t L_58 = V_9;
		V_6 = L_58;
		int32_t* L_59 = ___2_matchpos;
		int32_t L_60 = V_8;
		*((int32_t*)L_59) = (int32_t)L_60;
	}

IL_00ce:
	{
		int32_t L_61 = V_8;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_62 = V_0;
		int32_t L_63 = V_8;
		NullCheck(L_62);
		int32_t L_64 = ((int32_t)(L_63&((int32_t)65535)));
		uint16_t L_65 = (L_62)->GetAt(static_cast<il2cpp_array_size_t>(L_64));
		V_8 = ((int32_t)il2cpp_codegen_subtract(L_61, (int32_t)L_65));
	}

IL_00dd:
	{
		int32_t L_66 = V_8;
		int32_t L_67 = ___1_src_p;
		if ((((int32_t)L_66) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_67, ((int32_t)65535))))))
		{
			goto IL_00ec;
		}
	}
	{
		int32_t L_68 = V_4;
		if (L_68)
		{
			goto IL_008f;
		}
	}

IL_00ec:
	{
		int32_t L_69 = V_5;
		if (!L_69)
		{
			goto IL_0150;
		}
	}
	{
		int32_t L_70 = ___1_src_p;
		V_10 = L_70;
		int32_t L_71 = ___1_src_p;
		int32_t L_72 = V_5;
		V_11 = ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_71, L_72)), 3));
		goto IL_010f;
	}

IL_00fd:
	{
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_73 = V_0;
		int32_t L_74 = V_10;
		uint16_t L_75 = V_7;
		NullCheck(L_73);
		(L_73)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)(L_74&((int32_t)65535)))), (uint16_t)L_75);
		int32_t L_76 = V_10;
		V_10 = ((int32_t)il2cpp_codegen_add(L_76, 1));
	}

IL_010f:
	{
		int32_t L_77 = V_10;
		int32_t L_78 = V_11;
		uint16_t L_79 = V_7;
		if ((((int32_t)L_77) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_78, (int32_t)L_79)))))
		{
			goto IL_00fd;
		}
	}

IL_0118:
	{
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_80 = V_0;
		int32_t L_81 = V_10;
		uint16_t L_82 = V_7;
		NullCheck(L_80);
		(L_80)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)(L_81&((int32_t)65535)))), (uint16_t)L_82);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_83 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_84 = V_2;
		int32_t L_85 = V_10;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint32_t L_86;
		L_86 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_84, L_85, NULL);
		int32_t L_87 = V_10;
		int32_t L_88 = V_3;
		NullCheck(L_83);
		(L_83)->SetAt(static_cast<il2cpp_array_size_t>(((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_86, ((int32_t)-1640531535)))>>((int32_t)17))))), (int32_t)((int32_t)il2cpp_codegen_subtract(L_87, L_88)));
		int32_t L_89 = V_10;
		V_10 = ((int32_t)il2cpp_codegen_add(L_89, 1));
		int32_t L_90 = V_10;
		int32_t L_91 = V_11;
		if ((((int32_t)L_90) < ((int32_t)L_91)))
		{
			goto IL_0118;
		}
	}
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_92 = ___0_ctx;
		int32_t L_93 = V_11;
		NullCheck(L_92);
		L_92->___nextToUpdate = L_93;
	}

IL_0150:
	{
		int32_t L_94 = V_6;
		return L_94;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4HC_InsertAndGetWiderMatch_64_m65A1CF1BBFC339D3CCB377BA92B4CE21D1B131D0 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t ___1_src_p, int32_t ___2_startLimit, int32_t ___3_longest, int32_t* ___4_matchpos, int32_t* ___5_startpos, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_LZ4HC_InsertAndGetWiderMatch_64_m65A1CF1BBFC339D3CCB377BA92B4CE21D1B131D0_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_0 = NULL;
	UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* V_1 = NULL;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_2 = NULL;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_3 = NULL;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	int64_t V_12 = 0;
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_0 = ((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DEBRUIJN_TABLE_64;
		V_0 = L_0;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_1 = ___0_ctx;
		NullCheck(L_1);
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_2 = L_1->___chainTable;
		V_1 = L_2;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_3 = ___0_ctx;
		NullCheck(L_3);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_4 = L_3->___hashTable;
		V_2 = L_4;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_5 = ___0_ctx;
		NullCheck(L_5);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = L_5->___src;
		V_3 = L_6;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_7 = ___0_ctx;
		NullCheck(L_7);
		int32_t L_8 = L_7->___src_base;
		V_4 = L_8;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_9 = ___0_ctx;
		NullCheck(L_9);
		int32_t L_10 = L_9->___src_LASTLITERALS;
		V_5 = L_10;
		V_6 = ((int32_t)256);
		int32_t L_11 = ___1_src_p;
		int32_t L_12 = ___2_startLimit;
		V_7 = ((int32_t)il2cpp_codegen_subtract(L_11, L_12));
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_13 = ___0_ctx;
		int32_t L_14 = ___1_src_p;
		LZ4Codec_LZ4HC_Insert_64_m88809B5C1FB9ADDCF2E7FAA7BA30A729D907F415(L_13, L_14, NULL);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_15 = V_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = V_3;
		int32_t L_17 = ___1_src_p;
		uint32_t L_18;
		L_18 = LZ4Codec_Peek4_mC5F29DDFABCABBE0695393ADE87924F157EB318B(L_16, L_17, NULL);
		NullCheck(L_15);
		uintptr_t L_19 = ((uintptr_t)((int32_t)((uint32_t)((int32_t)il2cpp_codegen_multiply((int32_t)L_18, ((int32_t)-1640531535)))>>((int32_t)17))));
		int32_t L_20 = (L_15)->GetAt(static_cast<il2cpp_array_size_t>(L_19));
		int32_t L_21 = V_4;
		V_8 = ((int32_t)il2cpp_codegen_add(L_20, L_21));
		goto IL_0180;
	}

IL_005b:
	{
		int32_t L_22 = V_6;
		V_6 = ((int32_t)il2cpp_codegen_subtract(L_22, 1));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_23 = V_3;
		int32_t L_24 = ___2_startLimit;
		int32_t L_25 = ___3_longest;
		NullCheck(L_23);
		int32_t L_26 = ((int32_t)il2cpp_codegen_add(L_24, L_25));
		uint8_t L_27 = (L_23)->GetAt(static_cast<il2cpp_array_size_t>(L_26));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_28 = V_3;
		int32_t L_29 = V_8;
		int32_t L_30 = V_7;
		int32_t L_31 = ___3_longest;
		NullCheck(L_28);
		int32_t L_32 = ((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_subtract(L_29, L_30)), L_31));
		uint8_t L_33 = (L_28)->GetAt(static_cast<il2cpp_array_size_t>(L_32));
		if ((!(((uint32_t)L_27) == ((uint32_t)L_33))))
		{
			goto IL_0171;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_34 = V_3;
		int32_t L_35 = V_8;
		int32_t L_36 = ___1_src_p;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_37;
		L_37 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_34, L_35, L_36, NULL);
		if (!L_37)
		{
			goto IL_0171;
		}
	}
	{
		int32_t L_38 = V_8;
		V_9 = ((int32_t)il2cpp_codegen_add(L_38, 4));
		int32_t L_39 = ___1_src_p;
		V_10 = ((int32_t)il2cpp_codegen_add(L_39, 4));
		int32_t L_40 = ___1_src_p;
		V_11 = L_40;
		goto IL_00cf;
	}

IL_0092:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_41 = V_3;
		int32_t L_42 = V_9;
		int32_t L_43 = V_10;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		uint64_t L_44;
		L_44 = LZ4Codec_Xor8_m4A7619EA57DCCFC5B2A17F222C94BE01C57E50BD(L_41, L_42, L_43, NULL);
		V_12 = L_44;
		int64_t L_45 = V_12;
		if ((!(((uint64_t)L_45) == ((uint64_t)((int64_t)0)))))
		{
			goto IL_00b2;
		}
	}
	{
		int32_t L_46 = V_10;
		V_10 = ((int32_t)il2cpp_codegen_add(L_46, 8));
		int32_t L_47 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_47, 8));
		goto IL_00cf;
	}

IL_00b2:
	{
		int32_t L_48 = V_10;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_49 = V_0;
		int64_t L_50 = V_12;
		int64_t L_51 = V_12;
		if ((uint64_t)(((int64_t)((uint64_t)((int64_t)il2cpp_codegen_multiply(((int64_t)(L_50&((-L_51)))), ((int64_t)151050438428048703LL)))>>((int32_t)58)))) > INTPTR_MAX) IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), LZ4Codec_LZ4HC_InsertAndGetWiderMatch_64_m65A1CF1BBFC339D3CCB377BA92B4CE21D1B131D0_RuntimeMethod_var);
		NullCheck(L_49);
		intptr_t L_52 = ((intptr_t)((int64_t)((uint64_t)((int64_t)il2cpp_codegen_multiply(((int64_t)(L_50&((-L_51)))), ((int64_t)151050438428048703LL)))>>((int32_t)58))));
		int32_t L_53 = (L_49)->GetAt(static_cast<il2cpp_array_size_t>(L_52));
		V_10 = ((int32_t)il2cpp_codegen_add(L_48, L_53));
		goto IL_012d;
	}

IL_00cf:
	{
		int32_t L_54 = V_10;
		int32_t L_55 = V_5;
		if ((((int32_t)L_54) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_55, 7)))))
		{
			goto IL_0092;
		}
	}
	{
		int32_t L_56 = V_10;
		int32_t L_57 = V_5;
		if ((((int32_t)L_56) >= ((int32_t)((int32_t)il2cpp_codegen_subtract(L_57, 3)))))
		{
			goto IL_00f7;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_58 = V_3;
		int32_t L_59 = V_9;
		int32_t L_60 = V_10;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_61;
		L_61 = LZ4Codec_Equal4_m2EC09AA816DECB373AC01E31A6CAA5DCAC7974B2(L_58, L_59, L_60, NULL);
		if (!L_61)
		{
			goto IL_00f7;
		}
	}
	{
		int32_t L_62 = V_10;
		V_10 = ((int32_t)il2cpp_codegen_add(L_62, 4));
		int32_t L_63 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_63, 4));
	}

IL_00f7:
	{
		int32_t L_64 = V_10;
		int32_t L_65 = V_5;
		if ((((int32_t)L_64) >= ((int32_t)((int32_t)il2cpp_codegen_subtract(L_65, 1)))))
		{
			goto IL_0117;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_66 = V_3;
		int32_t L_67 = V_9;
		int32_t L_68 = V_10;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		bool L_69;
		L_69 = LZ4Codec_Equal2_m05C0F8A90FA336B8EFA50F98F2485EAF9A00FEF6(L_66, L_67, L_68, NULL);
		if (!L_69)
		{
			goto IL_0117;
		}
	}
	{
		int32_t L_70 = V_10;
		V_10 = ((int32_t)il2cpp_codegen_add(L_70, 2));
		int32_t L_71 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_71, 2));
	}

IL_0117:
	{
		int32_t L_72 = V_10;
		int32_t L_73 = V_5;
		if ((((int32_t)L_72) >= ((int32_t)L_73)))
		{
			goto IL_012d;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_74 = V_3;
		int32_t L_75 = V_9;
		NullCheck(L_74);
		int32_t L_76 = L_75;
		uint8_t L_77 = (L_74)->GetAt(static_cast<il2cpp_array_size_t>(L_76));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_78 = V_3;
		int32_t L_79 = V_10;
		NullCheck(L_78);
		int32_t L_80 = L_79;
		uint8_t L_81 = (L_78)->GetAt(static_cast<il2cpp_array_size_t>(L_80));
		if ((!(((uint32_t)L_77) == ((uint32_t)L_81))))
		{
			goto IL_012d;
		}
	}
	{
		int32_t L_82 = V_10;
		V_10 = ((int32_t)il2cpp_codegen_add(L_82, 1));
	}

IL_012d:
	{
		int32_t L_83 = V_8;
		V_9 = L_83;
		goto IL_013f;
	}

IL_0133:
	{
		int32_t L_84 = V_11;
		V_11 = ((int32_t)il2cpp_codegen_subtract(L_84, 1));
		int32_t L_85 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_subtract(L_85, 1));
	}

IL_013f:
	{
		int32_t L_86 = V_11;
		int32_t L_87 = ___2_startLimit;
		if ((((int32_t)L_86) <= ((int32_t)L_87)))
		{
			goto IL_0158;
		}
	}
	{
		int32_t L_88 = V_9;
		int32_t L_89 = V_4;
		if ((((int32_t)L_88) <= ((int32_t)L_89)))
		{
			goto IL_0158;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_90 = V_3;
		int32_t L_91 = V_11;
		NullCheck(L_90);
		int32_t L_92 = ((int32_t)il2cpp_codegen_subtract(L_91, 1));
		uint8_t L_93 = (L_90)->GetAt(static_cast<il2cpp_array_size_t>(L_92));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_94 = V_3;
		int32_t L_95 = V_9;
		NullCheck(L_94);
		int32_t L_96 = ((int32_t)il2cpp_codegen_subtract(L_95, 1));
		uint8_t L_97 = (L_94)->GetAt(static_cast<il2cpp_array_size_t>(L_96));
		if ((((int32_t)L_93) == ((int32_t)L_97)))
		{
			goto IL_0133;
		}
	}

IL_0158:
	{
		int32_t L_98 = V_10;
		int32_t L_99 = V_11;
		int32_t L_100 = ___3_longest;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract(L_98, L_99))) <= ((int32_t)L_100)))
		{
			goto IL_0171;
		}
	}
	{
		int32_t L_101 = V_10;
		int32_t L_102 = V_11;
		___3_longest = ((int32_t)il2cpp_codegen_subtract(L_101, L_102));
		int32_t* L_103 = ___4_matchpos;
		int32_t L_104 = V_9;
		*((int32_t*)L_103) = (int32_t)L_104;
		int32_t* L_105 = ___5_startpos;
		int32_t L_106 = V_11;
		*((int32_t*)L_105) = (int32_t)L_106;
	}

IL_0171:
	{
		int32_t L_107 = V_8;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_108 = V_1;
		int32_t L_109 = V_8;
		NullCheck(L_108);
		int32_t L_110 = ((int32_t)(L_109&((int32_t)65535)));
		uint16_t L_111 = (L_108)->GetAt(static_cast<il2cpp_array_size_t>(L_110));
		V_8 = ((int32_t)il2cpp_codegen_subtract(L_107, (int32_t)L_111));
	}

IL_0180:
	{
		int32_t L_112 = V_8;
		int32_t L_113 = ___1_src_p;
		if ((((int32_t)L_112) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_113, ((int32_t)65535))))))
		{
			goto IL_0192;
		}
	}
	{
		int32_t L_114 = V_6;
		if (L_114)
		{
			goto IL_005b;
		}
	}

IL_0192:
	{
		int32_t L_115 = ___3_longest;
		return L_115;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_encodeSequence_64_m19A79EA21D56581CFD3149E776B57A11A52AFD41 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, int32_t* ___1_src_p, int32_t* ___2_dst_p, int32_t* ___3_src_anchor, int32_t ___4_matchLength, int32_t ___5_src_ref, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	int32_t V_13 = 0;
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_0 = ___0_ctx;
		NullCheck(L_0);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = L_0->___src;
		V_0 = L_1;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_2 = ___0_ctx;
		NullCheck(L_2);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = L_2->___dst;
		V_1 = L_3;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_4 = ___0_ctx;
		NullCheck(L_4);
		int32_t L_5 = L_4->___dst_end;
		V_2 = L_5;
		int32_t* L_6 = ___1_src_p;
		int32_t L_7 = *((int32_t*)L_6);
		int32_t* L_8 = ___3_src_anchor;
		int32_t L_9 = *((int32_t*)L_8);
		V_4 = ((int32_t)il2cpp_codegen_subtract(L_7, L_9));
		int32_t* L_10 = ___2_dst_p;
		int32_t* L_11 = L_10;
		int32_t L_12 = *((int32_t*)L_11);
		int32_t L_13 = L_12;
		V_7 = L_13;
		*((int32_t*)L_11) = (int32_t)((int32_t)il2cpp_codegen_add(L_13, 1));
		int32_t L_14 = V_7;
		V_5 = L_14;
		int32_t* L_15 = ___2_dst_p;
		int32_t L_16 = *((int32_t*)L_15);
		int32_t L_17 = V_4;
		int32_t L_18 = V_4;
		int32_t L_19 = V_2;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_16, L_17)), 8)), ((int32_t)(L_18>>8))))) <= ((int32_t)L_19)))
		{
			goto IL_003a;
		}
	}
	{
		return 1;
	}

IL_003a:
	{
		int32_t L_20 = V_4;
		if ((((int32_t)L_20) < ((int32_t)((int32_t)15))))
		{
			goto IL_0084;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_21 = V_1;
		int32_t L_22 = V_5;
		NullCheck(L_21);
		(L_21)->SetAt(static_cast<il2cpp_array_size_t>(L_22), (uint8_t)((int32_t)240));
		int32_t L_23 = V_4;
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_23, ((int32_t)15)));
		goto IL_006b;
	}

IL_0051:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = V_1;
		int32_t* L_25 = ___2_dst_p;
		int32_t* L_26 = L_25;
		int32_t L_27 = *((int32_t*)L_26);
		int32_t L_28 = L_27;
		V_8 = L_28;
		*((int32_t*)L_26) = (int32_t)((int32_t)il2cpp_codegen_add(L_28, 1));
		int32_t L_29 = V_8;
		NullCheck(L_24);
		(L_24)->SetAt(static_cast<il2cpp_array_size_t>(L_29), (uint8_t)((int32_t)255));
		int32_t L_30 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_30, ((int32_t)255)));
	}

IL_006b:
	{
		int32_t L_31 = V_3;
		if ((((int32_t)L_31) > ((int32_t)((int32_t)254))))
		{
			goto IL_0051;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_32 = V_1;
		int32_t* L_33 = ___2_dst_p;
		int32_t* L_34 = L_33;
		int32_t L_35 = *((int32_t*)L_34);
		int32_t L_36 = L_35;
		V_9 = L_36;
		*((int32_t*)L_34) = (int32_t)((int32_t)il2cpp_codegen_add(L_36, 1));
		int32_t L_37 = V_9;
		int32_t L_38 = V_3;
		NullCheck(L_32);
		(L_32)->SetAt(static_cast<il2cpp_array_size_t>(L_37), (uint8_t)((int32_t)(uint8_t)L_38));
		goto IL_008d;
	}

IL_0084:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_39 = V_1;
		int32_t L_40 = V_5;
		int32_t L_41 = V_4;
		NullCheck(L_39);
		(L_39)->SetAt(static_cast<il2cpp_array_size_t>(L_40), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_41<<4))));
	}

IL_008d:
	{
		int32_t L_42 = V_4;
		if ((((int32_t)L_42) <= ((int32_t)0)))
		{
			goto IL_00af;
		}
	}
	{
		int32_t* L_43 = ___2_dst_p;
		int32_t L_44 = *((int32_t*)L_43);
		int32_t L_45 = V_4;
		V_6 = ((int32_t)il2cpp_codegen_add(L_44, L_45));
		int32_t* L_46 = ___3_src_anchor;
		int32_t* L_47 = L_46;
		int32_t L_48 = *((int32_t*)L_47);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_49 = V_0;
		int32_t* L_50 = ___3_src_anchor;
		int32_t L_51 = *((int32_t*)L_50);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_52 = V_1;
		int32_t* L_53 = ___2_dst_p;
		int32_t L_54 = *((int32_t*)L_53);
		int32_t L_55 = V_6;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_56;
		L_56 = LZ4Codec_WildCopy_mE6E7FF3DC7D46D37614FDE84DDDEA5D03B0B5F94(L_49, L_51, L_52, L_54, L_55, NULL);
		*((int32_t*)L_47) = (int32_t)((int32_t)il2cpp_codegen_add(L_48, L_56));
		int32_t* L_57 = ___2_dst_p;
		int32_t L_58 = V_6;
		*((int32_t*)L_57) = (int32_t)L_58;
	}

IL_00af:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_59 = V_1;
		int32_t* L_60 = ___2_dst_p;
		int32_t L_61 = *((int32_t*)L_60);
		int32_t* L_62 = ___1_src_p;
		int32_t L_63 = *((int32_t*)L_62);
		int32_t L_64 = ___5_src_ref;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_Poke2_mA9D6096893521372F0C65B006AE5A25C59E869E1(L_59, L_61, (uint16_t)((int32_t)(uint16_t)((int32_t)il2cpp_codegen_subtract(L_63, L_64))), NULL);
		int32_t* L_65 = ___2_dst_p;
		int32_t* L_66 = L_65;
		int32_t L_67 = *((int32_t*)L_66);
		*((int32_t*)L_66) = (int32_t)((int32_t)il2cpp_codegen_add(L_67, 2));
		int32_t L_68 = ___4_matchLength;
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_68, 4));
		int32_t* L_69 = ___2_dst_p;
		int32_t L_70 = *((int32_t*)L_69);
		int32_t L_71 = V_4;
		int32_t L_72 = V_2;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_70, 6)), ((int32_t)(L_71>>8))))) <= ((int32_t)L_72)))
		{
			goto IL_00d6;
		}
	}
	{
		return 1;
	}

IL_00d6:
	{
		int32_t L_73 = V_3;
		if ((((int32_t)L_73) < ((int32_t)((int32_t)15))))
		{
			goto IL_0163;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_74 = V_1;
		int32_t L_75 = V_5;
		NullCheck(L_74);
		uint8_t* L_76 = ((L_74)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_75)));
		uint8_t L_77 = (*(uint8_t*)L_76);
		*(uint8_t*)L_76 = (uint8_t)((int32_t)(uint8_t)((int32_t)il2cpp_codegen_add((int32_t)L_77, ((int32_t)15))));
		int32_t L_78 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_78, ((int32_t)15)));
		goto IL_0128;
	}

IL_00fc:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_79 = V_1;
		int32_t* L_80 = ___2_dst_p;
		int32_t* L_81 = L_80;
		int32_t L_82 = *((int32_t*)L_81);
		int32_t L_83 = L_82;
		V_10 = L_83;
		*((int32_t*)L_81) = (int32_t)((int32_t)il2cpp_codegen_add(L_83, 1));
		int32_t L_84 = V_10;
		NullCheck(L_79);
		(L_79)->SetAt(static_cast<il2cpp_array_size_t>(L_84), (uint8_t)((int32_t)255));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_85 = V_1;
		int32_t* L_86 = ___2_dst_p;
		int32_t* L_87 = L_86;
		int32_t L_88 = *((int32_t*)L_87);
		int32_t L_89 = L_88;
		V_11 = L_89;
		*((int32_t*)L_87) = (int32_t)((int32_t)il2cpp_codegen_add(L_89, 1));
		int32_t L_90 = V_11;
		NullCheck(L_85);
		(L_85)->SetAt(static_cast<il2cpp_array_size_t>(L_90), (uint8_t)((int32_t)255));
		int32_t L_91 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_91, ((int32_t)510)));
	}

IL_0128:
	{
		int32_t L_92 = V_3;
		if ((((int32_t)L_92) > ((int32_t)((int32_t)509))))
		{
			goto IL_00fc;
		}
	}
	{
		int32_t L_93 = V_3;
		if ((((int32_t)L_93) <= ((int32_t)((int32_t)254))))
		{
			goto IL_0152;
		}
	}
	{
		int32_t L_94 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_94, ((int32_t)255)));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_95 = V_1;
		int32_t* L_96 = ___2_dst_p;
		int32_t* L_97 = L_96;
		int32_t L_98 = *((int32_t*)L_97);
		int32_t L_99 = L_98;
		V_12 = L_99;
		*((int32_t*)L_97) = (int32_t)((int32_t)il2cpp_codegen_add(L_99, 1));
		int32_t L_100 = V_12;
		NullCheck(L_95);
		(L_95)->SetAt(static_cast<il2cpp_array_size_t>(L_100), (uint8_t)((int32_t)255));
	}

IL_0152:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_101 = V_1;
		int32_t* L_102 = ___2_dst_p;
		int32_t* L_103 = L_102;
		int32_t L_104 = *((int32_t*)L_103);
		int32_t L_105 = L_104;
		V_13 = L_105;
		*((int32_t*)L_103) = (int32_t)((int32_t)il2cpp_codegen_add(L_105, 1));
		int32_t L_106 = V_13;
		int32_t L_107 = V_3;
		NullCheck(L_101);
		(L_101)->SetAt(static_cast<il2cpp_array_size_t>(L_106), (uint8_t)((int32_t)(uint8_t)L_107));
		goto IL_017a;
	}

IL_0163:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_108 = V_1;
		int32_t L_109 = V_5;
		NullCheck(L_108);
		uint8_t* L_110 = ((L_108)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_109)));
		uint8_t L_111 = (*(uint8_t*)L_110);
		int32_t L_112 = V_3;
		*(uint8_t*)L_110 = (uint8_t)((int32_t)(uint8_t)((int32_t)il2cpp_codegen_add((int32_t)L_111, ((int32_t)(uint8_t)L_112))));
	}

IL_017a:
	{
		int32_t* L_113 = ___1_src_p;
		int32_t* L_114 = L_113;
		int32_t L_115 = *((int32_t*)L_114);
		int32_t L_116 = ___4_matchLength;
		*((int32_t*)L_114) = (int32_t)((int32_t)il2cpp_codegen_add(L_115, L_116));
		int32_t* L_117 = ___3_src_anchor;
		int32_t* L_118 = ___1_src_p;
		int32_t L_119 = *((int32_t*)L_118);
		*((int32_t*)L_117) = (int32_t)L_119;
		return 0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_LZ4_compressHCCtx_64_m0037ABA747959A480DCBB84290F6337E11C01CBD (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* ___0_ctx, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_6 = NULL;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	int32_t V_11 = 0;
	int32_t V_12 = 0;
	int32_t V_13 = 0;
	int32_t V_14 = 0;
	int32_t V_15 = 0;
	int32_t V_16 = 0;
	int32_t V_17 = 0;
	int32_t V_18 = 0;
	int32_t V_19 = 0;
	int32_t V_20 = 0;
	int32_t V_21 = 0;
	int32_t V_22 = 0;
	int32_t V_23 = 0;
	int32_t V_24 = 0;
	int32_t G_B7_0 = 0;
	int32_t G_B25_0 = 0;
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_0 = ___0_ctx;
		NullCheck(L_0);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = L_0->___src;
		V_0 = L_1;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_2 = ___0_ctx;
		NullCheck(L_2);
		int32_t L_3 = L_2->___src_base;
		V_1 = L_3;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_4 = ___0_ctx;
		NullCheck(L_4);
		int32_t L_5 = L_4->___src_end;
		V_2 = L_5;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_6 = ___0_ctx;
		NullCheck(L_6);
		int32_t L_7 = L_6->___dst_base;
		V_3 = L_7;
		int32_t L_8 = V_1;
		V_4 = L_8;
		int32_t L_9 = V_2;
		V_5 = ((int32_t)il2cpp_codegen_subtract(L_9, ((int32_t)12)));
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_10 = ___0_ctx;
		NullCheck(L_10);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_11 = L_10->___dst;
		V_6 = L_11;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_12 = ___0_ctx;
		NullCheck(L_12);
		int32_t L_13 = L_12->___dst_len;
		V_7 = L_13;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_14 = ___0_ctx;
		NullCheck(L_14);
		int32_t L_15 = L_14->___dst_base;
		V_8 = L_15;
		V_9 = 0;
		V_10 = 0;
		V_11 = 0;
		V_12 = 0;
		V_13 = 0;
		int32_t L_16 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_16, 1));
		goto IL_02b5;
	}

IL_0055:
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_17 = ___0_ctx;
		int32_t L_18 = V_1;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_19;
		L_19 = LZ4Codec_LZ4HC_InsertAndFindBestMatch_64_mF27AC8EADD1C62F6D705D63F861A60C701A2CB9B(L_17, L_18, (&V_9), NULL);
		V_14 = L_19;
		int32_t L_20 = V_14;
		if (L_20)
		{
			goto IL_006d;
		}
	}
	{
		int32_t L_21 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_21, 1));
		goto IL_02b5;
	}

IL_006d:
	{
		int32_t L_22 = V_1;
		V_15 = L_22;
		int32_t L_23 = V_9;
		V_16 = L_23;
		int32_t L_24 = V_14;
		V_17 = L_24;
	}

IL_0078:
	{
		int32_t L_25 = V_1;
		int32_t L_26 = V_14;
		int32_t L_27 = V_5;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_25, L_26))) < ((int32_t)L_27)))
		{
			goto IL_0084;
		}
	}
	{
		int32_t L_28 = V_14;
		G_B7_0 = L_28;
		goto IL_0099;
	}

IL_0084:
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_29 = ___0_ctx;
		int32_t L_30 = V_1;
		int32_t L_31 = V_14;
		int32_t L_32 = V_1;
		int32_t L_33 = V_14;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_34;
		L_34 = LZ4Codec_LZ4HC_InsertAndGetWiderMatch_64_m65A1CF1BBFC339D3CCB377BA92B4CE21D1B131D0(L_29, ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_30, L_31)), 2)), ((int32_t)il2cpp_codegen_add(L_32, 1)), L_33, (&V_11), (&V_10), NULL);
		G_B7_0 = L_34;
	}

IL_0099:
	{
		V_18 = G_B7_0;
		int32_t L_35 = V_18;
		int32_t L_36 = V_14;
		if ((!(((uint32_t)L_35) == ((uint32_t)L_36))))
		{
			goto IL_00b8;
		}
	}
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_37 = ___0_ctx;
		int32_t L_38 = V_14;
		int32_t L_39 = V_9;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_40;
		L_40 = LZ4Codec_LZ4_encodeSequence_64_m19A79EA21D56581CFD3149E776B57A11A52AFD41(L_37, (&V_1), (&V_8), (&V_4), L_38, L_39, NULL);
		if (!L_40)
		{
			goto IL_02b5;
		}
	}
	{
		return 0;
	}

IL_00b8:
	{
		int32_t L_41 = V_15;
		int32_t L_42 = V_1;
		if ((((int32_t)L_41) >= ((int32_t)L_42)))
		{
			goto IL_00d0;
		}
	}
	{
		int32_t L_43 = V_10;
		int32_t L_44 = V_1;
		int32_t L_45 = V_17;
		if ((((int32_t)L_43) >= ((int32_t)((int32_t)il2cpp_codegen_add(L_44, L_45)))))
		{
			goto IL_00d0;
		}
	}
	{
		int32_t L_46 = V_15;
		V_1 = L_46;
		int32_t L_47 = V_16;
		V_9 = L_47;
		int32_t L_48 = V_17;
		V_14 = L_48;
	}

IL_00d0:
	{
		int32_t L_49 = V_10;
		int32_t L_50 = V_1;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract(L_49, L_50))) >= ((int32_t)3)))
		{
			goto IL_00e4;
		}
	}
	{
		int32_t L_51 = V_18;
		V_14 = L_51;
		int32_t L_52 = V_10;
		V_1 = L_52;
		int32_t L_53 = V_11;
		V_9 = L_53;
		goto IL_0078;
	}

IL_00e4:
	{
		int32_t L_54 = V_10;
		int32_t L_55 = V_1;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract(L_54, L_55))) >= ((int32_t)((int32_t)18))))
		{
			goto IL_0135;
		}
	}
	{
		int32_t L_56 = V_14;
		V_19 = L_56;
		int32_t L_57 = V_19;
		if ((((int32_t)L_57) <= ((int32_t)((int32_t)18))))
		{
			goto IL_00fa;
		}
	}
	{
		V_19 = ((int32_t)18);
	}

IL_00fa:
	{
		int32_t L_58 = V_1;
		int32_t L_59 = V_19;
		int32_t L_60 = V_10;
		int32_t L_61 = V_18;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_58, L_59))) <= ((int32_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_60, L_61)), 4)))))
		{
			goto IL_0112;
		}
	}
	{
		int32_t L_62 = V_10;
		int32_t L_63 = V_1;
		int32_t L_64 = V_18;
		V_19 = ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_subtract(L_62, L_63)), L_64)), 4));
	}

IL_0112:
	{
		int32_t L_65 = V_19;
		int32_t L_66 = V_10;
		int32_t L_67 = V_1;
		V_20 = ((int32_t)il2cpp_codegen_subtract(L_65, ((int32_t)il2cpp_codegen_subtract(L_66, L_67))));
		int32_t L_68 = V_20;
		if ((((int32_t)L_68) <= ((int32_t)0)))
		{
			goto IL_0135;
		}
	}
	{
		int32_t L_69 = V_10;
		int32_t L_70 = V_20;
		V_10 = ((int32_t)il2cpp_codegen_add(L_69, L_70));
		int32_t L_71 = V_11;
		int32_t L_72 = V_20;
		V_11 = ((int32_t)il2cpp_codegen_add(L_71, L_72));
		int32_t L_73 = V_18;
		int32_t L_74 = V_20;
		V_18 = ((int32_t)il2cpp_codegen_subtract(L_73, L_74));
	}

IL_0135:
	{
		int32_t L_75 = V_10;
		int32_t L_76 = V_18;
		int32_t L_77 = V_5;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_75, L_76))) < ((int32_t)L_77)))
		{
			goto IL_0142;
		}
	}
	{
		int32_t L_78 = V_18;
		G_B25_0 = L_78;
		goto IL_0157;
	}

IL_0142:
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_79 = ___0_ctx;
		int32_t L_80 = V_10;
		int32_t L_81 = V_18;
		int32_t L_82 = V_10;
		int32_t L_83 = V_18;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_84;
		L_84 = LZ4Codec_LZ4HC_InsertAndGetWiderMatch_64_m65A1CF1BBFC339D3CCB377BA92B4CE21D1B131D0(L_79, ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_80, L_81)), 3)), L_82, L_83, (&V_13), (&V_12), NULL);
		G_B25_0 = L_84;
	}

IL_0157:
	{
		V_21 = G_B25_0;
		int32_t L_85 = V_21;
		int32_t L_86 = V_18;
		if ((!(((uint32_t)L_85) == ((uint32_t)L_86))))
		{
			goto IL_019b;
		}
	}
	{
		int32_t L_87 = V_10;
		int32_t L_88 = V_1;
		int32_t L_89 = V_14;
		if ((((int32_t)L_87) >= ((int32_t)((int32_t)il2cpp_codegen_add(L_88, L_89)))))
		{
			goto IL_016d;
		}
	}
	{
		int32_t L_90 = V_10;
		int32_t L_91 = V_1;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_90, L_91));
	}

IL_016d:
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_92 = ___0_ctx;
		int32_t L_93 = V_14;
		int32_t L_94 = V_9;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_95;
		L_95 = LZ4Codec_LZ4_encodeSequence_64_m19A79EA21D56581CFD3149E776B57A11A52AFD41(L_92, (&V_1), (&V_8), (&V_4), L_93, L_94, NULL);
		if (!L_95)
		{
			goto IL_0181;
		}
	}
	{
		return 0;
	}

IL_0181:
	{
		int32_t L_96 = V_10;
		V_1 = L_96;
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_97 = ___0_ctx;
		int32_t L_98 = V_18;
		int32_t L_99 = V_11;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_100;
		L_100 = LZ4Codec_LZ4_encodeSequence_64_m19A79EA21D56581CFD3149E776B57A11A52AFD41(L_97, (&V_1), (&V_8), (&V_4), L_98, L_99, NULL);
		if (!L_100)
		{
			goto IL_02b5;
		}
	}
	{
		return 0;
	}

IL_019b:
	{
		int32_t L_101 = V_12;
		int32_t L_102 = V_1;
		int32_t L_103 = V_14;
		if ((((int32_t)L_101) >= ((int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_102, L_103)), 3)))))
		{
			goto IL_0228;
		}
	}
	{
		int32_t L_104 = V_12;
		int32_t L_105 = V_1;
		int32_t L_106 = V_14;
		if ((((int32_t)L_104) < ((int32_t)((int32_t)il2cpp_codegen_add(L_105, L_106)))))
		{
			goto IL_0217;
		}
	}
	{
		int32_t L_107 = V_10;
		int32_t L_108 = V_1;
		int32_t L_109 = V_14;
		if ((((int32_t)L_107) >= ((int32_t)((int32_t)il2cpp_codegen_add(L_108, L_109)))))
		{
			goto IL_01e7;
		}
	}
	{
		int32_t L_110 = V_1;
		int32_t L_111 = V_14;
		int32_t L_112 = V_10;
		V_22 = ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_110, L_111)), L_112));
		int32_t L_113 = V_10;
		int32_t L_114 = V_22;
		V_10 = ((int32_t)il2cpp_codegen_add(L_113, L_114));
		int32_t L_115 = V_11;
		int32_t L_116 = V_22;
		V_11 = ((int32_t)il2cpp_codegen_add(L_115, L_116));
		int32_t L_117 = V_18;
		int32_t L_118 = V_22;
		V_18 = ((int32_t)il2cpp_codegen_subtract(L_117, L_118));
		int32_t L_119 = V_18;
		if ((((int32_t)L_119) >= ((int32_t)4)))
		{
			goto IL_01e7;
		}
	}
	{
		int32_t L_120 = V_12;
		V_10 = L_120;
		int32_t L_121 = V_13;
		V_11 = L_121;
		int32_t L_122 = V_21;
		V_18 = L_122;
	}

IL_01e7:
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_123 = ___0_ctx;
		int32_t L_124 = V_14;
		int32_t L_125 = V_9;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_126;
		L_126 = LZ4Codec_LZ4_encodeSequence_64_m19A79EA21D56581CFD3149E776B57A11A52AFD41(L_123, (&V_1), (&V_8), (&V_4), L_124, L_125, NULL);
		if (!L_126)
		{
			goto IL_01fb;
		}
	}
	{
		return 0;
	}

IL_01fb:
	{
		int32_t L_127 = V_12;
		V_1 = L_127;
		int32_t L_128 = V_13;
		V_9 = L_128;
		int32_t L_129 = V_21;
		V_14 = L_129;
		int32_t L_130 = V_10;
		V_15 = L_130;
		int32_t L_131 = V_11;
		V_16 = L_131;
		int32_t L_132 = V_18;
		V_17 = L_132;
		goto IL_0078;
	}

IL_0217:
	{
		int32_t L_133 = V_12;
		V_10 = L_133;
		int32_t L_134 = V_13;
		V_11 = L_134;
		int32_t L_135 = V_21;
		V_18 = L_135;
		goto IL_00e4;
	}

IL_0228:
	{
		int32_t L_136 = V_10;
		int32_t L_137 = V_1;
		int32_t L_138 = V_14;
		if ((((int32_t)L_136) >= ((int32_t)((int32_t)il2cpp_codegen_add(L_137, L_138)))))
		{
			goto IL_0285;
		}
	}
	{
		int32_t L_139 = V_10;
		int32_t L_140 = V_1;
		if ((((int32_t)((int32_t)il2cpp_codegen_subtract(L_139, L_140))) >= ((int32_t)((int32_t)15))))
		{
			goto IL_027f;
		}
	}
	{
		int32_t L_141 = V_14;
		if ((((int32_t)L_141) <= ((int32_t)((int32_t)18))))
		{
			goto IL_0242;
		}
	}
	{
		V_14 = ((int32_t)18);
	}

IL_0242:
	{
		int32_t L_142 = V_1;
		int32_t L_143 = V_14;
		int32_t L_144 = V_10;
		int32_t L_145 = V_18;
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_142, L_143))) <= ((int32_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_144, L_145)), 4)))))
		{
			goto IL_025a;
		}
	}
	{
		int32_t L_146 = V_10;
		int32_t L_147 = V_1;
		int32_t L_148 = V_18;
		V_14 = ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_subtract(L_146, L_147)), L_148)), 4));
	}

IL_025a:
	{
		int32_t L_149 = V_14;
		int32_t L_150 = V_10;
		int32_t L_151 = V_1;
		V_23 = ((int32_t)il2cpp_codegen_subtract(L_149, ((int32_t)il2cpp_codegen_subtract(L_150, L_151))));
		int32_t L_152 = V_23;
		if ((((int32_t)L_152) <= ((int32_t)0)))
		{
			goto IL_0285;
		}
	}
	{
		int32_t L_153 = V_10;
		int32_t L_154 = V_23;
		V_10 = ((int32_t)il2cpp_codegen_add(L_153, L_154));
		int32_t L_155 = V_11;
		int32_t L_156 = V_23;
		V_11 = ((int32_t)il2cpp_codegen_add(L_155, L_156));
		int32_t L_157 = V_18;
		int32_t L_158 = V_23;
		V_18 = ((int32_t)il2cpp_codegen_subtract(L_157, L_158));
		goto IL_0285;
	}

IL_027f:
	{
		int32_t L_159 = V_10;
		int32_t L_160 = V_1;
		V_14 = ((int32_t)il2cpp_codegen_subtract(L_159, L_160));
	}

IL_0285:
	{
		LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* L_161 = ___0_ctx;
		int32_t L_162 = V_14;
		int32_t L_163 = V_9;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_164;
		L_164 = LZ4Codec_LZ4_encodeSequence_64_m19A79EA21D56581CFD3149E776B57A11A52AFD41(L_161, (&V_1), (&V_8), (&V_4), L_162, L_163, NULL);
		if (!L_164)
		{
			goto IL_0299;
		}
	}
	{
		return 0;
	}

IL_0299:
	{
		int32_t L_165 = V_10;
		V_1 = L_165;
		int32_t L_166 = V_11;
		V_9 = L_166;
		int32_t L_167 = V_18;
		V_14 = L_167;
		int32_t L_168 = V_12;
		V_10 = L_168;
		int32_t L_169 = V_13;
		V_11 = L_169;
		int32_t L_170 = V_21;
		V_18 = L_170;
		goto IL_00e4;
	}

IL_02b5:
	{
		int32_t L_171 = V_1;
		int32_t L_172 = V_5;
		if ((((int32_t)L_171) < ((int32_t)L_172)))
		{
			goto IL_0055;
		}
	}
	{
		int32_t L_173 = V_2;
		int32_t L_174 = V_4;
		V_24 = ((int32_t)il2cpp_codegen_subtract(L_173, L_174));
		int32_t L_175 = V_8;
		int32_t L_176 = V_3;
		int32_t L_177 = V_24;
		int32_t L_178 = V_24;
		int32_t L_179 = V_7;
		if ((((int64_t)((int64_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_subtract(L_175, L_176)), L_177)), 1)), ((int32_t)(((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_178, ((int32_t)255))), ((int32_t)15)))/((int32_t)255))))))) <= ((int64_t)((int64_t)(uint64_t)((uint32_t)L_179)))))
		{
			goto IL_02e6;
		}
	}
	{
		return 0;
	}

IL_02e6:
	{
		int32_t L_180 = V_24;
		if ((((int32_t)L_180) < ((int32_t)((int32_t)15))))
		{
			goto IL_0335;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_181 = V_6;
		int32_t L_182 = V_8;
		int32_t L_183 = L_182;
		V_8 = ((int32_t)il2cpp_codegen_add(L_183, 1));
		NullCheck(L_181);
		(L_181)->SetAt(static_cast<il2cpp_array_size_t>(L_183), (uint8_t)((int32_t)240));
		int32_t L_184 = V_24;
		V_24 = ((int32_t)il2cpp_codegen_subtract(L_184, ((int32_t)15)));
		goto IL_031d;
	}

IL_0304:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_185 = V_6;
		int32_t L_186 = V_8;
		int32_t L_187 = L_186;
		V_8 = ((int32_t)il2cpp_codegen_add(L_187, 1));
		NullCheck(L_185);
		(L_185)->SetAt(static_cast<il2cpp_array_size_t>(L_187), (uint8_t)((int32_t)255));
		int32_t L_188 = V_24;
		V_24 = ((int32_t)il2cpp_codegen_subtract(L_188, ((int32_t)255)));
	}

IL_031d:
	{
		int32_t L_189 = V_24;
		if ((((int32_t)L_189) > ((int32_t)((int32_t)254))))
		{
			goto IL_0304;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_190 = V_6;
		int32_t L_191 = V_8;
		int32_t L_192 = L_191;
		V_8 = ((int32_t)il2cpp_codegen_add(L_192, 1));
		int32_t L_193 = V_24;
		NullCheck(L_190);
		(L_190)->SetAt(static_cast<il2cpp_array_size_t>(L_192), (uint8_t)((int32_t)(uint8_t)L_193));
		goto IL_0344;
	}

IL_0335:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_194 = V_6;
		int32_t L_195 = V_8;
		int32_t L_196 = L_195;
		V_8 = ((int32_t)il2cpp_codegen_add(L_196, 1));
		int32_t L_197 = V_24;
		NullCheck(L_194);
		(L_194)->SetAt(static_cast<il2cpp_array_size_t>(L_196), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_197<<4))));
	}

IL_0344:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_198 = V_0;
		int32_t L_199 = V_4;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_200 = V_6;
		int32_t L_201 = V_8;
		int32_t L_202 = V_2;
		int32_t L_203 = V_4;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		LZ4Codec_BlockCopy_mACC1BC0CE3541162DF70007FF31E19209D6C3C9D(L_198, L_199, L_200, L_201, ((int32_t)il2cpp_codegen_subtract(L_202, L_203)), NULL);
		int32_t L_204 = V_8;
		int32_t L_205 = V_2;
		int32_t L_206 = V_4;
		V_8 = ((int32_t)il2cpp_codegen_add(L_204, ((int32_t)il2cpp_codegen_subtract(L_205, L_206))));
		int32_t L_207 = V_8;
		int32_t L_208 = V_3;
		return ((int32_t)il2cpp_codegen_subtract(L_207, L_208));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec__cctor_mAE8A1F51F688486EB078D125CE643130BFE70146 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CPrivateImplementationDetailsU3EU7BF0F453ADU2D4DD4U2D4EFBU2D816CU2D6D223090545FU7D_t93196623BC479309CE2F3090E7B954A494E7AF33____U24U24method0x600007fU2D1_FieldInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CPrivateImplementationDetailsU3EU7BF0F453ADU2D4DD4U2D4EFBU2D816CU2D6D223090545FU7D_t93196623BC479309CE2F3090E7B954A494E7AF33____U24U24method0x600007fU2D2_FieldInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CPrivateImplementationDetailsU3EU7BF0F453ADU2D4DD4U2D4EFBU2D816CU2D6D223090545FU7D_t93196623BC479309CE2F3090E7B954A494E7AF33____U24U24method0x600007fU2D3_FieldInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CPrivateImplementationDetailsU3EU7BF0F453ADU2D4DD4U2D4EFBU2D816CU2D6D223090545FU7D_t93196623BC479309CE2F3090E7B954A494E7AF33____U24U24method0x600007fU2D4_FieldInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_0 = (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)SZArrayNew(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var, (uint32_t)8);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_1 = L_0;
		RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 L_2 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3EU7BF0F453ADU2D4DD4U2D4EFBU2D816CU2D6D223090545FU7D_t93196623BC479309CE2F3090E7B954A494E7AF33____U24U24method0x600007fU2D1_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B((RuntimeArray*)L_1, L_2, NULL);
		((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DECODER_TABLE_32 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DECODER_TABLE_32), (void*)L_1);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_3 = (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)SZArrayNew(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var, (uint32_t)8);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_4 = L_3;
		RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 L_5 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3EU7BF0F453ADU2D4DD4U2D4EFBU2D816CU2D6D223090545FU7D_t93196623BC479309CE2F3090E7B954A494E7AF33____U24U24method0x600007fU2D2_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B((RuntimeArray*)L_4, L_5, NULL);
		((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DECODER_TABLE_64 = L_4;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DECODER_TABLE_64), (void*)L_4);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_6 = (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)SZArrayNew(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var, (uint32_t)((int32_t)32));
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_7 = L_6;
		RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 L_8 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3EU7BF0F453ADU2D4DD4U2D4EFBU2D816CU2D6D223090545FU7D_t93196623BC479309CE2F3090E7B954A494E7AF33____U24U24method0x600007fU2D3_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B((RuntimeArray*)L_7, L_8, NULL);
		((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DEBRUIJN_TABLE_32 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DEBRUIJN_TABLE_32), (void*)L_7);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_9 = (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)SZArrayNew(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var, (uint32_t)((int32_t)64));
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_10 = L_9;
		RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 L_11 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3EU7BF0F453ADU2D4DD4U2D4EFBU2D816CU2D6D223090545FU7D_t93196623BC479309CE2F3090E7B954A494E7AF33____U24U24method0x600007fU2D4_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B((RuntimeArray*)L_10, L_11, NULL);
		((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DEBRUIJN_TABLE_64 = L_10;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var))->___DEBRUIJN_TABLE_64), (void*)L_10);
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4HC_Data_Structure__ctor_m5E8B7F4BD2B0BA48BCD08EFD2063130779B84D18 (LZ4HC_Data_Structure_tD6F59D1F3B35F5DBC9EFA37EA64E648806043B5A* __this, const RuntimeMethod* method) 
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec__cctor_m39C467FDA4B7A84F38C8A5A1562B3B5E54561DE2 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Func_1_tAD57E0E3EDDE20EC12439DA534F1722A9D24EF5D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_Has2010Runtime_m12032B2FFCBBBA3FEF01C4EE988B1A4A1C0BE3F0_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_InitializeLZ4cc_m31E3406932DFA777DF898179A9EC8A39C86A09E3_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_InitializeLZ4mm_m14C1305C69ACB9B663D07A8CFE4FEED4204F6130_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_InitializeLZ4n_m53DC33F1EDDC538B845072A0321E9CDEF5A6D14A_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_InitializeLZ4s_m4EC9AFFF8DD01160779275C1643D29A882CD5E00_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_Try_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m6E86D4ECD4E84B32E2566725E326A05A2E4E1E74_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject* V_0 = NULL;
	RuntimeObject* V_1 = NULL;
	RuntimeObject* V_2 = NULL;
	{
		Func_1_tAD57E0E3EDDE20EC12439DA534F1722A9D24EF5D* L_0 = (Func_1_tAD57E0E3EDDE20EC12439DA534F1722A9D24EF5D*)il2cpp_codegen_object_new(Func_1_tAD57E0E3EDDE20EC12439DA534F1722A9D24EF5D_il2cpp_TypeInfo_var);
		Func_1__ctor_m56E1CF05BB8790B37A7CA230D46C9F900021FE72(L_0, NULL, (intptr_t)((void*)LZ4Codec_Has2010Runtime_m12032B2FFCBBBA3FEF01C4EE988B1A4A1C0BE3F0_RuntimeMethod_var), NULL);
		bool L_1;
		L_1 = LZ4Codec_Try_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m6E86D4ECD4E84B32E2566725E326A05A2E4E1E74(L_0, (bool)0, LZ4Codec_Try_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m6E86D4ECD4E84B32E2566725E326A05A2E4E1E74_RuntimeMethod_var);
		if (!L_1)
		{
			goto IL_0036;
		}
	}
	{
		Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* L_2 = (Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97*)il2cpp_codegen_object_new(Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97_il2cpp_TypeInfo_var);
		Action__ctor_mA303A98BFE7D11C2D04A004FD6C69D154B3782FB(L_2, NULL, (intptr_t)((void*)LZ4Codec_InitializeLZ4mm_m14C1305C69ACB9B663D07A8CFE4FEED4204F6130_RuntimeMethod_var), NULL);
		LZ4Codec_Try_m1E504E6EBEFF72CC9A684B60A28F776ED921DE85(L_2, NULL);
		Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* L_3 = (Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97*)il2cpp_codegen_object_new(Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97_il2cpp_TypeInfo_var);
		Action__ctor_mA303A98BFE7D11C2D04A004FD6C69D154B3782FB(L_3, NULL, (intptr_t)((void*)LZ4Codec_InitializeLZ4cc_m31E3406932DFA777DF898179A9EC8A39C86A09E3_RuntimeMethod_var), NULL);
		LZ4Codec_Try_m1E504E6EBEFF72CC9A684B60A28F776ED921DE85(L_3, NULL);
	}

IL_0036:
	{
		Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* L_4 = (Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97*)il2cpp_codegen_object_new(Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97_il2cpp_TypeInfo_var);
		Action__ctor_mA303A98BFE7D11C2D04A004FD6C69D154B3782FB(L_4, NULL, (intptr_t)((void*)LZ4Codec_InitializeLZ4n_m53DC33F1EDDC538B845072A0321E9CDEF5A6D14A_RuntimeMethod_var), NULL);
		LZ4Codec_Try_m1E504E6EBEFF72CC9A684B60A28F776ED921DE85(L_4, NULL);
		Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* L_5 = (Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97*)il2cpp_codegen_object_new(Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97_il2cpp_TypeInfo_var);
		Action__ctor_mA303A98BFE7D11C2D04A004FD6C69D154B3782FB(L_5, NULL, (intptr_t)((void*)LZ4Codec_InitializeLZ4s_m4EC9AFFF8DD01160779275C1643D29A882CD5E00_RuntimeMethod_var), NULL);
		LZ4Codec_Try_m1E504E6EBEFF72CC9A684B60A28F776ED921DE85(L_5, NULL);
		LZ4Codec_SelectCodec_m4CD78DED1420D05EED0E06FAAEA6B27BBC50888C((&V_0), (&V_1), (&V_2), NULL);
		RuntimeObject* L_6 = V_0;
		((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___Encoder = L_6;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___Encoder), (void*)L_6);
		RuntimeObject* L_7 = V_1;
		((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___Decoder = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___Decoder), (void*)L_7);
		RuntimeObject* L_8 = V_2;
		((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___EncoderHC = L_8;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___EncoderHC), (void*)L_8);
		RuntimeObject* L_9 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___Encoder;
		if (!L_9)
		{
			goto IL_0083;
		}
	}
	{
		RuntimeObject* L_10 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___Decoder;
		if (L_10)
		{
			goto IL_008e;
		}
	}

IL_0083:
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_11 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_11, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral9AA547017F907F3267372CFA8352F5C48C4942F7)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_11, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec__cctor_m39C467FDA4B7A84F38C8A5A1562B3B5E54561DE2_RuntimeMethod_var)));
	}

IL_008e:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_SelectCodec_m4CD78DED1420D05EED0E06FAAEA6B27BBC50888C (RuntimeObject** ___0_encoder, RuntimeObject** ___1_decoder, RuntimeObject** ___2_encoderHC, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject* G_B9_0 = NULL;
	RuntimeObject** G_B9_1 = NULL;
	RuntimeObject* G_B2_0 = NULL;
	RuntimeObject** G_B2_1 = NULL;
	RuntimeObject* G_B3_0 = NULL;
	RuntimeObject** G_B3_1 = NULL;
	RuntimeObject* G_B4_0 = NULL;
	RuntimeObject** G_B4_1 = NULL;
	RuntimeObject* G_B5_0 = NULL;
	RuntimeObject** G_B5_1 = NULL;
	RuntimeObject* G_B6_0 = NULL;
	RuntimeObject** G_B6_1 = NULL;
	RuntimeObject* G_B7_0 = NULL;
	RuntimeObject** G_B7_1 = NULL;
	RuntimeObject* G_B8_0 = NULL;
	RuntimeObject** G_B8_1 = NULL;
	RuntimeObject* G_B17_0 = NULL;
	RuntimeObject** G_B17_1 = NULL;
	RuntimeObject* G_B10_0 = NULL;
	RuntimeObject** G_B10_1 = NULL;
	RuntimeObject* G_B11_0 = NULL;
	RuntimeObject** G_B11_1 = NULL;
	RuntimeObject* G_B12_0 = NULL;
	RuntimeObject** G_B12_1 = NULL;
	RuntimeObject* G_B13_0 = NULL;
	RuntimeObject** G_B13_1 = NULL;
	RuntimeObject* G_B14_0 = NULL;
	RuntimeObject** G_B14_1 = NULL;
	RuntimeObject* G_B15_0 = NULL;
	RuntimeObject** G_B15_1 = NULL;
	RuntimeObject* G_B16_0 = NULL;
	RuntimeObject** G_B16_1 = NULL;
	RuntimeObject* G_B25_0 = NULL;
	RuntimeObject** G_B25_1 = NULL;
	RuntimeObject* G_B18_0 = NULL;
	RuntimeObject** G_B18_1 = NULL;
	RuntimeObject* G_B19_0 = NULL;
	RuntimeObject** G_B19_1 = NULL;
	RuntimeObject* G_B20_0 = NULL;
	RuntimeObject** G_B20_1 = NULL;
	RuntimeObject* G_B21_0 = NULL;
	RuntimeObject** G_B21_1 = NULL;
	RuntimeObject* G_B22_0 = NULL;
	RuntimeObject** G_B22_1 = NULL;
	RuntimeObject* G_B23_0 = NULL;
	RuntimeObject** G_B23_1 = NULL;
	RuntimeObject* G_B24_0 = NULL;
	RuntimeObject** G_B24_1 = NULL;
	RuntimeObject* G_B34_0 = NULL;
	RuntimeObject** G_B34_1 = NULL;
	RuntimeObject* G_B27_0 = NULL;
	RuntimeObject** G_B27_1 = NULL;
	RuntimeObject* G_B28_0 = NULL;
	RuntimeObject** G_B28_1 = NULL;
	RuntimeObject* G_B29_0 = NULL;
	RuntimeObject** G_B29_1 = NULL;
	RuntimeObject* G_B30_0 = NULL;
	RuntimeObject** G_B30_1 = NULL;
	RuntimeObject* G_B31_0 = NULL;
	RuntimeObject** G_B31_1 = NULL;
	RuntimeObject* G_B32_0 = NULL;
	RuntimeObject** G_B32_1 = NULL;
	RuntimeObject* G_B33_0 = NULL;
	RuntimeObject** G_B33_1 = NULL;
	RuntimeObject* G_B42_0 = NULL;
	RuntimeObject** G_B42_1 = NULL;
	RuntimeObject* G_B35_0 = NULL;
	RuntimeObject** G_B35_1 = NULL;
	RuntimeObject* G_B36_0 = NULL;
	RuntimeObject** G_B36_1 = NULL;
	RuntimeObject* G_B37_0 = NULL;
	RuntimeObject** G_B37_1 = NULL;
	RuntimeObject* G_B38_0 = NULL;
	RuntimeObject** G_B38_1 = NULL;
	RuntimeObject* G_B39_0 = NULL;
	RuntimeObject** G_B39_1 = NULL;
	RuntimeObject* G_B40_0 = NULL;
	RuntimeObject** G_B40_1 = NULL;
	RuntimeObject* G_B41_0 = NULL;
	RuntimeObject** G_B41_1 = NULL;
	RuntimeObject* G_B50_0 = NULL;
	RuntimeObject** G_B50_1 = NULL;
	RuntimeObject* G_B43_0 = NULL;
	RuntimeObject** G_B43_1 = NULL;
	RuntimeObject* G_B44_0 = NULL;
	RuntimeObject** G_B44_1 = NULL;
	RuntimeObject* G_B45_0 = NULL;
	RuntimeObject** G_B45_1 = NULL;
	RuntimeObject* G_B46_0 = NULL;
	RuntimeObject** G_B46_1 = NULL;
	RuntimeObject* G_B47_0 = NULL;
	RuntimeObject** G_B47_1 = NULL;
	RuntimeObject* G_B48_0 = NULL;
	RuntimeObject** G_B48_1 = NULL;
	RuntimeObject* G_B49_0 = NULL;
	RuntimeObject** G_B49_1 = NULL;
	{
		int32_t L_0;
		L_0 = IntPtr_get_Size_m1FAAA59DA73D7E32BB1AB55DD92A90AFE3251DBE(NULL);
		if ((!(((uint32_t)L_0) == ((uint32_t)4))))
		{
			goto IL_00de;
		}
	}
	{
		RuntimeObject** L_1 = ___0_encoder;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_2 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM32;
		RuntimeObject* L_3 = L_2;
		if (L_3)
		{
			G_B9_0 = L_3;
			G_B9_1 = L_1;
			goto IL_0050;
		}
		G_B2_0 = L_3;
		G_B2_1 = L_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_4 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM64;
		RuntimeObject* L_5 = L_4;
		if (L_5)
		{
			G_B9_0 = L_5;
			G_B9_1 = G_B2_1;
			goto IL_0050;
		}
		G_B3_0 = L_5;
		G_B3_1 = G_B2_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_6 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N32;
		RuntimeObject* L_7 = L_6;
		if (L_7)
		{
			G_B9_0 = L_7;
			G_B9_1 = G_B3_1;
			goto IL_0050;
		}
		G_B4_0 = L_7;
		G_B4_1 = G_B3_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_8 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC32;
		RuntimeObject* L_9 = L_8;
		if (L_9)
		{
			G_B9_0 = L_9;
			G_B9_1 = G_B4_1;
			goto IL_0050;
		}
		G_B5_0 = L_9;
		G_B5_1 = G_B4_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_10 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N64;
		RuntimeObject* L_11 = L_10;
		if (L_11)
		{
			G_B9_0 = L_11;
			G_B9_1 = G_B5_1;
			goto IL_0050;
		}
		G_B6_0 = L_11;
		G_B6_1 = G_B5_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_12 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC64;
		RuntimeObject* L_13 = L_12;
		if (L_13)
		{
			G_B9_0 = L_13;
			G_B9_1 = G_B6_1;
			goto IL_0050;
		}
		G_B7_0 = L_13;
		G_B7_1 = G_B6_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_14 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S32;
		RuntimeObject* L_15 = L_14;
		if (L_15)
		{
			G_B9_0 = L_15;
			G_B9_1 = G_B7_1;
			goto IL_0050;
		}
		G_B8_0 = L_15;
		G_B8_1 = G_B7_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_16 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S64;
		G_B9_0 = L_16;
		G_B9_1 = G_B8_1;
	}

IL_0050:
	{
		*((RuntimeObject**)G_B9_1) = (RuntimeObject*)G_B9_0;
		Il2CppCodeGenWriteBarrier((void**)(RuntimeObject**)G_B9_1, (void*)(RuntimeObject*)G_B9_0);
		RuntimeObject** L_17 = ___1_decoder;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_18 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM32;
		RuntimeObject* L_19 = L_18;
		if (L_19)
		{
			G_B17_0 = L_19;
			G_B17_1 = L_17;
			goto IL_0096;
		}
		G_B10_0 = L_19;
		G_B10_1 = L_17;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_20 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM64;
		RuntimeObject* L_21 = L_20;
		if (L_21)
		{
			G_B17_0 = L_21;
			G_B17_1 = G_B10_1;
			goto IL_0096;
		}
		G_B11_0 = L_21;
		G_B11_1 = G_B10_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_22 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC64;
		RuntimeObject* L_23 = L_22;
		if (L_23)
		{
			G_B17_0 = L_23;
			G_B17_1 = G_B11_1;
			goto IL_0096;
		}
		G_B12_0 = L_23;
		G_B12_1 = G_B11_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_24 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC32;
		RuntimeObject* L_25 = L_24;
		if (L_25)
		{
			G_B17_0 = L_25;
			G_B17_1 = G_B12_1;
			goto IL_0096;
		}
		G_B13_0 = L_25;
		G_B13_1 = G_B12_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_26 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N64;
		RuntimeObject* L_27 = L_26;
		if (L_27)
		{
			G_B17_0 = L_27;
			G_B17_1 = G_B13_1;
			goto IL_0096;
		}
		G_B14_0 = L_27;
		G_B14_1 = G_B13_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_28 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N32;
		RuntimeObject* L_29 = L_28;
		if (L_29)
		{
			G_B17_0 = L_29;
			G_B17_1 = G_B14_1;
			goto IL_0096;
		}
		G_B15_0 = L_29;
		G_B15_1 = G_B14_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_30 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S64;
		RuntimeObject* L_31 = L_30;
		if (L_31)
		{
			G_B17_0 = L_31;
			G_B17_1 = G_B15_1;
			goto IL_0096;
		}
		G_B16_0 = L_31;
		G_B16_1 = G_B15_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_32 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S32;
		G_B17_0 = L_32;
		G_B17_1 = G_B16_1;
	}

IL_0096:
	{
		*((RuntimeObject**)G_B17_1) = (RuntimeObject*)G_B17_0;
		Il2CppCodeGenWriteBarrier((void**)(RuntimeObject**)G_B17_1, (void*)(RuntimeObject*)G_B17_0);
		RuntimeObject** L_33 = ___2_encoderHC;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_34 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM32;
		RuntimeObject* L_35 = L_34;
		if (L_35)
		{
			G_B25_0 = L_35;
			G_B25_1 = L_33;
			goto IL_00dc;
		}
		G_B18_0 = L_35;
		G_B18_1 = L_33;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_36 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM64;
		RuntimeObject* L_37 = L_36;
		if (L_37)
		{
			G_B25_0 = L_37;
			G_B25_1 = G_B18_1;
			goto IL_00dc;
		}
		G_B19_0 = L_37;
		G_B19_1 = G_B18_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_38 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N32;
		RuntimeObject* L_39 = L_38;
		if (L_39)
		{
			G_B25_0 = L_39;
			G_B25_1 = G_B19_1;
			goto IL_00dc;
		}
		G_B20_0 = L_39;
		G_B20_1 = G_B19_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_40 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC32;
		RuntimeObject* L_41 = L_40;
		if (L_41)
		{
			G_B25_0 = L_41;
			G_B25_1 = G_B20_1;
			goto IL_00dc;
		}
		G_B21_0 = L_41;
		G_B21_1 = G_B20_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_42 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N64;
		RuntimeObject* L_43 = L_42;
		if (L_43)
		{
			G_B25_0 = L_43;
			G_B25_1 = G_B21_1;
			goto IL_00dc;
		}
		G_B22_0 = L_43;
		G_B22_1 = G_B21_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_44 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC64;
		RuntimeObject* L_45 = L_44;
		if (L_45)
		{
			G_B25_0 = L_45;
			G_B25_1 = G_B22_1;
			goto IL_00dc;
		}
		G_B23_0 = L_45;
		G_B23_1 = G_B22_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_46 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S32;
		RuntimeObject* L_47 = L_46;
		if (L_47)
		{
			G_B25_0 = L_47;
			G_B25_1 = G_B23_1;
			goto IL_00dc;
		}
		G_B24_0 = L_47;
		G_B24_1 = G_B23_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_48 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S64;
		G_B25_0 = L_48;
		G_B25_1 = G_B24_1;
	}

IL_00dc:
	{
		*((RuntimeObject**)G_B25_1) = (RuntimeObject*)G_B25_0;
		Il2CppCodeGenWriteBarrier((void**)(RuntimeObject**)G_B25_1, (void*)(RuntimeObject*)G_B25_0);
		return;
	}

IL_00de:
	{
		RuntimeObject** L_49 = ___0_encoder;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_50 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM64;
		RuntimeObject* L_51 = L_50;
		if (L_51)
		{
			G_B34_0 = L_51;
			G_B34_1 = L_49;
			goto IL_0123;
		}
		G_B27_0 = L_51;
		G_B27_1 = L_49;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_52 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM32;
		RuntimeObject* L_53 = L_52;
		if (L_53)
		{
			G_B34_0 = L_53;
			G_B34_1 = G_B27_1;
			goto IL_0123;
		}
		G_B28_0 = L_53;
		G_B28_1 = G_B27_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_54 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N64;
		RuntimeObject* L_55 = L_54;
		if (L_55)
		{
			G_B34_0 = L_55;
			G_B34_1 = G_B28_1;
			goto IL_0123;
		}
		G_B29_0 = L_55;
		G_B29_1 = G_B28_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_56 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N32;
		RuntimeObject* L_57 = L_56;
		if (L_57)
		{
			G_B34_0 = L_57;
			G_B34_1 = G_B29_1;
			goto IL_0123;
		}
		G_B30_0 = L_57;
		G_B30_1 = G_B29_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_58 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC64;
		RuntimeObject* L_59 = L_58;
		if (L_59)
		{
			G_B34_0 = L_59;
			G_B34_1 = G_B30_1;
			goto IL_0123;
		}
		G_B31_0 = L_59;
		G_B31_1 = G_B30_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_60 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC32;
		RuntimeObject* L_61 = L_60;
		if (L_61)
		{
			G_B34_0 = L_61;
			G_B34_1 = G_B31_1;
			goto IL_0123;
		}
		G_B32_0 = L_61;
		G_B32_1 = G_B31_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_62 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S32;
		RuntimeObject* L_63 = L_62;
		if (L_63)
		{
			G_B34_0 = L_63;
			G_B34_1 = G_B32_1;
			goto IL_0123;
		}
		G_B33_0 = L_63;
		G_B33_1 = G_B32_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_64 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S64;
		G_B34_0 = L_64;
		G_B34_1 = G_B33_1;
	}

IL_0123:
	{
		*((RuntimeObject**)G_B34_1) = (RuntimeObject*)G_B34_0;
		Il2CppCodeGenWriteBarrier((void**)(RuntimeObject**)G_B34_1, (void*)(RuntimeObject*)G_B34_0);
		RuntimeObject** L_65 = ___1_decoder;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_66 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM64;
		RuntimeObject* L_67 = L_66;
		if (L_67)
		{
			G_B42_0 = L_67;
			G_B42_1 = L_65;
			goto IL_0169;
		}
		G_B35_0 = L_67;
		G_B35_1 = L_65;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_68 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N64;
		RuntimeObject* L_69 = L_68;
		if (L_69)
		{
			G_B42_0 = L_69;
			G_B42_1 = G_B35_1;
			goto IL_0169;
		}
		G_B36_0 = L_69;
		G_B36_1 = G_B35_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_70 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N32;
		RuntimeObject* L_71 = L_70;
		if (L_71)
		{
			G_B42_0 = L_71;
			G_B42_1 = G_B36_1;
			goto IL_0169;
		}
		G_B37_0 = L_71;
		G_B37_1 = G_B36_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_72 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC64;
		RuntimeObject* L_73 = L_72;
		if (L_73)
		{
			G_B42_0 = L_73;
			G_B42_1 = G_B37_1;
			goto IL_0169;
		}
		G_B38_0 = L_73;
		G_B38_1 = G_B37_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_74 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM32;
		RuntimeObject* L_75 = L_74;
		if (L_75)
		{
			G_B42_0 = L_75;
			G_B42_1 = G_B38_1;
			goto IL_0169;
		}
		G_B39_0 = L_75;
		G_B39_1 = G_B38_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_76 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC32;
		RuntimeObject* L_77 = L_76;
		if (L_77)
		{
			G_B42_0 = L_77;
			G_B42_1 = G_B39_1;
			goto IL_0169;
		}
		G_B40_0 = L_77;
		G_B40_1 = G_B39_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_78 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S64;
		RuntimeObject* L_79 = L_78;
		if (L_79)
		{
			G_B42_0 = L_79;
			G_B42_1 = G_B40_1;
			goto IL_0169;
		}
		G_B41_0 = L_79;
		G_B41_1 = G_B40_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_80 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S32;
		G_B42_0 = L_80;
		G_B42_1 = G_B41_1;
	}

IL_0169:
	{
		*((RuntimeObject**)G_B42_1) = (RuntimeObject*)G_B42_0;
		Il2CppCodeGenWriteBarrier((void**)(RuntimeObject**)G_B42_1, (void*)(RuntimeObject*)G_B42_0);
		RuntimeObject** L_81 = ___2_encoderHC;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_82 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM64;
		RuntimeObject* L_83 = L_82;
		if (L_83)
		{
			G_B50_0 = L_83;
			G_B50_1 = L_81;
			goto IL_01af;
		}
		G_B43_0 = L_83;
		G_B43_1 = L_81;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_84 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM32;
		RuntimeObject* L_85 = L_84;
		if (L_85)
		{
			G_B50_0 = L_85;
			G_B50_1 = G_B43_1;
			goto IL_01af;
		}
		G_B44_0 = L_85;
		G_B44_1 = G_B43_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_86 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC32;
		RuntimeObject* L_87 = L_86;
		if (L_87)
		{
			G_B50_0 = L_87;
			G_B50_1 = G_B44_1;
			goto IL_01af;
		}
		G_B45_0 = L_87;
		G_B45_1 = G_B44_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_88 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC64;
		RuntimeObject* L_89 = L_88;
		if (L_89)
		{
			G_B50_0 = L_89;
			G_B50_1 = G_B45_1;
			goto IL_01af;
		}
		G_B46_0 = L_89;
		G_B46_1 = G_B45_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_90 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N32;
		RuntimeObject* L_91 = L_90;
		if (L_91)
		{
			G_B50_0 = L_91;
			G_B50_1 = G_B46_1;
			goto IL_01af;
		}
		G_B47_0 = L_91;
		G_B47_1 = G_B46_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_92 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N64;
		RuntimeObject* L_93 = L_92;
		if (L_93)
		{
			G_B50_0 = L_93;
			G_B50_1 = G_B47_1;
			goto IL_01af;
		}
		G_B48_0 = L_93;
		G_B48_1 = G_B47_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_94 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S32;
		RuntimeObject* L_95 = L_94;
		if (L_95)
		{
			G_B50_0 = L_95;
			G_B50_1 = G_B48_1;
			goto IL_01af;
		}
		G_B49_0 = L_95;
		G_B49_1 = G_B48_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_96 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S64;
		G_B50_0 = L_96;
		G_B50_1 = G_B49_1;
	}

IL_01af:
	{
		*((RuntimeObject**)G_B50_1) = (RuntimeObject*)G_B50_0;
		Il2CppCodeGenWriteBarrier((void**)(RuntimeObject**)G_B50_1, (void*)(RuntimeObject*)G_B50_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* LZ4Codec_AutoTest_m6AE8699B517CD4D26C0F7840F521F63DB8A33B37 (RuntimeObject* ___0_service, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral4B9666A386862724B514C7436163D61E1497067A);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_1 = NULL;
	int32_t V_2 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_3 = NULL;
	int32_t V_4 = 0;
	String_t* V_5 = NULL;
	int32_t V_6 = 0;
	String_t* V_7 = NULL;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_8 = NULL;
	int32_t V_9 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_10 = NULL;
	int32_t V_11 = 0;
	String_t* V_12 = NULL;
	int32_t V_13 = 0;
	String_t* V_14 = NULL;
	{
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_0;
		L_0 = Encoding_get_UTF8_m9FA98A53CE96FD6D02982625C5246DD36C1235C9(NULL);
		NullCheck(L_0);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1;
		L_1 = VirtualFuncInvoker1< ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, String_t* >::Invoke(27, L_0, _stringLiteral4B9666A386862724B514C7436163D61E1497067A);
		V_0 = L_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = V_0;
		NullCheck(L_2);
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		int32_t L_3;
		L_3 = LZ4Codec_MaximumOutputLength_mDAA64101B4C4E6AFD835EDF5175CF6A8B1972126(((int32_t)(((RuntimeArray*)L_2)->max_length)), NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_3);
		V_1 = L_4;
		RuntimeObject* L_5 = ___0_service;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = V_0;
		NullCheck(L_7);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_9 = V_1;
		NullCheck(L_9);
		NullCheck(L_5);
		int32_t L_10;
		L_10 = InterfaceFuncInvoker6< int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(1, ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var, L_5, L_6, 0, ((int32_t)(((RuntimeArray*)L_7)->max_length)), L_8, 0, ((int32_t)(((RuntimeArray*)L_9)->max_length)));
		V_2 = L_10;
		int32_t L_11 = V_2;
		if ((((int32_t)L_11) >= ((int32_t)0)))
		{
			goto IL_0035;
		}
	}
	{
		return (RuntimeObject*)NULL;
	}

IL_0035:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = V_0;
		NullCheck(L_12);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_13 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)((int32_t)(((RuntimeArray*)L_12)->max_length)));
		V_3 = L_13;
		RuntimeObject* L_14 = ___0_service;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_15 = V_1;
		int32_t L_16 = V_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_18 = V_3;
		NullCheck(L_18);
		NullCheck(L_14);
		int32_t L_19;
		L_19 = InterfaceFuncInvoker7< int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, bool >::Invoke(3, ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var, L_14, L_15, 0, L_16, L_17, 0, ((int32_t)(((RuntimeArray*)L_18)->max_length)), (bool)1);
		V_4 = L_19;
		int32_t L_20 = V_4;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_21 = V_0;
		NullCheck(L_21);
		if ((((int32_t)L_20) == ((int32_t)((int32_t)(((RuntimeArray*)L_21)->max_length)))))
		{
			goto IL_0058;
		}
	}
	{
		return (RuntimeObject*)NULL;
	}

IL_0058:
	{
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_22;
		L_22 = Encoding_get_UTF8_m9FA98A53CE96FD6D02982625C5246DD36C1235C9(NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_23 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = V_3;
		NullCheck(L_24);
		NullCheck(L_22);
		String_t* L_25;
		L_25 = VirtualFuncInvoker3< String_t*, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(48, L_22, L_23, 0, ((int32_t)(((RuntimeArray*)L_24)->max_length)));
		V_5 = L_25;
		String_t* L_26 = V_5;
		bool L_27;
		L_27 = String_op_Inequality_m8C940F3CFC42866709D7CA931B3D77B4BE94BCB6(L_26, _stringLiteral4B9666A386862724B514C7436163D61E1497067A, NULL);
		if (!L_27)
		{
			goto IL_0079;
		}
	}
	{
		return (RuntimeObject*)NULL;
	}

IL_0079:
	{
		RuntimeObject* L_28 = ___0_service;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_29 = V_1;
		int32_t L_30 = V_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_31 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_32 = V_3;
		NullCheck(L_32);
		NullCheck(L_28);
		int32_t L_33;
		L_33 = InterfaceFuncInvoker7< int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, bool >::Invoke(3, ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var, L_28, L_29, 0, L_30, L_31, 0, ((int32_t)(((RuntimeArray*)L_32)->max_length)), (bool)0);
		V_6 = L_33;
		int32_t L_34 = V_6;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_35 = V_0;
		NullCheck(L_35);
		if ((((int32_t)L_34) == ((int32_t)((int32_t)(((RuntimeArray*)L_35)->max_length)))))
		{
			goto IL_0093;
		}
	}
	{
		return (RuntimeObject*)NULL;
	}

IL_0093:
	{
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_36;
		L_36 = Encoding_get_UTF8_m9FA98A53CE96FD6D02982625C5246DD36C1235C9(NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_37 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_38 = V_3;
		NullCheck(L_38);
		NullCheck(L_36);
		String_t* L_39;
		L_39 = VirtualFuncInvoker3< String_t*, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(48, L_36, L_37, 0, ((int32_t)(((RuntimeArray*)L_38)->max_length)));
		V_7 = L_39;
		String_t* L_40 = V_7;
		bool L_41;
		L_41 = String_op_Inequality_m8C940F3CFC42866709D7CA931B3D77B4BE94BCB6(L_40, _stringLiteral4B9666A386862724B514C7436163D61E1497067A, NULL);
		if (!L_41)
		{
			goto IL_00b4;
		}
	}
	{
		return (RuntimeObject*)NULL;
	}

IL_00b4:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_42 = V_0;
		NullCheck(L_42);
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		int32_t L_43;
		L_43 = LZ4Codec_MaximumOutputLength_mDAA64101B4C4E6AFD835EDF5175CF6A8B1972126(((int32_t)(((RuntimeArray*)L_42)->max_length)), NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_44 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_43);
		V_8 = L_44;
		RuntimeObject* L_45 = ___0_service;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_46 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_47 = V_0;
		NullCheck(L_47);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_48 = V_8;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_49 = V_8;
		NullCheck(L_49);
		NullCheck(L_45);
		int32_t L_50;
		L_50 = InterfaceFuncInvoker6< int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(2, ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var, L_45, L_46, 0, ((int32_t)(((RuntimeArray*)L_47)->max_length)), L_48, 0, ((int32_t)(((RuntimeArray*)L_49)->max_length)));
		V_9 = L_50;
		int32_t L_51 = V_9;
		if ((((int32_t)L_51) >= ((int32_t)0)))
		{
			goto IL_00de;
		}
	}
	{
		return (RuntimeObject*)NULL;
	}

IL_00de:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_52 = V_0;
		NullCheck(L_52);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_53 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)((int32_t)(((RuntimeArray*)L_52)->max_length)));
		V_10 = L_53;
		RuntimeObject* L_54 = ___0_service;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_55 = V_8;
		int32_t L_56 = V_9;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_57 = V_10;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_58 = V_10;
		NullCheck(L_58);
		NullCheck(L_54);
		int32_t L_59;
		L_59 = InterfaceFuncInvoker7< int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, bool >::Invoke(3, ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var, L_54, L_55, 0, L_56, L_57, 0, ((int32_t)(((RuntimeArray*)L_58)->max_length)), (bool)1);
		V_11 = L_59;
		int32_t L_60 = V_11;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_61 = V_0;
		NullCheck(L_61);
		if ((((int32_t)L_60) == ((int32_t)((int32_t)(((RuntimeArray*)L_61)->max_length)))))
		{
			goto IL_0106;
		}
	}
	{
		return (RuntimeObject*)NULL;
	}

IL_0106:
	{
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_62;
		L_62 = Encoding_get_UTF8_m9FA98A53CE96FD6D02982625C5246DD36C1235C9(NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_63 = V_10;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_64 = V_10;
		NullCheck(L_64);
		NullCheck(L_62);
		String_t* L_65;
		L_65 = VirtualFuncInvoker3< String_t*, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(48, L_62, L_63, 0, ((int32_t)(((RuntimeArray*)L_64)->max_length)));
		V_12 = L_65;
		String_t* L_66 = V_12;
		bool L_67;
		L_67 = String_op_Inequality_m8C940F3CFC42866709D7CA931B3D77B4BE94BCB6(L_66, _stringLiteral4B9666A386862724B514C7436163D61E1497067A, NULL);
		if (!L_67)
		{
			goto IL_0129;
		}
	}
	{
		return (RuntimeObject*)NULL;
	}

IL_0129:
	{
		RuntimeObject* L_68 = ___0_service;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_69 = V_8;
		int32_t L_70 = V_9;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_71 = V_10;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_72 = V_10;
		NullCheck(L_72);
		NullCheck(L_68);
		int32_t L_73;
		L_73 = InterfaceFuncInvoker7< int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, bool >::Invoke(3, ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var, L_68, L_69, 0, L_70, L_71, 0, ((int32_t)(((RuntimeArray*)L_72)->max_length)), (bool)0);
		V_13 = L_73;
		int32_t L_74 = V_13;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_75 = V_0;
		NullCheck(L_75);
		if ((((int32_t)L_74) == ((int32_t)((int32_t)(((RuntimeArray*)L_75)->max_length)))))
		{
			goto IL_0147;
		}
	}
	{
		return (RuntimeObject*)NULL;
	}

IL_0147:
	{
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_76;
		L_76 = Encoding_get_UTF8_m9FA98A53CE96FD6D02982625C5246DD36C1235C9(NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_77 = V_10;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_78 = V_10;
		NullCheck(L_78);
		NullCheck(L_76);
		String_t* L_79;
		L_79 = VirtualFuncInvoker3< String_t*, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(48, L_76, L_77, 0, ((int32_t)(((RuntimeArray*)L_78)->max_length)));
		V_14 = L_79;
		String_t* L_80 = V_14;
		bool L_81;
		L_81 = String_op_Inequality_m8C940F3CFC42866709D7CA931B3D77B4BE94BCB6(L_80, _stringLiteral4B9666A386862724B514C7436163D61E1497067A, NULL);
		if (!L_81)
		{
			goto IL_016a;
		}
	}
	{
		return (RuntimeObject*)NULL;
	}

IL_016a:
	{
		RuntimeObject* L_82 = ___0_service;
		return L_82;
	}
}
IL2CPP_EXTERN_C IL2CPP_NO_INLINE IL2CPP_METHOD_ATTR void LZ4Codec_Try_m1E504E6EBEFF72CC9A684B60A28F776ED921DE85 (Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* ___0_method, const RuntimeMethod* method) 
{
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	try
	{
		Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* L_0 = ___0_method;
		NullCheck(L_0);
		Action_Invoke_m6693C0B4B386A694967A120B24AC4323B2C48405_inline(L_0, NULL);
		goto IL_000b;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&RuntimeObject_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0008;
		}
		throw e;
	}

CATCH_0008:
	{
		RuntimeObject* L_1 = ((RuntimeObject*)IL2CPP_GET_ACTIVE_EXCEPTION(RuntimeObject*));;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_000b;
	}

IL_000b:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* LZ4Codec_get_CodecName_mBB6F57A64D6266F17AC327C3513AF742BBDA9AA1 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralF9204BE5A412814B29E1EAA785E472800DE24BDF);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralF94AA613862F53AAD0F034DAF760AFDD9509B693);
		s_Il2CppMethodInitialized = true;
	}
	String_t* G_B2_0 = NULL;
	String_t* G_B1_0 = NULL;
	String_t* G_B3_0 = NULL;
	String_t* G_B3_1 = NULL;
	String_t* G_B5_0 = NULL;
	String_t* G_B5_1 = NULL;
	String_t* G_B4_0 = NULL;
	String_t* G_B4_1 = NULL;
	String_t* G_B6_0 = NULL;
	String_t* G_B6_1 = NULL;
	String_t* G_B6_2 = NULL;
	String_t* G_B8_0 = NULL;
	String_t* G_B8_1 = NULL;
	String_t* G_B8_2 = NULL;
	String_t* G_B7_0 = NULL;
	String_t* G_B7_1 = NULL;
	String_t* G_B7_2 = NULL;
	String_t* G_B9_0 = NULL;
	String_t* G_B9_1 = NULL;
	String_t* G_B9_2 = NULL;
	String_t* G_B9_3 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___Encoder;
		if (!L_0)
		{
			G_B2_0 = _stringLiteralF9204BE5A412814B29E1EAA785E472800DE24BDF;
			goto IL_0018;
		}
		G_B1_0 = _stringLiteralF9204BE5A412814B29E1EAA785E472800DE24BDF;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_1 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___Encoder;
		NullCheck(L_1);
		String_t* L_2;
		L_2 = InterfaceFuncInvoker0< String_t* >::Invoke(0, ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var, L_1);
		G_B3_0 = L_2;
		G_B3_1 = G_B1_0;
		goto IL_001d;
	}

IL_0018:
	{
		G_B3_0 = _stringLiteralF94AA613862F53AAD0F034DAF760AFDD9509B693;
		G_B3_1 = G_B2_0;
	}

IL_001d:
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_3 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___Decoder;
		if (!L_3)
		{
			G_B5_0 = G_B3_0;
			G_B5_1 = G_B3_1;
			goto IL_0030;
		}
		G_B4_0 = G_B3_0;
		G_B4_1 = G_B3_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_4 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___Decoder;
		NullCheck(L_4);
		String_t* L_5;
		L_5 = InterfaceFuncInvoker0< String_t* >::Invoke(0, ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var, L_4);
		G_B6_0 = L_5;
		G_B6_1 = G_B4_0;
		G_B6_2 = G_B4_1;
		goto IL_0035;
	}

IL_0030:
	{
		G_B6_0 = _stringLiteralF94AA613862F53AAD0F034DAF760AFDD9509B693;
		G_B6_1 = G_B5_0;
		G_B6_2 = G_B5_1;
	}

IL_0035:
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_6 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___EncoderHC;
		if (!L_6)
		{
			G_B8_0 = G_B6_0;
			G_B8_1 = G_B6_1;
			G_B8_2 = G_B6_2;
			goto IL_0048;
		}
		G_B7_0 = G_B6_0;
		G_B7_1 = G_B6_1;
		G_B7_2 = G_B6_2;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_7 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___EncoderHC;
		NullCheck(L_7);
		String_t* L_8;
		L_8 = InterfaceFuncInvoker0< String_t* >::Invoke(0, ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var, L_7);
		G_B9_0 = L_8;
		G_B9_1 = G_B7_0;
		G_B9_2 = G_B7_1;
		G_B9_3 = G_B7_2;
		goto IL_004d;
	}

IL_0048:
	{
		G_B9_0 = _stringLiteralF94AA613862F53AAD0F034DAF760AFDD9509B693;
		G_B9_1 = G_B8_0;
		G_B9_2 = G_B8_1;
		G_B9_3 = G_B8_2;
	}

IL_004d:
	{
		String_t* L_9;
		L_9 = String_Format_mA0534D6E2AE4D67A6BD8D45B3321323930EB930C(G_B9_3, G_B9_2, G_B9_1, G_B9_0, NULL);
		return L_9;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_MaximumOutputLength_mDAA64101B4C4E6AFD835EDF5175CF6A8B1972126 (int32_t ___0_inputLength, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_inputLength;
		int32_t L_1 = ___0_inputLength;
		return ((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_0, ((int32_t)(L_1/((int32_t)255))))), ((int32_t)16)));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Encode_m95700861B517937C3B5CC74DCA9CA8002E2BB12B (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___Encoder;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___0_input;
		int32_t L_2 = ___1_inputOffset;
		int32_t L_3 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = ___3_output;
		int32_t L_5 = ___4_outputOffset;
		int32_t L_6 = ___5_outputLength;
		NullCheck(L_0);
		int32_t L_7;
		L_7 = InterfaceFuncInvoker6< int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(1, ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var, L_0, L_1, L_2, L_3, L_4, L_5, L_6);
		return L_7;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* LZ4Codec_Encode_m4AA8DA0B60EA929B5CBD5C2F044523CBDE939855 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	int32_t V_1 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_2 = NULL;
	{
		int32_t L_0 = ___2_inputLength;
		if ((((int32_t)L_0) >= ((int32_t)0)))
		{
			goto IL_000b;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___0_input;
		NullCheck(L_1);
		int32_t L_2 = ___1_inputOffset;
		___2_inputLength = ((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_1)->max_length)), L_2));
	}

IL_000b:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___0_input;
		if (L_3)
		{
			goto IL_0019;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_4 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral15088A7C50E83E49058833A4287B3C2F1CD730D2)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Encode_m4AA8DA0B60EA929B5CBD5C2F044523CBDE939855_RuntimeMethod_var)));
	}

IL_0019:
	{
		int32_t L_5 = ___1_inputOffset;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_0025;
		}
	}
	{
		int32_t L_6 = ___1_inputOffset;
		int32_t L_7 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_input;
		NullCheck(L_8);
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_6, L_7))) <= ((int32_t)((int32_t)(((RuntimeArray*)L_8)->max_length)))))
		{
			goto IL_0030;
		}
	}

IL_0025:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_9 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_9, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralB0DC6E48DD877538156865D4EC4FE974175E5766)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_9, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Encode_m4AA8DA0B60EA929B5CBD5C2F044523CBDE939855_RuntimeMethod_var)));
	}

IL_0030:
	{
		int32_t L_10 = ___2_inputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		int32_t L_11;
		L_11 = LZ4Codec_MaximumOutputLength_mDAA64101B4C4E6AFD835EDF5175CF6A8B1972126(L_10, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_11);
		V_0 = L_12;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_13 = ___0_input;
		int32_t L_14 = ___1_inputOffset;
		int32_t L_15 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = V_0;
		NullCheck(L_17);
		int32_t L_18;
		L_18 = LZ4Codec_Encode_m95700861B517937C3B5CC74DCA9CA8002E2BB12B(L_13, L_14, L_15, L_16, 0, ((int32_t)(((RuntimeArray*)L_17)->max_length)), NULL);
		V_1 = L_18;
		int32_t L_19 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_20 = V_0;
		NullCheck(L_20);
		if ((((int32_t)L_19) == ((int32_t)((int32_t)(((RuntimeArray*)L_20)->max_length)))))
		{
			goto IL_0072;
		}
	}
	{
		int32_t L_21 = V_1;
		if ((((int32_t)L_21) >= ((int32_t)0)))
		{
			goto IL_005f;
		}
	}
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_22 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_22, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral22562BDC01CC82A45F171035D855E64E7772E317)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_22, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Encode_m4AA8DA0B60EA929B5CBD5C2F044523CBDE939855_RuntimeMethod_var)));
	}

IL_005f:
	{
		int32_t L_23 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_23);
		V_2 = L_24;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_25 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_26 = V_2;
		int32_t L_27 = V_1;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_25, 0, (RuntimeArray*)L_26, 0, L_27, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_28 = V_2;
		return L_28;
	}

IL_0072:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_29 = V_0;
		return L_29;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_EncodeHC_m462A61B698E8E2B338A0332DA00FB64EBFC8F82C (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject* G_B2_0 = NULL;
	RuntimeObject* G_B1_0 = NULL;
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___EncoderHC;
		RuntimeObject* L_1 = L_0;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_000e;
		}
		G_B1_0 = L_1;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_2 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___Encoder;
		G_B2_0 = L_2;
	}

IL_000e:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___0_input;
		int32_t L_4 = ___1_inputOffset;
		int32_t L_5 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = ___3_output;
		int32_t L_7 = ___4_outputOffset;
		int32_t L_8 = ___5_outputLength;
		NullCheck(G_B2_0);
		int32_t L_9;
		L_9 = InterfaceFuncInvoker6< int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(2, ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var, G_B2_0, L_3, L_4, L_5, L_6, L_7, L_8);
		return L_9;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* LZ4Codec_EncodeHC_mC95383E6688E960B92088BF0B02885BC02E753A7 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	int32_t V_1 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_2 = NULL;
	{
		int32_t L_0 = ___2_inputLength;
		if ((((int32_t)L_0) >= ((int32_t)0)))
		{
			goto IL_000b;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___0_input;
		NullCheck(L_1);
		int32_t L_2 = ___1_inputOffset;
		___2_inputLength = ((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_1)->max_length)), L_2));
	}

IL_000b:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___0_input;
		if (L_3)
		{
			goto IL_0019;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_4 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral15088A7C50E83E49058833A4287B3C2F1CD730D2)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_EncodeHC_mC95383E6688E960B92088BF0B02885BC02E753A7_RuntimeMethod_var)));
	}

IL_0019:
	{
		int32_t L_5 = ___1_inputOffset;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_0025;
		}
	}
	{
		int32_t L_6 = ___1_inputOffset;
		int32_t L_7 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_input;
		NullCheck(L_8);
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_6, L_7))) <= ((int32_t)((int32_t)(((RuntimeArray*)L_8)->max_length)))))
		{
			goto IL_0030;
		}
	}

IL_0025:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_9 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_9, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralB0DC6E48DD877538156865D4EC4FE974175E5766)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_9, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_EncodeHC_mC95383E6688E960B92088BF0B02885BC02E753A7_RuntimeMethod_var)));
	}

IL_0030:
	{
		int32_t L_10 = ___2_inputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		int32_t L_11;
		L_11 = LZ4Codec_MaximumOutputLength_mDAA64101B4C4E6AFD835EDF5175CF6A8B1972126(L_10, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_11);
		V_0 = L_12;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_13 = ___0_input;
		int32_t L_14 = ___1_inputOffset;
		int32_t L_15 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = V_0;
		NullCheck(L_17);
		int32_t L_18;
		L_18 = LZ4Codec_EncodeHC_m462A61B698E8E2B338A0332DA00FB64EBFC8F82C(L_13, L_14, L_15, L_16, 0, ((int32_t)(((RuntimeArray*)L_17)->max_length)), NULL);
		V_1 = L_18;
		int32_t L_19 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_20 = V_0;
		NullCheck(L_20);
		if ((((int32_t)L_19) == ((int32_t)((int32_t)(((RuntimeArray*)L_20)->max_length)))))
		{
			goto IL_0072;
		}
	}
	{
		int32_t L_21 = V_1;
		if ((((int32_t)L_21) >= ((int32_t)0)))
		{
			goto IL_005f;
		}
	}
	{
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_22 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_22, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral22562BDC01CC82A45F171035D855E64E7772E317)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_22, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_EncodeHC_mC95383E6688E960B92088BF0B02885BC02E753A7_RuntimeMethod_var)));
	}

IL_005f:
	{
		int32_t L_23 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_23);
		V_2 = L_24;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_25 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_26 = V_2;
		int32_t L_27 = V_1;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_25, 0, (RuntimeArray*)L_26, 0, L_27, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_28 = V_2;
		return L_28;
	}

IL_0072:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_29 = V_0;
		return L_29;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Codec_Decode_m9A778AF80843CC473CB2DC1E68F04451742071B9 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, bool ___6_knownOutputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->___Decoder;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___0_input;
		int32_t L_2 = ___1_inputOffset;
		int32_t L_3 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = ___3_output;
		int32_t L_5 = ___4_outputOffset;
		int32_t L_6 = ___5_outputLength;
		bool L_7 = ___6_knownOutputLength;
		NullCheck(L_0);
		int32_t L_8;
		L_8 = InterfaceFuncInvoker7< int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, bool >::Invoke(3, ILZ4Service_tABBD1488E499A617EDC3025A793BE61D2ABB9E50_il2cpp_TypeInfo_var, L_0, L_1, L_2, L_3, L_4, L_5, L_6, L_7);
		return L_8;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* LZ4Codec_Decode_m775B077FBCADC4FDFFE1FF5ED79B76897449517C (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, int32_t ___3_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	int32_t V_1 = 0;
	{
		int32_t L_0 = ___2_inputLength;
		if ((((int32_t)L_0) >= ((int32_t)0)))
		{
			goto IL_000b;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___0_input;
		NullCheck(L_1);
		int32_t L_2 = ___1_inputOffset;
		___2_inputLength = ((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_1)->max_length)), L_2));
	}

IL_000b:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___0_input;
		if (L_3)
		{
			goto IL_0019;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_4 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_4, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral15088A7C50E83E49058833A4287B3C2F1CD730D2)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_4, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Decode_m775B077FBCADC4FDFFE1FF5ED79B76897449517C_RuntimeMethod_var)));
	}

IL_0019:
	{
		int32_t L_5 = ___1_inputOffset;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_0025;
		}
	}
	{
		int32_t L_6 = ___1_inputOffset;
		int32_t L_7 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_input;
		NullCheck(L_8);
		if ((((int32_t)((int32_t)il2cpp_codegen_add(L_6, L_7))) <= ((int32_t)((int32_t)(((RuntimeArray*)L_8)->max_length)))))
		{
			goto IL_0030;
		}
	}

IL_0025:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_9 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_9, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralB0DC6E48DD877538156865D4EC4FE974175E5766)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_9, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Decode_m775B077FBCADC4FDFFE1FF5ED79B76897449517C_RuntimeMethod_var)));
	}

IL_0030:
	{
		int32_t L_10 = ___3_outputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_11 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_10);
		V_0 = L_11;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___0_input;
		int32_t L_13 = ___1_inputOffset;
		int32_t L_14 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_15 = V_0;
		int32_t L_16 = ___3_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		int32_t L_17;
		L_17 = LZ4Codec_Decode_m9A778AF80843CC473CB2DC1E68F04451742071B9(L_12, L_13, L_14, L_15, 0, L_16, (bool)1, NULL);
		V_1 = L_17;
		int32_t L_18 = V_1;
		int32_t L_19 = ___3_outputLength;
		if ((((int32_t)L_18) == ((int32_t)L_19)))
		{
			goto IL_0053;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_20 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_20, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralD2022A52A84F41328946F27774BA456C970BB16D)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_20, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Decode_m775B077FBCADC4FDFFE1FF5ED79B76897449517C_RuntimeMethod_var)));
	}

IL_0053:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_21 = V_0;
		return L_21;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_Poke4_m12CBAC9FD91CA8B3B8BDD99AEE3BFF145843F2B6 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset, uint32_t ___2_value, const RuntimeMethod* method) 
{
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_buffer;
		int32_t L_1 = ___1_offset;
		uint32_t L_2 = ___2_value;
		NullCheck(L_0);
		(L_0)->SetAt(static_cast<il2cpp_array_size_t>(L_1), (uint8_t)((int32_t)(uint8_t)L_2));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___0_buffer;
		int32_t L_4 = ___1_offset;
		uint32_t L_5 = ___2_value;
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_4, 1))), (uint8_t)((int32_t)(uint8_t)((int32_t)((uint32_t)L_5>>8))));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = ___0_buffer;
		int32_t L_7 = ___1_offset;
		uint32_t L_8 = ___2_value;
		NullCheck(L_6);
		(L_6)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_7, 2))), (uint8_t)((int32_t)(uint8_t)((int32_t)((uint32_t)L_8>>((int32_t)16)))));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_9 = ___0_buffer;
		int32_t L_10 = ___1_offset;
		uint32_t L_11 = ___2_value;
		NullCheck(L_9);
		(L_9)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_10, 3))), (uint8_t)((int32_t)(uint8_t)((int32_t)((uint32_t)L_11>>((int32_t)24)))));
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t LZ4Codec_Peek4_m5F02DCE552F8A75D8DBE3861ACA4FD73438F1D40 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset, const RuntimeMethod* method) 
{
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_buffer;
		int32_t L_1 = ___1_offset;
		NullCheck(L_0);
		int32_t L_2 = L_1;
		uint8_t L_3 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = ___0_buffer;
		int32_t L_5 = ___1_offset;
		NullCheck(L_4);
		int32_t L_6 = ((int32_t)il2cpp_codegen_add(L_5, 1));
		uint8_t L_7 = (L_4)->GetAt(static_cast<il2cpp_array_size_t>(L_6));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___0_buffer;
		int32_t L_9 = ___1_offset;
		NullCheck(L_8);
		int32_t L_10 = ((int32_t)il2cpp_codegen_add(L_9, 2));
		uint8_t L_11 = (L_8)->GetAt(static_cast<il2cpp_array_size_t>(L_10));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___0_buffer;
		int32_t L_13 = ___1_offset;
		NullCheck(L_12);
		int32_t L_14 = ((int32_t)il2cpp_codegen_add(L_13, 3));
		uint8_t L_15 = (L_12)->GetAt(static_cast<il2cpp_array_size_t>(L_14));
		return ((int32_t)(((int32_t)(((int32_t)((int32_t)L_3|((int32_t)((int32_t)L_7<<8))))|((int32_t)((int32_t)L_11<<((int32_t)16)))))|((int32_t)((int32_t)L_15<<((int32_t)24)))));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* LZ4Codec_Wrap_m98B72AEB25379FC783BFD660A218720C91D3E73B (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_inputBuffer, int32_t ___1_inputOffset, int32_t ___2_inputLength, bool ___3_highCompression, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_1 = NULL;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_2 = NULL;
	int32_t G_B7_0 = 0;
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_inputBuffer;
		NullCheck(L_0);
		int32_t L_1 = ___1_inputOffset;
		int32_t L_2 = ___2_inputLength;
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		int32_t L_3;
		L_3 = Math_Min_m53C488772A34D53917BCA2A491E79A0A5356ED52(((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_0)->max_length)), L_1)), L_2, NULL);
		___2_inputLength = L_3;
		int32_t L_4 = ___2_inputLength;
		if ((((int32_t)L_4) >= ((int32_t)0)))
		{
			goto IL_001c;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_5 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_5, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralAFF7EC42D2B43A4238039905BC7A17628F5DE772)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_5, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Wrap_m98B72AEB25379FC783BFD660A218720C91D3E73B_RuntimeMethod_var)));
	}

IL_001c:
	{
		int32_t L_6 = ___2_inputLength;
		if (L_6)
		{
			goto IL_0026;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)8);
		return L_7;
	}

IL_0026:
	{
		int32_t L_8 = ___2_inputLength;
		V_0 = L_8;
		int32_t L_9 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_10 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_9);
		V_1 = L_10;
		bool L_11 = ___3_highCompression;
		if (L_11)
		{
			goto IL_003f;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___0_inputBuffer;
		int32_t L_13 = ___1_inputOffset;
		int32_t L_14 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_15 = V_1;
		int32_t L_16 = V_0;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		int32_t L_17;
		L_17 = LZ4Codec_Encode_m95700861B517937C3B5CC74DCA9CA8002E2BB12B(L_12, L_13, L_14, L_15, 0, L_16, NULL);
		G_B7_0 = L_17;
		goto IL_004a;
	}

IL_003f:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_18 = ___0_inputBuffer;
		int32_t L_19 = ___1_inputOffset;
		int32_t L_20 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_21 = V_1;
		int32_t L_22 = V_0;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		int32_t L_23;
		L_23 = LZ4Codec_EncodeHC_m462A61B698E8E2B338A0332DA00FB64EBFC8F82C(L_18, L_19, L_20, L_21, 0, L_22, NULL);
		G_B7_0 = L_23;
	}

IL_004a:
	{
		V_0 = G_B7_0;
		int32_t L_24 = V_0;
		int32_t L_25 = ___2_inputLength;
		if ((((int32_t)L_24) >= ((int32_t)L_25)))
		{
			goto IL_0053;
		}
	}
	{
		int32_t L_26 = V_0;
		if ((((int32_t)L_26) > ((int32_t)0)))
		{
			goto IL_0078;
		}
	}

IL_0053:
	{
		int32_t L_27 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_28 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)((int32_t)il2cpp_codegen_add(L_27, 8)));
		V_2 = L_28;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_29 = V_2;
		int32_t L_30 = ___2_inputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		LZ4Codec_Poke4_m12CBAC9FD91CA8B3B8BDD99AEE3BFF145843F2B6(L_29, 0, L_30, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_31 = V_2;
		int32_t L_32 = ___2_inputLength;
		LZ4Codec_Poke4_m12CBAC9FD91CA8B3B8BDD99AEE3BFF145843F2B6(L_31, 4, L_32, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_33 = ___0_inputBuffer;
		int32_t L_34 = ___1_inputOffset;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_35 = V_2;
		int32_t L_36 = ___2_inputLength;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_33, L_34, (RuntimeArray*)L_35, 8, L_36, NULL);
		goto IL_009b;
	}

IL_0078:
	{
		int32_t L_37 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_38 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)((int32_t)il2cpp_codegen_add(L_37, 8)));
		V_2 = L_38;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_39 = V_2;
		int32_t L_40 = ___2_inputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		LZ4Codec_Poke4_m12CBAC9FD91CA8B3B8BDD99AEE3BFF145843F2B6(L_39, 0, L_40, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_41 = V_2;
		int32_t L_42 = V_0;
		LZ4Codec_Poke4_m12CBAC9FD91CA8B3B8BDD99AEE3BFF145843F2B6(L_41, 4, L_42, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_43 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_44 = V_2;
		int32_t L_45 = V_0;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_43, 0, (RuntimeArray*)L_44, 8, L_45, NULL);
	}

IL_009b:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_46 = V_2;
		return L_46;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* LZ4Codec_Wrap_mC6D114AFD4A924EADB354FD0BF853844746645FC (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_inputBuffer, int32_t ___1_inputOffset, int32_t ___2_inputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_inputBuffer;
		int32_t L_1 = ___1_inputOffset;
		int32_t L_2 = ___2_inputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3;
		L_3 = LZ4Codec_Wrap_m98B72AEB25379FC783BFD660A218720C91D3E73B(L_0, L_1, L_2, (bool)0, NULL);
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* LZ4Codec_WrapHC_mE575F479EEB15C7B57B0CB7E7187ACCEAA78CC9A (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_inputBuffer, int32_t ___1_inputOffset, int32_t ___2_inputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_inputBuffer;
		int32_t L_1 = ___1_inputOffset;
		int32_t L_2 = ___2_inputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3;
		L_3 = LZ4Codec_Wrap_m98B72AEB25379FC783BFD660A218720C91D3E73B(L_0, L_1, L_2, (bool)1, NULL);
		return L_3;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* LZ4Codec_Unwrap_m18EAB28CE68D7548D67DE8DF353468B7AF271C94 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_inputBuffer, int32_t ___1_inputOffset, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_2 = NULL;
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_inputBuffer;
		NullCheck(L_0);
		int32_t L_1 = ___1_inputOffset;
		V_0 = ((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_0)->max_length)), L_1));
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) >= ((int32_t)8)))
		{
			goto IL_0015;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_3 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_3, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral5F400FF009A7EE014B6122DA67077EC44B887858)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_3, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Unwrap_m18EAB28CE68D7548D67DE8DF353468B7AF271C94_RuntimeMethod_var)));
	}

IL_0015:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = ___0_inputBuffer;
		int32_t L_5 = ___1_inputOffset;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		uint32_t L_6;
		L_6 = LZ4Codec_Peek4_m5F02DCE552F8A75D8DBE3861ACA4FD73438F1D40(L_4, L_5, NULL);
		V_1 = L_6;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = ___0_inputBuffer;
		int32_t L_8 = ___1_inputOffset;
		uint32_t L_9;
		L_9 = LZ4Codec_Peek4_m5F02DCE552F8A75D8DBE3861ACA4FD73438F1D40(L_7, ((int32_t)il2cpp_codegen_add(L_8, 4)), NULL);
		V_0 = L_9;
		int32_t L_10 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_11 = ___0_inputBuffer;
		NullCheck(L_11);
		int32_t L_12 = ___1_inputOffset;
		if ((((int32_t)L_10) <= ((int32_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_11)->max_length)), L_12)), 8)))))
		{
			goto IL_003c;
		}
	}
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_13 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_13, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralA620EDDDF34131E84DF5BB1E5EF8EE3294176550)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_13, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Codec_Unwrap_m18EAB28CE68D7548D67DE8DF353468B7AF271C94_RuntimeMethod_var)));
	}

IL_003c:
	{
		int32_t L_14 = V_0;
		int32_t L_15 = V_1;
		if ((((int32_t)L_14) < ((int32_t)L_15)))
		{
			goto IL_0055;
		}
	}
	{
		int32_t L_16 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_16);
		V_2 = L_17;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_18 = ___0_inputBuffer;
		int32_t L_19 = ___1_inputOffset;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_20 = V_2;
		int32_t L_21 = V_0;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_18, ((int32_t)il2cpp_codegen_add(L_19, 8)), (RuntimeArray*)L_20, 0, L_21, NULL);
		goto IL_006b;
	}

IL_0055:
	{
		int32_t L_22 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_23 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_22);
		V_2 = L_23;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_24 = ___0_inputBuffer;
		int32_t L_25 = ___1_inputOffset;
		int32_t L_26 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_27 = V_2;
		int32_t L_28 = V_1;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		int32_t L_29;
		L_29 = LZ4Codec_Decode_m9A778AF80843CC473CB2DC1E68F04451742071B9(L_24, ((int32_t)il2cpp_codegen_add(L_25, 8)), L_26, L_27, 0, L_28, (bool)1, NULL);
	}

IL_006b:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_30 = V_2;
		return L_30;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LZ4Codec_Has2010Runtime_m12032B2FFCBBBA3FEF01C4EE988B1A4A1C0BE3F0 (const RuntimeMethod* method) 
{
	{
		return (bool)0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_InitializeLZ4mm_m14C1305C69ACB9B663D07A8CFE4FEED4204F6130 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM64 = (RuntimeObject*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM64), (void*)(RuntimeObject*)NULL);
		((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM32 = (RuntimeObject*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_MM32), (void*)(RuntimeObject*)NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_InitializeLZ4cc_m31E3406932DFA777DF898179A9EC8A39C86A09E3 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC64 = (RuntimeObject*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC64), (void*)(RuntimeObject*)NULL);
		((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC32 = (RuntimeObject*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_CC32), (void*)(RuntimeObject*)NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Codec_InitializeLZ4n_m53DC33F1EDDC538B845072A0321E9CDEF5A6D14A (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N64 = (RuntimeObject*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N64), (void*)(RuntimeObject*)NULL);
		((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N32 = (RuntimeObject*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_N32), (void*)(RuntimeObject*)NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_NO_INLINE IL2CPP_METHOD_ATTR void LZ4Codec_InitializeLZ4s_m4EC9AFFF8DD01160779275C1643D29A882CD5E00 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_TryService_TisSafe32LZ4Service_t6C465065F50F51FE51B7CC5377CC242FFD50D5A5_m289E6121B7096157393CEBA6037EC24C71BE4882_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_TryService_TisSafe64LZ4Service_tB68E69D87E25EA3EFF8D49FB05A091BB50A80F0B_m89CAA0025A8BA51962C72DEC45A6A248F3E23F7B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		RuntimeObject* L_0;
		L_0 = LZ4Codec_TryService_TisSafe32LZ4Service_t6C465065F50F51FE51B7CC5377CC242FFD50D5A5_m289E6121B7096157393CEBA6037EC24C71BE4882(LZ4Codec_TryService_TisSafe32LZ4Service_t6C465065F50F51FE51B7CC5377CC242FFD50D5A5_m289E6121B7096157393CEBA6037EC24C71BE4882_RuntimeMethod_var);
		((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S32 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S32), (void*)L_0);
		RuntimeObject* L_1;
		L_1 = LZ4Codec_TryService_TisSafe64LZ4Service_tB68E69D87E25EA3EFF8D49FB05A091BB50A80F0B_m89CAA0025A8BA51962C72DEC45A6A248F3E23F7B(LZ4Codec_TryService_TisSafe64LZ4Service_tB68E69D87E25EA3EFF8D49FB05A091BB50A80F0B_m89CAA0025A8BA51962C72DEC45A6A248F3E23F7B_RuntimeMethod_var);
		((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S64 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&((LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_StaticFields*)il2cpp_codegen_static_fields_for(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var))->____service_S64), (void*)L_1);
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
void Action_Invoke_m6693C0B4B386A694967A120B24AC4323B2C48405_Multicast(Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* __this, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* currentDelegate = reinterpret_cast<Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl)((Il2CppObject*)currentDelegate->___method_code, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method));
	}
}
void Action_Invoke_m6693C0B4B386A694967A120B24AC4323B2C48405_OpenInst(Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* __this, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr)(method);
}
void Action_Invoke_m6693C0B4B386A694967A120B24AC4323B2C48405_OpenStatic(Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* __this, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr)(method);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97 (Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* __this, const RuntimeMethod* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc)();
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	il2cppPInvokeFunc();

}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action__ctor_mA303A98BFE7D11C2D04A004FD6C69D154B3782FB (Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method) 
{
	__this->___method_ptr = (intptr_t)il2cpp_codegen_get_method_pointer((RuntimeMethod*)___1_method);
	__this->___method = ___1_method;
	__this->___m_target = ___0_object;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target), (void*)___0_object);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___1_method);
	__this->___method_code = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___1_method))
	{
		bool isOpen = parameterCount == 0;
		if (isOpen)
			__this->___invoke_impl = (intptr_t)&Action_Invoke_m6693C0B4B386A694967A120B24AC4323B2C48405_OpenStatic;
		else
			{
				__this->___invoke_impl = __this->___method_ptr;
				__this->___method_code = (intptr_t)__this->___m_target;
			}
	}
	else
	{
		if (___0_object == NULL)
			il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
		__this->___invoke_impl = __this->___method_ptr;
		__this->___method_code = (intptr_t)__this->___m_target;
	}
	__this->___extra_arg = (intptr_t)&Action_Invoke_m6693C0B4B386A694967A120B24AC4323B2C48405_Multicast;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_Invoke_m6693C0B4B386A694967A120B24AC4323B2C48405 (Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* __this, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Action_BeginInvoke_m76DDA5C845BD5114826029EAF0F3F79BFC8511D6 (Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* __this, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___0_callback, RuntimeObject* ___1_object, const RuntimeMethod* method) 
{
	void *__d_args[1] = {0};
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___0_callback, (RuntimeObject*)___1_object);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Action_EndInvoke_mBEFF4C1BCF4E167A73D80AB6917C89604243EDD2 (Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* __this, RuntimeObject* ___0_result, const RuntimeMethod* method) 
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream__ctor_m72C0BCD1E752DAC8D50E7E58A6F2A1737DDBA263 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* ___0_innerStream, int32_t ___1_compressionMode, bool ___2_highCompression, int32_t ___3_blockSize, bool ___4_interactiveRead, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE_il2cpp_TypeInfo_var);
		Stream__ctor_mE8B074A0EBEB026FFF14062AB4B8A78E17EFFBF0(__this, NULL);
		Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* L_0 = ___0_innerStream;
		__this->____innerStream = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____innerStream), (void*)L_0);
		int32_t L_1 = ___1_compressionMode;
		__this->____compressionMode = L_1;
		bool L_2 = ___2_highCompression;
		__this->____highCompression = L_2;
		bool L_3 = ___4_interactiveRead;
		__this->____interactiveRead = L_3;
		__this->____isolateInnerStream = (bool)0;
		int32_t L_4 = ___3_blockSize;
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		int32_t L_5;
		L_5 = Math_Max_m530EBA549AFD98CFC2BD29FE86C6376E67DF11CF(((int32_t)16), L_4, NULL);
		__this->____blockSize = L_5;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream__ctor_m403377F2E66DCB170D98C5518C606FB11AA5AB10 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* ___0_innerStream, int32_t ___1_compressionMode, int32_t ___2_compressionFlags, int32_t ___3_blockSize, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE_il2cpp_TypeInfo_var);
		Stream__ctor_mE8B074A0EBEB026FFF14062AB4B8A78E17EFFBF0(__this, NULL);
		Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* L_0 = ___0_innerStream;
		__this->____innerStream = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____innerStream), (void*)L_0);
		int32_t L_1 = ___1_compressionMode;
		__this->____compressionMode = L_1;
		int32_t L_2 = ___2_compressionFlags;
		__this->____highCompression = (bool)((((int32_t)((((int32_t)((int32_t)((int32_t)L_2&2))) == ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		int32_t L_3 = ___2_compressionFlags;
		__this->____interactiveRead = (bool)((((int32_t)((((int32_t)((int32_t)((int32_t)L_3&1))) == ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		int32_t L_4 = ___2_compressionFlags;
		__this->____isolateInnerStream = (bool)((((int32_t)((((int32_t)((int32_t)((int32_t)L_4&4))) == ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		int32_t L_5 = ___3_blockSize;
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		int32_t L_6;
		L_6 = Math_Max_m530EBA549AFD98CFC2BD29FE86C6376E67DF11CF(((int32_t)16), L_5, NULL);
		__this->____blockSize = L_6;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* LZ4Stream_NotSupported_m65D89ADBD25DB5B852E14AE1D09E5F72B10BBFE3 (String_t* ___0_operationName, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral4ABCE38F42187F9B00C8BCC57A24823C3F0AF438);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = ___0_operationName;
		String_t* L_1;
		L_1 = String_Format_mA8DBB4C2516B9723C5A41E6CB1E2FAF4BBE96DD8(_stringLiteral4ABCE38F42187F9B00C8BCC57A24823C3F0AF438, L_0, NULL);
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_2 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var);
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_2, L_1, NULL);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR EndOfStreamException_t6B6A2609418A69523CBEF305228B18E0E5778028* LZ4Stream_EndOfStream_m868620C08A32DFEB1846D11C8F0E4B2B6D2D4A09 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&EndOfStreamException_t6B6A2609418A69523CBEF305228B18E0E5778028_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral687B0943A9A3524003E9BA508C255E8D60725E9D);
		s_Il2CppMethodInitialized = true;
	}
	{
		EndOfStreamException_t6B6A2609418A69523CBEF305228B18E0E5778028* L_0 = (EndOfStreamException_t6B6A2609418A69523CBEF305228B18E0E5778028*)il2cpp_codegen_object_new(EndOfStreamException_t6B6A2609418A69523CBEF305228B18E0E5778028_il2cpp_TypeInfo_var);
		EndOfStreamException__ctor_m5629E1A514051A3D56052BD6D2D50C054308CCA4(L_0, _stringLiteral687B0943A9A3524003E9BA508C255E8D60725E9D, NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LZ4Stream_TryReadVarInt_m98E1AC815BFD87BCB413B26908D77119B3678F05 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, uint64_t* ___0_result, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	int32_t V_1 = 0;
	uint8_t V_2 = 0x0;
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)1);
		V_0 = L_0;
		V_1 = 0;
		uint64_t* L_1 = ___0_result;
		*((int64_t*)L_1) = (int64_t)((int64_t)0);
	}

IL_000d:
	{
		Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* L_2 = __this->____innerStream;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = V_0;
		NullCheck(L_2);
		int32_t L_4;
		L_4 = VirtualFuncInvoker3< int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(35, L_2, L_3, 0, 1);
		if (L_4)
		{
			goto IL_0028;
		}
	}
	{
		int32_t L_5 = V_1;
		if (L_5)
		{
			goto IL_0022;
		}
	}
	{
		return (bool)0;
	}

IL_0022:
	{
		EndOfStreamException_t6B6A2609418A69523CBEF305228B18E0E5778028* L_6;
		L_6 = LZ4Stream_EndOfStream_m868620C08A32DFEB1846D11C8F0E4B2B6D2D4A09(NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_6, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Stream_TryReadVarInt_m98E1AC815BFD87BCB413B26908D77119B3678F05_RuntimeMethod_var)));
	}

IL_0028:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = V_0;
		NullCheck(L_7);
		int32_t L_8 = 0;
		uint8_t L_9 = (L_7)->GetAt(static_cast<il2cpp_array_size_t>(L_8));
		V_2 = L_9;
		uint64_t* L_10 = ___0_result;
		uint64_t* L_11 = ___0_result;
		int64_t L_12 = *((int64_t*)L_11);
		uint8_t L_13 = V_2;
		int32_t L_14 = V_1;
		*((int64_t*)L_10) = (int64_t)((int64_t)il2cpp_codegen_add(L_12, ((int64_t)(((int64_t)((int32_t)((int32_t)L_13&((int32_t)127))))<<((int32_t)(L_14&((int32_t)63)))))));
		int32_t L_15 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_15, 7));
		uint8_t L_16 = V_2;
		if (!((int32_t)((int32_t)L_16&((int32_t)128))))
		{
			goto IL_004d;
		}
	}
	{
		int32_t L_17 = V_1;
		if ((((int32_t)L_17) < ((int32_t)((int32_t)64))))
		{
			goto IL_000d;
		}
	}

IL_004d:
	{
		return (bool)1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t LZ4Stream_ReadVarInt_m20F01F26A0EA4C2E3B07C4DF304A6F48E09B99BE (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, const RuntimeMethod* method) 
{
	uint64_t V_0 = 0;
	{
		bool L_0;
		L_0 = LZ4Stream_TryReadVarInt_m98E1AC815BFD87BCB413B26908D77119B3678F05(__this, (&V_0), NULL);
		if (L_0)
		{
			goto IL_0010;
		}
	}
	{
		EndOfStreamException_t6B6A2609418A69523CBEF305228B18E0E5778028* L_1;
		L_1 = LZ4Stream_EndOfStream_m868620C08A32DFEB1846D11C8F0E4B2B6D2D4A09(NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Stream_ReadVarInt_m20F01F26A0EA4C2E3B07C4DF304A6F48E09B99BE_RuntimeMethod_var)));
	}

IL_0010:
	{
		uint64_t L_2 = V_0;
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Stream_ReadBlock_m023A6DE7D6164E281F15FAD297038C374C263E76 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset, int32_t ___2_length, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		V_0 = 0;
		goto IL_0024;
	}

IL_0004:
	{
		Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* L_0 = __this->____innerStream;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___0_buffer;
		int32_t L_2 = ___1_offset;
		int32_t L_3 = ___2_length;
		NullCheck(L_0);
		int32_t L_4;
		L_4 = VirtualFuncInvoker3< int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(35, L_0, L_1, L_2, L_3);
		V_1 = L_4;
		int32_t L_5 = V_1;
		if (!L_5)
		{
			goto IL_0028;
		}
	}
	{
		int32_t L_6 = ___1_offset;
		int32_t L_7 = V_1;
		___1_offset = ((int32_t)il2cpp_codegen_add(L_6, L_7));
		int32_t L_8 = ___2_length;
		int32_t L_9 = V_1;
		___2_length = ((int32_t)il2cpp_codegen_subtract(L_8, L_9));
		int32_t L_10 = V_0;
		int32_t L_11 = V_1;
		V_0 = ((int32_t)il2cpp_codegen_add(L_10, L_11));
	}

IL_0024:
	{
		int32_t L_12 = ___2_length;
		if ((((int32_t)L_12) > ((int32_t)0)))
		{
			goto IL_0004;
		}
	}

IL_0028:
	{
		int32_t L_13 = V_0;
		return L_13;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream_WriteVarInt_m48CBECCBE2470EF86965274DE22DB43141EFD642 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, uint64_t ___0_value, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	uint8_t V_1 = 0x0;
	uint8_t G_B3_0 = 0x0;
	int32_t G_B3_1 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* G_B3_2 = NULL;
	uint8_t G_B2_0 = 0x0;
	int32_t G_B2_1 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* G_B2_2 = NULL;
	int32_t G_B4_0 = 0;
	uint8_t G_B4_1 = 0x0;
	int32_t G_B4_2 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* G_B4_3 = NULL;
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)1);
		V_0 = L_0;
	}

IL_0007:
	{
		uint64_t L_1 = ___0_value;
		V_1 = (uint8_t)((int32_t)(uint8_t)((int64_t)((int64_t)L_1&((int64_t)((int32_t)127)))));
		uint64_t L_2 = ___0_value;
		___0_value = ((int64_t)((uint64_t)L_2>>7));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = V_0;
		uint8_t L_4 = V_1;
		uint64_t L_5 = ___0_value;
		if ((((int64_t)L_5) == ((int64_t)((int64_t)0))))
		{
			G_B3_0 = L_4;
			G_B3_1 = 0;
			G_B3_2 = L_3;
			goto IL_0022;
		}
		G_B2_0 = L_4;
		G_B2_1 = 0;
		G_B2_2 = L_3;
	}
	{
		G_B4_0 = ((int32_t)128);
		G_B4_1 = G_B2_0;
		G_B4_2 = G_B2_1;
		G_B4_3 = G_B2_2;
		goto IL_0023;
	}

IL_0022:
	{
		G_B4_0 = 0;
		G_B4_1 = G_B3_0;
		G_B4_2 = G_B3_1;
		G_B4_3 = G_B3_2;
	}

IL_0023:
	{
		NullCheck(G_B4_3);
		(G_B4_3)->SetAt(static_cast<il2cpp_array_size_t>(G_B4_2), (uint8_t)((int32_t)(uint8_t)((int32_t)((int32_t)G_B4_1|G_B4_0))));
		Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* L_6 = __this->____innerStream;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = V_0;
		NullCheck(L_6);
		VirtualActionInvoker3< ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(38, L_6, L_7, 0, 1);
		uint64_t L_8 = ___0_value;
		if ((!(((uint64_t)L_8) == ((uint64_t)((int64_t)0)))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream_FlushCurrentChunk_m228E2273C1A6B40673F48806C59615A57DFF0B98 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	int32_t V_3 = 0;
	int32_t G_B5_0 = 0;
	{
		int32_t L_0 = __this->____bufferOffset;
		if ((((int32_t)L_0) > ((int32_t)0)))
		{
			goto IL_000a;
		}
	}
	{
		return;
	}

IL_000a:
	{
		int32_t L_1 = __this->____bufferOffset;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_1);
		V_0 = L_2;
		bool L_3 = __this->____highCompression;
		if (L_3)
		{
			goto IL_003a;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = __this->____buffer;
		int32_t L_5 = __this->____bufferOffset;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = V_0;
		int32_t L_7 = __this->____bufferOffset;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		int32_t L_8;
		L_8 = LZ4Codec_Encode_m95700861B517937C3B5CC74DCA9CA8002E2BB12B(L_4, 0, L_5, L_6, 0, L_7, NULL);
		G_B5_0 = L_8;
		goto IL_0054;
	}

IL_003a:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_9 = __this->____buffer;
		int32_t L_10 = __this->____bufferOffset;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_11 = V_0;
		int32_t L_12 = __this->____bufferOffset;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		int32_t L_13;
		L_13 = LZ4Codec_EncodeHC_m462A61B698E8E2B338A0332DA00FB64EBFC8F82C(L_9, 0, L_10, L_11, 0, L_12, NULL);
		G_B5_0 = L_13;
	}

IL_0054:
	{
		V_1 = G_B5_0;
		int32_t L_14 = V_1;
		if ((((int32_t)L_14) <= ((int32_t)0)))
		{
			goto IL_0062;
		}
	}
	{
		int32_t L_15 = V_1;
		int32_t L_16 = __this->____bufferOffset;
		if ((((int32_t)L_15) < ((int32_t)L_16)))
		{
			goto IL_0070;
		}
	}

IL_0062:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = __this->____buffer;
		V_0 = L_17;
		int32_t L_18 = __this->____bufferOffset;
		V_1 = L_18;
	}

IL_0070:
	{
		int32_t L_19 = V_1;
		int32_t L_20 = __this->____bufferOffset;
		V_2 = (bool)((((int32_t)L_19) < ((int32_t)L_20))? 1 : 0);
		V_3 = 0;
		bool L_21 = V_2;
		if (!L_21)
		{
			goto IL_0083;
		}
	}
	{
		int32_t L_22 = V_3;
		V_3 = ((int32_t)((int32_t)L_22|1));
	}

IL_0083:
	{
		bool L_23 = __this->____highCompression;
		if (!L_23)
		{
			goto IL_008f;
		}
	}
	{
		int32_t L_24 = V_3;
		V_3 = ((int32_t)((int32_t)L_24|2));
	}

IL_008f:
	{
		int32_t L_25 = V_3;
		LZ4Stream_WriteVarInt_m48CBECCBE2470EF86965274DE22DB43141EFD642(__this, ((int64_t)L_25), NULL);
		int32_t L_26 = __this->____bufferOffset;
		LZ4Stream_WriteVarInt_m48CBECCBE2470EF86965274DE22DB43141EFD642(__this, ((int64_t)L_26), NULL);
		bool L_27 = V_2;
		if (!L_27)
		{
			goto IL_00af;
		}
	}
	{
		int32_t L_28 = V_1;
		LZ4Stream_WriteVarInt_m48CBECCBE2470EF86965274DE22DB43141EFD642(__this, ((int64_t)L_28), NULL);
	}

IL_00af:
	{
		Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* L_29 = __this->____innerStream;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_30 = V_0;
		int32_t L_31 = V_1;
		NullCheck(L_29);
		VirtualActionInvoker3< ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(38, L_29, L_30, 0, L_31);
		__this->____bufferOffset = 0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LZ4Stream_AcquireNextChunk_mB2AFE8A394C7E4C943D768E5A6789F1D62D45F59 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint64_t V_0 = 0;
	int32_t V_1 = 0;
	bool V_2 = false;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_5 = NULL;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t G_B5_0 = 0;

IL_0000:
	{
		bool L_0;
		L_0 = LZ4Stream_TryReadVarInt_m98E1AC815BFD87BCB413B26908D77119B3678F05(__this, (&V_0), NULL);
		if (L_0)
		{
			goto IL_000c;
		}
	}
	{
		return (bool)0;
	}

IL_000c:
	{
		uint64_t L_1 = V_0;
		V_1 = ((int32_t)L_1);
		int32_t L_2 = V_1;
		V_2 = (bool)((((int32_t)((((int32_t)((int32_t)((int32_t)L_2&1))) == ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		uint64_t L_3;
		L_3 = LZ4Stream_ReadVarInt_m20F01F26A0EA4C2E3B07C4DF304A6F48E09B99BE(__this, NULL);
		V_3 = ((int32_t)L_3);
		bool L_4 = V_2;
		if (L_4)
		{
			goto IL_0027;
		}
	}
	{
		int32_t L_5 = V_3;
		G_B5_0 = L_5;
		goto IL_002e;
	}

IL_0027:
	{
		uint64_t L_6;
		L_6 = LZ4Stream_ReadVarInt_m20F01F26A0EA4C2E3B07C4DF304A6F48E09B99BE(__this, NULL);
		G_B5_0 = ((int32_t)L_6);
	}

IL_002e:
	{
		V_4 = G_B5_0;
		int32_t L_7 = V_4;
		int32_t L_8 = V_3;
		if ((((int32_t)L_7) <= ((int32_t)L_8)))
		{
			goto IL_003b;
		}
	}
	{
		EndOfStreamException_t6B6A2609418A69523CBEF305228B18E0E5778028* L_9;
		L_9 = LZ4Stream_EndOfStream_m868620C08A32DFEB1846D11C8F0E4B2B6D2D4A09(NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_9, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Stream_AcquireNextChunk_mB2AFE8A394C7E4C943D768E5A6789F1D62D45F59_RuntimeMethod_var)));
	}

IL_003b:
	{
		int32_t L_10 = V_4;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_11 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_10);
		V_5 = L_11;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = V_5;
		int32_t L_13 = V_4;
		int32_t L_14;
		L_14 = LZ4Stream_ReadBlock_m023A6DE7D6164E281F15FAD297038C374C263E76(__this, L_12, 0, L_13, NULL);
		V_6 = L_14;
		int32_t L_15 = V_6;
		int32_t L_16 = V_4;
		if ((((int32_t)L_15) == ((int32_t)L_16)))
		{
			goto IL_005d;
		}
	}
	{
		EndOfStreamException_t6B6A2609418A69523CBEF305228B18E0E5778028* L_17;
		L_17 = LZ4Stream_EndOfStream_m868620C08A32DFEB1846D11C8F0E4B2B6D2D4A09(NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_17, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Stream_AcquireNextChunk_mB2AFE8A394C7E4C943D768E5A6789F1D62D45F59_RuntimeMethod_var)));
	}

IL_005d:
	{
		bool L_18 = V_2;
		if (L_18)
		{
			goto IL_0072;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_19 = V_5;
		__this->____buffer = L_19;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____buffer), (void*)L_19);
		int32_t L_20 = V_4;
		__this->____bufferLength = L_20;
		goto IL_00c0;
	}

IL_0072:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_21 = __this->____buffer;
		if (!L_21)
		{
			goto IL_0085;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_22 = __this->____buffer;
		NullCheck(L_22);
		int32_t L_23 = V_3;
		if ((((int32_t)((int32_t)(((RuntimeArray*)L_22)->max_length))) >= ((int32_t)L_23)))
		{
			goto IL_0091;
		}
	}

IL_0085:
	{
		int32_t L_24 = V_3;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_25 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_24);
		__this->____buffer = L_25;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____buffer), (void*)L_25);
	}

IL_0091:
	{
		int32_t L_26 = V_1;
		V_7 = ((int32_t)((int32_t)L_26>>2));
		int32_t L_27 = V_7;
		if (!L_27)
		{
			goto IL_00a5;
		}
	}
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_28 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NotSupportedException__ctor_mE174750CF0247BBB47544FFD71D66BB89630945B(L_28, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralFAD353B75E80AD61913B4FBBC2ADCBD997209B05)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_28, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Stream_AcquireNextChunk_mB2AFE8A394C7E4C943D768E5A6789F1D62D45F59_RuntimeMethod_var)));
	}

IL_00a5:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_29 = V_5;
		int32_t L_30 = V_4;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_31 = __this->____buffer;
		int32_t L_32 = V_3;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tEE4930A49EAC407F425BF906EAFB298DB4ACCBB1_il2cpp_TypeInfo_var);
		int32_t L_33;
		L_33 = LZ4Codec_Decode_m9A778AF80843CC473CB2DC1E68F04451742071B9(L_29, 0, L_30, L_31, 0, L_32, (bool)1, NULL);
		int32_t L_34 = V_3;
		__this->____bufferLength = L_34;
	}

IL_00c0:
	{
		__this->____bufferOffset = 0;
		int32_t L_35 = __this->____bufferLength;
		if (!L_35)
		{
			goto IL_0000;
		}
	}
	{
		return (bool)1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LZ4Stream_get_CanRead_mF540B50E61A08F9DD12102F659DD4B75D30BCE0D (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->____compressionMode;
		return (bool)((((int32_t)L_0) == ((int32_t)1))? 1 : 0);
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LZ4Stream_get_CanSeek_mD22D4A83EB31F7976D45FD55C21AF1363BD60320 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, const RuntimeMethod* method) 
{
	{
		return (bool)0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool LZ4Stream_get_CanWrite_mDE79562458464989A739B7F3853F90DCB641C65F (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->____compressionMode;
		return (bool)((((int32_t)L_0) == ((int32_t)0))? 1 : 0);
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream_Flush_m56A460AE328BAFB8AA65D6C77910C5A99F6229CA (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->____bufferOffset;
		if ((((int32_t)L_0) <= ((int32_t)0)))
		{
			goto IL_0017;
		}
	}
	{
		bool L_1;
		L_1 = VirtualFuncInvoker0< bool >::Invoke(11, __this);
		if (!L_1)
		{
			goto IL_0017;
		}
	}
	{
		LZ4Stream_FlushCurrentChunk_m228E2273C1A6B40673F48806C59615A57DFF0B98(__this, NULL);
	}

IL_0017:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t LZ4Stream_get_Length_m00F1E5071F70EACFB8E497E17E3426EDB6AACED5 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, const RuntimeMethod* method) 
{
	{
		return ((int64_t)(-1));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t LZ4Stream_get_Position_m5EC886C68DA2E36D3153A45635ED381E95068A5F (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, const RuntimeMethod* method) 
{
	{
		return ((int64_t)(-1));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream_set_Position_mA42750CADBED4B284E7D0D4D72FE8F46D5A1FED8 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, int64_t ___0_value, const RuntimeMethod* method) 
{
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_0;
		L_0 = LZ4Stream_NotSupported_m65D89ADBD25DB5B852E14AE1D09E5F72B10BBFE3(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralA6B02B723395681F874F9897DEDC56A228BC2667)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Stream_set_Position_mA42750CADBED4B284E7D0D4D72FE8F46D5A1FED8_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Stream_ReadByte_mEA9A1AF52429EFADA3821606420CE353346C027E (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		bool L_0;
		L_0 = VirtualFuncInvoker0< bool >::Invoke(8, __this);
		if (L_0)
		{
			goto IL_0013;
		}
	}
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_1;
		L_1 = LZ4Stream_NotSupported_m65D89ADBD25DB5B852E14AE1D09E5F72B10BBFE3(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral75C670EA0F7AE5A776E170D1A225F267CA674091)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Stream_ReadByte_mEA9A1AF52429EFADA3821606420CE353346C027E_RuntimeMethod_var)));
	}

IL_0013:
	{
		int32_t L_2 = __this->____bufferOffset;
		int32_t L_3 = __this->____bufferLength;
		if ((((int32_t)L_2) < ((int32_t)L_3)))
		{
			goto IL_002b;
		}
	}
	{
		bool L_4;
		L_4 = LZ4Stream_AcquireNextChunk_mB2AFE8A394C7E4C943D768E5A6789F1D62D45F59(__this, NULL);
		if (L_4)
		{
			goto IL_002b;
		}
	}
	{
		return (-1);
	}

IL_002b:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = __this->____buffer;
		int32_t L_6 = __this->____bufferOffset;
		int32_t L_7 = L_6;
		V_0 = L_7;
		__this->____bufferOffset = ((int32_t)il2cpp_codegen_add(L_7, 1));
		int32_t L_8 = V_0;
		NullCheck(L_5);
		int32_t L_9 = L_8;
		uint8_t L_10 = (L_5)->GetAt(static_cast<il2cpp_array_size_t>(L_9));
		return L_10;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Stream_Read_m7CE9AC5BD4F978BC58FE6E1709BA8898E9C6AADC (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset, int32_t ___2_count, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		bool L_0;
		L_0 = VirtualFuncInvoker0< bool >::Invoke(8, __this);
		if (L_0)
		{
			goto IL_0013;
		}
	}
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_1;
		L_1 = LZ4Stream_NotSupported_m65D89ADBD25DB5B852E14AE1D09E5F72B10BBFE3(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral75C670EA0F7AE5A776E170D1A225F267CA674091)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Stream_Read_m7CE9AC5BD4F978BC58FE6E1709BA8898E9C6AADC_RuntimeMethod_var)));
	}

IL_0013:
	{
		V_0 = 0;
		goto IL_0071;
	}

IL_0017:
	{
		int32_t L_2 = ___2_count;
		int32_t L_3 = __this->____bufferLength;
		int32_t L_4 = __this->____bufferOffset;
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		int32_t L_5;
		L_5 = Math_Min_m53C488772A34D53917BCA2A491E79A0A5356ED52(L_2, ((int32_t)il2cpp_codegen_subtract(L_3, L_4)), NULL);
		V_1 = L_5;
		int32_t L_6 = V_1;
		if ((((int32_t)L_6) <= ((int32_t)0)))
		{
			goto IL_0069;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = __this->____buffer;
		int32_t L_8 = __this->____bufferOffset;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_9 = ___0_buffer;
		int32_t L_10 = ___1_offset;
		int32_t L_11 = V_1;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_7, L_8, (RuntimeArray*)L_9, L_10, L_11, NULL);
		int32_t L_12 = __this->____bufferOffset;
		int32_t L_13 = V_1;
		__this->____bufferOffset = ((int32_t)il2cpp_codegen_add(L_12, L_13));
		int32_t L_14 = V_0;
		int32_t L_15 = V_1;
		V_0 = ((int32_t)il2cpp_codegen_add(L_14, L_15));
		bool L_16 = __this->____interactiveRead;
		if (L_16)
		{
			goto IL_0075;
		}
	}
	{
		int32_t L_17 = ___1_offset;
		int32_t L_18 = V_1;
		___1_offset = ((int32_t)il2cpp_codegen_add(L_17, L_18));
		int32_t L_19 = ___2_count;
		int32_t L_20 = V_1;
		___2_count = ((int32_t)il2cpp_codegen_subtract(L_19, L_20));
		goto IL_0071;
	}

IL_0069:
	{
		bool L_21;
		L_21 = LZ4Stream_AcquireNextChunk_mB2AFE8A394C7E4C943D768E5A6789F1D62D45F59(__this, NULL);
		if (!L_21)
		{
			goto IL_0075;
		}
	}

IL_0071:
	{
		int32_t L_22 = ___2_count;
		if ((((int32_t)L_22) > ((int32_t)0)))
		{
			goto IL_0017;
		}
	}

IL_0075:
	{
		int32_t L_23 = V_0;
		return L_23;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t LZ4Stream_Seek_m63BC2D4E046E34C55FD0846BE2BF311712DDEE19 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, int64_t ___0_offset, int32_t ___1_origin, const RuntimeMethod* method) 
{
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_0;
		L_0 = LZ4Stream_NotSupported_m65D89ADBD25DB5B852E14AE1D09E5F72B10BBFE3(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralB7CA6B7A7F82DA89BFD1F6A227BE9102B12D67B3)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Stream_Seek_m63BC2D4E046E34C55FD0846BE2BF311712DDEE19_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream_SetLength_m9AB6A8945A36652E275F31563F38A465A664C0E1 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, int64_t ___0_value, const RuntimeMethod* method) 
{
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_0;
		L_0 = LZ4Stream_NotSupported_m65D89ADBD25DB5B852E14AE1D09E5F72B10BBFE3(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralEA11839FFA673044FF4EB9A4F59B3BC47F4144AE)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Stream_SetLength_m9AB6A8945A36652E275F31563F38A465A664C0E1_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream_WriteByte_m34097C9CA98157F0BD83727FA39B1D084A9DB776 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, uint8_t ___0_value, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		bool L_0;
		L_0 = VirtualFuncInvoker0< bool >::Invoke(11, __this);
		if (L_0)
		{
			goto IL_0013;
		}
	}
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_1;
		L_1 = LZ4Stream_NotSupported_m65D89ADBD25DB5B852E14AE1D09E5F72B10BBFE3(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralC013226DF137B7010B5FE9B6BEB26EF8127E5B47)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Stream_WriteByte_m34097C9CA98157F0BD83727FA39B1D084A9DB776_RuntimeMethod_var)));
	}

IL_0013:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____buffer;
		if (L_2)
		{
			goto IL_003f;
		}
	}
	{
		int32_t L_3 = __this->____blockSize;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_3);
		__this->____buffer = L_4;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____buffer), (void*)L_4);
		int32_t L_5 = __this->____blockSize;
		__this->____bufferLength = L_5;
		__this->____bufferOffset = 0;
	}

IL_003f:
	{
		int32_t L_6 = __this->____bufferOffset;
		int32_t L_7 = __this->____bufferLength;
		if ((((int32_t)L_6) < ((int32_t)L_7)))
		{
			goto IL_0053;
		}
	}
	{
		LZ4Stream_FlushCurrentChunk_m228E2273C1A6B40673F48806C59615A57DFF0B98(__this, NULL);
	}

IL_0053:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = __this->____buffer;
		int32_t L_9 = __this->____bufferOffset;
		int32_t L_10 = L_9;
		V_0 = L_10;
		__this->____bufferOffset = ((int32_t)il2cpp_codegen_add(L_10, 1));
		int32_t L_11 = V_0;
		uint8_t L_12 = ___0_value;
		NullCheck(L_8);
		(L_8)->SetAt(static_cast<il2cpp_array_size_t>(L_11), (uint8_t)L_12);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream_Write_mE9D030B08A7B40BE1F50C5943E347BF28E175511 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_buffer, int32_t ___1_offset, int32_t ___2_count, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		bool L_0;
		L_0 = VirtualFuncInvoker0< bool >::Invoke(11, __this);
		if (L_0)
		{
			goto IL_0013;
		}
	}
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_1;
		L_1 = LZ4Stream_NotSupported_m65D89ADBD25DB5B852E14AE1D09E5F72B10BBFE3(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralC013226DF137B7010B5FE9B6BEB26EF8127E5B47)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Stream_Write_mE9D030B08A7B40BE1F50C5943E347BF28E175511_RuntimeMethod_var)));
	}

IL_0013:
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____buffer;
		if (L_2)
		{
			goto IL_008d;
		}
	}
	{
		int32_t L_3 = __this->____blockSize;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_3);
		__this->____buffer = L_4;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____buffer), (void*)L_4);
		int32_t L_5 = __this->____blockSize;
		__this->____bufferLength = L_5;
		__this->____bufferOffset = 0;
		goto IL_008d;
	}

IL_0041:
	{
		int32_t L_6 = ___2_count;
		int32_t L_7 = __this->____bufferLength;
		int32_t L_8 = __this->____bufferOffset;
		il2cpp_codegen_runtime_class_init_inline(Math_tEB65DE7CA8B083C412C969C92981C030865486CE_il2cpp_TypeInfo_var);
		int32_t L_9;
		L_9 = Math_Min_m53C488772A34D53917BCA2A491E79A0A5356ED52(L_6, ((int32_t)il2cpp_codegen_subtract(L_7, L_8)), NULL);
		V_0 = L_9;
		int32_t L_10 = V_0;
		if ((((int32_t)L_10) <= ((int32_t)0)))
		{
			goto IL_0087;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_11 = ___0_buffer;
		int32_t L_12 = ___1_offset;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_13 = __this->____buffer;
		int32_t L_14 = __this->____bufferOffset;
		int32_t L_15 = V_0;
		Buffer_BlockCopy_m2F7BC0C5BA97C500E3F87D5008718F797E02B358((RuntimeArray*)L_11, L_12, (RuntimeArray*)L_13, L_14, L_15, NULL);
		int32_t L_16 = ___1_offset;
		int32_t L_17 = V_0;
		___1_offset = ((int32_t)il2cpp_codegen_add(L_16, L_17));
		int32_t L_18 = ___2_count;
		int32_t L_19 = V_0;
		___2_count = ((int32_t)il2cpp_codegen_subtract(L_18, L_19));
		int32_t L_20 = __this->____bufferOffset;
		int32_t L_21 = V_0;
		__this->____bufferOffset = ((int32_t)il2cpp_codegen_add(L_20, L_21));
		goto IL_008d;
	}

IL_0087:
	{
		LZ4Stream_FlushCurrentChunk_m228E2273C1A6B40673F48806C59615A57DFF0B98(__this, NULL);
	}

IL_008d:
	{
		int32_t L_22 = ___2_count;
		if ((((int32_t)L_22) > ((int32_t)0)))
		{
			goto IL_0041;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream_Dispose_mBD991F58E609190CF068073F724B992DE686FF49 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, bool ___0_disposing, const RuntimeMethod* method) 
{
	{
		VirtualActionInvoker0::Invoke(23, __this);
		bool L_0 = __this->____isolateInnerStream;
		if (L_0)
		{
			goto IL_0019;
		}
	}
	{
		Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* L_1 = __this->____innerStream;
		NullCheck(L_1);
		Stream_Dispose_mCDB42F32A17541CCA6D3A5906827A401570B07A8(L_1, NULL);
	}

IL_0019:
	{
		bool L_2 = ___0_disposing;
		Stream_Dispose_m9B37BD21A57F8F2BD20EE353DE14405700810C5C(__this, L_2, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream__ctor_mBE33C6F8AA7299352D62FA9BF818C4A8F2BC54D6 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* ___0_innerStream, int32_t ___1_compressionMode, bool ___2_highCompression, int32_t ___3_blockSize, bool ___4_interactiveRead, const RuntimeMethod* method) 
{
	{
		Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* L_0 = ___0_innerStream;
		int32_t L_1 = ___1_compressionMode;
		int32_t L_2;
		L_2 = LZ4Stream_ToLZ4StreamMode_m0D51E395EC217ABE5CA45352CAEA99D49934B48F(L_1, NULL);
		bool L_3 = ___2_highCompression;
		bool L_4 = ___4_interactiveRead;
		int32_t L_5;
		L_5 = LZ4Stream_CombineLZ4Flags_m893A68D7D9486557D2753C0D6FEA961786691D83(L_3, L_4, NULL);
		int32_t L_6 = ___3_blockSize;
		LZ4Stream__ctor_m403377F2E66DCB170D98C5518C606FB11AA5AB10(__this, L_0, L_2, L_5, L_6, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LZ4Stream__ctor_m74495D7B095C79D10C8AE1106AA0CE0A855A9A67 (LZ4Stream_t9428C7F795E92374F5299CCF3A3E757B477CA7DF* __this, Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* ___0_innerStream, int32_t ___1_compressionMode, int32_t ___2_compressionFlags, int32_t ___3_blockSize, const RuntimeMethod* method) 
{
	{
		Stream_tF844051B786E8F7F4244DBD218D74E8617B9A2DE* L_0 = ___0_innerStream;
		int32_t L_1 = ___1_compressionMode;
		int32_t L_2;
		L_2 = LZ4Stream_ToLZ4StreamMode_m0D51E395EC217ABE5CA45352CAEA99D49934B48F(L_1, NULL);
		int32_t L_3 = ___2_compressionFlags;
		int32_t L_4 = ___3_blockSize;
		LZ4Stream__ctor_m403377F2E66DCB170D98C5518C606FB11AA5AB10(__this, L_0, L_2, L_3, L_4, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Stream_ToLZ4StreamMode_m0D51E395EC217ABE5CA45352CAEA99D49934B48F (int32_t ___0_compressionMode, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = ___0_compressionMode;
		V_0 = L_0;
		int32_t L_1 = V_0;
		switch (L_1)
		{
			case 0:
			{
				goto IL_0014;
			}
			case 1:
			{
				goto IL_0012;
			}
		}
	}
	{
		goto IL_0016;
	}

IL_0012:
	{
		return (int32_t)(0);
	}

IL_0014:
	{
		return (int32_t)(1);
	}

IL_0016:
	{
		int32_t L_2 = ___0_compressionMode;
		int32_t L_3 = L_2;
		RuntimeObject* L_4 = Box(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&CompressionMode_t840C8957CF84ACFBF5C43E48AEAEB9DB5E64F3C5_il2cpp_TypeInfo_var)), &L_3);
		String_t* L_5;
		L_5 = String_Format_mA8DBB4C2516B9723C5A41E6CB1E2FAF4BBE96DD8(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralF485E45E4151BA2CB0606C4893544827F6ED5D84)), L_4, NULL);
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_6 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_6, L_5, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_6, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&LZ4Stream_ToLZ4StreamMode_m0D51E395EC217ABE5CA45352CAEA99D49934B48F_RuntimeMethod_var)));
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t LZ4Stream_CombineLZ4Flags_m893A68D7D9486557D2753C0D6FEA961786691D83 (bool ___0_highCompression, bool ___1_interactiveRead, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		V_0 = 0;
		bool L_0 = ___0_highCompression;
		if (!L_0)
		{
			goto IL_0009;
		}
	}
	{
		int32_t L_1 = V_0;
		V_0 = ((int32_t)((int32_t)L_1|2));
	}

IL_0009:
	{
		bool L_2 = ___1_interactiveRead;
		if (!L_2)
		{
			goto IL_0010;
		}
	}
	{
		int32_t L_3 = V_0;
		V_0 = ((int32_t)((int32_t)L_3|1));
	}

IL_0010:
	{
		int32_t L_4 = V_0;
		return L_4;
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
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Safe32LZ4Service_get_CodecName_m520D6861E29FCFC9F40F93D5D3E2B976E3AEF3D3 (Safe32LZ4Service_t6C465065F50F51FE51B7CC5377CC242FFD50D5A5* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralB9B1E2FE6B9DEAA858C78D6320932A5865FF2D1E);
		s_Il2CppMethodInitialized = true;
	}
	{
		return _stringLiteralB9B1E2FE6B9DEAA858C78D6320932A5865FF2D1E;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Safe32LZ4Service_Encode_m0DEEFDE3C5C0D307FB15E66627DFDC3F85705618 (Safe32LZ4Service_t6C465065F50F51FE51B7CC5377CC242FFD50D5A5* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_input;
		int32_t L_1 = ___1_inputOffset;
		int32_t L_2 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___3_output;
		int32_t L_4 = ___4_outputOffset;
		int32_t L_5 = ___5_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_6;
		L_6 = LZ4Codec_Encode32_m0853FFD223239CC99ADEF3BCD85413F90B9D166A(L_0, L_1, L_2, L_3, L_4, L_5, NULL);
		return L_6;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Safe32LZ4Service_Decode_m13806AC214003FAC2C227032F5C385E80EA318AB (Safe32LZ4Service_t6C465065F50F51FE51B7CC5377CC242FFD50D5A5* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, bool ___6_knownOutputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_input;
		int32_t L_1 = ___1_inputOffset;
		int32_t L_2 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___3_output;
		int32_t L_4 = ___4_outputOffset;
		int32_t L_5 = ___5_outputLength;
		bool L_6 = ___6_knownOutputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_7;
		L_7 = LZ4Codec_Decode32_mD775EF89F609454DA26E01E021868A6BA0C43214(L_0, L_1, L_2, L_3, L_4, L_5, L_6, NULL);
		return L_7;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Safe32LZ4Service_EncodeHC_m819730EFBB8793A914B71C224E636CF65FCB0E40 (Safe32LZ4Service_t6C465065F50F51FE51B7CC5377CC242FFD50D5A5* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_input;
		int32_t L_1 = ___1_inputOffset;
		int32_t L_2 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___3_output;
		int32_t L_4 = ___4_outputOffset;
		int32_t L_5 = ___5_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_6;
		L_6 = LZ4Codec_Encode32HC_mE7B695E89746BC0A8AEB434AA894BA084A0A815F(L_0, L_1, L_2, L_3, L_4, L_5, NULL);
		return L_6;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Safe32LZ4Service__ctor_mE752E1ABFFD3583D80D4EDD86577DF49255CDF22 (Safe32LZ4Service_t6C465065F50F51FE51B7CC5377CC242FFD50D5A5* __this, const RuntimeMethod* method) 
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Safe64LZ4Service_get_CodecName_m9E82C7B5675E0465DC5BF5998EB9B9FB45BE2D0B (Safe64LZ4Service_tB68E69D87E25EA3EFF8D49FB05A091BB50A80F0B* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral0126FEA21D5814A5884E5E87A041F0816F5BAFA6);
		s_Il2CppMethodInitialized = true;
	}
	{
		return _stringLiteral0126FEA21D5814A5884E5E87A041F0816F5BAFA6;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Safe64LZ4Service_Encode_m397DA24533686CE3D24AD58983B65C22935D140B (Safe64LZ4Service_tB68E69D87E25EA3EFF8D49FB05A091BB50A80F0B* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_input;
		int32_t L_1 = ___1_inputOffset;
		int32_t L_2 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___3_output;
		int32_t L_4 = ___4_outputOffset;
		int32_t L_5 = ___5_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_6;
		L_6 = LZ4Codec_Encode64_m0834480EE01F94270BEFA9C101DDD498AB46402A(L_0, L_1, L_2, L_3, L_4, L_5, NULL);
		return L_6;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Safe64LZ4Service_Decode_m89B52345400DE2FA584EEDF3024654F809158CA4 (Safe64LZ4Service_tB68E69D87E25EA3EFF8D49FB05A091BB50A80F0B* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, bool ___6_knownOutputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_input;
		int32_t L_1 = ___1_inputOffset;
		int32_t L_2 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___3_output;
		int32_t L_4 = ___4_outputOffset;
		int32_t L_5 = ___5_outputLength;
		bool L_6 = ___6_knownOutputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_7;
		L_7 = LZ4Codec_Decode64_m3C186439F19EFC1FDC0CF27BCB8518808BF7A401(L_0, L_1, L_2, L_3, L_4, L_5, L_6, NULL);
		return L_7;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Safe64LZ4Service_EncodeHC_m18FBB6FEAB375351107EFDC6DE52D4C8DB3AA9EC (Safe64LZ4Service_tB68E69D87E25EA3EFF8D49FB05A091BB50A80F0B* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___0_input, int32_t ___1_inputOffset, int32_t ___2_inputLength, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___3_output, int32_t ___4_outputOffset, int32_t ___5_outputLength, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___0_input;
		int32_t L_1 = ___1_inputOffset;
		int32_t L_2 = ___2_inputLength;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___3_output;
		int32_t L_4 = ___4_outputOffset;
		int32_t L_5 = ___5_outputLength;
		il2cpp_codegen_runtime_class_init_inline(LZ4Codec_tF8139E47B7A2BE369D9790C97DF5B0449000F74A_il2cpp_TypeInfo_var);
		int32_t L_6;
		L_6 = LZ4Codec_Encode64HC_mBDD028D90BB74FB1CCE146FAB90A39116BBB4C05(L_0, L_1, L_2, L_3, L_4, L_5, NULL);
		return L_6;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Safe64LZ4Service__ctor_m3CA84D446959C5864676C7E32EDAF6AF98A9E03E (Safe64LZ4Service_tB68E69D87E25EA3EFF8D49FB05A091BB50A80F0B* __this, const RuntimeMethod* method) 
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
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_Invoke_m6693C0B4B386A694967A120B24AC4323B2C48405_inline (Action_tFEE200F32B6B62540977FC32C67A8DF62F8B1A97* __this, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, reinterpret_cast<RuntimeMethod*>(__this->___method));
}

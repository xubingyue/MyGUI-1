/*!
	@file
	@author		Generate utility by Albert Semenov
	@date		01/2009
	@module
*/

using System;
using System.Runtime.InteropServices;

namespace MyGUI.Sharp
{

    public  class ComboBox : EditBox
    {

        #region ComboBox

        protected override string GetWidgetType() { return "ComboBox"; }

        internal static BaseWidget RequestWrapComboBox(BaseWidget _parent, IntPtr _widget)
        {
			ComboBox widget = new ComboBox();
			widget.WrapWidget(_parent, _widget);
            return widget;
        }

        internal static BaseWidget RequestCreateComboBox(BaseWidget _parent, WidgetStyle _style, string _skin, IntCoord _coord, Align _align, string _layer, string _name)
        {
			ComboBox widget = new ComboBox();
			widget.CreateWidgetImpl(_parent, _style, _skin, _coord, _align, _layer, _name);
            return widget;
        }
        
		#endregion
	
		
		//InsertPoint
		#region Event ComboChangePosition

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBoxEvent_AdviseComboChangePosition( IntPtr _native, bool _advise );

		public delegate void HandleComboChangePosition(
			 ComboBox _sender ,
			 uint _index );
			
		private HandleComboChangePosition mEventComboChangePosition;
		public event HandleComboChangePosition EventComboChangePosition
		{
			add
			{
				if (ExportEventComboChangePosition.mDelegate == null)
				{
					ExportEventComboChangePosition.mDelegate = new ExportEventComboChangePosition.ExportHandle( OnExportComboChangePosition );
					ExportEventComboChangePosition.ExportComboBoxEvent_DelegateComboChangePosition( ExportEventComboChangePosition.mDelegate );
				}

				if (mEventComboChangePosition == null)
					ExportComboBoxEvent_AdviseComboChangePosition( mNative, true );
				mEventComboChangePosition += value;
			}
			remove
			{
				mEventComboChangePosition -= value;
				if (mEventComboChangePosition == null)
					ExportComboBoxEvent_AdviseComboChangePosition( mNative, false );
			}
		}

		private struct ExportEventComboChangePosition
		{
			[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ExportComboBoxEvent_DelegateComboChangePosition( ExportHandle _delegate );
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate void ExportHandle(
				[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InterfaceMarshaler))]  ComboBox _sender ,
				  uint _index );
				
			public static ExportHandle mDelegate;
		}

		private static void OnExportComboChangePosition(
			 ComboBox _sender ,
			 uint _index )
		{
			if (_sender.mEventComboChangePosition != null)
				_sender.mEventComboChangePosition(
					 _sender ,
					 _index );
		}

		#endregion
		#region Event ComboAccept

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBoxEvent_AdviseComboAccept( IntPtr _native, bool _advise );

		public delegate void HandleComboAccept(
			 ComboBox _sender ,
			 uint _index );
			
		private HandleComboAccept mEventComboAccept;
		public event HandleComboAccept EventComboAccept
		{
			add
			{
				if (ExportEventComboAccept.mDelegate == null)
				{
					ExportEventComboAccept.mDelegate = new ExportEventComboAccept.ExportHandle( OnExportComboAccept );
					ExportEventComboAccept.ExportComboBoxEvent_DelegateComboAccept( ExportEventComboAccept.mDelegate );
				}

				if (mEventComboAccept == null)
					ExportComboBoxEvent_AdviseComboAccept( mNative, true );
				mEventComboAccept += value;
			}
			remove
			{
				mEventComboAccept -= value;
				if (mEventComboAccept == null)
					ExportComboBoxEvent_AdviseComboAccept( mNative, false );
			}
		}

		private struct ExportEventComboAccept
		{
			[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ExportComboBoxEvent_DelegateComboAccept( ExportHandle _delegate );
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			public delegate void ExportHandle(
				[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InterfaceMarshaler))]  ComboBox _sender ,
				  uint _index );
				
			public static ExportHandle mDelegate;
		}

		private static void OnExportComboAccept(
			 ComboBox _sender ,
			 uint _index )
		{
			if (_sender.mEventComboAccept != null)
				_sender.mEventComboAccept(
					 _sender ,
					 _index );
		}

		#endregion
		#region Method BeginToItemSelected

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_BeginToItemSelected( IntPtr _native );

		public void BeginToItemSelected( )
		{
			ExportComboBox_BeginToItemSelected(  mNative );
		}

		#endregion
		#region Method BeginToItemLast

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_BeginToItemLast( IntPtr _native );

		public void BeginToItemLast( )
		{
			ExportComboBox_BeginToItemLast(  mNative );
		}

		#endregion
		#region Method BeginToItemFirst

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_BeginToItemFirst( IntPtr _native );

		public void BeginToItemFirst( )
		{
			ExportComboBox_BeginToItemFirst(  mNative );
		}

		#endregion
		#region Method BeginToItemAt

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_BeginToItemAt_index( IntPtr _native ,
			  uint _index );

		public void BeginToItemAt(
			uint _index )
		{
			ExportComboBox_BeginToItemAt_index( mNative , 
				 _index );
		}

		#endregion
		#region Method GetItemNameAt

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
        
		private static extern IntPtr ExportComboBox_GetItemNameAt_index( IntPtr _native ,
			  uint _index );

		public string GetItemNameAt(
			uint _index )
		{
			return  Marshal.PtrToStringUni(  ExportComboBox_GetItemNameAt_index( mNative , 
				 _index )  )  ;
		}

		#endregion
		#region Method SetItemNameAt

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_SetItemNameAt_index_name( IntPtr _native ,
			  uint _index ,
			[MarshalAs(UnmanagedType.LPWStr)]  string _name );

		public void SetItemNameAt(
			uint _index ,
			string _name )
		{
			ExportComboBox_SetItemNameAt_index_name( mNative , 
				 _index ,
				 _name );
		}

		#endregion
		#region Method GetItemDataAt

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.IUnknown)]
		private static extern object ExportComboBox_GetItemDataAt_index( IntPtr _native ,
			  uint _index );

		public object GetItemDataAt(
			uint _index )
		{
			return ExportComboBox_GetItemDataAt_index( mNative , 
				 _index );
		}

		#endregion
		#region Method ClearItemDataAt

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_ClearItemDataAt_index( IntPtr _native ,
			  uint _index );

		public void ClearItemDataAt(
			uint _index )
		{
			ExportComboBox_ClearItemDataAt_index( mNative , 
				 _index );
		}

		#endregion
		#region Method SetItemDataAt

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_SetItemDataAt_index_data( IntPtr _native ,
			  uint _index ,
			[MarshalAs(UnmanagedType.IUnknown)]  object _data );

		public void SetItemDataAt(
			uint _index ,
			object _data )
		{
			ExportComboBox_SetItemDataAt_index_data( mNative , 
				 _index ,
				 _data );
		}

		#endregion
		#region Method ClearIndexSelected

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_ClearIndexSelected( IntPtr _native );

		public void ClearIndexSelected( )
		{
			ExportComboBox_ClearIndexSelected(  mNative );
		}

		#endregion
		#region Method FindItemIndexWith

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
        
		private static extern uint ExportComboBox_FindItemIndexWith_name( IntPtr _native ,
			[MarshalAs(UnmanagedType.LPWStr)]  string _name );

		public uint FindItemIndexWith(
			string _name )
		{
			return  ExportComboBox_FindItemIndexWith_name( mNative , 
				 _name )  ;
		}

		#endregion
		#region Method RemoveAllItems

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_RemoveAllItems( IntPtr _native );

		public void RemoveAllItems( )
		{
			ExportComboBox_RemoveAllItems(  mNative );
		}

		#endregion
		#region Method RemoveItemAt

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_RemoveItemAt_index( IntPtr _native ,
			  uint _index );

		public void RemoveItemAt(
			uint _index )
		{
			ExportComboBox_RemoveItemAt_index( mNative , 
				 _index );
		}

		#endregion
		#region Method AddItem

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_AddItem_name_data( IntPtr _native ,
			[MarshalAs(UnmanagedType.LPWStr)]  string _name ,
			[MarshalAs(UnmanagedType.IUnknown)]  object _data );

		public void AddItem(
			string _name ,
			object _data )
		{
			ExportComboBox_AddItem_name_data( mNative , 
				 _name ,
				 _data );
		}

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_AddItem_name( IntPtr _native ,
			[MarshalAs(UnmanagedType.LPWStr)]  string _name );

		public void AddItem(
			string _name )
		{
			ExportComboBox_AddItem_name( mNative , 
				 _name );
		}

		#endregion
		#region Method InsertItemAt

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_InsertItemAt_index_name_data( IntPtr _native ,
			  uint _index ,
			[MarshalAs(UnmanagedType.LPWStr)]  string _name ,
			[MarshalAs(UnmanagedType.IUnknown)]  object _data );

		public void InsertItemAt(
			uint _index ,
			string _name ,
			object _data )
		{
			ExportComboBox_InsertItemAt_index_name_data( mNative , 
				 _index ,
				 _name ,
				 _data );
		}

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_InsertItemAt_index_name( IntPtr _native ,
			  uint _index ,
			[MarshalAs(UnmanagedType.LPWStr)]  string _name );

		public void InsertItemAt(
			uint _index ,
			string _name )
		{
			ExportComboBox_InsertItemAt_index_name( mNative , 
				 _index ,
				 _name );
		}

		#endregion
		#region Property FlowDirection

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I4)]
		private static extern FlowDirection ExportComboBox_GetFlowDirection( IntPtr _widget );
		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_SetFlowDirection( IntPtr _widget, [MarshalAs(UnmanagedType.I4)]  FlowDirection _value );

		public FlowDirection FlowDirection
		{
			get { return  ExportComboBox_GetFlowDirection( mNative )  ; }
			set { ExportComboBox_SetFlowDirection( mNative,  value ); }
		}

		#endregion
		#region Property MaxListLength

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
        
		private static extern int ExportComboBox_GetMaxListLength( IntPtr _widget );
		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_SetMaxListLength( IntPtr _widget,   int _value );

		public int MaxListLength
		{
			get { return  ExportComboBox_GetMaxListLength( mNative )  ; }
			set { ExportComboBox_SetMaxListLength( mNative,  value ); }
		}

		#endregion
		#region Property SmoothShow

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
		private static extern bool ExportComboBox_GetSmoothShow( IntPtr _widget );
		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_SetSmoothShow( IntPtr _widget, [MarshalAs(UnmanagedType.U1)]  bool _value );

		public bool SmoothShow
		{
			get { return  ExportComboBox_GetSmoothShow( mNative )  ; }
			set { ExportComboBox_SetSmoothShow( mNative,  value ); }
		}

		#endregion
		#region Property ComboModeDrop

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
		private static extern bool ExportComboBox_GetComboModeDrop( IntPtr _widget );
		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_SetComboModeDrop( IntPtr _widget, [MarshalAs(UnmanagedType.U1)]  bool _value );

		public bool ComboModeDrop
		{
			get { return  ExportComboBox_GetComboModeDrop( mNative )  ; }
			set { ExportComboBox_SetComboModeDrop( mNative,  value ); }
		}

		#endregion
		#region Property IndexSelected

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
        
		private static extern uint ExportComboBox_GetIndexSelected( IntPtr _widget );
		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
		private static extern void ExportComboBox_SetIndexSelected( IntPtr _widget,   uint _value );

		public uint IndexSelected
		{
			get { return  ExportComboBox_GetIndexSelected( mNative )  ; }
			set { ExportComboBox_SetIndexSelected( mNative,  value ); }
		}

		#endregion
		#region Property ItemCount

		[DllImport("MyGUI_Export", CallingConvention = CallingConvention.Cdecl)]
        
		private static extern uint ExportComboBox_GetItemCount( IntPtr _native );

		public uint ItemCount
		{
			get { return  ExportComboBox_GetItemCount( mNative )  ; }
		}

		#endregion
		
    }

}

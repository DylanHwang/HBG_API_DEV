   M S B A M L   `   `   `  ���� F  BHGB_DI_MONI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:HGB_DI_MONI.ViewHGB_DI_MONI.View  '    !HGB_DI_MONI.View.AvailabilityView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:HGB_DI_MONI.View     -   .��� 
�������.+��� $��Right=�$��Stretch=�.+��� -     ��Name$  	statusBar��$��	Ready ...�����	#FF4F83CC
�������� ���	#FF323A3E.+�� $��10,10,10,10q� � ColumnDefinitions �� $
��1.2* ��� $��* ��� $��* ��� $��* ��� $��* ��� $
��0.8* ��� $
��0.5* ��� $
��0.8* ��� $
��0.5* ��� $
��1.0* ��� $
��0.3* ��� $
��1.5* �.+��� $��Check-In/Out��$
��Left=�$��Center=�
�������$��0��$��0��$��Malgun Gothic)�$��12(�$��Normal"�(  "System.Windows.Controls.DatePicker  -     Name$ CheckIn��$��Stretch=�$��Center=�$��0��$��1��$��2����Z�   -   $ CheckOut��$��Stretch=�$��Center=�$��0��$��3��$��2��$��12(�$��Malgun Gothic)�$��Normal"���Z� �� $��Rooms��$��Right=�$��Center=�
�������$��26��$	��NaN��$��0��$��5��$��Malgun Gothic)�$��12(�$��Normal"��� -    ��Name$ 
RoomNum_CB��$��Stretch=�$��6��$��0��$��26��.@���  �� 
IsSelected . .��1�� .��2�� .��3�� .��4�� $��Adults��$��Right=�$��Center=�
�������$��26��$	��NaN��$��0��$��7��$��Malgun Gothic)�$��12(�$��Normal"��� -   $ AdultNum_CB��$��Stretch=�$��Center=�$��26��$��0��$��8��$��12(�$��Malgun Gothic)�$��Normal"�.@��� .��1��  . .��2�� .��3�� .��4�� $��	RateCheck��$��Right=�$	��Top=�
�������$��26��$	��NaN��$��0��$��9��$��Malgun Gothic)�$��12(�$��Normal"��� -    ��Name$ RateCheck_YN��$��0,5,0,0q�$
��Left=�$��Center=�
�������$��26��$	��NaN��$��0��$��10��$��Malgun Gothic)�$��12(�$��Normal"��� -    ��Name$ 	Start_btn��$��Start��$��Stretch=�$��11��
�������$��26�����	#FF3A3434$
��Bold"�$��Malgun Gothic)�$��12(���Z� � ���	#FF323A3E.+�� .+��� -	    ��Name$ HotelCodes_TB��$��10,10,10,10q�$��Stretch=�$	��100�� �� TextWrapping$
 Wrap=�	 �� AcceptsReturn	 . "
 �� VerticalScrollBarVisibility$

 Auto=�$	��Top=�$��Malgun Gothic)�$��12(����	#FF002F6C$��Normal"�� $��
10,10,10,0q� �� $��60 ��� $��* �.+��� $��API-URL��$��0��$
��Left=�$��Center=�$��26��$��54�����	#FF2C2C2C$��Malgun Gothic)�$��12(�$��Normal"��� -
   $ 	ApiUrl_TB��$��1��$��Stretch=�$��23��$
 Wrap=�$��TextBox��$��Center=����	#FF4F83CC���	#FF4F83CC$��12(�$��Malgun Gothic)�$��Normal"�� $
��AUTO��$	��Top=�$��0,0,0,0q�$��Stretch=� � RowDefinitions �� $��40 ��� $��* �.+��� $��Result Grid��$��
10,10,10,5q����	#FF22AABD
�������$
��Bold"�&   System.Windows.Controls.DataGrid  -     Name$ hbHotelRoom_Grid��$��1��$
��Left=�$	��350��$��10,10,10,10q�$	��Top=�$	��NaN��$	��770��   AutoGenerateColumns .     GridLinesVisibility$ 
Horizontal=�   SelectionUnit$
 Cell=�   SelectionMode$ Extended=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
Hotel Code��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
hotel_code+  $ 
Hotel Name�� .  �� *
hotel_name+  $ Check-In�� .  �� *	checkIn+  $ 	Check-Out�� .  �� *
checkOut+  $ 	room_name�� .  �� *	room_name+  $ rateKey�� .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 400  �� *	rateKey+  $ rateType�� .  �� *
rateType+  $ 	rateClass�� .  �� *	rateClass+  $ 	boardName�� .  �� *	boardName+  $	 Net�� .  �� *net+  $ sellingRate�� .  �� *sellingRate+  $	 GnD�� .  �� *GnD+  $ Destination�� .  �� *hotel_destinationName+  $ zoneName�� .  �� *hotel_zoneName+  $ 	packaging�� .  �� *	packaging+  $ CallBack�� .  �� *
callBack+� $��Stretch=� �� $��* � �� $��* ��� $��* �.+��� $��JSON Request Query��$��Stretch=�$��0��$��0��$
��AUTO��$��	10,5,10,5q�$	��Top=�$��Malgun Gothic)�$��16(�$
��Bold"����	#FF01579B���	#FF01579B.���� -   $ 
RQ_Json_TB��$��Stretch=�$	��260��$��10,10,10,10q�$
 Wrap=�	 . $

 Auto=�$	��Top=�$��Malgun Gothic)�$��12(����	#FF002F6C$��Normal"��� $��JSON Respons��$��Stretch=�$��0��$��1��$	��NaN��$��	10,5,10,5q�$	��Top=����	#FF01579B���	#FF01579B$��16(�$
��Bold"�.���� -   $ 
RS_Json_TB��$��Stretch=�$	��NaN��$��10,10,10,10q�$
 Wrap=�	 . $

 Auto=�$	��Top=�$	��260��$	��350��$��12(�$��Normal"����	#FF002F6C
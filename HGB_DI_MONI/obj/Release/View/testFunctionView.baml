   M S B A M L   `   `   `  ���� F  BHGB_DI_MONI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:HGB_DI_MONI.ViewHGB_DI_MONI.View  '    !HGB_DI_MONI.View.testFunctionView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:HGB_DI_MONI.View     -   .��� 
�������.+��� $��Right=�$��Stretch=�.+��� -     ��Name$  	statusBar��$��	Ready ...�����	#FF4F83CC
�������� ���	#FF323A3E.+�� $��10,10,10,10q� � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+��� -    ��Name$ GetRoomDescrip_btn��$��1. Get RoomDecription��$��0,0,10,-0.4q�$��0��$��0��$��Stretch=�
����������	#FF3A3434$
��Bold"�$��Malgun Gothic)�$��12(�$��22��$��Bottom=���Z� �� -   $ GetImage_btn��$��2.Get image links��$��0,0,10,0q�$��0��$��1��$��Stretch=�
����������	#FF3A3434$
��Bold"�$��Malgun Gothic)�$��12(���Z� �� -   $ Extract_btn��$��3. Extract CVS File��$��0��$��10,0,0,0q�$��2��$��Stretch=�
����������	#FF3A3434$
��Bold"�$��Malgun Gothic)�$��12(���Z� � ���	#FF323A3E.+�� -    �Name$ Option_Grid��$��10,10,10,10q� �� $��* ��� $��* ��� $��* �.+��� -   $ GetCountry_btn��$��Get Country - CSV��$��0,0,10,-0.4q�$��0��$��0��$��Stretch=�
����������	#FF3A3434$
��Bold"�$��Malgun Gothic)�$��12(�$��22��$��Bottom=���Z� �� -   $ GetdDestination_btn��$��Get Destination - CSV��$��0,0,10,-0.4q�$��0��$��1��$��Stretch=�
����������	#FF3A3434$
��Bold"�$��Malgun Gothic)�$��12(�$��22��$	��Top=� J� RenderTransformOrigin$ 	0.501,0.5&���Z� � $��
10,10,10,0q� �� $��60 ��� $��* �.+��� $��API-URL��$��0��$
��Left=�$��Center=�$��26��$��54�����	#FF2C2C2C$��Malgun Gothic)�$��12(�$��Normal"��� -	    ��Name$ 	ApiUrl_TB��$��1��$��Stretch=�$��23�� �� TextWrapping$
 Wrap=�$��TextBox��$��Center=����	#FF4F83CC���	#FF4F83CC$��12(�$��Malgun Gothic)�$��Normal"�� $
��AUTO��$	��Top=�$��0,0,0,0q�$��Stretch=� � RowDefinitions �� $��40 ��� $��* �.+��� $��Result Grid��$��
10,10,10,5q����	#FF22AABD
�������$
��Bold"�&   System.Windows.Controls.DataGrid  -
     Name$ hbHotelRoom_Grid��$��1��$��Stretch=�$	��Top=�$��10,10,10,10q�$	��NaN��$	��600��	   AutoGenerateColumns	 . 
   GridLinesVisibility$
 
Horizontal=�   SelectionUnit$
 Cell=�   SelectionMode$ Extended=�
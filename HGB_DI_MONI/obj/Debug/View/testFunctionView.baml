   M S B A M L   `   `   `  ����F  BHGB_DI_MONI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:HGB_DI_MONI.ViewHGB_DI_MONI.View  5      '    !HGB_DI_MONI.View.testFunctionView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:HGB_DI_MONI.View     5      -   5        .��5	      � 
�������.+�5
   
   �� $��Right=�6   $��Stretch=�6,   .+�5      �� -   5          ��Name$  	statusBar��5      $��	Ready ...��6'   ���	#FF4F83CC
�������6R   � 5      ���	#FF323A3E.+�5      � $��10,10,10,10q�6    � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $��* �6+   �� 5      $��* �6+   .+�5      �� -   5         ��Name$ GetRoomDescrip_btn��5      $��1. Get RoomDecription��69   $��0,0,10,-0.4q�6Y   $��0��6n   $��0��6{   $��Stretch=�6�   
����������	#FF3A3434$
��Bold"�6�   $��Malgun Gothic)�6�   $��12(�6  $��22��6%  $��Bottom=�61  ��6�   Z� 6L  �� 5      -   5        $ GetImage_btn��5      $��2.Get image links��63   $��0,0,10,0q�6O   $��0��6a   $��1��6n   $��Stretch=�6~   
����������	#FF3A3434$
��Bold"�6�   $��Malgun Gothic)�6�   $��12(�6
  ��6�   Z� 6  �� 5      -   5        $ Extract_btn��5      $��3. Extract CVS File��62   $��0��6P   $��10,0,0,0q�6]   $��2��6o   $��Stretch=�6   
����������	#FF3A3434$
��Bold"�6�   $��Malgun Gothic)�6�   $��12(�6  ��6�   Z� 6  5      5      � 5      ���	#FF323A3E.+�5      � -   5         �Name$ Option_Grid��5      $��10,10,10,10q�6,    5      �� 5      $��* �6+   �� 5      $��* �6+   �� 5      $��* �6+   .+�5      �� -   5        $ GetCountry_btn��5      $��Get Country - CSV��65   $��0,0,10,-0.4q�6Q   $��0��6f   $��0��6s   $��Stretch=�6�   
����������	#FF3A3434$
��Bold"�6�   $��Malgun Gothic)�6�   $��12(�6  $��22��6  $��Bottom=�6)  ��6�   Z� 6D  �� 5       -   5        $ GetdDestination_btn��5       $��Get Destination - CSV��6:   $��0,0,10,-0.4q�6Z   $��0��6o   $��1��6|   $��Stretch=�6�   
����������	#FF3A3434$
��Bold"�6�   $��Malgun Gothic)�6�   $��12(�6  $��22��6&  $	��Top=�62   J� RenderTransformOrigin$ 	0.501,0.5&�6J  ��6�   Z� 6l  5!      5"      � 5#      $��
10,10,10,0q�6    5$      �� 5%      $��60 �6'   �� 5&      $��* �6'   .+�5(      �� $��API-URL��6   $��0��6*   $
��Left=�6:   $��Center=�6U   $��26��6p   $��54��6|   ���	#FF2C2C2C$��Malgun Gothic)�6�   $��12(�6�   $��Normal"�6�   �� 5)      -	   5         ��Name$ 	ApiUrl_TB��5)      $��1��6-   $��Stretch=�6=   $��23��6[    �� TextWrapping$
 Wrap=�6g   $��TextBox��6{   $��Center=�6�   ���	#FF4F83CC���	#FF4F83CC$��12(�6�   $��Malgun Gothic)�6�   $��Normal"�6�   5*      � 5+      $
��AUTO��6   $	��Top=�6!   $��0,0,0,0q�69   $��Stretch=�6J    � RowDefinitions 5,      �� 5-      $��40 �6$   �� 5.      $��* �6$   .+�50      �� $��Result Grid��6   $��
10,10,10,5q�6.   ���	#FF22AABD
�������$
��Bold"�6l   &   System.Windows.Controls.DataGrid  51      -
   5          Name$ hbHotelRoom_Grid��51      $��1��65   $��Stretch=�6B   $	��Top=�6`   $��10,10,10,10q�52      $	��NaN��6,   $	��600��69   	   AutoGenerateColumns	 . 
   GridLinesVisibility$
 
Horizontal=�53   2      SelectionUnit$
 Cell=�6T      SelectionMode$ Extended=�6i   5D      5E      5F      5G      5H      
   M S B A M L   `   `   `  ����F  BHGB_DI_MONI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:HGB_DI_MONI.ViewHGB_DI_MONI.View  5      %    HGB_DI_MONI.View.ContentAPIView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:HGB_DI_MONI.View     5      -   5        .��5	      � 
�������.+�5
   
   �� $��Right=�6   $��Stretch=�6,   .+�5      �� -   5          ��Name$  	statusBar��5      $��	Ready ...��6'   ���	#FF4F83CC
�������6R   � 5      ���	#FF323A3E.+�5      � $��10,10,10,10q�6    � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $��* �6+   .+�5      �� -   5         ��Name$ GetHotel_btn��5      $��Get All Hotel Information��63   $��0,0,10,0q�6W   $��0��6i   $��0��6v   $��Stretch=�6�   
����������	#FF3A3434$
��Bold"�6�   $��Malgun Gothic)�6�   $��12(�6  ��6�   Z� 6   �� 5      -   5        $ Extract_btn��5      $��Extract CVS File��62   $��0��6M   $��10,0,0,0q�6Z   $��1��6l   $��Stretch=�6|   
����������	#FF3A3434$
��Bold"�6�   $��Malgun Gothic)�6�   $��12(�6  ��6�   Z� 6  5      5      � 5      ���	#FF323A3E.+�5      � -   5         �Name$ Option_Grid��5      $��10,10,10,10q�6,    5      �� 5      $	��150 �6+   �� 5      $	��150 �6+   �� 5      $��* �6+   .+�5      �� -   5         ��Name$ country_Combo��5   +   $	��100��6   $��0��6C   $��0��6P    �� DisplayMemberPath$ country_description��6�    �� SelectedValuePath$ country_code��6�    �� 
IsEditable . ��6`   �� *	Countries+��5      �� 5      .�5    "   -   5        5!      5#      �� 5$      -   5        $ extract_Opt_Combo��5$      $��0��6:   $��1��6G   .@�5%      �� -	   5        $��HT��5%   E   $��Hotel Static Data��6'    �� 
IsSelected . 6P   �� 5&      -
   5        $	��IMG��5&   A   $��Hotel Images��6'   6A   �� 5'      -   5        $
��WILD��5'   <   $��WildCard��6'   6<   �� 5(      -   5        $��HTROOM��5(   C   $��Hotel Room Data��6'   6C   5)      5*      5+      � 51      $��
10,10,10,0q�6    52      �� 53      $��60 �6'   �� 54      $��* �6'   .+�56      �� $��API-URL��6   $��0��6*   $
��Left=�6:   $��Center=�6U   $��26��6p   $��54��6|   ���	#FF2C2C2C$��Malgun Gothic)�6�   $��12(�6�   $��Normal"�6�   �� 57      -   5        	 ��Name$	 	ApiUrl_TB��57      $��1��6-   $��Stretch=�6=   $��23��6[   
 �� TextWrapping$

 Wrap=�6g   $��TextBox��6{   $��Center=�6�   ���	#FF4F83CC���	#FF4F83CC$��12(�6�   $��Malgun Gothic)�6�   $��Normal"�6�   58      � 59      $
��AUTO��6   $	��Top=�6!   $��0,0,0,0q�69   $��Stretch=�6J    � RowDefinitions 5:      �� 5;      $��40 �6$   �� 5<      $��* �6$   .+�5>      �� $��Result Grid��6   $��
10,10,10,5q�6.   ���	#FF22AABD
�������$
��Bold"�6l   &   System.Windows.Controls.DataGrid  5?      -   5          Name$ hbHotelRoom_Grid��5?      $��1��65   $��Stretch=�6B   $	��Top=�6`   $��10,10,10,10q�5@      $	��NaN��6,   $	��600��69      AutoGenerateColumns .    GridLinesVisibility$ 
Horizontal=�5A   2      SelectionUnit$
 Cell=�6T      SelectionMode$ Extended=�6i   5U      5V      5W      5X      5Y      
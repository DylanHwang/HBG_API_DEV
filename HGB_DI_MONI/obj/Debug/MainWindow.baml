   M S B A M L   `   `   `  ����F  BHGB_DI_MONI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HGB_DI_MONIHGB_DI_MONI  5   	   =#clr-namespace:HGB_DI_MONI.ViewModelHGB_DI_MONI.ViewModel  5   	   3clr-namespace:HGB_DI_MONI.ViewHGB_DI_MONI.View  5   	       HGB_DI_MONI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:HGB_DI_MONI     5   	   :
viewmodels#clr-namespace:HGB_DI_MONI.ViewModel     5   	   0viewsclr-namespace:HGB_DI_MONI.View     5   	   -   5          � Title$  
MainWindow��5
   	   $��851.71��6   $��1275.75��6,    � 	Resources 5       �� DataType/   )HGB_DI_MONI.ViewModel.ContentAPIViewModel%   HGB_DI_MONI.View.ContentAPIView � DataContext4   .HGB_DI_MONI.ViewModel.AvailabilityAPIViewModel'   !HGB_DI_MONI.View.AvailabilityView3   -HGB_DI_MONI.ViewModel.BookingDetailsViewModel)   #HGB_DI_MONI.View.BookingDetailsView1  +HGB_DI_MONI.ViewModel.testFunctionViewModel'   !HGB_DI_MONI.View.testFunctionView��%�  (��       5   3   *, +)(�� W     5   8   *, +)(�� �     5   7   *, +)(��     5   5   *, +)�� 5   
   ContentApiTemplete��"  63   .R�5         6#   �� 5      �� 5   
   AvailabilityApiTemplete��"  68   .R�5         6%   �� 5      �� 5   
   BookingDetailsTemplete��"  67   .R�5         6'   �� 5      �� 5   
   testFunctionTemplete��"  65   .R�5         6%   �� 5      5      .��5      ]� $��Stretch=�6   $��Stretch=�6.   ��. $	��NaN��6_   $	��NaN��6l   $��0,0,0,0q�6y   .+�5   
   �� .��5      � .+�5      ]� .+�5      �� $
��Left=�6!   $
��Left=�67   $	��260��6R    �� Orientation$ Vertical=�6^   $	��NaN��6u   $��Stretch=�6�   ���	#FF323A3E.+�5      � $	��150��6   $��Stretch=�6,   ���	#FF272B2C.+�5      �� $��10q�6)   $��Center=�65   .+�5    "   �� $��	HotelBeds��6(   
�������$
��Bold"�6O   $��Microsoft JhengHei UI)�6a   $��20(�6�   �� 5!   "   $��Aptitude��6(   
�������$
��Bold"�6N   $��Microsoft JhengHei UI)�6`   $��20(�6�   �� 5"   "   $��Testing APP��6(   
�������$
��Bold"�6Q   $��Microsoft JhengHei UI)�6c   $��20(�6�   5#      5$      � 5%      $	��NaN��6   $��
10,30,15,0q�6+    � RowDefinitions 5&      �� 5'   "   $��* �60   �� 5(   "   $��* �60    � ColumnDefinitions 5*      �� 5+   "   $��* �63   �� 5,   "   $
��3.5* �63   .+�5.      �� $��API-KEY��6$   $
��Left=�66   $	��Top=�6Q   
�������$��26��6|   $��55��6�   $��0��6�   $��0��6�   $��Malgun Gothic)�6�   $��12(�6�   $��Normal"�6�   �� 5/      -   5         ��Name$ 	ApiKey_TB��5/   &   $
��Left=�69   $��23��6T    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��220��6�   ���	#FF4F83CC���	#FF4F83CC$��1��6�   $��0��6�   $��12(�6�   $��Malgun Gothic)�6�   $��Normal"�6  �� 50      $��Security��6$   $
��Left=�67   $	��Top=�6R   
�������$��26��6}   $��55��6�   $��1��6�   $��0��6�   $��Malgun Gothic)�6�   $��12(�6�   $��Normal"�6�   �� 51      -   5        $ Security_TB��51   &   $
��Left=�6;   $��23��6V   $
 Wrap=�6b   $	��Top=�6v   $	��220��6�   ���	#FF4F83CC���	#FF4F83CC$��2��6�   $��1��6�   $��12(�6�   $��Malgun Gothic)�6�   $��Normal"�6  52      �� 53      $��Select API Menu��6    $��	0,30,0,10q�6:   $��10,5,5,5q�6M   ���	#FF272B2C
�������$
��Bold"�6�   �� 54      -   5        	 ��Name$	 Content_btn��54   !   $��Contents��66   $��Stretch=�6I   $��55��6g   $��
10,10,10,5q�6s   
����������	#FF3A3434$
��Bold"�6�   $��Malgun Gothic)�6�   $��12(�6�   ��6�   Z� 6  �� 55      -   5        $	 Availability_btn��55   !   $��Availablity��6;   $��Stretch=�6Q   $��55��6o   $��
10,5,10,10q�6{   
����������	#FF3A3434$
��Bold"�6�   $��Malgun Gothic)�6�   $��12(�6�   ��6�   Z� 6  �� 56      -   5        $	 BookingDetail_btn��56   !   $��BookingDetail��6<   $��Stretch=�6T   $��55��6r   $��
10,5,10,10q�6~   
����������	#FF3A3434$
��Bold"�6�   $��Malgun Gothic)�6�   $��12(�6   ��6�   Z� 6  �� 57      -   5        $	 test_btn��57   !   $��TestFunction��63   {�.  $��Stretch=�6\   $��55��6z   $��
10,5,10,10q�6�   
����������	#FF3A3434$
��Bold"�6�   $��Malgun Gothic)�6�   $��12(�6  ��6�   Z� 6  58      �� 5:      $��Right=�6%   $��Stretch=�6<   $��Stretch=�6X   ��6w   �� 5=      5>      5?      5@      5A      
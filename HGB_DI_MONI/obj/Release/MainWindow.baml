   M S B A M L   `   `   `  ���� F  BHGB_DI_MONI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HGB_DI_MONIHGB_DI_MONI  =#clr-namespace:HGB_DI_MONI.ViewModelHGB_DI_MONI.ViewModel  3clr-namespace:HGB_DI_MONI.ViewHGB_DI_MONI.View      HGB_DI_MONI.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:HGB_DI_MONI     :
viewmodels#clr-namespace:HGB_DI_MONI.ViewModel     0viewsclr-namespace:HGB_DI_MONI.View     -     � Title$  
MainWindow��$��851.71��$��1275.75�� � 	Resources  �� DataType/   )HGB_DI_MONI.ViewModel.ContentAPIViewModel%   HGB_DI_MONI.View.ContentAPIView � DataContext4   .HGB_DI_MONI.ViewModel.AvailabilityAPIViewModel'   !HGB_DI_MONI.View.AvailabilityView1  +HGB_DI_MONI.ViewModel.testFunctionViewModel'   !HGB_DI_MONI.View.testFunctionView��%�   (��       *, +)(�� 2     *, +)(�� i     *, +)�� ContentApiTemplete��"  .R�   �� �� AvailabilityApiTemplete��"  .R�   �� �� testFunctionTemplete��"  .R�   �� .��]� $��Stretch=�$��Stretch=���. $	��NaN��$	��NaN��$��0,0,0,0q�.+��� .��� .+�]� .+��� $
��Left=�$
��Left=�$	��260�� �� Orientation$ Vertical=�$	��NaN��$��Stretch=����	#FF323A3E.+�� $	��150��$��Stretch=����	#FF272B2C.+��� $��10q�$��Center=�.+��� $��	HotelBeds��
�������$
��Bold"�$��Microsoft JhengHei UI)�$��20(��� $��Aptitude��
�������$
��Bold"�$��Microsoft JhengHei UI)�$��20(��� $��Testing APP��
�������$
��Bold"�$��Microsoft JhengHei UI)�$��20(�� $	��NaN��$��
10,30,15,0q� � RowDefinitions �� $��* ��� $��* � � ColumnDefinitions �� $��* ��� $
��3.5* �.+��� $��API-KEY��$
��Left=�$	��Top=�
�������$��26��$��55��$��0��$��0��$��Malgun Gothic)�$��12(�$��Normal"��� -    ��Name$ 	ApiKey_TB��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$	��220�����	#FF4F83CC���	#FF4F83CC$��1��$��0��$��12(�$��Malgun Gothic)�$��Normal"��� $��Security��$
��Left=�$	��Top=�
�������$��26��$��55��$��1��$��0��$��Malgun Gothic)�$��12(�$��Normal"��� -   $ Security_TB��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��220�����	#FF4F83CC���	#FF4F83CC$��2��$��1��$��12(�$��Malgun Gothic)�$��Normal"��� $��Select API Menu��$��	0,30,0,10q�$��10,5,5,5q����	#FF272B2C
�������$
��Bold"��� -   	 ��Name$	 Content_btn��$��Contents��$��Stretch=�$��55��$��
10,10,10,5q�
����������	#FF3A3434$
��Bold"�$��Malgun Gothic)�$��12(���Z� �� -   $	 Availability_btn��$��Availablity��$��Stretch=�$��55��$��
10,5,10,10q�
����������	#FF3A3434$
��Bold"�$��Malgun Gothic)�$��12(���Z� �� -   $	 test_btn��$��TestFunction��{�.  $��Stretch=�$��55��$��
10,5,10,10q�
����������	#FF3A3434$
��Bold"�$��Malgun Gothic)�$��12(���Z� �� $��Right=�$��Stretch=�$��Stretch=����� 
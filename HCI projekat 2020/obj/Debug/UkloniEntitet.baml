   M S B A M L   `   `   `  ����L  HHCI projekat 2020, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HCI_projekat_2020HCI_projekat_2020  5   	   %    HCI_projekat_2020.UkloniEntitet   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:HCI_projekat_2020     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ CanMinimize=�5	   	    � Title$ UkloniEntitet��5
   	   $��434.595��6   $��287.027��60   .��5      � $��0,0,0,-1q�6   
�������.+�5   
   �� -   5         ��Name$ 
tabControl��5      $
��Left=�6X   $	��Top=�6t   $	��156��6�   
�������$	��394��6�   .@�5      �� -   5        $
��tab1��5      $��	Događaji��6"   $
��-2,0q�64   .��5      �� -   5         ��Name$ 	listView1��5      
������ 
���   �$��
-6,-5,-6,0q�6�   $	��371��6�   $��Bottom=�6�   ��6Z   �� *
listaDog+ �� UpdateSourceTrigger$ PropertyChanged=� �� View 5      �� 5      .P�5      ��  �� Width$ 50��6-   $��Oznaka��68    �� DisplayMemberBinding 6H   �� *oznaka+�� 5      $��Naziv��6-   $ 50��6<    6G   �� *naziv+�� 5      $	��Tip��6-   $ 55��6:    6E   �� *tip+5      5      5      �� 5      -   5        $
��tab2��5      $��Tipovi��6"   $
��-2,0q�62   .��5      �� -   5        $ 	listView2��5      
������ 
���   �$��
-9,-5,-6,0q�6�   ��6Z   �� *
listaTip+$ PropertyChanged=� 5      �� 5      .P�5      �� $ 80��6-   $��Oznaka��68    6H   �� *oznaka+�� 5       $��Naziv��6-   $ 80��6<    6G   �� *naziv+5!      5#      5$      �� 5&      -   5        $
��tab3��5&      $��Etikete��6"   $
��-2,0q�63   .��5'      �� -   5        $ 	listView3��5'      
������ 
���   �$��
-9,-5,-5,0q�6�   ��6Z   �� *	listaEt+$ PropertyChanged=� 5(      �� 5)      .P�5*      �� $	 158��6-   $��Oznaka��69    6I   �� *oznaka+5+      5-      5.      50      �� 52   
   -	   5        	 ��Name$	 button��52      $��Ukloni događaj��6!   $
��Left=�6:   $��
164,26,0,0q�6U   $	��Top=�6i   $��96��6�   $��44��6�   6�   53      54      
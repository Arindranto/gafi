   M S B A M L   `   `   `  ����V  RApplicationEnveloppeConvexe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ApplicationEnveloppeConvexeApplicationEnveloppeConvexe  5   	   ,    &ApplicationEnveloppeConvexe.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ApplicationEnveloppeConvexe     5   	     � Title$  Enveloppe Convexe��5   	   $	��450��6#   $	��800��60    � WindowState$ 	Maximized=�6<    � WindowStartupLocation$ CenterScreen=�6T    � 
ResizeMode$ NoResize=�6y   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   ]� $��5q�6   .+�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $��15(�6   $��SemiBold"�6&   .��6<   Nombre de points6N   �� 5      -   5        $��TBNbr��5   -   $��0 5 0 10q�6   $��30��6:   $��15(�6F   6V   �� 5      -   5        $
��20 0q�5      $��	Générer��6'   $��30��69   $��15(�6E    � Cursor$
 Hand��6S   6a   5      5      �� 5   
   -   5        $��
MainCanvas��5   -   $��1��6   $��20q�6!   .+�5      �� $��15(�6   $
��Bold"�6&   
 �� Top$ 1��68    �� Left$	 2.5��6G   06\   �� 5      
���   �$��2��6"   		 �� X1$	 0��66   	
 �� Y1$
 0��6=   	 �� X2$ 0��6D   	 �� Y2 6K   ��  �� Path$ ActualHeight� �� RelativeSource ��  �� AncestorType" ��6�   �� 5      
���   �$��2��6"   $	 0��66   $
 0��6=   $ 0��6�    6D   �� $ ActualWidth� �� " ��6�   5      5      5      
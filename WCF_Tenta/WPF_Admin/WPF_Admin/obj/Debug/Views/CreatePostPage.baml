   M S B A M L   `   `   `  ����D  @WPF_Admin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPF_Admin.ViewModelsWPF_Admin.ViewModels  5          WPF_Admin.CreatePostPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1vm"clr-namespace:WPF_Admin.ViewModels     5        N� Title$  CreatePostPage��5	       � DataContext 5      .  (WPF_Admin.ViewModels.CreatePostViewModel  5   
   .��5      � ���	#FF272727 � ColumnDefinitions 5   
   �� 5      $
��553* �6   �� 5      $
��241* �6    � RowDefinitions 5   
   �� 5      $	��25* �6   �� 5      $	��38* �6   �� 5      $
��290* �6   �� 5      $	��35* �6   �� 5      $	��63* �6   .+�5   
   �� $��5,2,5,2q�6O   $��1��6`    �� TextWrapping$
 Wrap=�6m   ��6   �� *Header+ �� UpdateSourceTrigger$ PropertyChanged=�6m   �� 5   
   $��5,2,5,2q�6P   $��2��6a   $
 Wrap=�6n   ��6   �� *	Content+$ PropertyChanged=�6n   �� 5   
   $��5,2,5,2q�6M   $��3��6^   $
 Wrap=�6k   ��6   �� *Tags+$ PropertyChanged=�6k   �� 5    
   $��20,10,20,10q�64   $��4��6I   $��Create newspost��6V   $��20(�6p   $
��Bold"�6~   ��6   �� *CreateNewsPost+6~   �� 5!   
   $��Cancel��68   $��1��6I   $��4��6Y   $��30,15,30,15q�6f   $��20(�6{   $
��Bold"�6�   ��6   �� *BackToPreviousPage+6�   �� 5#   
    �� DisplayMemberPath$
 Name��6[   $��1��6�   $��1��6�   $��2q�6�   ��6   �� *
Categories+$ PropertyChanged=� �� SelectedItem 6t   �� *SelectedCategory+6�   5$      5%      
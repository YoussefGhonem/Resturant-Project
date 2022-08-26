import { MenuItem } from './menu.model';

export const MENU: MenuItem[] = [

  {
    id: 1,
    label: 'Business',
    icon: 'ri-dashboard-2-line',
    subItems: [
      {
        id: 'Press',
        label: 'Press',
        link: '/business/press',
        parentId: 1
      },
      {
        id: 'PrivateDining',
        label: 'Private Dining (Events)',
        link: '/business/private-dining',
        parentId: 1
      },
      {
        id: 'Manu',
        label: 'Manu Management',
        link: '/business/manu',
        parentId: 1
      },
      {
        id: 'Happenings',
        label: 'Happenings',
        link: '/business/happenings',
        parentId: 1
      },
      {
        id: 'Jobs',
        label: 'Jobs',
        link: '/business/jobs',
        parentId: 1
      },
      {
        id: 'ROJECTS',
        label: 'ROJECTS',
        link: '/dashboard/projects',
        parentId: 1
      },
      {
        id: 'NFT',
        label: 'NFT',
        link: '/dashboard/nft',
        parentId: 1,
        badge: {
          variant: 'bg-danger',
          text: 'MENUITEMS.DASHBOARD.BADGE',
        },
      }
    ]
  },
  {
    id: 3,
    label: 'Settings',
    icon: ' ri-settings-2-line',
    link: '/settings'
  },
  {
    id: 11,
    label: 'Our-Teams',
    icon: 'ri-team-fill',
    link: '/business/our-teams'
  },

  {
    id: 3,
    label: 'Manage Users',
    icon: ' ri-settings-2-line',
    link: '/users'
  },
  {
    id: 3,
    label: 'Contacts',
    icon: ' ri-mail-send-line',
    link: '/business/contacts'
  },

];

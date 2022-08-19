export const PublicUserController = {
  PublicUsers: `users/public-users`,
  Create: `public-users`,
  Delete: (id: string) => `public-users/${id}`,
  Activate: (id: string) => `public-users/${id}/activate`,
  Deactivate: (id: string) => `public-users/${id}/deactivate`,
}

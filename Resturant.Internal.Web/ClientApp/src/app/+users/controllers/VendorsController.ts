export const VendorsController = {
  Vendors: `vendors`,
  Create: `vendors`,
  Delete: (id: string) => `vendors/${id}`,
  Activate: (id: string) => `vendors/${id}/activate`,
  Deactivate: (id: string) => `vendors/${id}/deactivate`,
}

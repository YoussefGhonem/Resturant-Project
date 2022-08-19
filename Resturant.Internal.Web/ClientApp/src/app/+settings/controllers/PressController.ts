export const PressController = {
    GetAll: `press`,
    Create: `commitee-members`,
    Delete: (id: string) => `commitee-members/${id}`,
    Update: (id: string) => `commitee-members/${id}/deactivate`,
}

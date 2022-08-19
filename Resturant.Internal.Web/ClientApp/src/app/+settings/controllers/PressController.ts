export const PressController = {
    GetAll: `press`,
    Create: `press`,
    Delete: (id: string) => `commitee-members/${id}`,
    Update: (id: string) => `commitee-members/${id}/deactivate`,
}

export const CommitteeMembersController = {
  CommitteeMembers: `commitee-members`,
  Create: `commitee-members`,
  Delete: (id: string) => `commitee-members/${id}`,
  Activate: (id: string) => `commitee-members/${id}/activate`,
  Deactivate: (id: string) => `commitee-members/${id}/deactivate`,
}
